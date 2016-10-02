Public Class Settings

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbautoresumedelay.Items.Add("1 Minute")
        cmbautoresumedelay.Items.Add("2 Minutes")
        cmbautoresumedelay.Items.Add("3 Minutes")
        cmbautoresumedelay.Items.Add("4 Minutes")
        cmbautoresumedelay.Items.Add("5 Minutes")
        cmbautoresumedelay.Items.Add("6 Minutes")
        cmbautoresumedelay.Items.Add("7 Minutes")
        cmbautoresumedelay.Items.Add("8 Minutes")
        cmbautoresumedelay.Items.Add("9 Minutes")
        cmbautoresumedelay.Items.Add("10 Minutes")
        cmbautoresumedelay.Items.Add("15 Minutes")
        cmbautoresumedelay.Items.Add("20 Minutes")
        cmbautoresumedelay.SelectedIndex = 9

        cmbautotasksdelay.Items.Add("1 Minute")
        cmbautotasksdelay.Items.Add("2 Minutes")
        cmbautotasksdelay.Items.Add("3 Minutes")
        cmbautotasksdelay.Items.Add("4 Minutes")
        cmbautotasksdelay.Items.Add("5 Minutes")
        cmbautotasksdelay.Items.Add("6 Minutes")
        cmbautotasksdelay.Items.Add("7 Minutes")
        cmbautotasksdelay.Items.Add("8 Minutes")
        cmbautotasksdelay.Items.Add("9 Minutes")
        cmbautotasksdelay.Items.Add("10 Minutes")
        cmbautotasksdelay.Items.Add("15 Minutes")
        cmbautotasksdelay.Items.Add("20 Minutes")
        cmbautotasksdelay.SelectedIndex = 11

        cmbtimeout.Items.Add("1 Minute")
        cmbtimeout.Items.Add("2 Minutes")
        cmbtimeout.Items.Add("3 Minutes")
        cmbtimeout.Items.Add("4 Minutes")
        cmbtimeout.Items.Add("5 Minutes")
        cmbtimeout.Items.Add("6 Minutes")
        cmbtimeout.Items.Add("7 Minutes")
        cmbtimeout.Items.Add("8 Minutes")
        cmbtimeout.Items.Add("9 Minutes")
        cmbtimeout.Items.Add("10 Minutes")
        cmbtimeout.Items.Add("15 Minutes")
        cmbtimeout.Items.Add("20 Minutes")
        cmbtimeout.Items.Add("25 Minutes")
        cmbtimeout.Items.Add("30 Minutes")
        cmbtimeout.SelectedIndex = 9

        cmbresthresh.Items.Add("Low")
        cmbresthresh.Items.Add("Medium")
        cmbresthresh.Items.Add("High")
        cmbresthresh.SelectedIndex = 1

        cmbremoveinfectedfolders.Items.Add("Ask Me")
        cmbremoveinfectedfolders.Items.Add("Automatic")
        cmbremoveinfectedfolders.SelectedIndex = 0

        cmbheuristic.Items.Add("Off")
        cmbheuristic.Items.Add("Automatic")
        cmbheuristic.Items.Add("Aggresive")
        cmbheuristic.SelectedIndex = 1

        cmblowrisk.Items.Add("Ignore")
        cmblowrisk.Items.Add("Ask Me")
        cmblowrisk.Items.Add("Remove")
        cmblowrisk.SelectedIndex = 1

        cmbtrackingcookies.Items.Add("Ignore")
        cmbtrackingcookies.Items.Add("Ask Me")
        cmbtrackingcookies.Items.Add("Remove")
        cmbtrackingcookies.SelectedIndex = 2

        cmbthreads.Items.Add("Automatic")
        cmbthreads.Items.Add("1")
        cmbthreads.Items.Add("2")
        cmbthreads.Items.Add("4")
        cmbthreads.Items.Add("8")
        cmbthreads.Items.Add("16")
        cmbthreads.Items.Add("32")
        cmbthreads.SelectedIndex = 0

        cmbperf.Items.Add("High Trust")
        cmbperf.Items.Add("Standard Trust")
        cmbperf.Items.Add("Full Scan")
        cmbperf.SelectedIndex = 1

        cmbremoveauto.Items.Add("Ask Me")
        cmbremoveauto.Items.Add("High Certainty Only")
        cmbremoveauto.Items.Add("Always")
        cmbremoveauto.SelectedIndex = 1

        cmbremoverisksif.Items.Add("Ask Me")
        cmbremoverisksif.Items.Add("High Certainty Only")
        cmbremoverisksif.Items.Add("Always")
        cmbremoverisksif.SelectedIndex = 1

        cmbfeed.Items.Add("On")
        cmbfeed.Items.Add("Ask Me")
        cmbfeed.Items.Add("Off")
        cmbfeed.SelectedIndex = 1

        cmbblock.Items.Add("On")
        cmbblock.Items.Add("Off")
        cmbblock.SelectedIndex = 1

        cmbreport.Items.Add("Always")
        cmbreport.Items.Add("Unproven Files Only")
        cmbreport.Items.Add("Never")
        cmbreport.SelectedIndex = 1
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Visible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.Save()
        My.Settings.Reload()

        My.Settings.Save()
        My.Settings.Reload()
    End Sub
End Class