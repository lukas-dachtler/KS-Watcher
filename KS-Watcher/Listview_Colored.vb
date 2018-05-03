Imports KS_Watcher.Form_Main
Imports System.Drawing.Color

Public Class Listview_Colored
    Inherits ListView

    Public Sub New()
        BackColor = White
        ForeColor = Black
        View = View.Details
        CheckBoxes = True
        FullRowSelect = True
        MultiSelect = False
        OwnerDraw = True
        DoubleBuffered = True
    End Sub

#Region "Drawing implementation"
    Private Sub CLV_DrawItem(ByVal sender As Object, ByVal e As DrawListViewItemEventArgs) Handles MyBase.DrawItem
        If e.Item.Tag = "cms" Then
            e.Graphics.FillRectangle(New SolidBrush(FromArgb(225, 225, 225)), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
        Else
            e.Graphics.FillRectangle(Brushes.White, e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height)
        End If
        If e.Item.Checked = True Then
            e.Graphics.DrawRectangle(New Pen(Brushes.Black, 2), e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12)
            e.Graphics.FillRectangle(New SolidBrush(color_ks_primary), e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12)
            e.Graphics.DrawString(e.Item.Text, MyBase.Font, New SolidBrush(color_ks_primary), e.Bounds.X + 20, e.Bounds.Y + 2, New StringFormat(HorizontalAlignment.Left))
        Else
            e.Graphics.DrawRectangle(New Pen(Brushes.Black, 2), e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12)
            e.Graphics.FillRectangle(Brushes.White, e.Bounds.X + 5, e.Bounds.Y + 5, 12, 12)
            e.Graphics.DrawString(e.Item.Text, MyBase.Font, Brushes.Black, e.Bounds.X + 20, e.Bounds.Y + 2, New StringFormat(HorizontalAlignment.Left))
        End If
    End Sub

    Private Sub CLV_DrawSubItem(ByVal sender As Object, ByVal e As DrawListViewSubItemEventArgs) Handles MyBase.DrawSubItem
        Dim r As Rectangle = e.Bounds
        r.Y += 2
        If e.ColumnIndex > 0 Then
            If e.Item.Tag = "cms" Then
                e.Graphics.FillRectangle(New SolidBrush(FromArgb(225, 225, 225)), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            Else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height)
            End If
            If e.ColumnIndex = 1 And (Tiers_Setup(e.Item.Index).Value = Tiers_Setup(e.Item.Index).Max) Then
                e.Graphics.DrawString(e.SubItem.Text, MyBase.Font, New SolidBrush(Color.FromArgb(164, 24, 24)), r, New StringFormat(HorizontalAlignment.Right))
            Else
                If e.Item.Checked = True Then
                    e.Graphics.DrawString(e.SubItem.Text, MyBase.Font, New SolidBrush(color_ks_primary), r, New StringFormat(HorizontalAlignment.Right))
                Else
                    e.Graphics.DrawString(e.SubItem.Text, MyBase.Font, Brushes.Black, r, New StringFormat(HorizontalAlignment.Right))
                End If
            End If
        End If
    End Sub

    Private Sub CLV_DrawColumnHeader(ByVal sender As Object, ByVal e As DrawListViewColumnHeaderEventArgs) Handles MyBase.DrawColumnHeader
        e.Graphics.FillRectangle(New SolidBrush(color_ks_primary), e.Bounds)
        e.Graphics.DrawString(e.Header.Text, MyBase.Font, New SolidBrush(color_ks_secondary), e.Bounds, New StringFormat(e.Header.TextAlign))
    End Sub
#End Region

    Private Sub CLV_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Right Then
            For Each item As ListViewItem In Items
                If item.Bounds.Contains(e.Location) = True Then
                    item.Tag = "cms"
                    frm_custom_cms.selected_index = item.Index
                    frm_custom_cms.Location = Cursor.Position
                    frm_custom_cms.Update_Limit()
                    frm_custom_cms.Show()
                    Exit Sub
                End If
            Next
        End If
    End Sub

    Private Sub CLV_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
        Dim item As ListViewItem = GetItemAt(e.X, e.Y)
        If item IsNot Nothing AndAlso item.Tag Is Nothing Then
            Invalidate(item.Bounds)
            If item.Tag <> "cms" Then
                item.Tag = "tagged"
            End If
        End If
    End Sub

    Private Sub CLV_ItemChecked(ByVal sender As Object, ByVal e As ItemCheckedEventArgs) Handles MyBase.ItemChecked
        Try
            Tiers_Setup(e.Item.Index).Marked = e.Item.Checked
        Catch : End Try
    End Sub

    Private Sub CLV_Invalidated(ByVal sender As Object, ByVal e As InvalidateEventArgs) Handles MyBase.Invalidated
        For Each item As ListViewItem In Items
            If item Is Nothing Then Return
            If item.Tag <> "cms" Then
                item.Tag = Nothing
            End If
        Next
    End Sub

    Private Sub CLV_ColumnWidthChanged(ByVal sender As Object, ByVal e As ColumnWidthChangingEventArgs) Handles MyBase.ColumnWidthChanging
        e.Cancel = True
        e.NewWidth = Columns.Item(e.ColumnIndex).Width
    End Sub

    Public Sub CLV_Select_All_Items()
        For Each item As ListViewItem In Items
            item.Checked = True
        Next
    End Sub

    Public Sub CLV_Deselect_All_Items()
        For Each item As ListViewItem In Items
            item.Checked = False
        Next
    End Sub

    Public Sub CLV_Clear_Highlight()
        For Each item As ListViewItem In Items
            If item.Tag = "cms" Then
                item.Tag = Nothing
            End If
        Next
    End Sub
End Class