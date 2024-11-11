<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RescateMarino
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox6 = New PictureBox()
        PictureBox7 = New PictureBox()
        PictureBox10 = New PictureBox()
        lbl_time = New Label()
        PictureBox11 = New PictureBox()
        tmr_game = New Timer(components)
        tmr_speedboat = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.fuel_sprite
        PictureBox1.Location = New Point(23, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(80, 80)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.heart_sprite
        PictureBox2.Location = New Point(1729, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(47, 49)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = My.Resources.Resources.heart_sprite
        PictureBox3.Location = New Point(1676, 12)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(47, 49)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = My.Resources.Resources.heart_sprite
        PictureBox4.Location = New Point(1570, 12)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(47, 49)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 4
        PictureBox4.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources.heart_sprite
        PictureBox5.Location = New Point(1623, 12)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(47, 49)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 3
        PictureBox5.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox6.BackColor = Color.Transparent
        PictureBox6.Image = My.Resources.Resources.heart_sprite
        PictureBox6.Location = New Point(1517, 12)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(47, 49)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 5
        PictureBox6.TabStop = False
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackColor = Color.Transparent
        PictureBox7.Image = My.Resources.Resources.shark_sprite_3
        PictureBox7.Location = New Point(160, 182)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(85, 85)
        PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox7.TabIndex = 6
        PictureBox7.TabStop = False
        ' 
        ' PictureBox10
        ' 
        PictureBox10.Anchor = AnchorStyles.Top
        PictureBox10.BackColor = Color.Transparent
        PictureBox10.Image = My.Resources.Resources.clock_sprite
        PictureBox10.Location = New Point(755, 12)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New Size(101, 76)
        PictureBox10.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox10.TabIndex = 9
        PictureBox10.TabStop = False
        ' 
        ' lbl_time
        ' 
        lbl_time.AutoSize = True
        lbl_time.BackColor = Color.Transparent
        lbl_time.Font = New Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_time.ForeColor = Color.Black
        lbl_time.Location = New Point(862, 28)
        lbl_time.Name = "lbl_time"
        lbl_time.Size = New Size(94, 45)
        lbl_time.TabIndex = 10
        lbl_time.Text = "5:00"
        ' 
        ' PictureBox11
        ' 
        PictureBox11.BackColor = Color.Transparent
        PictureBox11.Image = My.Resources.Resources.raft_sprite
        PictureBox11.Location = New Point(241, 179)
        PictureBox11.Name = "PictureBox11"
        PictureBox11.Size = New Size(86, 88)
        PictureBox11.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox11.TabIndex = 11
        PictureBox11.TabStop = False
        ' 
        ' tmr_game
        ' 
        ' 
        ' tmr_speedboat
        ' 
        tmr_speedboat.Interval = 10
        ' 
        ' RescateMarino
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.sea_sprite_4
        ClientSize = New Size(1778, 1244)
        Controls.Add(PictureBox11)
        Controls.Add(lbl_time)
        Controls.Add(PictureBox10)
        Controls.Add(PictureBox7)
        Controls.Add(PictureBox6)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        DoubleBuffered = True
        Name = "RescateMarino"
        Text = "Rescate Marino"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox11, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents lbl_time As Label
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents tmr_game As Timer
    Friend WithEvents tmr_speedboat As Timer

End Class
