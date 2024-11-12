Public Class RescateMarino

    Dim max_swimmers = 10
    Dim swimmer_count = 0
    Dim vpic_swimmers(10) As PictureBox
    Dim max_fuel As Integer = 600

    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1800, 1300)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        Initialize_Speedboat()
        Initialize_Lifeboat()

        tmr_game.Enabled = True
        tmr_lifeboat.Enabled = True
        tmr_swimmer_spawn.Enabled = True
    End Sub

    Private Sub Initialize_Speedboat()
        'Colocar el bote en el centro de la pantalla
        Dim dimension As Integer = 100
        Dim posx As Integer = (Me.Width / 2) - 100 / 2
        Dim posy As Integer = (Me.Height / 2) - 100 / 2

        Dim speedboat As New Vehicle("pic_speedboat", GameEntity.EntityType.SPEEDBOAT, posx, posy, dimension, dimension)
        speedboat.max_speed = 5
        speedboat.acceleration = 1

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

    Private Sub Initialize_Swimmer()

        Dim rand As New Random()
        Dim dimension As Integer = 100
        Dim points As Integer = 10
        Dim posx As Integer
        Dim posy As Integer
        Dim spawn_padding As Integer = 50
        Dim new_swimmer As Swimmer
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If swimmer_count < max_swimmers Then
            posx = rand.Next(spawn_padding, Me.Width - spawn_padding - lifeboat.Width - dimension)
            posy = rand.Next(pnl_statusbar.Height + spawn_padding, Me.Height - spawn_padding - dimension)
            new_swimmer = New Swimmer("swimmer_" & swimmer_count + 1, GameEntity.EntityType.HUMAN, posx, posy, dimension, dimension, points)
            new_swimmer.max_speed = 10
            new_swimmer.acceleration = 1
            vpic_swimmers.Append(new_swimmer)
            Me.Controls.Add(new_swimmer)
            swimmer_count += 1
        End If
    End Sub


    Private Sub Initialize_Shark()

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
                btn_fuel_bar.Width = max_fuel
            End If

            'Mantener el bote dentro del mapa
            If speedboat.Location.X <= 0 Or speedboat.Location.X >= Me.Width - speedboat.Width - 10 Then
                speedboat.dirx = -speedboat.dirx / 2
            End If
            If speedboat.Location.Y <= 0 Or speedboat.Location.Y >= Me.Height - speedboat.Height - 40 Then
                speedboat.diry = -speedboat.diry / 2
            End If

        End If


        If btn_fuel_bar IsNot Nothing Then
            btn_fuel_bar.Width -= 1

            If btn_fuel_bar.Width / max_fuel >= 0.66 Then
                btn_fuel_bar.BackColor = Color.Lime
            ElseIf btn_fuel_bar.Width / max_fuel < 0.66 And btn_fuel_bar.Width / max_fuel >= 0.33 Then
                btn_fuel_bar.BackColor = Color.Yellow
            Else
                btn_fuel_bar.BackColor = Color.Red
            End If
        End If

    End Sub

    Private Sub tmr_lifeboat_Tick(sender As Object, e As EventArgs) Handles tmr_lifeboat.Tick
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If lifeboat IsNot Nothing Then
            lifeboat.Location = New Point(lifeboat.Location.X, lifeboat.Location.Y + lifeboat.diry)
        End If

        If lifeboat.Location.Y > Me.Height Then
            lifeboat.Location = New Point(lifeboat.Location.X, -lifeboat.Height)
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        Dim speedboat As GameEntity = Me.Controls("pic_speedboat")

        'Si no hay gasolina no hacer nada
        If btn_fuel_bar.Width = 0 Then
            Exit Function
        End If

        Select Case keyData
            Case Keys.Up, Keys.W
                speedboat.diry -= speedboat.acceleration
            Case Keys.Down, Keys.S
                speedboat.diry += speedboat.acceleration
            Case Keys.Left, Keys.A
                speedboat.dirx -= speedboat.acceleration
            Case Keys.Right, Keys.D
                speedboat.dirx += speedboat.acceleration
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

    Private Sub tmr_swimmer_spawn_Tick(sender As Object, e As EventArgs) Handles tmr_swimmer_spawn.Tick
        Initialize_Swimmer()
    End Sub
End Class
