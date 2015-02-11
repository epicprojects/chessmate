Imports System.Media
Imports Microsoft.DirectX.AudioVideoPlayback
Public Class splash
    Dim audioFile As Audio = New Audio(Application.StartupPath + "\Sounds\intro.wav")
    Dim ab As New about
    ' Dim F As New frmMain
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        audioFile.Stop()
        Me.Hide()
        frmMain.Show()
    End Sub
    Private Sub PictureBox1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.Image = My.Resources.n
        Dim MyPlayer As New SoundPlayer()
        MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\tick.wav"
        MyPlayer.Play()
    End Sub
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.no
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim F As New frmMain
        audioFile.Stop()
        F.Show()
        Me.Hide()
    End Sub
    Private Sub PictureBox2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.Image = My.Resources.loadO
        Dim MyPlayer As New SoundPlayer()
        MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\tick.wav"
        MyPlayer.Play()
    End Sub
    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.load
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        ab.Show()
    End Sub
    Private Sub PictureBox3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.Image = My.Resources.aboutO
        Dim MyPlayer As New SoundPlayer()
        MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\tick.wav"
        MyPlayer.Play()
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.about

    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        'Exit CLick Code
        If (MessageBox.Show("Are you sure you want to exit?", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = 1) Then
            Application.Exit()
        Else
        End If
    End Sub
    Private Sub PictureBox4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.Image = My.Resources.exitO
        Dim MyPlayer As New SoundPlayer()
        MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\tick.wav"
        MyPlayer.Play()
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Image = My.Resources._exit
    End Sub
    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        audioFile.Play()
    End Sub
End Class