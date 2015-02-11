
Public Class Knight
    Inherits Piece
    Dim board As New ChessBoard
    Public KnightCount(2, 2) As Integer
    Public posmovarray(8, 8) As Integer

    Public Sub New()

        MyBase.SetPieceStatus(False)

    End Sub
    Public Function getLocation(ByVal KnightNo As Integer)
        Dim location As String = ""
        location = location & KnightCount(KnightNo, 0) & ","
        location = location & KnightCount(KnightNo, 1)
        Return location
    End Function
    Public Sub setLocation(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)
        KnightCount(IndexNUmber, 0) = X
        KnightCount(IndexNUmber, 1) = Y
    End Sub

    Public Function getIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        For i As Integer = 0 To 1
            If KnightCount(i, 0) = x And KnightCount(i, 1) = y Then
                Return i
            End If
        Next
    End Function

    Public Sub initKnight(ByVal IndexNUmber As Integer, ByVal X As Integer, ByVal Y As Integer)

        setLocation(IndexNUmber, X, Y)

    End Sub

   Public Function getPossibleMoves(ByVal x As Integer, ByVal y As Integer)
        Try
            Dim moves As String
            Dim count As Integer = 0
            Dim white As Boolean = Char.IsLower(Player.piece_info(x, y))

            If Not (x = 1) AndAlso y < 7 Then
                If Player.matchcolor(x - 1, y + 2, white) = 1 Or Player.piece_info(x - 1, y + 2) = "o" Then
                    Me.posmovarray(x - 1, y + 2) = 1
                    count = count + 1
                    moves = moves & "," & x - 1 & "," & y + 2 & "," & Player.matchcolor(x - 1, y + 2, white)
                End If
            End If

            If x > 2 AndAlso Not (y = 8) Then
                If Player.matchcolor(x - 2, y + 1, white) = 1 Or Player.piece_info(x - 2, y + 1) = "o" Then
                    Me.posmovarray(x - 2, y + 1) = 1
                    count = count + 1
                    moves = moves & "," & x - 2 & "," & y + 1 & "," & Player.matchcolor(x - 2, y + 1, white)
                End If
            End If

            If Not (x = 8) AndAlso y < 7 Then
                If Player.matchcolor(x + 1, y + 2, white) = 1 Or Player.piece_info(x + 1, y + 2) = "o" Then
                    Me.posmovarray(x + 1, y + 2) = 1
                    count = count + 1
                    moves = moves & "," & x + 1 & "," & y + 2 & "," & Player.matchcolor(x + 1, y + 2, white)
                End If
            End If

            If x < 7 AndAlso Not (y = 8) Then
                If Player.matchcolor(x + 2, y + 1, white) = 1 Or Player.piece_info(x + 2, y + 1) = "o" Then
                    Me.posmovarray(x + 2, y + 1) = 1
                    count = count + 1
                    moves = moves & "," & x + 2 & "," & y + 1 & "," & Player.matchcolor(x + 2, y + 1, white)
                End If
            End If

            If Not (x = 1) AndAlso y > 2 Then
                If Player.matchcolor(x - 1, y - 2, white) = 1 Or Player.piece_info(x - 1, y - 2) = "o" Then
                    Me.posmovarray(x - 1, y - 2) = 1
                    count = count + 1
                    moves = moves & "," & x - 1 & "," & y - 2 & "," & Player.matchcolor(x - 1, y - 2, white)
                End If
            End If

            If x > 2 AndAlso Not (y = 1) Then
                If Player.matchcolor(x - 2, y - 1, white) = 1 Or Player.piece_info(x - 2, y - 1) = "o" Then
                    Me.posmovarray(x - 2, y - 1) = 1
                    count = count + 1
                    moves = moves & "," & x - 2 & "," & y - 1 & "," & Player.matchcolor(x - 2, y - 1, white)
                End If
            End If

            If x <= 5 AndAlso Not (y = 1) Then
                If Player.matchcolor(x + 2, y - 1, white) = 1 Or Player.piece_info(x + 2, y - 1) = "o" Then
                    Me.posmovarray(x + 2, y - 1) = 1
                    count = count + 1
                    moves = moves & "," & x + 2 & "," & y - 1 & "," & Player.matchcolor(x + 2, y - 1, white)
                End If
            End If

            If Not (x = 6) AndAlso y > 2 Then
                If (x < 8) Then
                    If Player.matchcolor(x + 1, y - 2, white) = 1 Or Player.piece_info(x + 1, y - 2) = "o" Then
                        Me.posmovarray(x + 1, y - 2) = 1
                        count = count + 1
                        moves = moves & "," & x + 1 & "," & y - 2 & "," & Player.matchcolor(x + 1, y - 2, white)
                    End If
                End If
            End If

            For index1 As Integer = 1 To 8
                For index2 As Integer = 1 To 8
                    If Not (Me.posmovarray(index1, index2) = 1) Then
                        Me.posmovarray(index1, index2) = 0
                    End If
                Next
            Next
            '   MsgBox(count & moves)
            Return count & moves
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
