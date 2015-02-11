Public Class Queen
    Inherits Piece
 Public QueenCount(1, 2) As Integer
    Dim board As New ChessBoard
    Public Sub New()
        MyBase.SetPieceStatus(False)

    End Sub
    Public Sub setLocation(ByVal X As Integer, ByVal Y As Integer)
        QueenCount(0, 0) = X
        QueenCount(0, 1) = Y
    End Sub
    Public Function getLocation() As String
        Dim location As String = ""
        location = location & QueenCount(0, 0) & ","
        location = location & QueenCount(0, 1)
        Return location
    End Function
    Public Sub initQueen(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        setLocation(X, Y)
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
                        GoTo GETOUT4
                    End If
                Next

            End If
GETOUT4:

            'Checking moves at UP Diagnal LEFT
            'check while x,y is not on corner of board
            If y = 8 And x = 1 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                '  For i = x - 1 To 1
                i = x - 1
                For j = y + 1 To 8
                    If i > 0 And j < 9 Then
                        If boardinfo(i, j) = "o" Then
                            'allocating locations of possible moves
                            moves = moves & i & "," & j & ",0,"
                            count = count + 1
                        Else
                            'checking your team colour 1=white 0=black
                            'alphabet B for black and W for white
                            If colour = 0 Then
                                If Not board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            Else
                                If board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            End If
                            GoTo GETOUT6
                        End If
                        i = i - 1
                    End If
                Next

                '   Next

            End If
GETOUT6:



            'Checking moves at UP Diagnal RIGHT
            'check while x,y is not on corner of board
            If y = 8 And x = 8 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                ' For i = x + 1 To 8
                i = x + 1
                For j = y + 1 To 8
                    If i < 9 And j < 9 Then
                        If boardinfo(i, j) = "o" Then
                            'allocating locations of possible moves
                            moves = moves & i & "," & j & ",0,"
                            count = count + 1
                        Else
                            'checking your team colour 1=white 0=black
                            'alphabet B for black and W for white
                            If colour = 0 Then
                                If Not board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            Else
                                If board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            End If
                            GoTo GETOUT7
                        End If
                        i = i + 1
                    End If
                Next
                ' Next

            End If
GETOUT7:



            'Checking moves at DOWN Diagnal LEFT
            'check while x,y is not on corner of board
            If y = 1 And x = 1 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                '  For i = x - 1 To 1
                i = x - 1
                For j = y - 1 To 1 Step -1
                    If i >= 0 And j >= 0 Then
                        If boardinfo(i, j) = "o" Then
                            'allocating locations of possible moves
                            moves = moves & i & "," & j & ",0,"
                            count = count + 1
                        Else
                            'checking your team colour 1=white 0=black
                            'alphabet B for black and W for white
                            If colour = 0 Then
                                If Not board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            Else
                                If board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            End If
                            GoTo GETOUT8
                        End If
                        i = i - 1
                    End If
                Next
                '  Next

            End If
GETOUT8:


            'Checking moves at DOWN Diagnal RIGHT
            'check while x,y is not on corner of board
            If y = 1 And x = 8 Then
                'it is on corner, so no loop required :P
            Else

                'now looping to top while x=constant
                '    For i = x + 1 To 8
                i = x + 1
                For j = y - 1 To 1 Step -1
                    If i < 9 And j > 0 Then
                        If boardinfo(i, j) = "o" Then
                            'allocating locations of possible moves
                            moves = moves & i & "," & j & ",0,"
                            count = count + 1
                        Else
                            'checking your team colour 1=white 0=black
                            'alphabet B for black and W for white
                            If colour = 0 Then
                                If Not board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            Else
                                If board.isBlack(boardinfo(i, j)) Then
                                    moves = moves & i & "," & j & ",1,"
                                    count = count + 1
                                End If
                            End If
                            GoTo GETOUT9
                        End If
                        i = i + 1
                    End If
                Next
                '  Next

            End If
GETOUT9:

            'As so far the possible moves for queen has been finished
            'now going to return the respected string
            'returning string
            'moves = count & "," & moves
            'MsgBox(count & "," & moves)
            Return count & "," & moves
        Catch ex As Exception
            MsgBox("Error Queen Class:" & (ex.ToString))
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
