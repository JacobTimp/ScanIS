Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = PerformanceCounter1.NextValue.ToString
        Label1.Text = "System:" + ProgressBar1.Value.ToString + "%"
    End Sub

    Private Sub btnadvanced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadvanced.Click
        AdvancedSettings.Visible = True
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Settings.Visible = True
    End Sub

    Private Sub btnupdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdates.Click
        Updatess.Visible = True
    End Sub

    Private Sub btnscannow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnscannow.Click
        Scannow.Visible = True
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Feedbacks.Visible = True
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        MsgBox("Undergoing Mantainence, sorry for the inconvenience")
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lblup.Click

    End Sub
End Class

