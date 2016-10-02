Imports System.Net.Mail
Public Class Feedbacks

    Private Sub btnSendEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
        Try
            Dim MyMailMessage As New MailMessage()
            MyMailMessage.From = New MailAddress(txtEmail.Text)
            MyMailMessage.To.Add(txtToEmail.Text)
            MyMailMessage.Subject = txtSubject.Text
            MyMailMessage.Body = txtBody.Text
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            SMTPServer.Port = 587
            SMTPServer.Credentials = New System.Net.NetworkCredential(txtEmail.Text, txtPassword.Text)
            SMTPServer.EnableSsl = True
            SMTPServer.Send(MyMailMessage)
        Catch ex As Exception

        End Try
        MsgBox("Email Sent!, Your problem will be reviewed in the next 24 hours. Thank you for your feedback, -The ScanSense Team ")
    End Sub

    Private Sub txtToEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtToEmail.TextChanged

    End Sub

    Private Sub Feedbacks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class