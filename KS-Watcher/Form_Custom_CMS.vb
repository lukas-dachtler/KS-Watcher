Imports KS_Watcher.Form_Main
Imports System.Drawing.Color
Imports System.Text.RegularExpressions

Public Class Form_Custom_CMS

    Public Btn_Select_All As New Button_Colored
    Public Btn_Deselect_All As New Button_Colored
    Public Btn_Change_Limit As New Button_Colored
    Public Tb_Change_Limit As New TextBox
    Public selected_index As UInteger
    Private Const CP_DROPSHADOW As Integer = &H20000

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ClassStyle = cp.ClassStyle Or CP_DROPSHADOW
            Return cp
        End Get
    End Property

    ''' <summary>
    ''' Updates the limit in the contextmenu
    ''' </summary>
    Public Sub Update_Limit()
        If Tb_Change_Limit IsNot Nothing Then
            Tb_Change_Limit.Text = Tiers_Setup(selected_index).Limit
            Tb_Change_Limit.Select()
        End If
    End Sub

    Private Sub Form_Custom_CMS_Load(sender As Object, e As EventArgs) Handles Me.Load
        Tb_Change_Limit.Font = New Font("Arial", 9.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Tb_Change_Limit.Size = New Size(50, 25)
        Tb_Change_Limit.Location = New Point(2, 4)
        Tb_Change_Limit.Text = Tiers_Setup(selected_index).Limit
        Tb_Change_Limit.BackColor = color_ks_primary
        Tb_Change_Limit.ForeColor = color_ks_secondary
        AddHandler Tb_Change_Limit.TextChanged, AddressOf Tb_Change_Limit_TextChanged
        AddHandler Tb_Change_Limit.LostFocus, AddressOf Tb_Change_Limit_LostFocus
        AddHandler Tb_Change_Limit.KeyUp, AddressOf Tb_Change_Limit_KeyUp

        Btn_Change_Limit.Font = New Font("Arial", 8.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Change_Limit.Size = New Size(100, 25)
        Btn_Change_Limit.Location = New Point(54, 2)
        Btn_Change_Limit.TextAlign = ContentAlignment.MiddleLeft
        Btn_Change_Limit.Text = Form_Main.Lib_Language_Active.s_btn_change_limit
        AddHandler Btn_Change_Limit.Click, AddressOf Btn_Change_Limit_Click
        AddHandler Btn_Change_Limit.LostFocus, AddressOf Btn_Change_Limit_LostFocus

        Btn_Select_All.Font = New Font("Arial", 8.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Select_All.Size = New Size(152, 25)
        Btn_Select_All.Location = New Point(2, 29)
        Btn_Select_All.TextAlign = ContentAlignment.MiddleLeft
        Btn_Select_All.Text = Form_Main.Lib_Language_Active.s_btn_select_all
        AddHandler Btn_Select_All.Click, AddressOf Btn_Select_All_Click
        AddHandler Btn_Select_All.LostFocus, AddressOf Btn_Select_All_LostFocus

        Btn_Deselect_All.Font = New Font("Arial", 8.0!, FontStyle.Bold, GraphicsUnit.Point, 0)
        Btn_Deselect_All.Size = New Size(152, 25)
        Btn_Deselect_All.Location = New Point(2, 56)
        Btn_Deselect_All.TextAlign = ContentAlignment.MiddleLeft
        Btn_Deselect_All.Text = Form_Main.Lib_Language_Active.s_btn_deselect_all
        AddHandler Btn_Deselect_All.Click, AddressOf Btn_Deselect_All_Click
        AddHandler Btn_Deselect_All.LostFocus, AddressOf Btn_Deselect_All_LostFocus

        Controls.Add(Tb_Change_Limit)
        Controls.Add(Btn_Change_Limit)
        Controls.Add(Btn_Select_All)
        Controls.Add(Btn_Deselect_All)
        Tb_Change_Limit.Select()
        Size = New Size(156, 83)
    End Sub

    Private Sub Tb_Change_Limit_TextChanged(sender As Object, e As EventArgs)
        Dim r As New Regex("[^\d]")
        Tb_Change_Limit.Text = r.Replace(Tb_Change_Limit.Text, "")
        Tb_Change_Limit.Select(Tb_Change_Limit.Text.Length, 0)
        If Tb_Change_Limit.Text.Length > 9 Then
            Tb_Change_Limit.Text = Tb_Change_Limit.Text.Substring(0, 9)
        End If
    End Sub

    Private Sub Tb_Change_Limit_LostFocus(sender As Object, e As EventArgs)
        If (Btn_Change_Limit.Focused = False And Btn_Select_All.Focused = False And Btn_Deselect_All.Focused = False) Then
            Form_Main.CLV_Tiers.CLV_Clear_Highlight()
            Hide()
        End If
    End Sub

    Private Sub Tb_Change_Limit_KeyUp(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Btn_Change_Limit.PerformClick()
        End If
    End Sub

    Private Sub Btn_Change_Limit_Click(sender As Object, e As EventArgs)
        If IsNumeric(Tb_Change_Limit.Text) Then
            Dim l As Integer = Tb_Change_Limit.Text
            If l < Tiers_Setup(selected_index).Max And l > Tiers_Setup(selected_index).Value Then
                Tiers_Setup(selected_index).Limit = l
                Form_Main.CLV_Tiers.CLV_Clear_Highlight()
                Hide()
            End If
        End If
    End Sub

    Private Sub Btn_Change_Limit_LostFocus(sender As Object, e As EventArgs)
        If (Tb_Change_Limit.Focused = False And Btn_Select_All.Focused = False And Btn_Select_All.Focused = False) Then
            Form_Main.CLV_Tiers.CLV_Clear_Highlight()
            Hide()
        End If
    End Sub

    Private Sub Btn_Select_All_Click(sender As Object, e As EventArgs)
        Form_Main.CLV_Tiers.CLV_Select_All_Items()
        Form_Main.CLV_Tiers.CLV_Clear_Highlight()
        Hide()
    End Sub

    Private Sub Btn_Select_All_LostFocus(sender As Object, e As EventArgs)
        If (Tb_Change_Limit.Focused = False And Btn_Change_Limit.Focused = False And Btn_Deselect_All.Focused = False) Then
            Form_Main.CLV_Tiers.CLV_Clear_Highlight()
            Hide()
        End If
    End Sub

    Private Sub Btn_Deselect_All_Click(sender As Object, e As EventArgs)
        Form_Main.CLV_Tiers.CLV_Deselect_All_Items()
        Form_Main.CLV_Tiers.CLV_Clear_Highlight()
        Hide()
    End Sub

    Private Sub Btn_Deselect_All_LostFocus(sender As Object, e As EventArgs)
        If (Tb_Change_Limit.Focused = False And Btn_Change_Limit.Focused = False And Btn_Select_All.Focused = False) Then
            Form_Main.CLV_Tiers.CLV_Clear_Highlight()
            Hide()
        End If
    End Sub

    Private Sub Form_Custom_CMS_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Form_Main.CLV_Tiers.CLV_Clear_Highlight()
        Hide()
    End Sub

    Private Sub Form_Custom_CMS_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ControlPaint.DrawBorder(e.Graphics, ClientRectangle, DarkGray, 1, ButtonBorderStyle.Solid, DarkGray, 1, ButtonBorderStyle.Solid, DarkGray, 0, ButtonBorderStyle.None, DarkGray, 0, ButtonBorderStyle.None)
    End Sub
End Class