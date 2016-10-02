Public Class securityhistory

    Private Sub securityhistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbsechist.Items.Add("")
        cmbsechist.Items.Add("")
        cmbsechist.Items.Add("Recent History")
        cmbsechist.Items.Add("Full History")
        cmbsechist.Items.Add("Scan Results")
        cmbsechist.Items.Add("Resolved Security Risks")
        cmbsechist.Items.Add("Unresolved Security Risks")
        cmbsechist.Items.Add("Quarantine")
        cmbsechist.Items.Add("Firewall - Activities")
        cmbsechist.Items.Add("Intrusion Prevention")
        cmbsechist.Items.Add("Download Check")
        cmbsechist.Items.Add("Antispam")
        cmbsechist.Items.Add("Identity")
        cmbsechist.Items.Add("Performance Alerts")
        cmbsechist.Items.Add("Network Cost Awareness")
        cmbsechist.Items.Add("Sites Reported to be Malicious")
        cmbsechist.Items.Add("Product Error Reporting")
        cmbsechist.Items.Add("Email Errors")
        cmbsechist.Items.Add("Silent Mode")
        cmbsechist.Items.Add("Updates")
        cmbsechist.Items.Add("")
        cmbsechist.Items.Add("")

        cmbsechist.SelectedIndex = 2
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Visible = False
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        lstsechist.Items.Clear()
    End Sub
End Class