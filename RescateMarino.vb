Public Class RescateMarino

    Dim vpic_swimmers(10) As PictureBox

    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1800, 1300)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        Initialize_Speedboat()
        Initialize_Lifeboat()

        tmr_game.Enabled = True

    End Sub

    Private Sub Initialize_Speedboat()
        'Colocar el bote en el centro de la pantalla
        Dim dimension As Integer = 100
        Dim posx As Integer = (Me.Width / 2) - 100 / 2
        Dim posy As Integer = (Me.Height / 2) - 100 / 2

        Dim speedboat As New GameEntity("pic_speedboat", GameEntity.EntityType.SPEEDBOAT, posx, posy, dimension, dimension)


        Me.Controls.Add(speedboat)
    End Sub

    Private Sub Initialize_Lifeboat()
        Dim posx As Integer = 1600
        Dim posy As Integer = -330

        Dim lifeboat As New GameEntity("pic_lifeboat", GameEntity.EntityType.LIFEBOAT, posx, posy, 150, 330)
        lifeboat.dirx = 0
        lifeboat.diry = 2

        Me.Controls.Add(lifeboat)
    End Sub

    Private Sub tmr_game_Tick(sender As Object, e As EventArgs) Handles tmr_game.Tick
        Dim speedboat As GameEntity = Me.Controls("pic_speedboat")
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")
        Dim statusbar As Panel = Me.Controls("pnl_statusbar")

        If speedboat IsNot Nothing Then
            speedboat.Location = New Point(speedboat.Location.X + speedboat.dirx, speedboat.Location.Y + speedboat.diry)

            If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Or speedboat.Bounds.IntersectsWith(statusbar.Bounds) Then
                speedboat.dirx = -speedboat.dirx
                speedboat.diry = -speedboat.diry
            End If

            'Mantener el bote dentro del mapa
            If speedboat.Location.X <= 0 Or speedboat.Location.X >= Me.Width - speedboat.Width - 10 Then
                speedboat.dirx = -speedboat.dirx
            End If
            If speedboat.Location.Y <= 0 Or speedboat.Location.Y >= Me.Height - speedboat.Height - 40 Then
                speedboat.diry = -speedboat.diry
            End If

        End If

        If lifeboat IsNot Nothing Then
            lifeboat.Location = New Point(lifeboat.Location.X, lifeboat.Location.Y + lifeboat.diry)
        End If

        If lifeboat.Location.Y > Me.Height Then
            lifeboat.Location = New Point(lifeboat.Location.X, -lifeboat.Height)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        Dim speedboat As GameEntity = Me.Controls("pic_speedboat")

        Select Case keyData
            Case Keys.Up, Keys.W
                speedboat.diry -= 2
            Case Keys.Down, Keys.S
                speedboat.diry += 2
            Case Keys.Left, Keys.A
                speedboat.dirx -= 2
            Case Keys.Right, Keys.D
                speedboat.dirx += 2
            Case Keys.Space
                'Simular freno
                speedboat.dirx /= 2
                speedboat.diry /= 2
        End Select

        If speedboat.diry > 0 Then
            speedboat.diry = Math.Min(speedboat.diry, speedboat.max_speed)
        End If

        If speedboat.diry < 0 Then
            speedboat.diry = Math.Max(speedboat.diry, -speedboat.max_speed)
        End If


        If speedboat.dirx > 0 Then
            speedboat.dirx = Math.Min(speedboat.dirx, speedboat.max_speed)
        End If

        If speedboat.dirx < 0 Then
            speedboat.dirx = Math.Max(speedboat.dirx, -speedboat.max_speed)
        End If

        If speedboat.dirx > 0 Then
            speedboat.Image = My.Resources.speedboat_sprite_r
        Else
            speedboat.Image = My.Resources.speedboat_sprite
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
