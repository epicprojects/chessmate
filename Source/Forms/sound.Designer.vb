<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sound
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.listn = New System.Windows.Forms.Button()
        Me.sett = New System.Windows.Forms.Button()
        Me.stp = New System.Windows.Forms.Button()
        Me.bck = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Items.AddRange(New Object() {"Track1", "Track2", "Track3", "Track4", "Track5", "Track6", "Track7", "Track8", "Track9", "Track10"})
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(65, 134)
        Me.ListBox1.TabIndex = 0
        '
        'listn
        '
        Me.listn.Location = New System.Drawing.Point(98, 25)
        Me.listn.Name = "listn"
        Me.listn.Size = New System.Drawing.Size(46, 23)
        Me.listn.TabIndex = 1
        Me.listn.Text = "Listen"
        Me.listn.UseVisualStyleBackColor = True
        '
        'sett
        '
        Me.sett.Location = New System.Drawing.Point(98, 119)
        Me.sett.Name = "sett"
        Me.sett.Size = New System.Drawing.Size(46, 23)
        Me.sett.TabIndex = 1
        Me.sett.Text = "Set"
        Me.sett.UseVisualStyleBackColor = True
        '
        'stp
        '
        Me.stp.Location = New System.Drawing.Point(98, 72)
        Me.stp.Name = "stp"
        Me.stp.Size = New System.Drawing.Size(46, 23)
        Me.stp.TabIndex = 1
        Me.stp.Text = "Stop"
        Me.stp.UseVisualStyleBackColor = True
        '
        'bck
        '
        Me.bck.Location = New System.Drawing.Point(21, 163)
        Me.bck.Name = "bck"
        Me.bck.Size = New System.Drawing.Size(123, 29)
        Me.bck.TabIndex = 1
        Me.bck.Text = "Back"
        Me.bck.UseVisualStyleBackColor = True
        '
        'sound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(160, 218)
        Me.Controls.Add(Me.bck)
        Me.Controls.Add(Me.sett)
        Me.Controls.Add(Me.stp)
        Me.Controls.Add(Me.listn)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "sound"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Select Sound"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents listn As System.Windows.Forms.Button
    Friend WithEvents sett As System.Windows.Forms.Button
    Friend WithEvents stp As System.Windows.Forms.Button
    Friend WithEvents bck As System.Windows.Forms.Button
End Class
