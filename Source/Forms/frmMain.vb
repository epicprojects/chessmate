
Option Explicit On

Imports Microsoft.DirectX.AudioVideoPlayback
Imports System.Media
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization

Public Class frmMain
    Dim audioFile As Audio = New Audio(Application.StartupPath + "\Sounds\main.wav")

#Region "Variable declarations"

    Private output As FileStream
    Private formatter As BinaryFormatter = New BinaryFormatter()
    Dim filename As String = Application.StartupPath + "\Save\chs.sav"
    Private input As FileStream

    'Do we display the board flipped (i.e. black at bottom)?
    Public Shared Frstmove As Boolean = False
    Private BoardFlipped As Boolean
    Dim board As New ChessBoard
    'Bitmaps for black pieces
    Dim c As Char
    Dim val As String
    Private str1(6) As String
    Public Shared imr As Integer = 0
    Dim str() As String
    Public Shared Undercheck As Boolean = False
    Shared TotalPossibleMoves As Integer
    Private Shared BlackPawnBitMap As System.Drawing.Bitmap
    Private Shared BlackKnightBitMap As System.Drawing.Bitmap
    Private Shared BlackBishopBitMap As System.Drawing.Bitmap
    Private Shared BlackRookBitMap As System.Drawing.Bitmap
    Private Shared BlackQueenBitMap As System.Drawing.Bitmap
    Private Shared BlackKingBitMap As System.Drawing.Bitmap
    Shared k As Integer
    'Bitmaps for white pieces
    Private Shared WhitePawnBitMap As System.Drawing.Bitmap
    Private Shared WhiteKnightBitMap As System.Drawing.Bitmap
    Private Shared WhiteBishopBitMap As System.Drawing.Bitmap
    Private Shared WhiteRookBitMap As System.Drawing.Bitmap
    Private Shared WhiteQueenBitMap As System.Drawing.Bitmap
    Private Shared WhiteKingBitMap As System.Drawing.Bitmap

    'Main game object
    'Private G As Game
    Public SquareBox(8, 8) As Windows.Forms.PictureBox
    'Last entered move coordinates
    Private MoveStartX As Integer
    Private MoveEndX As Integer
    Private MoveStartY As Integer
    Private MoveEndY As Integer

    'A string containing the Tag property of the square the mouse was last detected on
    Private MouseLastOverTag As String

    'Is it black or white to move?
    Private Shared BlackToMove As Boolean = False

    'Should I ignore any clicks?
    Private IgnoreInput As Boolean = False

    'Are we in "Add to book" mode?
    Private BookUpdateMode As Boolean = False
    ' Private AIPlayer As AIEngine
    'Did we recently disable the AI due to a Browse request?
    Private AIRecentlyDisabledDueToBrowse As Boolean = False
    Private Shared SX As Integer
    Private Shared SY As Integer
    Private Shared EX As Integer
    Private Shared EY As Integer
    Dim ir As System.Drawing.Bitmap

#End Region

#Region "Initialisation of pieces, board and game"

    Sub LoadImages()

        'Set up the images we use for drawing the pieces
        ir = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\ir.bmp")
        BlackPawnBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackPawn.bmp")
        BlackKingBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackKing.bmp")
        BlackKnightBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackKnight.bmp")
        BlackBishopBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackBishop.bmp")
        BlackRookBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackRook.bmp")
        BlackQueenBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\BlackQueen.bmp")



        WhiteKnightBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhiteKnight.bmp")
        WhiteBishopBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhiteBishop.bmp")
        WhiteRookBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhiteRook.bmp")
        WhiteQueenBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhiteQueen.bmp")
        WhitePawnBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhitePawn.bmp")
        WhiteKingBitMap = System.Drawing.Bitmap.FromFile(Application.StartupPath + "\IMG\WhiteKing.bmp")

        'Make the most prevalent color in each bmp transparent
        BlackPawnBitMap.MakeTransparent()
        BlackKnightBitMap.MakeTransparent()
        BlackBishopBitMap.MakeTransparent()
        BlackRookBitMap.MakeTransparent()
        BlackQueenBitMap.MakeTransparent()
        BlackKingBitMap.MakeTransparent()

        WhitePawnBitMap.MakeTransparent()
        WhiteKnightBitMap.MakeTransparent()
        WhiteBishopBitMap.MakeTransparent()
        WhiteRookBitMap.MakeTransparent()
        WhiteQueenBitMap.MakeTransparent()
        WhiteKingBitMap.MakeTransparent()

    End Sub

    Sub InitBoard()

        Try
            For XX As Integer = 8 To 1 Step -1

                For YY As Integer = 8 To 1 Step -1

                    Dim BoxLoc As System.Drawing.Point
                    Dim BoxSize As System.Drawing.Size
                    BoxSize.Width = 64
                    BoxSize.Height = 64
                    BoxLoc.X = 64 * (XX - 1) + 40
                    BoxLoc.Y = 64 * (9 - YY - 1) + 43
                    SquareBox(XX, YY) = New Windows.Forms.PictureBox
                    SquareBox(XX, YY).Location = BoxLoc
                    SquareBox(XX, YY).Size = BoxSize
                    SquareBox(XX, YY).BackColor = Color.Transparent
                    SquareBox(XX, YY).Tag = CStr(XX) + "," + CStr(YY)
                    SquareBox(XX, YY).Name = "Square_" + CStr(XX) + "_" + CStr(YY)
                    Me.SquareBox(XX, YY).AllowDrop = True
                    AddHandler SquareBox(XX, YY).MouseDown, AddressOf btnImage_MouseDown
                    AddHandler SquareBox(XX, YY).DragEnter, AddressOf pictureBox_DragEnter
                    AddHandler SquareBox(XX, YY).DragDrop, AddressOf pictureBox_DragDrop
                    AddHandler SquareBox(XX, YY).MouseHover, AddressOf pictureBox_enter
                    AddHandler SquareBox(XX, YY).MouseLeave, AddressOf pictureBox_leave
                    GroupBox1.Controls.Add(SquareBox(XX, YY))
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub initChessBoard()

        Dim i As Integer
        For i = 57 To 0 Step -8

            With CType(GroupBox1.Controls(i), Windows.Forms.PictureBox)
                .Image = BlackPawnBitMap
            End With
        Next
        With CType(GroupBox1.Controls(56), Windows.Forms.PictureBox)
            .Image = BlackRookBitMap
        End With
        With CType(GroupBox1.Controls(48), Windows.Forms.PictureBox)
            .Image = BlackKnightBitMap
        End With
        With CType(GroupBox1.Controls(40), Windows.Forms.PictureBox)
            .Image = BlackBishopBitMap
        End With
        With CType(GroupBox1.Controls(32), Windows.Forms.PictureBox)
            .Image = BlackQueenBitMap
        End With
        With CType(GroupBox1.Controls(24), Windows.Forms.PictureBox)
            .Image = BlackKingBitMap
        End With

        With CType(GroupBox1.Controls(16), Windows.Forms.PictureBox)
            .Image = BlackBishopBitMap
        End With

        With CType(GroupBox1.Controls(8), Windows.Forms.PictureBox)
            .Image = BlackKnightBitMap
        End With

        With CType(GroupBox1.Controls(0), Windows.Forms.PictureBox)
            .Image = BlackRookBitMap
        End With
        '---------------------------------------
        For i = 62 To 0 Step -8

            With CType(GroupBox1.Controls(i), Windows.Forms.PictureBox)
                .Image = WhitePawnBitMap
            End With
        Next
        With CType(GroupBox1.Controls(63), Windows.Forms.PictureBox)
            .Image = WhiteRookBitMap
        End With
        With CType(GroupBox1.Controls(55), Windows.Forms.PictureBox)
            .Image = WhiteKnightBitMap
        End With
        With CType(GroupBox1.Controls(47), Windows.Forms.PictureBox)
            .Image = WhiteBishopBitMap
        End With
        With CType(GroupBox1.Controls(39), Windows.Forms.PictureBox)
            .Image = WhiteQueenBitMap
        End With
        With CType(GroupBox1.Controls(31), Windows.Forms.PictureBox)
            .Image = WhiteKingBitMap
        End With

        With CType(GroupBox1.Controls(23), Windows.Forms.PictureBox)
            .Image = WhiteBishopBitMap
        End With

        With CType(GroupBox1.Controls(15), Windows.Forms.PictureBox)
            .Image = WhiteKnightBitMap
        End With

        With CType(GroupBox1.Controls(7), Windows.Forms.PictureBox)
            .Image = WhiteRookBitMap
        End With

    End Sub

#End Region


#Region "Form events"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadImages()
            InitBoard()
            Frstmove = True
            initChessBoard()
            '    StartNewGame()
            AITimer.Start()
            board.WhitePlayer = New Player(True)
            board.BlackPlayer = New Player(False)
            '  AIPlayer = New AIEngine(board.BlackPlayer, board.WhitePlayer)
            audioFile.Play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        resignGame()
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub AboutusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutusToolStripMenuItem.Click
        Dim ab As New about
        ab.Show()
    End Sub

    Private Sub SoundsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SoundsToolStripMenuItem.Click
        audioFile.Stop()
        Dim S As New sound
        S.Show()
    End Sub
    Private Sub StartNewGame()
        board.WhitePlayer = New Player(True)
        board.BlackPlayer = New Player(False)
        For i = 63 To 0 Step -1
            With CType(GroupBox1.Controls(i), Windows.Forms.PictureBox)
                .Image = Nothing
            End With
        Next
        frmMain_Load(Nothing, Nothing)
    End Sub
    Private Sub resignGame()
        If MsgBox("Do you really want to Quit Game", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub
#Region "MouseEvents"
    Private Sub btnImage_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        'Try
        Dim btnPic = CType(sender, PictureBox)
        btnPic.DoDragDrop(btnPic.Image, DragDropEffects.Copy)
        Dim Location(2) As String
        Location = Split(btnPic.Tag, ",")
        SX = Location(0)
        SY = Location(1)
        ' If Not ((SY = EY And EX = SX) Or IgnoreInput) Then

        If Not IgnoreInput And Not (EX = SX And EY = SY) Then   'neofied
            SquareBox(SX, SY).Image = Nothing
            resetValues()
        Else
            IgnoreInput = False
            Exit Sub
        End If

        If BlackToMove Then
            Cursor.Current = Cursors.WaitCursor
            DOAI()
            If board.isUnderCheck(1) Then
                MsgBox("You are undercheck")
            End If
            Cursor.Current = Cursors.Arrow
        End If

        'Catch ex As Exception
        '    MsgBox("dfdf" + ex.Message)
        'End Try
    End Sub
    Public Sub resetValues()
        SX = 0
        SY = 0
        EX = 0
        EY = 0
        BlackToMove = Not BlackToMove
        IgnoreInput = False
    End Sub
    Private Sub pictureBox_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragEnter
        Try
            If e.Data.GetDataPresent(DataFormats.Bitmap) Then
                e.Effect = DragDropEffects.Copy
            Else
                e.Effect = DragDropEffects.None
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Shared Backup(8, 8) As Char
    Private Sub pictureBox_DragDrop(ByVal sender As Object, ByVal e As DragEventArgs) Handles Me.DragDrop
        Try

            Dim picbox As PictureBox = CType(sender, PictureBox)
            Dim g As Graphics = picbox.CreateGraphics()
            Dim Location(2) As String
            Location = Split(picbox.Tag, ",")
            EX = Location(0)
            EY = Location(1)
            Dim Ispossible As Boolean = False
            BackupDatabase()
            'If Not (board.IsCheckmate()) Then
            If Char.IsUpper(c) Then
                Ispossible = board.BlackPlayer.updatepiece(c, SX, SY, EX, EY)
                'refreshBoard()
            Else
                Ispossible = board.WhitePlayer.updatepiece(c, SX, SY, EX, EY)
                'refreshBoard()
            End If
            If (Ispossible) Then
                If (board.isUnderCheck(Playercolor) And board.undercheck = True) Then
                    MsgBox("You are UnderCheck or ur king can get threat through this move", MsgBoxStyle.Information)
                    RestoreDatabase()
                    IgnoreInput = True
                    board.BlackPlayer.restorepieces()
                    board.WhitePlayer.restorepieces()
                ElseIf (board.isUnderCheck((1 - Playercolor)) And board.undercheck = True) Then
                    MsgBox("Checked!!!!!!", MsgBoxStyle.Information)
                    If board.IsCheckmate Then
                        MsgBox("Checkmate")
                    End If
                    board.BlackPlayer.restorepieces()
                    board.WhitePlayer.restorepieces()
                    picbox.Image = CType(e.Data.GetData(DataFormats.Bitmap), Image)
                    Dim MyPlayer As New SoundPlayer()
                    MyPlayer.SoundLocation = Application.StartupPath + "\Sounds\drop.wav"
                    MyPlayer.Play()
                Else
                    picbox.Image = CType(e.Data.GetData(DataFormats.Bitmap), Image)
                    Dim MyPlayer2 As New SoundPlayer()
                    MyPlayer2.SoundLocation = Application.StartupPath + "\Sounds\drop.wav"
                    MyPlayer2.Play()
                End If
            Else
                MsgBox("Illegal Move", MsgBoxStyle.Critical)
                IgnoreInput = True
                Exit Sub
            End If
            refreshBoard()
            ' Else

            '  picbox.Image = CType(e.Data.GetData(DataFormats.Bitmap), Image)
            ' End If
        Catch ex As Exception

        End Try

    End Sub
#End Region


    Private Sub NewGameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewGameToolStripMenuItem.Click
        StartNewGame()
    End Sub
    Public Sub BackupDatabase()
        For i = 0 To 8
            For j = 0 To 8
                Backup(i, j) = Player.piece_info(i, j)
            Next
        Next
    End Sub
    Public Sub RestoreDatabase()
        For i = 0 To 8
            For j = 0 To 8
                Player.piece_info(i, j) = Backup(i, j)
            Next
        Next
    End Sub
    Private Sub tbNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbNew.Click
        NewGameToolStripMenuItem_Click(Nothing, Nothing)
    End Sub
    Public PossibleMoves() As ChessBoard.PossibleMoves
    Public Shared Playercolor As Integer
    Private Sub pictureBox_enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Try

            Dim picbox As PictureBox = CType(sender, PictureBox)

            Dim Location(2) As String

            Location = Split(picbox.Tag, ",")
            SX = Location(0)
            SY = Location(1)
            c = board.WhitePlayer.piece_info(Location(0), Location(1))

            If c = "o" Then     'checks wether there is a piece on current position or not
                Exit Sub
            Else
                If Char.IsLower(c) Then    'identify either the piece is white or black
                    Playercolor = 1
                Else
                    Playercolor = 0
                End If
            End If
            If (BlackToMove And Playercolor = 1) Or (Not BlackToMove And Playercolor = 0) Then
                Exit Sub
            End If

            Dim r As Integer = 0
            Dim pawnMoves As New Pawn
            Dim rookMoves As New Rook
            Dim KnightMoves As New Knight
            Dim bishopMoves As New Bishop
            Dim kingMoves As New King
            Dim queenMoves As New Queen

            If (SX = 0 Or SY = 0) Then
                MsgBox("Exception:Cannot Move Piece")
                Exit Sub
            End If
            Select Case Char.ToLower(c)
                Case "p"
                    str = Split(pawnMoves.getPossibleMoves(SX, SY), ",")
                Case "r"
                    str = Split(rookMoves.getPossibleMoves(SX, SY, Playercolor, board.BlackPlayer.piece_info), ",")
                Case "n"
                    str = Split(KnightMoves.getPossibleMoves(SX, SY), ",")
                Case "b"
                    str = Split(bishopMoves.getPossibleMoves(SX, SY, Playercolor, board.BlackPlayer.piece_info), ",")
                Case "k"
                    str = Split(kingMoves.getPossibleMoves(SX, SY, Playercolor, board.BlackPlayer.piece_info), ",")
                Case "q"
                    str = Split(queenMoves.getPossibleMoves(SX, SY, Playercolor, board.BlackPlayer.piece_info), ",")
            End Select
            k = 0
            TotalPossibleMoves = str(0)
            ReDim PossibleMoves(TotalPossibleMoves - 1)
            For i = 1 To (TotalPossibleMoves * 3)
                Dim x As Integer = i
                i += 1
                SquareBox(str(x), str(i)).BackgroundImage = ir
                PossibleMoves(k).X = str(x)
                PossibleMoves(k).Y = str(i)
                i += 1
                PossibleMoves(k).insight = str(i)
                k += 1
            Next
            'Backup = Player.piece_info
        Catch ex As Exception
            '  MsgBox("Hunu lulu: " + ex.Message)
        End Try
    End Sub

    Private Sub pictureBox_leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Try
            For i = 1 To (TotalPossibleMoves * 3)
                Dim x As Integer = i
                i += 1
                SquareBox(str(x), str(i)).BackgroundImage = Nothing
                i += 1
            Next
        Catch ex As Exception
            '       MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If board.isUnderCheck(1) Then
            MsgBox("RED")
        Else
            MsgBox("Green")
        End If
    End Sub


    Private Sub AITimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AITimer.Tick
        If BlackToMove Then
            PlayerTurn.Text = "Black to Move"
        Else
            PlayerTurn.Text = "White to Move"
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
    End Sub
    Public Function getPlayerTurn() As Boolean
        Return BlackToMove
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'For i = 0 To Player.captured_piece.Count - 1
        '    MsgBox(Player.captured_piece.Item(i))
        'Next
        Dim a As New AIE
        MsgBox(a.intellignce())
    End Sub
    Public Sub DOAI()
        Try
            Dim ai As New AIE

            Dim st(4) As String
            Dim c As Char
            Dim str As String = ai.intellignce()
            If str.Equals("hard") Then
                ai.Convert()
                st = (Split(ai.AIengine(), ","))
                board.BlackPlayer.updatepiece(Player.piece_info(st(0), st(1)), st(0), st(1), st(2), st(3))
                '    MsgBox("hard")
            Else
                ai.ConvertBackup()
                Dim RandomClass As New Random
                Dim RandomNumber As Integer
                RandomNumber = RandomClass.Next(0, 3)
                st = (Split(ai.WoodPush(RandomNumber), ","))
                board.BlackPlayer.updatepiece(Player.piece_info(st(0), st(1)), st(0), st(1), st(2), st(3))
                '   MsgBox("easy")
            End If
            c = Player.piece_info(st(0), st(1))

            board.BlackPlayer.domove(c, Convert.ToInt32(st(
                                                        0)), Convert.ToInt32(st(1)), c, Convert.ToInt32(st(2)), Convert.ToInt32(st(3)))

            Player.piece_info(st(0), st(1)) = "o"
            refreshBoard()
            BlackToMove = Not BlackToMove
        Catch ex As Exception
            ' MsgBox("DO AI  : " + ex.Message)
        End Try
    End Sub

    Private Sub SaveGame()
        Try
            Dim savedat As New Savedata(Player.piece_info, Player.captured_piece, Player.blackPieceCaptured, Player.whitePieceCaptured, BlackToMove, Undercheck)
            output = New FileStream(filename, FileMode.Create, FileAccess.Write)
            Try
                formatter.Serialize(output, savedat)
            Catch serializableException As SerializationException
                MessageBox.Show("Error saving to File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            output.Close()
        Catch er As Exception
            MsgBox("Save Data Error : " + er.Message)
        End Try
    End Sub
    '-----------------------------------
    Private Sub LoadGame()
        Dim savedat As Savedata
        Try

            input = New FileStream(filename, FileMode.Open, FileAccess.Read)
            savedat = CType(formatter.Deserialize(input), Savedata)
            If (input Is Nothing) = False Then
                input.Close()
            End If
        Catch serializableException As SerializationException
            input.Close()
        End Try

        Player.piece_info = savedat.p_i
        Player.captured_piece = savedat.c_p
        Player.blackPieceCaptured = savedat.blackPieceCaptured
        Player.whitePieceCaptured = savedat.whitePieceCaptured
        BlackToMove = savedat.playerturn
        Undercheck = savedat.check
    End Sub

    Private Sub tbBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbBack.Click
        Try
            If (Player.captured_piece.Count) > 0 And Player.captured_piece.Count - imr > 0 Then
                imr += 1
                Player.captured_piece.TrimToSize()
                val = Player.captured_piece(Player.captured_piece.Count - imr)

                str1 = Split(val, ",")

                If Char.IsLower(str1(0)) Then

                    board.WhitePlayer.domove(str1(0), Convert.ToInt32(str1(4)), Convert.ToInt32(str1(5)), str1(3), Convert.ToInt32(str1(1)), Convert.ToInt32(str1(2)))

                Else

                    board.BlackPlayer.domove(str1(0), Convert.ToInt32(str1(4)), Convert.ToInt32(str1(5)), str1(3), Convert.ToInt32(str1(1)), Convert.ToInt32(str1(2)))

                    'End If

                End If
                refreshBoard()
                BlackToMove = Not BlackToMove
            Else
                MessageBox.Show("Place a move 1st")
            End If
        Catch ex As Exception
            MsgBox("No Previous Move Exist")
        End Try

    End Sub
    Public Sub PawnPromotion(ByVal PEX As Integer, ByVal PEY As Integer, ByVal SelectedPiece As Integer)
        Try
            BlackToMove = Not BlackToMove
            Dim TempPieceArray(,) As Integer
            Select Case SelectedPiece
                Case 0
                    If (getPlayerTurn()) Then
                        Player.piece_info(PEX, PEY) = "Q"
                        '  SquareBox(PEX, PEY).Image = BlackQueenBitMap
                    Else
                        Player.piece_info(PEX, PEY) = "q"
                        '  SquareBox(PEX, PEY).Image = WhiteQueenBitMap
                    End If
                Case 1
                    If (getPlayerTurn()) Then
                        Player.piece_info(PEX, PEY) = "B"
                        ' SquareBox(PEX, PEY).Image = BlackBishopBitMap
                    Else
                        Player.piece_info(PEX, PEY) = "b"
                        ' SquareBox(PEX, PEY).Image = WhiteBishopBitMap
                    End If
                Case 2
                    If (getPlayerTurn()) Then
                        Player.piece_info(PEX, PEY) = "R"
                        ' SquareBox(PEX, PEY).Image = BlackRookBitMap
                    Else
                        Player.piece_info(PEX, PEY) = "r"
                        'SquareBox(PEX, PEY).Image = WhiteRookBitMap
                    End If
                Case 3
                    If (getPlayerTurn()) Then
                        Player.piece_info(PEX, PEY) = "N"
                        ' SquareBox(PEX, PEY).Image = BlackKnightBitMap
                    Else
                        Player.piece_info(PEX, PEY) = "n"
                        'SquareBox(PEX, PEY).Image = WhiteKnightBitMap
                    End If

            End Select

            refreshBoard()
            BlackToMove = Not BlackToMove
            DOAI()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub refreshBoard()
        Try
            Dim p As Integer
            Dim piec(64) As Char
            Dim i As Integer = 0
            '---------------------------------------------CLEARS BOARD------------------------------------

            For p = 0 To 63 Step 1
                With CType(GroupBox1.Controls(p), Windows.Forms.PictureBox)
                    .Image = Nothing
                End With
            Next

            '------------------------------------------------
            For c1 As Integer = 8 To 1 Step -1
                For c2 As Integer = 8 To 1 Step -1
                    piec(i) = Player.piece_info(c1, c2)
                    i += 1

                Next
            Next
            '-------------------------------------------------
            For p2 As Integer = 0 To 63

                Select Case piec(p2)

                    'WHITE
                    Case "p"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhitePawnBitMap
                        End With

                    Case "r"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhiteRookBitMap
                        End With

                    Case "n"

                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhiteKnightBitMap
                        End With

                    Case "b"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhiteBishopBitMap
                        End With


                    Case "q"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhiteQueenBitMap
                        End With


                    Case "k"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = WhiteKingBitMap
                        End With

                        'BLACK
                    Case "P"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackPawnBitMap
                        End With

                    Case "R"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackRookBitMap
                        End With

                    Case "N"

                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackKnightBitMap
                        End With

                    Case "B"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackBishopBitMap
                        End With


                    Case "Q"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackQueenBitMap
                        End With


                    Case "K"
                        With CType(GroupBox1.Controls(p2), Windows.Forms.PictureBox)
                            .Image = BlackKingBitMap
                        End With

                End Select
                '---------------------------------------------------------------------------------
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tbForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbForward.Click
        Try
            If Player.captured_piece.Count > 0 And imr <> 0 Then

                Player.captured_piece.TrimToSize()
                val = Player.captured_piece(Player.captured_piece.Count - imr)

                str1 = Split(val, ",")

                If Char.IsLower(str1(0)) Then

                    board.WhitePlayer.domove(str1(0), Convert.ToInt32(str1(1)), Convert.ToInt32(str1(2)), str1(3), Convert.ToInt32(str1(4)), Convert.ToInt32(str1(5)))

                Else

                    board.BlackPlayer.domove(str1(0), Convert.ToInt32(str1(1)), Convert.ToInt32(str1(2)), str1(3), Convert.ToInt32(str1(4)), Convert.ToInt32(str1(5)))

                    'End If
                    ' imr -= 1
                End If
                imr -= 1
                refreshBoard()
                BlackToMove = Not BlackToMove
            Else
                MessageBox.Show("Place a move 1st")
            End If
        Catch ex As Exception
            MsgBox("No Forward Move Exist")
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        audioFile.Stop()
        Application.Exit()
    End Sub

    Private Sub tbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbSave.Click
        SaveGame()
    End Sub

    Private Sub tbOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbOpen.Click
        LoadGame()
        refreshBoard()
    End Sub

    Private Sub SavePositionToFENFileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePositionToFENFileToolStripMenuItem.Click
        LoadGame()
        refreshBoard()
    End Sub

    Private Sub SavePositionToFENFileToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SavePositionToFENFileToolStripMenuItem1.Click
        SaveGame()
    End Sub
End Class
