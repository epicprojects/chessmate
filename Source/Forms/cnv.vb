Public Class cnv
    Public board As New ChessBoard
    Dim main As New frmMain
    Private Shared SelectedPiece As Integer = -1
    Private Sub PictureBox1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.BISHOP
    End Sub
    Private Sub PictureBox2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.Q
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.Rook
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Image = My.Resources.k
    End Sub
    Private Sub PictureBox3_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = Nothing
    End Sub
    Private Sub PictureBox2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = Nothing
    End Sub
    Private Sub PictureBox4_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = Nothing
    End Sub
    Private Sub PictureBox1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = Nothing
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        ' MsgBox("Bishop")

        SelectedPiece = 1
        frmMain.PawnPromotion(board.PEX, board.PEY, getSelectedPiece())
        Me.Close()
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        ' MsgBox("Rook")
        SelectedPiece = 2
        frmMain.PawnPromotion(board.PEX, board.PEY, getSelectedPiece())
        Me.Close()
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        ' MsgBox("Queen")
        SelectedPiece = 0
        frmMain.PawnPromotion(board.PEX, board.PEY, getSelectedPiece())
        Me.Close()
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        ' MsgBox("Knigt")
        SelectedPiece = 3
        frmMain.PawnPromotion(board.PEX, board.PEY, getSelectedPiece())
        Me.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Public Function getSelectedPiece() As Integer
        Return SelectedPiece
    End Function
End Class