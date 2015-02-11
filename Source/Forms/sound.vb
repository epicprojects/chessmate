Imports System.Media

Public Class sound
    Dim MyPlayer As New SoundPlayer()
 
    Private Sub listn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listn.Click
        listn.Enabled = False
        stp.Enabled = True
        Try
            MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\Tracks\" + ListBox1.SelectedItem.ToString() + ".wav"
            MyPlayer.PlayLooping()
        Catch ex As Exception
            MessageBox.Show("Cannot Find File", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            listn.Enabled = True
            stp.Enabled = False

        End Try
       
    End Sub

    Private Sub sound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        stp.Enabled = False
        MyPlayer.Stop()
    End Sub

    Private Sub bck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bck.Click
        listn.Enabled = False
        stp.Enabled = True
        Me.Hide()
    End Sub

    Private Sub sett_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sett.Click
        Try
            MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\Tracks\" + ListBox1.SelectedItem.ToString() + ".wav"
            MyPlayer.PlayLooping()
            listn.Enabled = False
            stp.Enabled = True
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Cannot Find File", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            listn.Enabled = True
            stp.Enabled = False

        End Try
    End Sub

    Private Sub stp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stp.Click
        stp.Enabled = False
        listn.Enabled = True
        MyPlayer.Stop()
    End Sub
End Class