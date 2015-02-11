Option Explicit On
Option Strict On
Module modPublic

    Public MainAppThread As System.Threading.Thread

    'Values used in generating a Zobrist hash
    Public AnalysisHashKeys(,,) As Integer
    Public WhiteAndBlackCanBothCastleBothSides As Integer = 343
    Public WhiteCanCastleKingSideBlackBothSides As Integer = 445
    Public WhiteCanCastleQueenSideBlackBothSides As Integer = 1902
    Public WhiteCanCastleQueenSideBlackKingSide As Integer = 9282
    Public WhiteCantCastleBlackBothSides As Integer = 777
    Public WhiteCantCastleBlackKingSideOnly As Integer = 645344
    Public WhiteCantCastleBlackQueenSideOnly As Integer = 345981
    Public WhiteAndBlackCanCastleKingSideOnly As Integer = 81121
    Public WhiteAndBlackCanCastleQueenSideOnly As Integer = 64124
    Public WhiteBothSidesBlackKingSideOnly As Integer = 11113
    Public WhiteBothSidesBlackQueenSideOnly As Integer = 40907
    Public WhiteBothSidesBlackCant As Integer = 999900
    Public WhiteKingSideBlackQueenSide As Integer = 321112
    Public WhiteKingSideBlackCant As Integer = 4565
    Public WhiteQueenSideBlackCant As Integer = 7119
    Public WhiteCantBlackCant As Integer = 2221134
    Public BlackToMoveHash As Integer = 282

    Sub Main()

        InitiateHashValues()

        MainAppThread = New System.Threading.Thread(AddressOf Start)
        MainAppThread.SetApartmentState(Threading.ApartmentState.STA)
        MainAppThread.Start()
        MainAppThread.Priority = Threading.ThreadPriority.Highest

    End Sub

    Sub Start()

        Dim TheForm As New frmMain
        frmMain.ShowDialog()

    End Sub

    Public Function GetColumnByX(ByVal X As Integer) As String

        If X = 1 Then
            Return "a"
        ElseIf X = 2 Then
            Return "b"
        ElseIf X = 3 Then
            Return "c"
        ElseIf X = 4 Then
            Return "d"
        ElseIf X = 5 Then
            Return "e"
        ElseIf X = 6 Then
            Return "f"
        ElseIf X = 7 Then
            Return "g"
        ElseIf X = 8 Then
            Return "h"
        End If

        Return "ERR"

    End Function

    Public Function GetXByColumn(ByVal Col As String) As Integer

        Select Case LCase(Col)
            Case "a"
                Return 1
            Case "b"
                Return 2
            Case "c"
                Return 3
            Case "d"
                Return 4
            Case "e"
                Return 5
            Case "f"
                Return 6
            Case "g"
                Return 7
            Case "h"
                Return 8
        End Select

        Return -1

    End Function

    Public Sub InitiateHashValues()

        ReDim AnalysisHashKeys(8, 8, 12)

        For XX As Integer = 1 To 8
            For YY As Integer = 1 To 8
                For PP As Integer = 1 To 12
                    Do
                        AnalysisHashKeys(XX, YY, PP) = CInt(Int(Rnd() * 2000000000))
                    Loop Until (AnalysisHashKeys(XX, YY, PP) <> WhiteAndBlackCanBothCastleBothSides) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCanCastleKingSideBlackBothSides) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCanCastleQueenSideBlackBothSides) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCantCastleBlackBothSides) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteAndBlackCanCastleKingSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteAndBlackCanCastleQueenSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteBothSidesBlackKingSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteBothSidesBlackQueenSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCanCastleQueenSideBlackKingSide) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteBothSidesBlackCant) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCantCastleBlackKingSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCantCastleBlackQueenSideOnly) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteCantBlackCant) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteQueenSideBlackCant) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteKingSideBlackCant) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> WhiteKingSideBlackQueenSide) AndAlso _
                        (AnalysisHashKeys(XX, YY, PP) <> BlackToMoveHash) AndAlso (AnalysisHashKeys(XX, YY, PP) > 500)
                Next
            Next
        Next

    End Sub

End Module
