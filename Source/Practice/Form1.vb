Public Class Form1

  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim labels(8, 8) As Windows.Forms.Label
            Dim BoxSize As System.Drawing.Size
            BoxSize.Width = 15
            BoxSize.Height = 15
            Dim str As String
            Dim l As Integer = 0
            For i = 1 To 8
                For j = 1 To 8
                    Dim BoxLoc As System.Drawing.Point
                    BoxLoc.X = 32 * (i - 1) + 40
                    BoxLoc.Y = 32 * (9 - j - 1) + 43
                    ' With(labels(i),Windows.Forms.Label)
                    labels(i, j) = New Windows.Forms.Label
                    str = Convert.ToString(Player.piece_info(i, j))
                    labels(i, j).Name = "label_" + CStr(i) + "_" + CStr(j)
                    labels(i, j).Location = BoxLoc
                    labels(i, j).Size = BoxSize
                    labels(i, j).Text = str
                    GroupBox1.Controls.Add(labels(i, j))
                    'End With
                    ' l += 1
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class