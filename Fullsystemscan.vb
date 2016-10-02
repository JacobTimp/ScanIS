Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class Fullsystemscan
    Dim CurrentFolder = 0
    Dim ScanCount = 0
    Dim FolderScanCount = 0
    Dim CurrPath = System.IO.Directory.GetCurrentDirectory()
    Dim userealtime = True

    Dim Timecount = 0

    Function GetMD5(ByVal filePath As String)
        Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
        Dim f As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        f = New FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        md5.ComputeHash(f)
        f.Close()
        f.Dispose()
        Dim hash As Byte() = md5.Hash
        Dim buff As StringBuilder = New StringBuilder
        Dim hashByte As Byte

        For Each hashByte In hash
            buff.Append(String.Format("{0:X2}", hashByte))
        Next

        Dim md5string As String
        md5string = buff.ToString()

        Return md5string

    End Function


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Hashes.Font = Found.Font
        Hashes.ForeColor = Color.Blue

        If My.Settings.showalerts = "true" Then
            CheckBox1.CheckState = CheckState.Checked
        Else
            CheckBox1.CheckState = CheckState.Unchecked

        End If
        REM Add drives to list...
        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        For Each d In allDrives
            ScanLocations.Items.Add(d.Name, True)
        Next
        REM done...

        If My.Settings.realtimepath = "" Then
            If ScanLocations.Items.Contains("C:\") Then
                My.Settings.realtimepath = "C:\"
            Else
                My.Settings.realtimepath = ScanLocations.Items(0)
            End If
        End If
        If My.Settings.userealtime = "true" Then
            If My.Computer.FileSystem.FileExists(CurrPath & "/database.txt") Then
                FileSystemWatcher1.Path = My.Settings.realtimepath
                FileSystemWatcher1.EnableRaisingEvents = True
                Button6.Text = "Disable real-time scanner"
            Else
                FileSystemWatcher1.EnableRaisingEvents = False
                Button6.Text = "Enable real-time scanner"
                Button6.Enabled = False

            End If

        Else
            FileSystemWatcher1.EnableRaisingEvents = False
            Button6.Text = "Enable real-time scanner"
        End If
        TextBox1.Text = My.Settings.realtimepath

        REM check if database file exists... if so... read to databse listbox...
        Try
            If My.Computer.FileSystem.FileExists(CurrPath & "/database.txt") Then
                For Each line As String In System.IO.File.ReadAllLines(CurrPath & "/database.txt")
                    Database1.Items.Add(line.Substring(0, line.IndexOf("|")))
                    line = line.Remove(0, (line.IndexOf("|") + 1))
                    Database2.Items.Add(line)
                Next
            Else
                Button6.Enabled = False

                MsgBox("No database was found...")
            End If

        Catch ex As Exception

        End Try
        REM done...


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim nn As New FolderBrowserDialog
        nn.ShowDialog()
        ScanLocations.Items.Add(nn.SelectedPath, True)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Percentage.Text = progress.Value & "%"
        ProgressBar1.Value = progress.Value
        Scanned.Text = ScanCount
        FoldersScanned1.Text = dp1.Text
        Found1.Text = Found.Items.Count
        Label2.Text = Found.Items.Count

        Label8.Text = Form2.ListBox1.Items.Count
        Label7.Text = Scanned.Text
        Label6.Text = Found1.Text
        Label13.Text = FileSystemWatcher1.Path

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Timecount = 0
        Time.Start()


        Timer1.Start()
        For Each Locc As String In ScanLocations.CheckedItems

            Label12.Text = "Scanning " & Locc
            Label12.ForeColor = Color.Blue

            Form2.ListBox1.Items.Clear()
            Form2.ListBox2.Items.Clear()

            progress.Value = 0
            dp1.Text = 0
            dp2.Text = 0
            CurrentFolder = 0

            CurrentFolder = 0
            Status.ForeColor = Color.Orange

            Status.Text = "Indexing folders..."
            Dim path As String = Locc
            Dim di As New IO.DirectoryInfo(path)
            Dim Drs() As IO.DirectoryInfo = di.GetDirectories()

            For Each dr As IO.DirectoryInfo In Drs
                If dr.ToString.Contains(".") = False Then
                    Form2.ListBox1.Items.Add(dr.FullName)
                End If

            Next
            While CurrentFolder < Form2.ListBox1.Items.Count

                Application.DoEvents()
                Try
                    Dim path2 As String = Form2.ListBox1.Items(CurrentFolder).ToString

                    Dim di2 As New IO.DirectoryInfo(path2)
                    Dim Drs2() As IO.DirectoryInfo = di2.GetDirectories()

                    For Each dr As IO.DirectoryInfo In Drs2
                        If dr.ToString.Contains(".") = False Then
                            Form2.ListBox1.Items.Add(dr.FullName)
                        End If

                    Next
                Catch ex As Exception

                End Try
                CurrentFolder = CurrentFolder + 1



            End While

            Status.ForeColor = Color.Green
            Status.Text = "Scanning files..."
            dp1.Text = Form2.ListBox1.Items.Count

            For Each dd As String In Form2.ListBox1.Items
                Application.DoEvents()
                dp2.Text = dp2.Text + 1
                progress.Value = Math.Round((dp2.Text / dp1.Text) * 100)
                Try
                    Dim folderInfo As New IO.DirectoryInfo(dd)
                    Dim arrFilesInFolder() As IO.FileInfo
                    Dim fileInFolder As IO.FileInfo
                    arrFilesInFolder = folderInfo.GetFiles("*.*")
                    For Each fileInFolder In arrFilesInFolder
                        Application.DoEvents()
                        Form2.ListBox2.Items.Add(fileInFolder.FullName)
                        ScanCount = ScanCount + 1
                        Dim hashh As String = GetMD5(fileInFolder.FullName)
                        If Database1.Items.Contains(hashh) Then
                            If Found.Items.Contains(fileInFolder.FullName) = False Then
                                Found.Items.Add(fileInFolder.FullName, True)
                                Hashes.Items.Add(hashh)
                            End If



                        End If

                    Next
                Catch ex As Exception

                End Try

            Next
        Next

        Timer1.Stop()
        Status.Text = "idle"
        Status.ForeColor = Color.Red
        Time.Stop()

        MsgBox("Done... Found: " & Found.Items.Count & " detections...")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form2.Show()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Found_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Process.Start(Found.SelectedItem.ToString.Substring(0, Found.SelectedItem.ToString.LastIndexOf("\")))
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Found_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Found_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Found.SelectedIndexChanged
        Try
            Hashes.SelectedIndex = Found.SelectedIndex

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Database1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Database1.SelectedIndexChanged
        Try
            Database2.SelectedIndex = Database1.SelectedIndex

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Time_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time.Tick
        Timecount = Timecount + 1
        Tlapsed.Text = Math.Round(Timecount / 60) & " min"
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If userealtime = True Then
            userealtime = False
            FileSystemWatcher1.EnableRaisingEvents = False
            My.Settings.userealtime = "false"
            Button6.Text = "Enable real-time scanner"

        Else
            FileSystemWatcher1.Path = My.Settings.realtimepath
            FileSystemWatcher1.EnableRaisingEvents = True
            My.Settings.userealtime = "true"
            Button6.Text = "Disable real-time scanner"
        End If
        My.Settings.Save()


    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Try
            ScanCount = ScanCount + 1
            Dim hashh As String = GetMD5(e.FullPath)
            Form2.ListBox2.Items.Add(e.FullPath)
            If Database1.Items.Contains(hashh) Then
                If Found.Items.Contains(e.FullPath) = False Then
                    Found.Items.Add(e.FullPath, True)
                    Hashes.Items.Add(hashh)
                End If

                If My.Settings.showalerts = "true" Then
                    Alert.Show()
                    Alert.RichTextBox1.Text = e.FullPath & " was detected!"

                End If

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        My.Settings.realtimepath = TextBox1.Text
        FileSystemWatcher1.Path = TextBox1.Text
        My.Settings.Save()

    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created
        Try
            ScanCount = ScanCount + 1
            Dim hashh As String = GetMD5(e.FullPath)
            Form2.ListBox2.Items.Add(e.FullPath)
            If Database1.Items.Contains(hashh) Then
                If Found.Items.Contains(e.FullPath) = False Then
                    Found.Items.Add(e.FullPath, True)
                    Hashes.Items.Add(hashh)
                End If

                If My.Settings.showalerts = "true" Then
                    Alert.Show()
                    Alert.RichTextBox1.Text = e.FullPath & " was detected!"

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            My.Settings.showalerts = "true"
        Else
            My.Settings.showalerts = "false"

        End If
    End Sub

    Private Sub FileSystemWatcher1_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        Try
            ScanCount = ScanCount + 1
            Dim hashh As String = GetMD5(e.FullPath)
            Form2.ListBox2.Items.Add(e.FullPath)
            If Database1.Items.Contains(hashh) Then
                If Found.Items.Contains(e.FullPath) = False Then
                    Found.Items.Add(e.FullPath, True)
                    Hashes.Items.Add(hashh)
                End If

                If My.Settings.showalerts = "true" Then
                    Alert.Show()
                    Alert.RichTextBox1.Text = e.FullPath & " was detected!"

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each ff As String In Found.Items
            Try
                Kill(ff)


            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)

            End Try
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For Each ff As String In Found.CheckedItems
            Try
                Kill(ff)

            Catch ex As Exception
                MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical)

            End Try
        Next
        Dim CheckedItems(Found.CheckedItems.Count - 1) As Object
        Found.CheckedItems.CopyTo(CheckedItems, 0)
        For Each CheckedItem As Object In CheckedItems
            ' Alternateively, add code to copy CheckedItem here.
            If FileIO.FileSystem.FileExists(CheckedItem.ToString) Then
                Try
                    Kill(CheckedItem.ToString)
                    Found.Items.Remove(CheckedItem)
                Catch ex As Exception

                End Try
            End If

        Next
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Found.Items.Clear()
        Hashes.Items.Clear()

    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    End Sub
End Class