Public Class Piece
    Private PlayerColor As Boolean
    Private X As Integer
    Private Y As Integer
    Private color As Integer
    Private isCapture As Boolean
    Public Sub SetPieceStatus(ByVal pieceStatus As Boolean)
        isCapture = pieceStatus
    End Sub
    Public Function getPieceStatus(ByVal taken As Boolean) As Boolean
        Return isCapture
    End Function
    Public Function GetPossibleMoves(ByVal X As Integer, ByVal Y As Integer, ByVal Type As Integer) As ArrayList
        Dim PossibleLocations As New ArrayList
        Select Case Type
            Case 0
                MsgBox("Pawn")
            Case 1
                MsgBox("Rook")
            Case 2
                MsgBox("Knight")
            Case 3
                MsgBox("Bishop")
            Case 4
                MsgBox("King")
            Case 5
                MsgBox("Queen")
        End Select

        Return PossibleLocations
    End Function
    Public Sub setPieceColor(ByVal color As Integer)
        Me.color = color
    End Sub
    Public Function getPieceColor() As Integer
        Return color
    End Function
    
End Class
