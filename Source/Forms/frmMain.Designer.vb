<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SavePositionToFENFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SavePositionToFENFileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoundsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.statBar = New System.Windows.Forms.StatusStrip()
        Me.infoText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.AITimer = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbNew = New System.Windows.Forms.ToolStripButton()
        Me.tbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbBack = New System.Windows.Forms.ToolStripButton()
        Me.tbForward = New System.Windows.Forms.ToolStripButton()
        Me.Saver = New System.Windows.Forms.SaveFileDialog()
        Me.Opener = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PlayerTurn = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.WhiteCaptured = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BlackCaptured = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.statBar.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(595, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ToolStripMenuItem2, Me.SavePositionToFENFileToolStripMenuItem, Me.SavePositionToFENFileToolStripMenuItem1, Me.ToolStripMenuItem4, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Image = Global.DotNetChess.My.Resources.Resources._1305377359_mail_new
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NewGameToolStripMenuItem.Text = "&New Game"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(131, 6)
        '
        'SavePositionToFENFileToolStripMenuItem
        '
        Me.SavePositionToFENFileToolStripMenuItem.Image = Global.DotNetChess.My.Resources.Resources._1305377080_Download
        Me.SavePositionToFENFileToolStripMenuItem.Name = "SavePositionToFENFileToolStripMenuItem"
        Me.SavePositionToFENFileToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SavePositionToFENFileToolStripMenuItem.Text = "Load Game"
        '
        'SavePositionToFENFileToolStripMenuItem1
        '
        Me.SavePositionToFENFileToolStripMenuItem1.Image = Global.DotNetChess.My.Resources.Resources._1305377221_download_box_blue
        Me.SavePositionToFENFileToolStripMenuItem1.Name = "SavePositionToFENFileToolStripMenuItem1"
        Me.SavePositionToFENFileToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.SavePositionToFENFileToolStripMenuItem1.Text = "Save Game"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(131, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = Global.DotNetChess.My.Resources.Resources.Shutdown
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SoundsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "O&ptions"
        '
        'SoundsToolStripMenuItem
        '
        Me.SoundsToolStripMenuItem.Image = Global.DotNetChess.My.Resources.Resources.Audio_Cd
        Me.SoundsToolStripMenuItem.Name = "SoundsToolStripMenuItem"
        Me.SoundsToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.SoundsToolStripMenuItem.Text = "Sounds"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutusToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutusToolStripMenuItem
        '
        Me.AboutusToolStripMenuItem.Name = "AboutusToolStripMenuItem"
        Me.AboutusToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AboutusToolStripMenuItem.Text = "About &us"
        '
        'statBar
        '
        Me.statBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.infoText})
        Me.statBar.Location = New System.Drawing.Point(0, 626)
        Me.statBar.Name = "statBar"
        Me.statBar.Size = New System.Drawing.Size(595, 22)
        Me.statBar.TabIndex = 2
        Me.statBar.Text = "gsfdgdfg"
        '
        'infoText
        '
        Me.infoText.Name = "infoText"
        Me.infoText.Size = New System.Drawing.Size(0, 17)
        '
        'AITimer
        '
        Me.AITimer.Enabled = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbNew, Me.tbOpen, Me.tbSave, Me.ToolStripSeparator1, Me.tbBack, Me.tbForward})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(595, 25)
        Me.ToolStrip1.TabIndex = 3
        '
        'tbNew
        '
        Me.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbNew.Image = Global.DotNetChess.My.Resources.Resources._1305377359_mail_new
        Me.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNew.Name = "tbNew"
        Me.tbNew.Size = New System.Drawing.Size(23, 22)
        Me.tbNew.Text = "ToolStripButton1"
        Me.tbNew.ToolTipText = "New Game"
        '
        'tbOpen
        '
        Me.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbOpen.Image = Global.DotNetChess.My.Resources.Resources._1305377308_folder_up
        Me.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbOpen.Name = "tbOpen"
        Me.tbOpen.Size = New System.Drawing.Size(23, 22)
        Me.tbOpen.Text = "Load Game"
        Me.tbOpen.ToolTipText = "Load Game"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Image = Global.DotNetChess.My.Resources.Resources._1305377129_Save
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(23, 22)
        Me.tbSave.Text = "Save Game"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tbBack
        '
        Me.tbBack.BackColor = System.Drawing.Color.Transparent
        Me.tbBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbBack.Image = Global.DotNetChess.My.Resources.Resources._1305378342_Gnome_Go_Previous_32
        Me.tbBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbBack.Name = "tbBack"
        Me.tbBack.Size = New System.Drawing.Size(23, 22)
        Me.tbBack.Text = "ToolStripButton1"
        Me.tbBack.ToolTipText = "Back One Move"
        '
        'tbForward
        '
        Me.tbForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbForward.Font = New System.Drawing.Font("Tahoma", 5.0!)
        Me.tbForward.Image = Global.DotNetChess.My.Resources.Resources._1305378539_gtk_go_back_rtl
        Me.tbForward.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbForward.Name = "tbForward"
        Me.tbForward.Size = New System.Drawing.Size(23, 22)
        Me.tbForward.Text = "Forward One Move"
        '
        'Opener
        '
        Me.Opener.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Location = New System.Drawing.Point(0, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(756, 622)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(427, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "IScheck"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PlayerTurn
        '
        Me.PlayerTurn.AutoSize = True
        Me.PlayerTurn.Font = New System.Drawing.Font("Impact", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerTurn.Location = New System.Drawing.Point(204, 27)
        Me.PlayerTurn.Name = "PlayerTurn"
        Me.PlayerTurn.Size = New System.Drawing.Size(127, 18)
        Me.PlayerTurn.TabIndex = 5
        Me.PlayerTurn.Text = "White Player  to Move"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(346, 24)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Form"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(508, 24)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(253, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "White Captured:"
        '
        'WhiteCaptured
        '
        Me.WhiteCaptured.AutoSize = True
        Me.WhiteCaptured.BackColor = System.Drawing.Color.Transparent
        Me.WhiteCaptured.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WhiteCaptured.ForeColor = System.Drawing.Color.Black
        Me.WhiteCaptured.Location = New System.Drawing.Point(354, 4)
        Me.WhiteCaptured.Name = "WhiteCaptured"
        Me.WhiteCaptured.Size = New System.Drawing.Size(19, 14)
        Me.WhiteCaptured.TabIndex = 9
        Me.WhiteCaptured.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(386, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 14)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Black Captured:"
        '
        'BlackCaptured
        '
        Me.BlackCaptured.AutoSize = True
        Me.BlackCaptured.BackColor = System.Drawing.Color.Transparent
        Me.BlackCaptured.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlackCaptured.ForeColor = System.Drawing.Color.Black
        Me.BlackCaptured.Location = New System.Drawing.Point(483, 4)
        Me.BlackCaptured.Name = "BlackCaptured"
        Me.BlackCaptured.Size = New System.Drawing.Size(19, 14)
        Me.BlackCaptured.TabIndex = 11
        Me.BlackCaptured.Text = "00"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(595, 648)
        Me.Controls.Add(Me.BlackCaptured)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.WhiteCaptured)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PlayerTurn)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.statBar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Intelligent Chess"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.statBar.ResumeLayout(False)
        Me.statBar.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents statBar As System.Windows.Forms.StatusStrip
    Friend WithEvents infoText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AITimer As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbForward As System.Windows.Forms.ToolStripButton
    Friend WithEvents Saver As System.Windows.Forms.SaveFileDialog
    Friend WithEvents NewGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SavePositionToFENFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SavePositionToFENFileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Opener As System.Windows.Forms.OpenFileDialog
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoundsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PlayerTurn As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WhiteCaptured As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BlackCaptured As System.Windows.Forms.Label

End Class
