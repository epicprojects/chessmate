
Public Class Bishop
    Inherits Piece
    Public BishopCount(2, 2) As Integer
    Dim board As New ChessBoard
    
    Public Sub New()

        MyBase.SetPieceStatus(False)

    End Sub
    Public Sub setLocation(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        BishopCount(IndexNUmber, 0) = X
        BishopCount(IndexNUmber, 1) = Y
    End Sub
    Public Function getIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        For i As Integer = 0 To 1
            If BishopCount(i, 0) = x And BishopCount(i, 1) = y Then
                Return i
            End If
        Next
    End Function
    Public Function getLocation(ByVal BishopNO As Integer) As String
        Dim location As String = ""
        location = location & BishopCount(BishopNO, 0) & ","
        location = location & BishopCount(BishopNO, 1)
        Return location
    End Function
    Public Sub initBishop(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        setLocation(IndexNUmber, X, Y)
    End Sub
    Public Function getPossibleMoves(ByVal x As Integer, ByVal y As Integer, ByVal colour As Integer, ByVal boardinfo(,) As Char)
        Try
            Dim moves As String
            Dim count As Integer
            Dim i, j As Integer
            count = 0
            'player selected Bishop

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
                    If i > 0 And j > 0 Then
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
