Public Class defaultFrm
    Dim startInfo As New ProcessStartInfo(Environment.GetFolderPath(Environment.SpecialFolder.System) + "\netsh.exe")
    Dim passKey As String

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo.Arguments = "wlan stop hosted network"
            Process.Start(startInfo)
            OvalShape1.FillColor = Color.Red
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        End Try
        WebBrowser1.Url = Nothing
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        startInfo.WindowStyle = ProcessWindowStyle.Hidden

        If (TextBox1.Text.Length < 8) Then
            MessageBox.Show("Passkey can not be null & its length should be 8 digit", "Information")
        Else
            startInfo.Arguments = "wlan set hostednetwork mode=allow ssid=DWRS key=" + TextBox1.Text
            Process.Start(startInfo)
            My.Computer.FileSystem.WriteAllText("pass", TextBox1.Text, False)
            startInfo.Arguments = "wlan start hosted network"
            Process.Start(startInfo)
            WebBrowser1.Url = New System.Uri("http://localhost/dropbox")
            OvalShape1.FillColor = Color.Green
        End If
    End Sub

    Private Sub defaultFrm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo.Arguments = "wlan stop hosted network"
            Process.Start(startInfo)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "error")
        End Try
    End Sub

    Private Sub defaultFrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            passKey = My.Computer.FileSystem.ReadAllText("pass")
            TextBox1.Text = passKey
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText("pass", "", False)
        End Try
        OvalShape1.FillColor = Color.Red
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.PasswordChar = Nothing
        Else
            TextBox1.PasswordChar = "*"
        End If
    End Sub
End Class
