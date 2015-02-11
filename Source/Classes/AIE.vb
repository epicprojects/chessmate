Imports System.Math

Public Class AIE

    Dim Mode As String, Selected%, SelX%, SelY%, ToX%, ToY%
    Dim Turn As String
    Dim Colour As String
    Dim cost As Integer
    Dim moving As Boolean
    Shared levelHum As Double = 0.0
    Shared levelAI As Double = 0.0
    Dim taking As Boolean
    Dim Board(8, 8) As String 'Board
    Dim RBoard(8, 8) As String 'AI play board
    Shared flevel As Double
    Dim main As frmMain

    Public Function AIengine() As String
        'If Mode <> "Offline" Then Exit Sub
        'If Turn = "B" Then Exit Sub
        '    Timer1.Enabled = False
        '    Randomize(Timer)
        Turn = "B"
        Dim X As Integer
        Dim Y As Integer
        Dim n As Integer
        Dim m As Integer
        Dim Opposite As String
        Dim BestScore As Integer
        Dim HypFrX%(72)
        Dim HypFrY%(72)
        Dim HypToX%(72)
        Dim HypToY%(72)
        BestScore = -32000

        Dim pX As Integer
        Dim pY As Integer

        Dim Score As Integer
        Dim CurrentPos As Integer
        ' Debug info
        'Open "C:\Chess.log" For Output As #1
        CurrentPos = 0
        For X = 1 To 8
            For Y = 1 To 8
                ' If this is our piece then see where we can move to
                If Right(Board(X, Y), 1) = "B" Then
                    For X2 = 1 To 8
                        For Y2 = 1 To 8
                            If MoveAlright(X, Y, X2, Y2) Then
                                ' Get the + score of this move (value of the piece taken)
                                Score = QualityOfTarget(X2, Y2)
                                ' Subsidise moving out of a threatened space
                                If CheckPosition(X, Y) And CheckPosition(X2, Y2) = False Then Score = Score + CostOfLoss(X, Y)
                                ' Subtract from subsidy if covered by an inferior peice
                                If CoveredPosition(X, Y) Then Score = Score - 0.67 * CostOfLoss(X, Y)


                                ' Reset the temporary board
                                For pX = 1 To 8
                                    For pY = 1 To 8
                                        RBoard(pX, pY) = Board(pX, pY)
                                    Next pY
                                Next pX

                                ' Move from x -> n and y -> m
                                Dim MovingObject

                                RBoard(X2, Y2) = Board(X, Y)
                                RBoard(X, Y) = ""

                                ' Get the - score of this move (the highest piece we are now exposing to be taken)
                                cost = moveCost()

                                Dim DontMoveTheKing As Integer
                                MovingObject = Board(X, Y)
                                ' Don't move the king unless you need to.
                                If Left(MovingObject, 4) = "King" And Board(X2, Y2) = "" Then
                                    DontMoveTheKing = 0
                                Else
                                    DontMoveTheKing = 0
                                End If

                                If (Score - (cost + DontMoveTheKing)) > BestScore Then
                                    '                                Write #1, "-----------------------------------------"
                                    BestScore = (Score - (cost + DontMoveTheKing))

                                    '                                Write #1, "New Best Score Move:" & MovingObject & ">" & Score & "," & Cost
                                    HypFrX%(0) = X
                                    HypFrY%(0) = Y
                                    HypToX%(0) = X2
                                    HypToY%(0) = Y2

                                    CurrentPos = 0


                                    '                               Write #1, BestScore & "," & Score & "," & cost & "," & x & "," & y & "," & X2 & "," & Y2 & ","
                                ElseIf (Score - (cost + DontMoveTheKing)) = BestScore Then
                                    CurrentPos = CurrentPos + 1

                                    '                                Write #1, "Additional Best Score Move:" & MovingObject & ">" & Score & "," & Cost
                                    HypFrX%(CurrentPos) = X
                                    HypFrY%(CurrentPos) = Y
                                    HypToX%(CurrentPos) = X2
                                    HypToY%(CurrentPos) = Y2



                                End If
                                'End If
                            End If
                        Next Y2
                    Next X2
                End If
            Next Y
        Next X


        Dim temp As Integer
        ' Randomly pick from the list of numbers
        If CurrentPos = 0 Then
            temp = 0
        Else
            temp = PickaNumber(0, CurrentPos)
        End If

        SelX% = HypFrX%(temp)
        SelY% = HypFrY%(temp)
        ToX% = HypToX%(temp)
        ToY% = HypToY%(temp)

        'MsgBox(CStr(SelX%) + " " + CStr(SelY%) + " " + CStr(ToX%) + " " + CStr(ToY%))
        'Return (CStr(SelX%) + "," + CStr(SelY%) + "," + CStr(ToX%) + "," + CStr(ToY%))
        '  Dim ai As New AI
        '  ai.Convert()
        If (IsLegalMove(SelX%, SelY%, ToX%, ToY%)) Then
            Return (CStr(SelX%) + "," + CStr(SelY%) + "," + CStr(ToX%) + "," + CStr(ToY%))
        Else
            ConvertBackup()
            Return (WoodPush(0))
        End If
    End Function
    Public Function intellignce() As String
        Dim a As Integer = countx(Player.KilledBlack)
        Dim b As Integer = countx(Player.KilledWhite)




        If main.Frstmove = True Then
            main.Frstmove = False
            Return "easy"
        End If
        If Player.KilledBlack(0) <> Nothing Then

            For j As Integer = 0 To a - 1
                '  MsgBox(Player.KilledBlack.Length.ToString())
                Select Case (Split(Player.KilledBlack(j).First()).GetValue(j))
                    Case "P"
                        levelHum += 0.125

                    Case "R"
                        levelHum += 0.5

                    Case "N"
                        levelHum += 0.5

                    Case "B"
                        levelHum += 0.5

                    Case "K"
                        'game ends
                    Case "Q"
                        levelHum += 1


                End Select

            Next
            flevel = flevel - levelHum
            flevel = flevel * -1
        End If


        If Player.KilledWhite(0) <> Nothing Then

            For i As Integer = 0 To b - 1
                '  MsgBox(Player.KilledWhite.Length.ToString())
                Select Case (Split(Player.KilledWhite(i)).GetValue(i))
                    Case "p"
                        levelAI += 0.125

                    Case "r"
                        levelAI += 0.5

                    Case "n"
                        levelAI += 0.5

                    Case "b"
                        levelAI += 0.5

                    Case "k"
                        'game ends
                    Case "q"
                        levelAI += 1
                End Select

            Next

            flevel = flevel - levelHum
        End If

        If flevel > 0.0 Then
            'hard the ai
            Return "hard"
        Else
            'easy the ai
            Return "easy"
        End If

    End Function

    Public Function countx(ByVal array() As String) As Integer
        Dim c As Integer = 0
        For i As Integer = 0 To array.Length - 1
            If (array(i) <> Nothing) Then
                c += 1
            End If
        Next
        Return c
    End Function
    Public Function WoodPush(ByVal ii As Integer) As String
        Dim StartX(4096) As Byte, StartY(4096) As Byte
        Dim EndX(4096) As Byte, EndY(4096) As Byte
        '   Dim StartTime As Long, EndTime As Long
        Dim CurrentIndex As Integer
        Dim X As Integer, Y As Integer
        Dim i As Integer, J As Integer
        '  Turn = "B"
        ' StartTime = GetTickCount

        '  If Turn = "B" Then 'WoodPusher is Black
        For X = 0 To 7
            For Y = 0 To 7
                If Board(X, Y) < 10 Then 'Get Peice
                    For i = 0 To 7
                        For J = 0 To 7
                            If Not (X = i And J = Y) Then
                                If IsLegalMove(X + 1, Y + 1, i + 1, J + 1) Then 'Move Legal, So log
                                    StartX(CurrentIndex) = X
                                    StartY(CurrentIndex) = Y
                                    EndX(CurrentIndex) = i
                                    EndY(CurrentIndex) = J
                                    CurrentIndex = CurrentIndex + 1
                                End If
                            End If
                        Next J
                    Next i
                End If
            Next Y
        Next X
        'End If


        i = Int(Rnd() * CurrentIndex + ii) 'Choose Random Move
        Return (CStr(StartX(i) + 1) & "," & CStr(StartY(i) + 1) & "," & CStr(EndX(i) + 1) & "," & CStr(EndY(i)) + 1)
    End Function
    Public Function ConvertBackup()
        Try
            Dim c As Char
            For i As Integer = 1 To 8
                For j As Integer = 1 To 8
                    c = Player.piece_info(i, j)
                    ' MsgBox(c)
                    If Char.IsLower(c) Then
                        Select Case (c)

                            'WHITE
                            Case "o"
                                Board(i - 1, j - 1) = 0
                                ' BoardAI(i - 1, j - 1) = 0
                            Case "p"
                                Board(i - 1, j - 1) = 16
                                ' BoardAI(i - 1, j - 1) = 16
                            Case "r"
                                Board(i - 1, j - 1) = 11
                                ' BoardAI(i - 1, j - 1) = 11
                            Case "n"
                                Board(i - 1, j - 1) = 12
                                ' BoardAI(i - 1, j - 1) = 12
                            Case "b"
                                Board(i - 1, j - 1) = 13
                                ' BoardAI(i - 1, j - 1) = 13
                            Case "k"
                                Board(i - 1, j - 1) = 15
                                ' BoardAI(i - 1, j - 1) = 15
                            Case "q"
                                Board(i - 1, j - 1) = 14
                                ' BoardAI(i - 1, j - 1) = 14
                        End Select
                    Else
                        Select Case (c)
                            'BLACK
                            Case "P"
                                Board(i - 1, j - 1) = 6
                                'BoardAI(i - 1, j - 1) = 6
                            Case "R"
                                Board(i - 1, j - 1) = 1
                                ' BoardAI(i - 1, j - 1) = 1
                            Case "N"
                                Board(i - 1, j - 1) = 2
                                ' BoardAI(i - 1, j - 1) = 2
                            Case "B"
                                Board(i - 1, j - 1) = 3
                                ' BoardAI(i - 1, j - 1) = 3
                            Case "K"
                                Board(i - 1, j - 1) = 5
                                ' BoardAI(i - 1, j - 1) = 5
                            Case "Q"
                                Board(i - 1, j - 1) = 4
                                ' BoardAI(i - 1, j - 1) = 4
                        End Select

                    End If
                Next
            Next
        Catch ex As Exception
            MsgBox("Convert" + ex.Message)
        End Try
        'MsgBox(Board(0, 0))
    End Function
    Public Function IsLegalMove(ByVal SX, ByVal SY, ByVal EX, ByVal EY) As Boolean
        Try
            Dim piece As Char
            Dim str() As String
            Dim pawnMoves As New Pawn
            Dim rookMoves As New Rook
            Dim boardx As ChessBoard
            Dim KnightMoves As New Knight
            Dim bishopMoves As New Bishop
            Dim kingMoves As New King
            Dim queenMoves As New Queen
            Dim TotalPossibleMoves As Integer
            piece = Player.piece_info(SX, SY)
            If piece <> "o" And piece <> "" Then
                Select Case Char.ToLower(piece)
                    Case "p"
                        str = Split(pawnMoves.getPossibleMoves(SX, SY), ",")
                    Case "r"
                        str = Split(rookMoves.getPossibleMoves(SX, SY, 0, boardx.BlackPlayer.piece_info), ",")
                    Case "n"
                        str = Split(KnightMoves.getPossibleMoves(SX, SY), ",")
                    Case "b"
                        str = Split(bishopMoves.getPossibleMoves(SX, SY, 0, boardx.BlackPlayer.piece_info), ",")
                    Case "k"
                        str = Split(kingMoves.getPossibleMoves(SX, SY, 0, boardx.BlackPlayer.piece_info), ",")
                    Case "q"
                        str = Split(queenMoves.getPossibleMoves(SX, SY, 0, boardx.BlackPlayer.piece_info), ",")

                End Select

                TotalPossibleMoves = str(0)
                For i = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = i
                    i += 1
                    If EX = str(x) And EY = str(i) Then
                        Return True
                    End If
                    i += 1
                Next
                Return False
            End If
        Catch er As Exception
            MsgBox("Yaki in is poosible " + er.Message)
        End Try
    End Function
    Public Function Convert()
        Dim c As Char
        For i As Integer = 1 To 8
            For j As Integer = 1 To 8
                c = Player.piece_info(i, j)
                ' MsgBox(c)
                If Char.IsLower(c) Then
                    Select Case (c)

                        'WHITE
                        Case "o"
                            Board(i, j) = ""

                        Case "p"
                            Board(i, j) = "PawnW"

                        Case "r"
                            Board(i, j) = "CastleW"

                        Case "n"
                            Board(i, j) = "KnightW"

                        Case "b"
                            Board(i, j) = "BishopW"

                        Case "k"
                            Board(i, j) = "KingW"

                        Case "q"
                            Board(i, j) = "QueenW"

                    End Select
                Else
                    Select Case (c)
                        'BLACK
                        Case "P"
                            Board(i, j) = "PawnB"

                        Case "R"
                            Board(i, j) = "CastleB"

                        Case "N"
                            Board(i, j) = "KnightB"

                        Case "B"
                            Board(i, j) = "BishopB"

                        Case "K"
                            Board(i, j) = "KingB"

                        Case "Q"
                            Board(i, j) = "QueenB"

                    End Select

                End If
            Next
        Next
        'MsgBox(Board(0, 0))
    End Function

    Function PickaNumber(ByVal StartNum As Integer, ByVal EndNum As Integer) As Integer

        PickaNumber = Int((EndNum - StartNum + 1) * Rnd + StartNum)

    End Function
    Function CheckPosition(ByVal KingX, ByVal KingY) As Boolean
        For X = 0 To 8 'See if the king is in a check
            For Y = 0 To 8
                If Board(X, Y) <> "" Then
                    If Right(Board(X, Y), 1) <> Turn Then
                        If MoveAlrightRBoard(X, Y, KingX, KingY) Then
                            CheckPosition = True 'CHECK
                            Exit Function
                        End If
                    End If
                End If
            Next
        Next
    End Function
    Function MoveAlrightRBoard(ByVal sx, ByVal sy, ByVal tx, ByVal ty) As Boolean
        Dim OK As Integer

        Colour$ = Right(RBoard(sx, sy), 1)


        If RBoard(sx, sy) = "" Or _
            tx > 8 Or _
            ty > 8 Or _
            (sx = tx And sy = ty) Or _
            Colour$ = Right(RBoard(tx, ty), 1) Then ' Can't take our own.

            MoveAlrightRBoard = False
            Exit Function
        Else
            OK = 0

            'See if were trying to take a piece
            If Colour$ <> Right(RBoard(tx, ty), 1) And Right(RBoard(tx, ty), 1) <> "" Then
                taking = True
                moving = False
            Else ' We are just moving to a blank space.
                taking = False
                moving = True
            End If

            Select Case Mid(RBoard(sx, sy), 1, Len(RBoard(sx, sy)) - 1)
                Case "Pawn" 'Prawn movement
                    If taking Then
                        If ty = sy - 1 And Colour$ = "B" And (tx = sx - 1 Or tx = sx + 1) Then OK = 5 'Black Up + Left/Right to White Taking a piece
                        If ty = sy + 1 And Colour$ = "W" And (tx = sx - 1 Or tx = sx + 1) Then OK = 5 'White Up + Left/Right to Black Taking a piece
                    Else
                        If (RBoard(tx, ty) = "" And ty = sy - 1 And Colour$ = "B" And sx = tx) Then OK = 3 'White vertical
                        If (RBoard(tx, ty) = "" And ty = sy + 1 And Colour$ = "W" And sx = tx) Then OK = 3 'Black Vertical
                        If (Colour$ = "B" And sy = 7 And ty = sy - 2) And tx = sx Then OK = 3 'First move may be double WHITE
                        If (Colour$ = "W" And sy = 2 And ty = sy + 2) And tx = sx Then OK = 3 'First move may be double BLACK
                    End If

                Case "King"     'King movement
                    If tx <= sx + 1 And tx >= sx - 1 And ty <= sy + 1 And ty >= sy - 1 Then OK = 5 'Move in any direction by one

                    ' Allow castling to the right
                    If tx < 8 Then _
                        If Left(RBoard(tx + 1, ty), 6) = "Castle" And _
                            tx = sx + 2 And ty = sy Then OK = 7

                    ' Allow castling to the Left
                    If tx > 2 Then _
                        If Left(RBoard(tx - 2, ty), 6) = "Castle" And _
                            tx = sx - 2 And ty = sy Then OK = 7


                Case "Queen"
                    'Diagonal
                    If Abs(sx - tx) = Abs(sy - ty) Or Abs(tx - sx) = Abs(ty - sy) Then OK = 5
                    'Left
                    If tx < sx And ty = sy Then OK = 4
                    'Right
                    If tx > sx And ty = sy Then OK = 2
                    'Up
                    If tx = sx And ty < sy Then OK = 1
                    'Down
                    If tx = sx And ty > sy Then OK = 3

                Case "Bishop"
                    If Abs(sx - tx) = Abs(sy - ty) Or Abs(tx - sx) = Abs(ty - sy) Then OK = 5

                Case "Knight" 'Horsey
                    If (tx = sx + 2 And ty = sy + 1) Then OK = 6
                    If (tx = sx + 1 And ty = sy + 2) Then OK = 6
                    If (tx = sx - 2 And ty = sy - 1) Then OK = 6
                    If (tx = sx - 1 And ty = sy - 2) Then OK = 6
                    If (tx = sx + 2 And ty = sy - 1) Then OK = 6
                    If (tx = sx + 1 And ty = sy - 2) Then OK = 6
                    If (tx = sx - 2 And ty = sy + 1) Then OK = 6
                    If (tx = sx - 1 And ty = sy + 2) Then OK = 6
                Case "Castle" 'Castle

                    'Left
                    If tx < sx And ty = sy Then OK = 4
                    'Right
                    If tx > sx And ty = sy Then OK = 2
                    'Up
                    If tx = sx And ty < sy Then OK = 1
                    'Down
                    If tx = sx And ty > sy Then OK = 3

            End Select
            'Check to see if we can move, without jumping a piece, based on OK values

            Select Case OK
                Case 0
                    MoveAlrightRBoard = False
                    Exit Function
                Case 1 'Up
                    For Y = sy - 1 To ty Step -1
                        If Y < 0 Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If moving And RBoard(sx, Y) <> "" Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If taking And (Board(sx, Y) <> "" And (sx <> tx Or Y <> ty)) Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                    Next
                Case 2 'Right
                    For X = sx + 1 To tx Step 1
                        If X < 0 Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If moving And RBoard(X, sy) <> "" Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If taking And (Board(X, sy) <> "" And (X <> tx Or sy <> ty)) Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                    Next
                Case 3 'Down
                    For Y = sy + 1 To ty Step 1
                        If Y < 0 Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If moving And RBoard(sx, Y) <> "" Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If taking And (Board(sx, Y) <> "" And (sx <> tx Or Y <> ty)) Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                    Next
                Case 4 'Left
                    For X = sx - 1 To tx Step -1
                        If X < 0 Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If moving And RBoard(X, sy) <> "" Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                        If taking And (Board(X, sy) <> "" And (X <> tx Or sy <> ty)) Then
                            MoveAlrightRBoard = False
                            Exit Function
                        End If

                    Next
                Case 5 'Diagonal
                    If sx > tx And sy > ty Then 'Up Left
                        For X = sx - 1 To tx Step -1
                            For Y = sy - 1 To ty Step -1
                                If sx - X = sy - Y Then 'Only check if it's a diagonal
                                    If moving And RBoard(X, Y) <> "" Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                    If taking And Board(X, Y) <> "" And (X <> tx Or Y <> ty) Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If

                    If sx < tx And sy > ty Then 'Up Right
                        For X = sx + 1 To tx
                            For Y = sy - 1 To ty Step -1
                                If sx - X = Y - sy Then  'Only check if it's a diagonal
                                    If moving And RBoard(X, Y) <> "" Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                    If sx > tx And sy < ty Then 'Down Left
                        For X = sx - 1 To tx Step -1
                            For Y = sy + 1 To ty
                                If X - sx = sy - Y Then 'Only check if it's a diagonal
                                    If moving And RBoard(X, Y) <> "" Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                    If sx < tx And sy < ty Then 'Down Right
                        For X = sx + 1 To tx
                            For Y = sy + 1 To ty
                                If sx - X = sy - Y Then 'Only check if it's a diagonal
                                    If moving And RBoard(X, Y) <> "" Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlrightRBoard = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                Case 6
                    'It's a horsey & they're allowed to jump pieces!
                Case 7
                    ' We are castling the pieces here
                    If taking Then
                        ' Move not OK so just exit
                        MoveAlrightRBoard = False
                        Exit Function
                    ElseIf moving Then
                        ' look left
                        For X = sx - 1 To tx Step -1

                            If moving And RBoard(X, sy) <> "" Then
                                MoveAlrightRBoard = False
                                Exit Function
                            End If
                        Next X

                        For X = sx + 1 To tx Step 1


                            If moving And RBoard(X, sy) <> "" Then
                                MoveAlrightRBoard = False
                                Exit Function
                            End If
                        Next X

                    End If
            End Select

            'Successful Move!
            MoveAlrightRBoard = True
        End If
    End Function

    Function moveCost() As Integer
        Dim BestScore As Integer
        Dim Score As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim n As Integer
        Dim m As Integer
        BestScore = -100


        For X = 1 To 8
            For Y = 1 To 8
                ' IF its an opponents piece then
                If Right(RBoard(X, Y), 1) = "B" Then
                    For X2 = 1 To 8
                        For Y2 = 1 To 8
                            If MoveAlrightRBoard(X, Y, X2, Y2) Then
                                'Your in Check.

                                Score = QualityOfTempTarget(X2, Y2)
                                If Score > BestScore Then BestScore = Score
                                '                        Write #1, x, y, X2, Y2, tempBoard(x, y), "MoveCost:" & Score

                            End If
                        Next Y2
                    Next X2
                End If
            Next Y

        Next X
        moveCost = BestScore
    End Function

    Function QualityOfTempTarget(ByVal X, ByVal Y)
        If RBoard(X, Y) = "" Then
            QualityOfTempTarget = 0
            Exit Function
        End If

        Select Case Mid(RBoard(X, Y), 1, Len(RBoard(X, Y)) - 1)
            Case "Pawn"
                QualityOfTempTarget = 4
            Case "Castle"
                QualityOfTempTarget = 12
            Case "Knight"
                QualityOfTempTarget = 10
            Case "Bishop"
                QualityOfTempTarget = 9
            Case "Queen"
                QualityOfTempTarget = 14
            Case "King"
                QualityOfTempTarget = 9999
        End Select
    End Function

    Function CoveredPosition(ByVal pX, ByVal pY)
        For X = 0 To 8
            For Y = 0 To 8
                If Right(Board(X, Y), 1) = Right(Board(pX, pY), 1) Then 'If piece is on same team
                    If MoveAlright(X, Y, pX, pY) Then 'If peice is covered by other peice
                        CoveredPosition = True
                        Exit Function
                    End If
                End If
            Next
        Next
    End Function

    Public Function QualityOfTarget(ByVal X, ByVal Y)
        If Board(X, Y) = "" Then
            QualityOfTarget = -10
            Exit Function
        End If
    End Function

    Function CostOfLoss(ByVal X, ByVal Y)
        If Board(X, Y) = "" Then Exit Function
        Select Case Mid(Board(X, Y), 1, Len(Board(X, Y)) - 1)
            Case "Pawn"
                CostOfLoss = 50
            Case "Castle"
                CostOfLoss = 150
            Case "Knight"
                CostOfLoss = 110
            Case "Bishop"
                CostOfLoss = 150
            Case "Queen"
                CostOfLoss = 200
            Case "King"
                CostOfLoss = 1000
        End Select
    End Function
    Public Function MoveAlright(ByVal sx, ByVal sy, ByVal tx, ByVal ty) As Boolean
        'On Error Resume Next
        Dim OK As Integer

        Colour$ = Right(Board(sx, sy), 1)



        If Board(sx, sy) = "" Or _
            tx > 8 Or _
            ty > 8 Or _
            (sx = tx And sy = ty) Or _
            Colour$ = Right(Board(tx, ty), 1) Then ' Can't take our own.

            MoveAlright = False
            Exit Function
        Else
            OK = 0

            ' Check for check.
            '    If Board(sx, sy) = "KingW" Then
            '        MsgBox Board(sx, sy) & ": " & tx & ", " & ty & "-> " & Board(tx, ty)
            '    End If
            If Mid(Board(sx, sy), 1, Len(Board(sx, sy)) - 1) = "King" And CheckPosition(tx, ty) Then
                MoveAlright = False
                Exit Function
            End If
            If Mid(Board(sx, sy), 1, Len(Board(sx, sy)) - 1) <> "King" And CheckForCheck And CheckPosition(tx, ty) Then
                MoveAlright = False
                Exit Function
            End If

            'See if were trying to take a piece
            If Colour$ <> Right(Board(tx, ty), 1) And Right(Board(tx, ty), 1) <> "" Then
                taking = True
                moving = False
            Else ' We are just moving to a blank space.
                taking = False
                moving = True
            End If

            Select Case Mid(Board(sx, sy), 1, Len(Board(sx, sy)) - 1)
                Case "Pawn" 'Prawn movement
                    If taking Then
                        If ty = sy - 1 And Colour$ = "B" And (tx = sx - 1 Or tx = sx + 1) Then OK = 5 'Black Up + Left/Right to White Taking a piece
                        If ty = sy + 1 And Colour$ = "W" And (tx = sx - 1 Or tx = sx + 1) Then OK = 5 'White Up + Left/Right to Black Taking a piece
                    Else
                        If (Board(tx, ty) = "" And ty = sy - 1 And Colour$ = "B" And sx = tx) Then OK = 3 'White vertical
                        If (Board(tx, ty) = "" And ty = sy + 1 And Colour$ = "W" And sx = tx) Then OK = 3 'Black Vertical
                        If (Colour$ = "B" And sy = 7 And ty = sy - 2) And tx = sx Then OK = 3 'First move may be double WHITE
                        If (Colour$ = "W" And sy = 2 And ty = sy + 2) And tx = sx Then OK = 3 'First move may be double BLACK
                    End If

                Case "King"     'King movement
                    If tx <= sx + 1 And tx >= sx - 1 And ty <= sy + 1 And ty >= sy - 1 Then OK = 5 'Move in any direction by one

                    ' Allow castling to the right
                    If tx < 8 Then _
                        If Left(Board(tx + 1, ty), 6) = "Castle" And _
                            tx = sx + 2 And ty = sy Then OK = 7

                    ' Allow castling to the Left
                    If tx > 2 Then _
                        If Left(Board(tx - 2, ty), 6) = "Castle" And _
                            tx = sx - 2 And ty = sy Then OK = 7


                Case "Queen"
                    'Diagonal
                    If Abs(sx - tx) = Abs(sy - ty) Or Abs(tx - sx) = Abs(ty - sy) Then OK = 5
                    'Left
                    If tx < sx And ty = sy Then OK = 4
                    'Right
                    If tx > sx And ty = sy Then OK = 2
                    'Up
                    If tx = sx And ty < sy Then OK = 1
                    'Down
                    If tx = sx And ty > sy Then OK = 3

                Case "Bishop"
                    If Abs(sx - tx) = Abs(sy - ty) Or Abs(tx - sx) = Abs(ty - sy) Then OK = 5

                Case "Knight" 'Horsey
                    If (tx = sx + 2 And ty = sy + 1) Then OK = 6
                    If (tx = sx + 1 And ty = sy + 2) Then OK = 6
                    If (tx = sx - 2 And ty = sy - 1) Then OK = 6
                    If (tx = sx - 1 And ty = sy - 2) Then OK = 6
                    If (tx = sx + 2 And ty = sy - 1) Then OK = 6
                    If (tx = sx + 1 And ty = sy - 2) Then OK = 6
                    If (tx = sx - 2 And ty = sy + 1) Then OK = 6
                    If (tx = sx - 1 And ty = sy + 2) Then OK = 6
                Case "Castle" 'Castle

                    'Left
                    If tx < sx And ty = sy Then OK = 4
                    'Right
                    If tx > sx And ty = sy Then OK = 2
                    'Up
                    If tx = sx And ty < sy Then OK = 1
                    'Down
                    If tx = sx And ty > sy Then OK = 3

            End Select
            'Check to see if we can move, without jumping a piece, based on OK values

            Select Case OK
                Case 0
                    MoveAlright = False
                    Exit Function
                Case 1 'Up
                    For Y = sy - 1 To ty Step -1
                        If Y < 0 Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If moving And Board(sx, Y) <> "" Then
                            MoveAlright = False
                            Exit Function
                        End If

                        ' are we taking, is the current square blank, if its not blank is it the desired one
                        If taking And (Board(sx, Y) <> "" And (sx <> tx Or Y <> ty)) Then
                            MoveAlright = False
                            Exit Function
                        End If

                    Next
                Case 2 'Right
                    For X = sx + 1 To tx Step 1
                        If X < 0 Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If moving And Board(X, sy) <> "" Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If taking And (Board(X, sy) <> "" And (X <> tx Or sy <> ty)) Then
                            MoveAlright = False
                            Exit Function
                        End If

                    Next
                Case 3 'Down
                    For Y = sy + 1 To ty Step 1
                        If Y < 0 Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If moving And Board(sx, Y) <> "" Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If taking And (Board(sx, Y) <> "" And (sx <> tx Or Y <> ty)) Then
                            MoveAlright = False
                            Exit Function
                        End If

                    Next
                Case 4 'Left
                    For X = sx - 1 To tx Step -1
                        If X < 0 Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If moving And Board(X, sy) <> "" Then
                            MoveAlright = False
                            Exit Function
                        End If

                        If taking And (Board(X, sy) <> "" And (X <> tx Or sy <> ty)) Then
                            MoveAlright = False
                            Exit Function
                        End If

                    Next
                Case 5 'Diagonal
                    If sx > tx And sy > ty Then 'Up Left
                        For X = sx - 1 To tx Step -1
                            For Y = sy - 1 To ty Step -1
                                If sx - X = sy - Y Then 'Only check if it's a diagonal
                                    If moving And Board(X, Y) <> "" Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                    If taking And Board(X, Y) <> "" And (X <> tx Or Y <> ty) Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If

                    If sx < tx And sy > ty Then 'Up Right
                        For X = sx + 1 To tx
                            For Y = sy - 1 To ty Step -1
                                If sx - X = Y - sy Then  'Only check if it's a diagonal
                                    If moving And Board(X, Y) <> "" Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                    If sx > tx And sy < ty Then 'Down Left
                        For X = sx - 1 To tx Step -1
                            For Y = sy + 1 To ty
                                If X - sx = sy - Y Then 'Only check if it's a diagonal
                                    If moving And Board(X, Y) <> "" Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                    If sx < tx And sy < ty Then 'Down Right
                        For X = sx + 1 To tx Step 1
                            For Y = sy + 1 To ty Step 1
                                If sx - X = sy - Y Then 'Only check if it's a diagonal
                                    If moving And Board(X, Y) <> "" Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                    If taking And (Board(X, Y) <> "" And (X <> tx Or Y <> ty)) Then
                                        MoveAlright = False
                                        Exit Function
                                    End If

                                End If
                            Next
                        Next
                    End If
                Case 6
                    'It's a horsey & they're allowed to jump pieces!
                Case 7
                    ' We are castling the pieces here
                    If taking Then
                        ' Move not OK so just exit
                        MoveAlright = False
                        Exit Function
                    ElseIf moving Then
                        ' look left
                        For X = sx - 1 To tx Step -1

                            If moving And Board(X, sy) <> "" Then
                                MoveAlright = False
                                Exit Function
                            End If
                        Next X

                        For X = sx + 1 To tx Step 1


                            If moving And Board(X, sy) <> "" Then
                                MoveAlright = False
                                Exit Function
                            End If
                        Next X

                    End If
            End Select

            'Successful Move!
            MoveAlright = True
        End If
    End Function
   
    Function CheckForCheck() As Boolean
        Dim KingX, KingY

        If KingX = 0 And KingY = 0 Then 'Find the king of the moving side!
            For X = 0 To 8
                For Y = 0 To 8
                    If Board(X, Y) = "King" + Turn Then
                        KingX = X
                        KingY = Y
                    End If
                Next
                If KingX <> 0 And KingY <> 0 Then Exit For
            Next
        End If

        For X = 0 To 8 'See if the king is in a check
            For Y = 0 To 8
                If Board(X, Y) <> "" Then
                    If Right(Board(X, Y), 1) <> Turn Then
                        If MoveAlrightRBoard(X, Y, KingX, KingY) Then
                            CheckForCheck = True 'CHECK
                            SelX% = KingX
                            SelY% = KingY
                            Exit Function
                        End If
                    End If
                End If
            Next
        Next

    End Function

End Class
