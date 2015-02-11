<Serializable()> Public Class Savedata
    Public p_i(,) As Char
    Public c_p As ArrayList
    Public blackPieceCaptured As Integer = 0
    Public whitePieceCaptured As Integer = 0
    Public playerturn As Boolean
    Public check As Boolean

    Public Sub New(ByVal p(,) As Char, ByVal c_p As ArrayList, ByVal blp As Integer, ByVal wpc As Integer, ByVal pt As Boolean, ByVal check As Boolean)
        Me.p_i = p
        Me.c_p = c_p
        Me.blackPieceCaptured = blp
        Me.whitePieceCaptured = wpc
        Me.check = check
    End Sub
End Class
