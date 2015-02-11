Public Class Player

    Public white As Boolean
    Public Shared piece_info(8, 8) As Char
    Public pawns As New Pawn
    Public queen As New Queen
    Public king As New King
    Public bishops As New Bishop
    Public rooks As New Rook
    Public Shared Killd As Integer = 0
    Public Shared Bkilld As Integer = 0
    Public knights As New Knight
    Public Shared captured_piece As ArrayList = New ArrayList(1)
    Private main As New frmMain
    Private board As New ChessBoard
    Public Shared blackPieceCaptured As Integer = 0
    Public Shared whitePieceCaptured As Integer = 0
    Public Shared KilledWhite(64) As String
    Public Shared KilledBlack(64) As String


    Public Sub New(ByVal white As Boolean)
        Dim i As Integer
        Dim u As Integer
        Dim s As Integer
        Me.white = white
        If (white) Then
            i = 1
            u = 2
            s = 1
        Else
            i = 8
            u = 7
            s = -1
        End If

        '   Int(XAttribute = captured_piece.Capacity)

        For y As Integer = i To u Step s
            For x As Integer = 1 To 8

                Dim index As Integer

                If y = i Then

                    If x <= 5 Then
                        index = 0
                    Else
                        index = 1
                    End If

                    Select Case x
                        Case 1
                            rooks.setLocation(index, x, y)
                        Case 2
                            knights.setLocation(index, x, y)
                        Case 3
                            bishops.setLocation(index, x, y)
                        Case 4
                            queen.setLocation(x, y)
                        Case 5
                            king.setLocation(x, y)
                        Case 6
                            bishops.setLocation(index, x, y)
                        Case 7
                            knights.setLocation(index, x, y)
                        Case 8
                            rooks.setLocation(index, x, y)
                    End Select
                End If

                If y = u Then
                    pawns.setLocation(x - 1, x, y)
                End If
            Next
        Next
        Me.piecearray()
    End Sub

    Public Function piecearray()
        Try
            Dim pawn As Char = "p"
            Dim rook As Char = "r"
            Dim knight As Char = "n"
            Dim bishop As Char = "b"
            Dim queen As Char = "q"
            Dim king As Char = "k"

            If Me.white = False Then
                pawn = pawn.ToUpper(pawn)
                rook = rook.ToUpper(rook)
                knight = knight.ToUpper(knight)
                bishop = bishop.ToUpper(bishop)
                queen = queen.ToUpper(queen)
                king = king.ToUpper(king)
            End If
            For index As Integer = 0 To 7
                If index <= 7 Then
                    piece_info(pawns.PawnCount(index, 0), pawns.PawnCount(index, 1)) = pawn
                End If

                If index <= 1 Then
                    piece_info(bishops.BishopCount(index, 0), bishops.BishopCount(index, 1)) = bishop
                    piece_info(rooks.RookCount(index, 0), rooks.RookCount(index, 1)) = rook
                    piece_info(knights.KnightCount(index, 0), knights.KnightCount(index, 1)) = knight
                End If

                If index = 0 Then
                    piece_info(Me.king.KingCount(index, 0), Me.king.KingCount(index, 1)) = king
                    piece_info(Me.queen.QueenCount(index, 0), Me.queen.QueenCount(index, 1)) = queen

                End If

            Next
            For index1 As Integer = 1 To 8
                For index2 As Integer = 1 To 8
                    If piece_info(index1, index2) = Nothing Then
                        piece_info(index1, index2) = "o"
                    End If

                Next
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    
    Private Sub capturedPieces(ByVal x2, ByVal y2)
        Try
            If piece_info(x2, y2) <> "o" Then
                If main.getPlayerTurn Then
                    whitePieceCaptured += 1
                    KilledWhite(BKilld) = (CStr(piece_info(x2, y2)) + "," + CStr(whitePieceCaptured))
                    frmMain.WhiteCaptured.Text = whitePieceCaptured
                    Bkilld += 1
                Else
                    blackPieceCaptured += 1
                    KilledBlack(Killd) = (CStr(piece_info(x2, y2)) + "," + CStr(blackPieceCaptured))
                    '  MsgBox(KilledBlack(Killd))
                    frmMain.BlackCaptured.Text = blackPieceCaptured
                    Killd += 1
                End If
            End If
        Catch ex As Exception
            MsgBox("Captured Pieces Error " + ex.Message)
        End Try
    End Sub

    Public Function updatepiece(ByVal c As Char, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer) As Boolean
        Try
            Dim piece As Char
            Dim SF As Boolean = False
            piece = Char.ToLower(c)

            'If board.isUnderCheck(main.Playercolor) = False Then
            capturedPieces(x2, y2)
            Select Case piece

                Case "p"
                    If pawns.isPossibleMove(x2, y2) Then
                        If x2 = Pawn.EN_pas_x And y2 = Pawn.EN_pas_y Then
                            pawns.setLocation(pawns.getIndex(x1, y1), x2, y2)
                            If frmMain.imr > 0 Then
                                captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                                frmMain.imr = 0
                            End If
                            If frmMain.imr = 0 Then
                                captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(Pawn.EN_pas_capX, Pawn.EN_pas_capY) & "," & x2 & "," & y2)
                            Else
                                captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(Pawn.EN_pas_capX, Pawn.EN_pas_capY) & "," & x2 & "," & y2)
                            End If
                            piece_info(x2, y2) = piece_info(x1, y1)
                            piece_info(x1, y1) = "o"
                            piece_info(Pawn.EN_pas_capX, Pawn.EN_pas_capY) = "o"
                            updateCapturedPiece(x1, y1)
                            SF = True
                        Else
                            If Not board.isItTimeToChange(y2, main.getPlayerTurn) Then
                                pawns.setLocation(pawns.getIndex(x1, y1), x2, y2)
                                If frmMain.imr > 0 Then
                                    captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                                    frmMain.imr = 0
                                End If
                                If frmMain.imr = 0 Then
                                    captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                                Else
                                    captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                                End If
                                piece_info(x2, y2) = piece_info(x1, y1)
                                piece_info(x1, y1) = "o"
                                updateCapturedPiece(x1, y1)
                            End If
                            'pawns.setLocation(pawns.getIndex(x1, y1), 0, 0)
                            board.PEX = x2
                            board.PEY = y2
                            SF = True
                        End If
                    End If

                Case "r"
                    If rooks.isPossibleMove(x2, y2) Then
                        rooks.setLocation(rooks.getIndex(x1, y1), x2, y2)
                        If frmMain.imr > 0 Then
                            captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                            frmMain.imr = 0
                        End If
                        If frmMain.imr = 0 Then
                            captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        Else
                            captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        End If
                        piece_info(x2, y2) = piece_info(x1, y1)
                        piece_info(x1, y1) = "o"
                        updateCapturedPiece(x1, y1)
                        SF = True
                    End If

                Case "n"
                    If knights.isPossibleMove(x2, y2) Then
                        knights.setLocation(knights.getIndex(x1, y1), x2, y2)
                        If frmMain.imr > 0 Then
                            captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                            frmMain.imr = 0
                        End If
                        If frmMain.imr = 0 Then
                            captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        Else
                            captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        End If
                        piece_info(x2, y2) = piece_info(x1, y1)
                        piece_info(x1, y1) = "o"
                        updateCapturedPiece(x1, y1)
                        SF = True
                    End If

                Case "b"
                    If bishops.isPossibleMove(x2, y2) Then
                        bishops.setLocation(bishops.getIndex(x1, y1), x2, y2)
                        If frmMain.imr > 0 Then
                            captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                            frmMain.imr = 0
                        End If
                        If frmMain.imr = 0 Then
                            captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        Else
                            captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        End If
                        piece_info(x2, y2) = piece_info(x1, y1)
                        piece_info(x1, y1) = "o"
                        updateCapturedPiece(x1, y1)
                        SF = True
                    End If

                Case "q"
                    If queen.isPossibleMove(x2, y2) Then
                        queen.setLocation(x2, y2)
                        If frmMain.imr > 0 Then
                            captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                            frmMain.imr = 0
                        End If
                        If frmMain.imr = 0 Then
                            captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        Else
                            captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        End If
                        piece_info(x2, y2) = piece_info(x1, y1)
                        piece_info(x1, y1) = "o"
                        updateCapturedPiece(x1, y1)
                        SF = True
                    End If

                Case "k"
                    If king.isPossibleMove(x2, y2) Then
                        king.setLocation(x2, y2)
                        If frmMain.imr > 0 Then
                            captured_piece.RemoveRange((captured_piece.Count - frmMain.imr), frmMain.imr)
                            frmMain.imr = 0
                        End If
                        If frmMain.imr = 0 Then
                            captured_piece.Insert((captured_piece.Count - frmMain.imr), piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        Else
                            captured_piece.Insert((captured_piece.Count - frmMain.imr) + 1, piece_info(x1, y1) & "," & x1 & "," & y1 & "," & piece_info(x2, y2) & "," & x2 & "," & y2)
                        End If
                        piece_info(x2, y2) = piece_info(x1, y1)
                        piece_info(x1, y1) = "o"
                        updateCapturedPiece(x1, y1)
                        SF = True
                    End If
            End Select

            'Else
            '    MsgBox("U r undercheck")
            'End If
            If SF Then
                Return True
            Else
                Return False
            End If

        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Function

    Public Function domove(ByVal c As Char, ByVal x1 As Integer, ByVal y1 As Integer, ByVal c2 As Char, ByVal x2 As Integer, ByVal y2 As Integer)
        Try
            Dim piece As Char
            Dim SF As Boolean = False
            piece = Char.ToLower(c)
            Select Case piece

                Case "p"
                    pawns.setLocation(pawns.getIndex(x1, y1), x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2



                Case "r"
                    rooks.isPossibleMove(x2, y2)
                    rooks.setLocation(rooks.getIndex(x1, y1), x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2


                Case "n"
                    knights.setLocation(knights.getIndex(x1, y1), x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2


                Case "b"
                    bishops.setLocation(bishops.getIndex(x1, y1), x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2



                Case "q"
                    queen.setLocation(x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2



                Case "k"
                    king.setLocation(x2, y2)
                    piece_info(x2, y2) = piece_info(x1, y1)
                    piece_info(x1, y1) = c2

            End Select

        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Function

    Public Shared Function matchcolor(ByVal x As Integer, ByVal y As Integer, ByVal wht As Boolean)
        If Not (Player.piece_info(x, y) = "o") And Not (Char.IsLower(Player.piece_info(x, y)) = wht) Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Sub restorepieces()

        Try


            Dim piece As Char
            Dim index() As Integer = {0, 0, 0, 0, 0, 0}
            Dim ok As Boolean

            For y As Integer = 1 To 8
                For x As Integer = 1 To 8

                    If piece_info(x, y) = "o" Then
                        Continue For
                    End If

                    piece = ""
                    ok = False

                    If Me.white Then
                        If Char.IsLower(piece_info(x, y)) Then
                            piece = piece_info(x, y)
                            ok = True
                        End If


                    Else
                        If Char.IsUpper(piece_info(x, y)) Then
                            piece = piece_info(x, y)
                            ok = True
                        End If
                    End If

                    If ok Then

                        Select Case Char.ToLower(piece)

                            Case "p"
                                If index(0) <= 7 Then
                                    pawns.setLocation(index(0), x, y)
                                    index(0) += 1
                                End If


                            Case "r"
                                If index(1) <= 1 Then
                                    rooks.setLocation(index(1), x, y)
                                    index(1) += 1
                                End If


                            Case "n"
                                If index(2) <= 1 Then
                                    knights.setLocation(index(2), x, y)
                                    index(2) += 1
                                End If


                            Case "b"
                                If index(3) <= 1 Then
                                    bishops.setLocation(index(3), x, y)
                                    index(3) += 1
                                End If


                            Case "q"

                                If index(4) = 0 Then
                                    queen.setLocation(x, y)
                                End If


                            Case "k"

                                If index(5) = 0 Then
                                    king.setLocation(x, y)
                                End If

                        End Select
                    End If


                Next
            Next

        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub


    Public Sub updateCapturedPiece(ByVal x As Integer, ByVal y As Integer)
        Try

            Dim piece As Char = piece_info(x, y)
            Select Case piece

                Case "p"
                    pawns.setLocation(pawns.getIndex(x, y), -1, -1)


                Case "r"
                    rooks.setLocation(rooks.getIndex(x, y), -1, -1)

                Case "n"
                    knights.setLocation(knights.getIndex(x, y), -1, -1)


                Case "b"
                    bishops.setLocation(bishops.getIndex(x, y), -1, -1)

                Case "q"
                    queen.setLocation(-1, -1)


                Case "k"
                    king.setLocation(-1, -1)


            End Select


        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub

End Class
