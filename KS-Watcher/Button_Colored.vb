Imports KS_Watcher.Form_Main
Imports System.Drawing.Color

Public Class Button_Colored
    Inherits Button

    Private mouse_click As Boolean = False

    Public Sub New()
        MyBase.New()
        FlatStyle = FlatStyle.Flat
        BackColor = color_ks_primary
        ForeColor = color_ks_secondary
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        mouse_click = False
        If Enabled = True Then
            BackColor = color_ks_primary
            ForeColor = color_ks_secondary
        Else
            BackColor = color_ks_primary
            ForeColor = Black
        End If
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        mouse_click = False
        If Enabled = True Then
            BackColor = color_ks_primary
            ForeColor = color_ks_secondary
        Else
            BackColor = color_ks_primary
            ForeColor = Black
        End If
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        mouse_click = True
        If Enabled = True Then
            BackColor = color_ks_secondary
            ForeColor = color_ks_primary
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If Enabled = True Then
            BackColor = color_ks_primary
            ForeColor = color_ks_secondary
        End If
        If ClientRectangle.Contains(e.Location) = True And mouse_click = True Then
            PerformClick()
        End If
    End Sub
End Class