Public Class Pawn
    Inherits Piece
    Private isFirstTime As Boolean
    Public PawnCount(8, 2) As Integer
    Public PosMovArray(8, 8) As Integer
    Public Shared EN_pas_x As Integer
    Public Shared EN_pas_y As Integer
    Public Shared EN_pas_capX As Integer
    Public Shared EN_pas_capY As Integer
    Dim board As New ChessBoard
    Public Sub New()
        isFirstTime = True
        MyBase.SetPieceStatus(False)

    End Sub
    Public Sub setLocation(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        PawnCount(IndexNUmber, 0) = X
        PawnCount(IndexNUmber, 1) = Y
    End Sub
    Public Function getLocation(ByVal PawnNo As Integer)
        Dim location As String = ""
        location = location & PawnCount(PawnNo, 0) & ","
        location = location & PawnCount(PawnNo, 1)
        Return location
    End Function
    Public Function getIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        For i As Integer = 0 To 7
            If PawnCount(i, 0) = x And PawnCount(i, 1) = y Then
                Return i
            End If
        Next
    End Function

    Public Sub initPawn(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        setLocation(IndexNUmber, X, Y)
    End Sub

    Public Function getPossibleMoves(ByVal x As Integer, ByVal y As Integer) As String

        Try
            Dim moves As String
            Dim count As Integer = 0
            Dim white As Boolean = Char.IsLower(Player.piece_info(x, y))
            Dim firsttime As Boolean
            Dim d As Integer

            EN_pas_x = Nothing
            EN_pas_y = Nothing
            EN_pas_capX = Nothing
            EN_pas_capY = Nothing


            If white Then
                If y = 2 Then
                    firsttime = True
                End If
                d = 1
            Else
                If y = 7 Then
                    firsttime = True
                End If
                d = -1
            End If

            If Player.piece_info(x, y + (d * 1)) = "o" Then
                PosMovArray(x, y + (d * 1)) = 1
                count = count + 1
                moves = moves & "," & x & "," & y + (d * 1) & "," & 0

                If firsttime Then
                    If Player.piece_info(x, y + (d * 2)) = "o" Then
                        PosMovArray(x, y + (d * 2)) = 1
                        count = count + 1
                        moves = moves & "," & x & "," & y + (d * 2) & "," & 0
                    End If
                End If
            End If

            If white Then
                If Not (y = 8 Or x = 8) Then
                    If Player.matchcolor(x + (d * 1), y + (d * 1), white) = 1 Then
                        PosMovArray(x + (d * 1), y + (d * 1)) = 1
                        count = count + 1
                        moves = moves & "," & x + (d * 1) & "," & y + (d * 1) & "," & 1
                    End If
                End If
            Else
                If Not (y = 1) Or Not (x = 1) Then
                    If Player.matchcolor(x + (d * 1), y + (d * 1), white) = 1 Then
                        PosMovArray(x + (d * 1), y + (d * 1)) = 1
                        count = count + 1
                        moves = moves & "," & x + (d * 1) & "," & y + (d * 1) & "," & 1
                    End If
                End If
            End If

            If white Then
                If Not (y = 8 Or x = 1) Then
                    If Player.matchcolor(x - (d * 1), y + (d * 1), white) = 1 Then
                        PosMovArray(x - (d * 1), y + (d * 1)) = 1
                        count = count + 1
                        moves = moves & "," & x - (d * 1) & "," & y + (d * 1) & "," & 1
                    End If
                End If

            Else
                If Not (y = 1 Or x = 8) Then
                    If Player.matchcolor(x - (d * 1), y + (d * 1), white) = 1 Then
                        PosMovArray(x - (d * 1), y + (d * 1)) = 1
                        count = count + 1
                        moves = moves & "," & x - (d * 1) & "," & y + (d * 1) & "," & 1
                    End If
                End If
            End If

            'En Passant Move:-
            If Player.captured_piece.Count <> 0 Then
                Dim size As Integer = Player.captured_piece.Count

                Player.captured_piece.TrimToSize()
                Dim Str() As String = Split(Player.captured_piece(size - 1), ",")
                Dim same_col As Boolean = Char.IsLower(Str(0))
                Dim last_piece As Char = Char.ToLower(Str(0))
                Dim sx As Integer = Convert.ToInt32(Str(1))
                Dim sy As Integer = Convert.ToInt32(Str(2))
                Dim ex As Integer = Convert.ToInt32(Str(4))
                Dim ey As Integer = Convert.ToInt32(Str(5))
                Dim dir As Integer

                If white Then
                    dir = -1
                Else
                    dir = 1
                End If


                If last_piece = "p" And white <> same_col And ey = sy + (dir * 2) Then 'checking if last piece that moved(first time) was pawn of different colour 

                    If white Then
                        If x < 8 And ex = x + 1 And y = 5 And y = ey Then
                            PosMovArray(x + (d * 1), y + (d * 1)) = 1
                            count = count + 1
                            moves = moves & "," & x + (d * 1) & "," & y + (d * 1) & "," & 1
                            EN_pas_x = x + (d * 1)
                            EN_pas_y = y + (d * 1)
                            EN_pas_capX = ex
                            EN_pas_capY = ey
                        End If
                    Else
                        If x > 1 And sx = x - 1 And y = 4 And y = ey Then
                            PosMovArray(x + (d * 1), y + (d * 1)) = 1
                            count = count + 1
                            moves = moves & "," & x + (d * 1) & "," & y + (d * 1) & "," & 1
                            EN_pas_x = x + (d * 1)
                            EN_pas_y = y + (d * 1)
                            EN_pas_capX = ex
                            EN_pas_capY = ey
                        End If
                    End If

                    If white Then
                        If x > 1 And ex = x - 1 And y = 5 And y = ey Then
                            PosMovArray(x - (d * 1), y + (d * 1)) = 1
                            count = count + 1
                            moves = moves & "," & x - (d * 1) & "," & y + (d * 1) & "," & 1
                            EN_pas_x = x - (d * 1)
                            EN_pas_y = y + (d * 1)
                            EN_pas_capX = ex
                            EN_pas_capY = ey
                        End If
                    Else
                        If x < 8 And ex = x + 1 And y = 4 And y = ey Then
                            PosMovArray(x - (d * 1), y + (d * 1)) = 1
                            count = count + 1
                            moves = moves & "," & x - (d * 1) & "," & y + (d * 1) & "," & 1
                            EN_pas_x = x - (d * 1)
                            EN_pas_y = y + (d * 1)
                            EN_pas_capX = ex
                            EN_pas_capY = ey
                        End If
                    End If

                End If
            End If
            '---------------------------En Passant
                Return count & moves
        Catch ex As Exception
            ' MsgBox("ERROR PAWN :" & ex.Message)
        End Try
    End Function

    Public Function isPossibleMove(ByVal x2 As Integer, ByVal y2 As Integer) As Boolean
        Try
            Dim i As Integer
            For i = 0 To frmMain.PossibleMoves.Length - 1
                If frmMain.PossibleMoves(i).X = x2 And frmMain.PossibleMoves(i).Y = y2 Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


End Class
