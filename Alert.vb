Public Class Alert

    Private Sub Alert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.TopMost = True
        RichTextBox1.BorderStyle = BorderStyle.None

    End Sub
End Class