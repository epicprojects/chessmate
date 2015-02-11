Public Class Class1
    '------------------Text From Get aul possible moves--------------------------
    '    Dim str() As String
    '    Dim PossibleMovesOnBoard(,) As Integer
    '    Dim insight() As Integer
    '    Dim TotalPossibleMoves As Integer
    '    Dim info(8, 8) As String
    '    Dim i, j, k, sight As Integer
    '            For j = 1 To 8
    '                For i = 1 To 8
    '                    info(j, i) = "o"
    '                Next
    '            Next
    '            info(7, 7) = "b"
    '            info(4, 1) = "w"
    '            str = Split(getBishopMoves(1, 1, 4, 1, info), ",")
    '            TotalPossibleMoves = str(0)
    '            k = 1
    '            ReDim Moves(TotalPossibleMoves)
    '            For i = 1 To TotalPossibleMoves * 3
    '                Moves(i).X = str(k)
    '                k += 1
    '                Moves(i).Y = str(k)
    '                k += 1
    '                Moves(i).insight = str(k)
    '            Next
    '    MsgBox(TotalPossibleMoves)
    '    k = 1
    '    sight = 0
    '    For i = 0 To 8
    '        For j = 0 To 1
    '            If k Mod 3 = 0 Then
    '                insight(sight) = str(k)
    '            Else
    '                PossibleMovesOnBoard(i, j) = str(k)
    '            End If
    '            sight += 1
    '            k += 1
    '        Next
    '    Next

    '    For i = 1 To TotalPossibleMoves * 3
    '    Dim x As Integer = i
    '        i += 1
    '        SquareBox(str(x), str(i)).BackColor = Color.Aqua
    '        i += 1
    '    Next
    '------------------Text From Get aul possible moves--------------------------
End Class
