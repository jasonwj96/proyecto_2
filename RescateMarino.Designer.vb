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
        pic_clock = New PictureBox()
        lbl_time = New Label()
        tmr_game = New Timer(components)
        pnl_statusbar = New Panel()
        Label1 = New Label()
        lbl_current_points = New Label()
        btn_fuel_bar = New Button()
        tmr_lifeboat = New Timer(components)
        tmr_swimmer_spawn = New Timer(components)
        btn_a_key = New PictureBox()
        btn_s_key = New PictureBox()
        btn_w_key = New PictureBox()
        btn_d_key = New PictureBox()
        btn_space_key = New PictureBox()
        tmr_swimmer_move = New Timer(components)
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(pic_clock, ComponentModel.ISupportInitialize).BeginInit()
        pnl_statusbar.SuspendLayout()
        CType(btn_a_key, ComponentModel.ISupportInitialize).BeginInit()
        CType(btn_s_key, ComponentModel.ISupportInitialize).BeginInit()
        CType(btn_w_key, ComponentModel.ISupportInitialize).BeginInit()
        CType(btn_d_key, ComponentModel.ISupportInitialize).BeginInit()
        CType(btn_space_key, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.fuel_sprite
        PictureBox1.Location = New Point(12, 14)
        PictureBox1.Margin = New Padding(2)
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
        PictureBox2.Location = New Point(1545, 20)
        PictureBox2.Margin = New Padding(2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(48, 49)
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
        PictureBox3.Location = New Point(1491, 20)
        PictureBox3.Margin = New Padding(2)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(48, 49)
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
        PictureBox4.Location = New Point(1386, 20)
        PictureBox4.Margin = New Padding(2)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(48, 49)
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
        PictureBox5.Location = New Point(1439, 20)
        PictureBox5.Margin = New Padding(2)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(48, 49)
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
        PictureBox6.Location = New Point(1332, 20)
        PictureBox6.Margin = New Padding(2)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(48, 49)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 5
        PictureBox6.TabStop = False
        ' 
        ' pic_clock
        ' 
        pic_clock.Anchor = AnchorStyles.Top
        pic_clock.BackColor = Color.Transparent
        pic_clock.Image = My.Resources.Resources.clock_sprite
        pic_clock.Location = New Point(621, 14)
        pic_clock.Margin = New Padding(2)
        pic_clock.Name = "pic_clock"
        pic_clock.Size = New Size(62, 55)
        pic_clock.SizeMode = PictureBoxSizeMode.Zoom
        pic_clock.TabIndex = 9
        pic_clock.TabStop = False
        ' 
        ' lbl_time
        ' 
        lbl_time.AutoSize = True
        lbl_time.BackColor = Color.Transparent
        lbl_time.Font = New Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_time.ForeColor = Color.Black
        lbl_time.Location = New Point(687, 23)
        lbl_time.Margin = New Padding(2, 0, 2, 0)
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
        pnl_statusbar.Controls.Add(Label1)
        pnl_statusbar.Controls.Add(lbl_current_points)
        pnl_statusbar.Controls.Add(btn_fuel_bar)
        pnl_statusbar.Controls.Add(PictureBox1)
        pnl_statusbar.Controls.Add(lbl_time)
        pnl_statusbar.Controls.Add(PictureBox6)
        pnl_statusbar.Controls.Add(PictureBox4)
        pnl_statusbar.Controls.Add(pic_clock)
        pnl_statusbar.Controls.Add(PictureBox5)
        pnl_statusbar.Controls.Add(PictureBox2)
        pnl_statusbar.Controls.Add(PictureBox3)
        pnl_statusbar.Location = New Point(-1, -2)
        pnl_statusbar.Margin = New Padding(2)
        pnl_statusbar.Name = "pnl_statusbar"
        pnl_statusbar.Size = New Size(1625, 85)
        pnl_statusbar.TabIndex = 12
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Black
        Label1.Location = New Point(932, 21)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(163, 45)
        Label1.TabIndex = 15
        Label1.Text = "Puntaje:"
        ' 
        ' lbl_current_points
        ' 
        lbl_current_points.AutoSize = True
        lbl_current_points.BackColor = Color.Transparent
        lbl_current_points.Font = New Font("Arial Black", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lbl_current_points.ForeColor = Color.Black
        lbl_current_points.Location = New Point(1089, 23)
        lbl_current_points.Margin = New Padding(2, 0, 2, 0)
        lbl_current_points.Name = "lbl_current_points"
        lbl_current_points.Size = New Size(41, 45)
        lbl_current_points.TabIndex = 14
        lbl_current_points.Text = "0"
        ' 
        ' btn_fuel_bar
        ' 
        btn_fuel_bar.BackColor = Color.Lime
        btn_fuel_bar.FlatStyle = FlatStyle.Popup
        btn_fuel_bar.Location = New Point(80, 33)
        btn_fuel_bar.Margin = New Padding(2)
        btn_fuel_bar.Name = "btn_fuel_bar"
        btn_fuel_bar.RightToLeft = RightToLeft.Yes
        btn_fuel_bar.Size = New Size(450, 25)
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
        ' btn_a_key
        ' 
        btn_a_key.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_a_key.BackColor = Color.Transparent
        btn_a_key.ErrorImage = My.Resources.Resources.a_key
        btn_a_key.Image = My.Resources.Resources.a_key
        btn_a_key.InitialImage = Nothing
        btn_a_key.Location = New Point(1461, 876)
        btn_a_key.Margin = New Padding(2)
        btn_a_key.Name = "btn_a_key"
        btn_a_key.Size = New Size(40, 40)
        btn_a_key.SizeMode = PictureBoxSizeMode.Zoom
        btn_a_key.TabIndex = 13
        btn_a_key.TabStop = False
        ' 
        ' btn_s_key
        ' 
        btn_s_key.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_s_key.BackColor = Color.Transparent
        btn_s_key.ErrorImage = My.Resources.Resources.a_key
        btn_s_key.Image = My.Resources.Resources.s_key
        btn_s_key.InitialImage = Nothing
        btn_s_key.Location = New Point(1499, 876)
        btn_s_key.Margin = New Padding(2)
        btn_s_key.Name = "btn_s_key"
        btn_s_key.Size = New Size(40, 40)
        btn_s_key.SizeMode = PictureBoxSizeMode.Zoom
        btn_s_key.TabIndex = 14
        btn_s_key.TabStop = False
        ' 
        ' btn_w_key
        ' 
        btn_w_key.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_w_key.BackColor = Color.Transparent
        btn_w_key.ErrorImage = My.Resources.Resources.a_key
        btn_w_key.Image = My.Resources.Resources.w_key
        btn_w_key.InitialImage = Nothing
        btn_w_key.Location = New Point(1499, 834)
        btn_w_key.Margin = New Padding(2)
        btn_w_key.Name = "btn_w_key"
        btn_w_key.Size = New Size(40, 40)
        btn_w_key.SizeMode = PictureBoxSizeMode.Zoom
        btn_w_key.TabIndex = 16
        btn_w_key.TabStop = False
        ' 
        ' btn_d_key
        ' 
        btn_d_key.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_d_key.BackColor = Color.Transparent
        btn_d_key.ErrorImage = My.Resources.Resources.a_key
        btn_d_key.Image = My.Resources.Resources.d_key
        btn_d_key.InitialImage = Nothing
        btn_d_key.Location = New Point(1536, 876)
        btn_d_key.Margin = New Padding(2)
        btn_d_key.Name = "btn_d_key"
        btn_d_key.Size = New Size(40, 40)
        btn_d_key.SizeMode = PictureBoxSizeMode.Zoom
        btn_d_key.TabIndex = 15
        btn_d_key.TabStop = False
        ' 
        ' btn_space_key
        ' 
        btn_space_key.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btn_space_key.BackColor = Color.Transparent
        btn_space_key.ErrorImage = My.Resources.Resources.explosion_sprite
        btn_space_key.Image = My.Resources.Resources.space
        btn_space_key.InitialImage = Nothing
        btn_space_key.Location = New Point(1305, 876)
        btn_space_key.Margin = New Padding(2)
        btn_space_key.Name = "btn_space_key"
        btn_space_key.Size = New Size(150, 40)
        btn_space_key.SizeMode = PictureBoxSizeMode.Zoom
        btn_space_key.TabIndex = 17
        btn_space_key.TabStop = False
        ' 
        ' tmr_swimmer_move
        ' 
        ' 
        ' RescateMarino
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1602, 941)
        Controls.Add(btn_space_key)
        Controls.Add(btn_w_key)
        Controls.Add(btn_d_key)
        Controls.Add(btn_s_key)
        Controls.Add(btn_a_key)
        Controls.Add(pnl_statusbar)
        DoubleBuffered = True
        Margin = New Padding(2)
        Name = "RescateMarino"
        Text = "Rescate Marino"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(pic_clock, ComponentModel.ISupportInitialize).EndInit()
        pnl_statusbar.ResumeLayout(False)
        pnl_statusbar.PerformLayout()
        CType(btn_a_key, ComponentModel.ISupportInitialize).EndInit()
        CType(btn_s_key, ComponentModel.ISupportInitialize).EndInit()
        CType(btn_w_key, ComponentModel.ISupportInitialize).EndInit()
        CType(btn_d_key, ComponentModel.ISupportInitialize).EndInit()
        CType(btn_space_key, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents pic_clock As PictureBox
    Friend WithEvents lbl_time As Label
    Friend WithEvents tmr_game As Timer
    Friend WithEvents pnl_statusbar As Panel
    Friend WithEvents tmr_lifeboat As Timer
    Friend WithEvents tmr_swimmer_spawn As Timer
    Friend WithEvents btn_fuel_bar As Button
    Friend WithEvents btn_a_key As PictureBox
    Friend WithEvents btn_s_key As PictureBox
    Friend WithEvents btn_w_key As PictureBox
    Friend WithEvents btn_d_key As PictureBox
    Friend WithEvents btn_space_key As PictureBox
    Friend WithEvents tmr_swimmer_move As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents lbl_current_points As Label

End Class
