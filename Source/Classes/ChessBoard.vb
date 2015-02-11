Public Class ChessBoard
    Public Shared WhitePlayer As Player
    Public Shared BlackPlayer As Player
    Public Shared undercheck As Boolean = False
    Public Shared checkmate As Boolean = False
    Public Shared Checkmate_Calc As Boolean = False
    Public Structure PossibleMoves
        Dim X As Integer
        Dim Y As Integer
        Dim insight As Integer
    End Structure
    Public Shared PSX As Integer
    Public Shared PSY As Integer
    Public Shared PEX As Integer
    Public Shared PEY As Integer
    Public Moves(30) As PossibleMoves
    Public Function GetBoardInfo()

    End Function
    Public Function isUnderCheck(ByVal color As Integer) As Boolean
        Try

            Dim VictumPlayer As Player
            Dim AttackerPlayer As Player
            Dim KingLocation() As String
            Dim attackerMoves() As String
            Dim attackerLocation() As String
            Dim i As Integer = 0
            Dim TotalPossibleMoves As Integer
            Dim AttackerColor As Integer
            Dim SX As Integer

            If color = 1 Then
                VictumPlayer = WhitePlayer
                AttackerPlayer = BlackPlayer
                AttackerColor = (0)
            Else
                VictumPlayer = BlackPlayer
                AttackerPlayer = WhitePlayer
                AttackerColor = (1)
            End If
            undercheck = False
            KingLocation = Split(VictumPlayer.king.getLocation, ",")

            ' checking one piece at a time wthr enemy king is in its range r not
            ' if enemy king is in range than undercheck var will b true


            ''''''''''''''''''''''''''''''''PAWN MOVES '''''''''''''''''''''''''''''''''''''''''''

            For i = 0 To 7
                attackerLocation = Split(AttackerPlayer.pawns.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.pawns.getPossibleMoves(attackerLocation(0), attackerLocation(1)), ",")
                If attackerMoves(0) = "" Then
                    Continue For
                End If
                TotalPossibleMoves = attackerMoves(0)

                For j = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = j
                    j += 1
                    If attackerMoves(x) = KingLocation(0) And attackerMoves(j) = KingLocation(1) Then
                        undercheck = True
                    End If
                    j += 1
                Next
            Next

            ''''''''''''''''''''''''''''''Knight Moves'''''''''''''''''''''''''''''''''''''''''''''

            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.knights.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.knights.getPossibleMoves(attackerLocation(0), attackerLocation(1)), ",")
                TotalPossibleMoves = attackerMoves(0)
                For j = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = j
                    j += 1
                    If attackerMoves(x) = KingLocation(0) And attackerMoves(j) = KingLocation(1) Then
                        undercheck = True
                    End If
                    j += 1
                Next
            Next

            '''''''''''''''''''''''''''''''BISHOP MOVES''''''''''''''''''''''''''''''''''''''''''''''
            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.bishops.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.bishops.getPossibleMoves(attackerLocation(0), attackerLocation(1), AttackerColor, AttackerPlayer.piece_info), ",")
                
                TotalPossibleMoves = attackerMoves(0)
                For j = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = j
                    j += 1
                    If attackerMoves(x) = KingLocation(0) And attackerMoves(j) = KingLocation(1) Then
                        undercheck = True
                    End If
                    j += 1
                Next
            Next
            '''''''''''''''''''''''''''''''QUEEN MOVES''''''''''''''''''''''''''''''''''''''''''''''
            attackerLocation = Split(AttackerPlayer.queen.getLocation(), ",")
            attackerMoves = Split(AttackerPlayer.queen.getPossibleMoves(attackerLocation(0), attackerLocation(1), AttackerColor, AttackerPlayer.piece_info), ",")
            TotalPossibleMoves = attackerMoves(0)
            For j = 1 To (TotalPossibleMoves * 3)
                Dim x As Integer = j
                j += 1
                If attackerMoves(x) = KingLocation(0) And attackerMoves(j) = KingLocation(1) Then
                    undercheck = True
                End If
                j += 1
            Next
            ''''''''''''''''''''''''''''''''''''''ROOK MOVES'''''''''''''''''''''''''''''''''''''''''''''
            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.rooks.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.rooks.getPossibleMoves(attackerLocation(0), attackerLocation(1), AttackerColor, AttackerPlayer.piece_info), ",")
                TotalPossibleMoves = attackerMoves(0)
                For j = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = j
                    j += 1
                    If attackerMoves(x) = KingLocation(0) And attackerMoves(j) = KingLocation(1) Then
                        undercheck = True
                    End If
                    j += 1
                Next
            Next

            Return undercheck
        Catch ex As Exception
            MsgBox("Error Chessboard_Undercheck" & ex.Message)
        End Try
    End Function
    Function isBlack(ByVal Piece As Char) As Boolean
        Try
            Dim p As Integer
            p = Convert.ToInt32(Piece)
            If (p > 64 And p < 83) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Public Function isPlayerUndercheck()

    End Function
    Public Function isItTimeToChange(ByVal EY As Integer, ByVal PlayerTurn As Boolean) As Boolean
        If Not Checkmate_Calc Then
            If EY = 8 Then
                MsgBox("Your Pawn Reached to Enemy base Click ok and select piece you want to replace with your Pawn")
                cnv.Show()
                Return True
            ElseIf EY = 1 Then
                MsgBox("Your Pawn Reached to Enemy base Click ok and select piece you want to replace with your Pawn")
                cnv.Show()
                Return True
            End If
        End If
        Return False
    End Function
    Public Function IsCheckmate() As Boolean
        Try
            Checkmate_Calc = True
            ' Dim str() As String
            Dim plr As Player
            Dim ObjPawn As New Pawn
            Dim ObjRook As New Rook
            Dim ObjKnight As New Knight
            Dim ObjBishop As New Bishop
            Dim Objking As New King
            Dim ObjQueen As New Queen
            Dim playerColor As Integer
            Dim SX As Integer
            Dim SY As Integer
            Dim k As Integer = 0
            Dim EX As Integer
            Dim EY As Integer
            Dim i As Integer = 0
            Dim VictumPlayer As Player
            Dim AttackerPlayer As Player
            Dim KingLocation() As String
            Dim attackerMoves() As String
            Dim attackerLocation() As String
            Dim TotalPossibleMoves As Integer

            frmMain.BackupDatabase()   '''''''taking backup of Piece_info

            If (frmMain.getPlayerTurn) Then
                AttackerPlayer = WhitePlayer
                playerColor = 1
            Else
                AttackerPlayer = BlackPlayer
                playerColor = 0
            End If


            '''''''''''''''''''''''Calculating All pawn moves to check whthr player can get rid from undercheck
            ''''''''''''''''''''''' if not thn player wil lose his\her game'''''''''''''''''''''''''''''''''''''''
            For i = 0 To 7
                attackerLocation = Split(AttackerPlayer.pawns.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.pawns.getPossibleMoves(attackerLocation(0), attackerLocation(1)), ",")

                SX = attackerLocation(0)
                SY = attackerLocation(1)

                If attackerMoves(0) = "" Then
                    Continue For
                End If
                '-----------------------
                TotalPossibleMoves = attackerMoves(0)
                ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
                k = 0
                For m = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = m
                    m += 1

                    frmMain.PossibleMoves(k).X = attackerMoves(x)
                    frmMain.PossibleMoves(k).Y = attackerMoves(m)
                    m += 1
                    frmMain.PossibleMoves(k).insight = attackerMoves(m)
                    k += 1
                Next
                '-----------------------
                '    TotalPossibleMoves = attackerMoves(0)

                For j = 1 To (TotalPossibleMoves * 3)
                    Dim Temp As Integer = j
                    j += 1
                    AttackerPlayer.updatepiece("P", SX, SY, attackerMoves(Temp), attackerMoves(j))
                    ' SX = attackerMoves(EX)
                    'SY = attackerMoves(j)
                    j += 1
                    If Not isUnderCheck(playerColor) Then
                        frmMain.RestoreDatabase()
                        Return False
                    End If
                Next
            Next
            ''''''''''''Moves checking for knight'''''''''''''''''''''''''
            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.knights.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.knights.getPossibleMoves(attackerLocation(0), attackerLocation(1)), ",")

                SX = attackerLocation(0)
                SY = attackerLocation(1)

                If attackerMoves(0) = "" Then
                    Continue For
                End If
                '-----------------------
                TotalPossibleMoves = attackerMoves(0)
                ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
                k = 0
                For m = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = m
                    m += 1

                    frmMain.PossibleMoves(k).X = attackerMoves(x)
                    frmMain.PossibleMoves(k).Y = attackerMoves(m)
                    m += 1
                    frmMain.PossibleMoves(k).insight = attackerMoves(m)
                    k += 1
                Next
                '-----------------------
                '    TotalPossibleMoves = attackerMoves(0)

                For j = 1 To (TotalPossibleMoves * 3)
                    Dim Temp As Integer = j
                    j += 1
                    AttackerPlayer.updatepiece("k", SX, SY, attackerMoves(Temp), attackerMoves(j))
                    ' SX = attackerMoves(EX)
                    'SY = attackerMoves(j)
                    j += 1
                    If Not isUnderCheck(playerColor) Then
                        frmMain.RestoreDatabase()
                        Return False
                    End If
                Next
            Next

            ''''''''''''''''''''''''''''''''''''''''''Bishop'''''''''''''''''''''''''''''''''''''''''''''''
            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.bishops.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.bishops.getPossibleMoves(attackerLocation(0), attackerLocation(1), playerColor, BlackPlayer.piece_info), ",")

                SX = attackerLocation(0)
                SY = attackerLocation(1)

                If attackerMoves(0) = "" Then
                    Continue For
                End If
                '-----------------------
                TotalPossibleMoves = attackerMoves(0)
                ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
                k = 0
                For m = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = m
                    m += 1

                    frmMain.PossibleMoves(k).X = attackerMoves(x)
                    frmMain.PossibleMoves(k).Y = attackerMoves(m)
                    m += 1
                    frmMain.PossibleMoves(k).insight = attackerMoves(m)
                    k += 1
                Next
                '-----------------------
                '    TotalPossibleMoves = attackerMoves(0)

                For j = 1 To (TotalPossibleMoves * 3)
                    Dim Temp As Integer = j
                    j += 1
                    AttackerPlayer.updatepiece("b", SX, SY, attackerMoves(Temp), attackerMoves(j))
                    ' SX = attackerMoves(EX)
                    'SY = attackerMoves(j)
                    j += 1
                    If Not isUnderCheck(playerColor) Then
                        frmMain.RestoreDatabase()
                        Return False
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''Rook''''''''''''''''''''''''''''''''''''''''''''''''
            For i = 0 To 1
                attackerLocation = Split(AttackerPlayer.rooks.getLocation(i), ",")
                attackerMoves = Split(AttackerPlayer.rooks.getPossibleMoves(attackerLocation(0), attackerLocation(1), playerColor, BlackPlayer.piece_info), ",")

                SX = attackerLocation(0)
                SY = attackerLocation(1)

                If attackerMoves(0) = "" Then
                    Continue For
                End If
                '-----------------------
                TotalPossibleMoves = attackerMoves(0)
                ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
                k = 0
                For m = 1 To (TotalPossibleMoves * 3)
                    Dim x As Integer = m
                    m += 1

                    frmMain.PossibleMoves(k).X = attackerMoves(x)
                    frmMain.PossibleMoves(k).Y = attackerMoves(m)
                    m += 1
                    frmMain.PossibleMoves(k).insight = attackerMoves(m)
                    k += 1
                Next
                '-----------------------
                '    TotalPossibleMoves = attackerMoves(0)

                For j = 1 To (TotalPossibleMoves * 3)
                    Dim Temp As Integer = j
                    j += 1
                    AttackerPlayer.updatepiece("r", SX, SY, attackerMoves(Temp), attackerMoves(j))
                    ' SX = attackerMoves(EX)
                    'SY = attackerMoves(j)
                    j += 1
                    If Not isUnderCheck(playerColor) Then
                        frmMain.RestoreDatabase()
                        Return False
                    End If
                Next
            Next
            ''''''''''''''''''''''''''''''''''''''Queen''''''''''''''''''''''''''''''''''''''''''''''
            '  For i = 0 To 1
            i = 0
            attackerLocation = Split(AttackerPlayer.queen.getLocation(), ",")
            attackerMoves = Split(AttackerPlayer.queen.getPossibleMoves(attackerLocation(0), attackerLocation(1), playerColor, BlackPlayer.piece_info), ",")

            SX = attackerLocation(0)
            SY = attackerLocation(1)

            'If attackerMoves(0) = "" Then
            '    Continue For
            'End If
            '-----------------------
            TotalPossibleMoves = attackerMoves(0)
            ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
            k = 0
            For m = 1 To (TotalPossibleMoves * 3)
                Dim x As Integer = m
                m += 1

                frmMain.PossibleMoves(k).X = attackerMoves(x)
                frmMain.PossibleMoves(k).Y = attackerMoves(m)
                m += 1
                frmMain.PossibleMoves(k).insight = attackerMoves(m)
                k += 1
            Next
            '-----------------------
            '    TotalPossibleMoves = attackerMoves(0)

            For j = 1 To (TotalPossibleMoves * 3)
                Dim Temp As Integer = j
                j += 1
                AttackerPlayer.updatepiece("q", SX, SY, attackerMoves(Temp), attackerMoves(j))
                ' SX = attackerMoves(EX)
                'SY = attackerMoves(j)
                j += 1
                If Not isUnderCheck(playerColor) Then
                    frmMain.RestoreDatabase()
                    Return False
                End If
            Next
            '  Next
            '''''''''''''''''''''''''''''''''''''''''''''''king''''''''''''''''''''''''''''''''''''''''''
            '  For i = 0 To 1
            i = 0
            attackerLocation = Split(AttackerPlayer.king.getLocation(), ",")
            attackerMoves = Split(AttackerPlayer.king.getPossibleMoves(attackerLocation(0), attackerLocation(1), playerColor, BlackPlayer.piece_info), ",")

            SX = attackerLocation(0)
            SY = attackerLocation(1)

            'If attackerMoves(0) = "" Then
            '    Continue For
            'End If
            '-----------------------
            TotalPossibleMoves = attackerMoves(0)
            ReDim frmMain.PossibleMoves(TotalPossibleMoves - 1)
            k = 0
            For m = 1 To (TotalPossibleMoves * 3)
                Dim x As Integer = m
                m += 1

                frmMain.PossibleMoves(k).X = attackerMoves(x)
                frmMain.PossibleMoves(k).Y = attackerMoves(m)
                m += 1
                frmMain.PossibleMoves(k).insight = attackerMoves(m)
                k += 1
            Next
            '-----------------------
            '    TotalPossibleMoves = attackerMoves(0)

            For j = 1 To (TotalPossibleMoves * 3)
                Dim Temp As Integer = j
                j += 1
                AttackerPlayer.updatepiece("k", SX, SY, attackerMoves(Temp), attackerMoves(j))
                ' SX = attackerMoves(EX)
                'SY = attackerMoves(j)
                j += 1
                If Not isUnderCheck(playerColor) Then
                    frmMain.RestoreDatabase()
                    Return False
                End If
            Next
            ' Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            frmMain.RestoreDatabase() ''''''''Restoring backup to Piece_info
            Checkmate_Calc = False
            Return True
        Catch ex As Exception
            MsgBox("Checkmate Error : " + ex.Message)
        End Try
    End Function
End Class
