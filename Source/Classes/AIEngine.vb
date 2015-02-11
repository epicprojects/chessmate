Public Class AIEngine

    Dim AIPlayer As Player
    Dim opponent As Player
    Dim board As ChessBoard
    Dim hits(8, 8) As String
    Dim mymoves(8, 8) As String
    Shared IsItMyTurn As Boolean = False
    Public Function IsLegalMove(ByVal SX, ByVal SY, ByVal EX, ByVal EY) As Boolean
        Dim piece As Char
        Dim str() As String
        Dim pawnMoves As New Pawn
        Dim rookMoves As New Rook
        Dim KnightMoves As New Knight
        Dim bishopMoves As New Bishop
        Dim kingMoves As New King
        Dim queenMoves As New Queen
        Dim TotalPossibleMoves As Integer
        piece = Player.piece_info(SX, SY)
        Select Case Char.ToLower(piece)
            Case "p"
                str = Split(pawnMoves.getPossibleMoves(SX, SY), ",")
            Case "r"
                str = Split(rookMoves.getPossibleMoves(SX, SY, 0, board.BlackPlayer.piece_info), ",")
            Case "n"
                str = Split(KnightMoves.getPossibleMoves(SX, SY), ",")
            Case "b"
                str = Split(bishopMoves.getPossibleMoves(SX, SY, 0, board.BlackPlayer.piece_info), ",")
            Case "k"
                str = Split(kingMoves.getPossibleMoves(SX, SY, 0, board.BlackPlayer.piece_info), ",")
            Case "q"
                str = Split(queenMoves.getPossibleMoves(SX, SY, 0, board.BlackPlayer.piece_info), ",")
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
    End Function
    Public Sub New(ByVal AIPlayer As Player, ByVal opponent As Player)
        Me.AIPlayer = AIPlayer
        Me.opponent = opponent
    End Sub

    Public Sub gethits()
        getthisplayermoves(hits, opponent)
    End Sub

    Public Sub getMyMoves()
        getthisplayermoves(mymoves, AIPlayer)
    End Sub

    Public Sub getthisplayermoves(ByRef mov(,) As String, ByVal player As Player)

        Dim str() As String
        Dim c As Char
        For i As Integer = 1 To 8
            For j As Integer = 1 To 8
                mov(i, j) = "o"
            Next
        Next

        For x As Integer = 1 To 8
            For y As Integer = 1 To 8

                c = player.piece_info(x, y)

                If c = "o" Then
                    Continue For
                End If

                Select Case Char.ToLower(c)
                    Case "p"
                        str = Split(opponent.pawns.getPossibleMoves(x, y), ",")
                    Case "r"
                        str = Split(opponent.rooks.getPossibleMoves(x, y, 1, player.piece_info), ",")
                    Case "n"
                        str = Split(opponent.knights.getPossibleMoves(x, y), ",")
                    Case "b"
                        str = Split(opponent.bishops.getPossibleMoves(x, y, 1, player.piece_info), ",")
                    Case "k"
                        str = Split(opponent.king.getPossibleMoves(x, y, 1, player.piece_info), ",")
                    Case "q"
                        str = Split(opponent.queen.getPossibleMoves(x, y, 1, player.piece_info), ",")
                End Select

                Calc_HitsByPiece(mov, str, c, x, y)

            Next
        Next
    End Sub

    Public Sub Calc_HitsByPiece(ByRef mov(,) As String, ByRef str() As String, ByVal c As Char, ByVal x As Integer, ByVal y As Integer)
        For i As Integer = 1 To str.Length - 3 Step 3
            mov(Convert.ToInt32(str(i)), Convert.ToInt32(str(i + 1))) &= "," & c & "," & x & "," & y
        Next
    End Sub
    Public Function AiKingCheck() As Boolean
        If board.isUnderCheck(0) Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function AiKingCheckMate() As Boolean
        If AiKingCheck() = True Then
            If board.IsCheckmate Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
    Public Sub evadecheck()
        If AiKingCheck() Then

        End If
    End Sub

    Public Function isthreat(ByVal x As Integer, ByVal y As Integer)
        gethits()
        If hits(x, y) = "o" Then
            Return False
        Else
            Return True
        End If
    End Function

End Class
