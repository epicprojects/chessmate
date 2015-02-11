Public Class Rook
    Inherits Piece
    Public RookCount(2, 2) As Integer
    Dim board As New ChessBoard
    Public Sub New()

        MyBase.SetPieceStatus(False)

    End Sub
    Public Sub setLocation(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        RookCount(IndexNUmber, 0) = X
        RookCount(IndexNUmber, 1) = Y
    End Sub
    Public Function getIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        For i As Integer = 0 To 1
            If RookCount(i, 0) = x And RookCount(i, 1) = y Then
                Return i
            End If
        Next
    End Function
    Public Function getLocation(ByVal BishopNO As Integer) As String
        Dim location As String = ""
        location = location & RookCount(BishopNO, 0) & ","
        location = location & RookCount(BishopNO, 1)
        Return location
    End Function
    Public Sub initRook(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        setLocation(IndexNUmber, X, Y)
    End Sub
    Public Function getPossibleMoves(ByVal x As Integer, ByVal y As Integer, ByVal colour As Integer, ByVal boardinfo(,) As Char)
        Try
            Dim moves As String
            Dim count As Integer
            Dim i, j As Integer
            count = 0
            'player selected QUEEN

            'Checking moves at RIGHT
            'check while x is not on corner of board
            If x = 8 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to left while y=constant
                For i = x + 1 To 8
                    If boardinfo(i, y) = "o" Then
                        'allocating locations of possible moves
                        moves = moves & i & "," & y & ",0,"
                        count = count + 1
                    Else
                        'checking your team colour 1=white 0=black
                        'alphabet B for black and W for white
                        'COLOUR SELECTED BLACK
                        If colour = 0 Then
                            If Not board.isBlack(boardinfo(i, y)) Then
                                moves = moves & i & "," & y & ",1,"
                                count = count + 1
                            End If
                        Else
                            If board.isBlack(boardinfo(i, y)) Then
                                moves = moves & i & "," & y & ",1,"
                                count = count + 1
                            End If
                        End If
                        GoTo GETOUT1
                    End If
                Next

            End If
GETOUT1:
            'Checking moves at LEFT
            'check while x is not on corner of board
            If x = 1 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to right while y=constant
                For i = (x - 1) To 1 Step -1
                    If boardinfo(i, y) = "o" Then
                        'allocating locations of possible moves
                        moves = moves & i & "," & y & ",0,"
                        count = count + 1
                    Else
                        'checking your team colour 1=white 0=black
                        'alphabet B for black and W for white
                        If colour = 0 Then
                            If Not board.isBlack(boardinfo(i, y)) Then
                                moves = moves & i & "," & y & ",1,"
                                count = count + 1
                            End If
                        Else
                            If board.isBlack(boardinfo(i, y)) Then
                                moves = moves & i & "," & y & ",1,"
                                count = count + 1
                            End If
                        End If
                        GoTo GETOUT2
                    End If
                Next

            End If
GETOUT2:


            'Checking moves at top
            'check while y is not on corner of board
            If y = 8 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                For i = y + 1 To 8
                    If boardinfo(x, i) = "o" Then
                        'allocating locations of possible moves
                        moves = moves & x & "," & i & ",0,"
                        count = count + 1
                    Else
                        'checking your team colour 1=white 0=black
                        'alphabet B for black and W for white
                        If colour = 0 Then
                            If Not board.isBlack(boardinfo(x, i)) Then
                                moves = moves & x & "," & i & ",1,"
                                count = count + 1
                            End If
                        Else
                            If board.isBlack(boardinfo(x, i)) Then
                                moves = moves & x & "," & i & ",1,"
                                count = count + 1
                            End If
                        End If
                        GoTo GETOUT3
                    End If
                Next

            End If
GETOUT3:



            'Checking moves at bottom
            'check while y is not on corner of board
            If y = 1 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                For i = y - 1 To 1 Step -1
                    If boardinfo(x, i) = "o" Then
                        'allocating locations of possible moves
                        moves = moves & x & "," & i & ",0,"
                        count = count + 1
                    Else
                        'checking your team colour 1=white 0=black
                        'alphabet B for black and W for white
                        If colour = 0 Then
                            If Not board.isBlack(boardinfo(x, i)) Then
                                moves = moves & x & "," & i & ",1,"
                                count = count + 1
                            End If
                        Else
                            If board.isBlack(boardinfo(x, i)) Then
                                moves = moves & x & "," & i & ",1,"
                                count = count + 1
                            End If
                        End If
                        GoTo GETOUT9
                    End If
                Next

            End If

GETOUT9:
            moves = count & "," & moves
            Return moves
        Catch ex As Exception
            MsgBox(ex.Message)
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
