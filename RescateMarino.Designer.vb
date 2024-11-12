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
        PictureBox10 = New PictureBox()
        lbl_time = New Label()
        tmr_game = New Timer(components)
        pnl_statusbar = New Panel()
        btn_fuel_bar = New Button()
        tmr_lifeboat = New Timer(components)
        tmr_swimmer_spawn = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).BeginInit()
        pnl_statusbar.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.fuel_sprite
        PictureBox1.Location = New Point(13, 14)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(60, 60)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.ErrorImage = Nothing
        PictureBox2.Image = My.Resources.Resources.heart_sprite
        PictureBox2.InitialImage = Nothing
        PictureBox2.Location = New Point(1726, 20)
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
        PictureBox3.ErrorImage = Nothing
        PictureBox3.Image = My.Resources.Resources.heart_sprite
        PictureBox3.InitialImage = Nothing
        PictureBox3.Location = New Point(1673, 20)
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
        PictureBox4.ErrorImage = Nothing
        PictureBox4.Image = My.Resources.Resources.heart_sprite
        PictureBox4.InitialImage = Nothing
        PictureBox4.Location = New Point(1567, 20)
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
        PictureBox5.ErrorImage = Nothing
        PictureBox5.Image = My.Resources.Resources.heart_sprite
        PictureBox5.InitialImage = Nothing
        PictureBox5.Location = New Point(1620, 20)
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
        PictureBox6.ErrorImage = Nothing
        PictureBox6.Image = My.Resources.Resources.heart_sprite
        PictureBox6.InitialImage = Nothing
        PictureBox6.Location = New Point(1514, 20)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(47, 49)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 5
        PictureBox6.TabStop = False
        ' 
        ' PictureBox10
        ' 
        PictureBox10.Anchor = AnchorStyles.Top
        PictureBox10.BackColor = Color.Transparent
        PictureBox10.Image = My.Resources.Resources.clock_sprite
        PictureBox10.Location = New Point(778, 19)
        PictureBox10.Name = "PictureBox10"
        PictureBox10.Size = New Size(63, 55)
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
        lbl_time.Location = New Point(847, 24)
        lbl_time.Name = "lbl_time"
        lbl_time.Size = New Size(94, 45)
        lbl_time.TabIndex = 10
        lbl_time.Text = "5:00"
        ' 
        ' tmr_game
        ' 
        tmr_game.Interval = 10
        ' 
        ' pnl_statusbar
        ' 
        pnl_statusbar.BackColor = Color.Gold
        pnl_statusbar.Controls.Add(btn_fuel_bar)
        pnl_statusbar.Controls.Add(PictureBox1)
        pnl_statusbar.Controls.Add(lbl_time)
        pnl_statusbar.Controls.Add(PictureBox6)
        pnl_statusbar.Controls.Add(PictureBox4)
        pnl_statusbar.Controls.Add(PictureBox10)
        pnl_statusbar.Controls.Add(PictureBox5)
        pnl_statusbar.Controls.Add(PictureBox2)
        pnl_statusbar.Controls.Add(PictureBox3)
        pnl_statusbar.Location = New Point(-1, -2)
        pnl_statusbar.Name = "pnl_statusbar"
        pnl_statusbar.Size = New Size(1780, 85)
        pnl_statusbar.TabIndex = 12
        ' 
        ' btn_fuel_bar
        ' 
        btn_fuel_bar.BackColor = Color.Lime
        btn_fuel_bar.FlatStyle = FlatStyle.Popup
        btn_fuel_bar.Location = New Point(79, 33)
        btn_fuel_bar.Name = "btn_fuel_bar"
        btn_fuel_bar.RightToLeft = RightToLeft.Yes
        btn_fuel_bar.Size = New Size(600, 23)
        btn_fuel_bar.TabIndex = 13
        btn_fuel_bar.UseVisualStyleBackColor = False
        ' 
        ' tmr_lifeboat
        ' 
        tmr_lifeboat.Interval = 10
        ' 
        ' tmr_swimmer_spawn
        ' 
        tmr_swimmer_spawn.Interval = 1000
        ' 
        ' RescateMarino
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = My.Resources.Resources.sea_sprite_4
        ClientSize = New Size(1778, 1244)
        Controls.Add(pnl_statusbar)
        DoubleBuffered = True
        Name = "RescateMarino"
        Text = "Rescate Marino"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox10, ComponentModel.ISupportInitialize).EndInit()
        pnl_statusbar.ResumeLayout(False)
        pnl_statusbar.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents lbl_time As Label
    Friend WithEvents tmr_game As Timer
    Friend WithEvents pnl_statusbar As Panel
    Friend WithEvents tmr_lifeboat As Timer
    Friend WithEvents tmr_swimmer_spawn As Timer
    Friend WithEvents btn_fuel_bar As Button

End Class
