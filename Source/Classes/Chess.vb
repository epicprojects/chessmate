Public Class Chess

    Dim Main As New frmMain
    Public Sub initNewGame()

    End Sub

    Public Function ResignGame()
        If MsgBox("Do You Want to Quit", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If MsgBox("Do You Want Save Game", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SaveGame()
            End If
            Main.Close()
        End If
    End Function

    Public Function SaveGame()

    End Function

    Public Function LoadGame()

    End Function

    Public Function ScoreCard()

    End Function

End Class
