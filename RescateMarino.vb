Public Class RescateMarino

    Dim MAX_SWIMMERS = 10
    Dim SPRITE_SIZE = 75
    Dim vpic_swimmers As New List(Of PictureBox)
    Dim vpic_sharks As New List(Of PictureBox)

    Dim current_points = 0
    Dim rescued_swimmers = 0
    Dim current_round

    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(1300, 800)

        Me.Size = New Size(1900, 1400)
        ' Me.FormBorderStyle = FormBorderStyle.FixedDialog
        ' Me.MaximizeBox = False

        pnl_statusbar.Width = Me.Width
        pic_clock.Location = New Point(Me.Width / 2 - pic_clock.Width, pic_clock.Location.Y)
        lbl_time.Location = New Point(Me.Width / 2, lbl_time.Location.Y)

        Initialize_Speedboat()
        Initialize_Lifeboat()

        tmr_game.Enabled = True
        tmr_lifeboat.Enabled = True
        tmr_swimmer_spawn.Enabled = True
        tmr_swimmer_move.Enabled = True
        tmr_shark_move.Enabled = True
    End Sub

    Private Sub Initialize_Speedboat()
        'Colocar el bote en el centro de la pantalla
        Dim posx As Integer = (Me.Width / 2) - 100 / 2
        Dim posy As Integer = (Me.Height / 2) - 100 / 2

        Dim speedboat As New Vehicle("pic_speedboat", GameEntity.EntityType.SPEEDBOAT, posx, posy, SPRITE_SIZE, SPRITE_SIZE)
        speedboat.max_speed = 5
        speedboat.acceleration = 1

        Me.Controls.Add(speedboat)

        btn_fuel_bar.Width = speedboat.current_fuel
    End Sub

    Private Sub Initialize_Lifeboat()
        Dim posx As Integer = Me.Width - 190
        Dim posy As Integer = -330

        Dim lifeboat As New Vehicle("pic_lifeboat", GameEntity.EntityType.LIFEBOAT, posx, posy, 150, 350)
        lifeboat.ChangeDirection(0, 2)

        Me.Controls.Add(lifeboat)
    End Sub

    Private Sub Initialize_Swimmer()

        Dim rand As New Random()
        Dim points As Integer = 10
        Dim posx As Integer
        Dim posy As Integer
        Dim spawn_padding As Integer = 50
        Dim new_swimmer As Swimmer
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If vpic_swimmers.Count() < MAX_SWIMMERS Then
            posx = rand.Next(spawn_padding, Me.Width - spawn_padding - lifeboat.Width - SPRITE_SIZE)
            posy = rand.Next(pnl_statusbar.Height + spawn_padding, Me.Height - spawn_padding - SPRITE_SIZE)
            new_swimmer = New Swimmer("swimmer_" & vpic_swimmers.Count + 1, GameEntity.EntityType.HUMAN, posx, posy, SPRITE_SIZE, SPRITE_SIZE, points) With {
                .max_speed = 20,
                .acceleration = 5
            }

            new_swimmer.ChangeDirection(If(rand.Next(0, 2) = 0, -1, 1), If(rand.Next(0, 2) = 0, -1, 1))

            vpic_swimmers.Add(new_swimmer)

            Me.Controls.Add(new_swimmer)
        End If
    End Sub

    Private Sub Initialize_Shark()
        Dim rand As New Random()
        Dim points As Integer = 10
        Dim posx As Integer
        Dim posy As Integer
        Dim spawn_padding As Integer = 50
        Dim new_shark As Swimmer
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If vpic_sharks.Count() < MAX_SWIMMERS Then
            posx = rand.Next(spawn_padding, Me.Width - spawn_padding - lifeboat.Width - SPRITE_SIZE)
            posy = rand.Next(pnl_statusbar.Height + spawn_padding, Me.Height - spawn_padding - SPRITE_SIZE)
            new_shark = New Swimmer("shark_" & vpic_sharks.Count + 1, GameEntity.EntityType.SHARK, posx, posy, SPRITE_SIZE, SPRITE_SIZE, points) With {
                .max_speed = 20,
                .acceleration = 5
            }

            new_shark.ChangeDirection(If(rand.Next(0, 2) = 0, -1, 1), If(rand.Next(0, 2) = 0, -1, 1))

            vpic_sharks.Add(new_shark)

            Me.Controls.Add(new_shark)
        End If
    End Sub

    Private Sub tmr_game_Tick(sender As Object, e As EventArgs) Handles tmr_game.Tick
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")
        Dim statusbar As Panel = Me.Controls("pnl_statusbar")

        If speedboat IsNot Nothing Then

            If speedboat.current_fuel > 0 Then
                speedboat.MoveEntity()
            End If

            If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Or speedboat.Bounds.IntersectsWith(statusbar.Bounds) Then
                speedboat.ChangeDirection(-speedboat.dirx, -speedboat.diry)
            End If

            If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Then
                speedboat.AddFuel(speedboat.max_fuel)
                btn_fuel_bar.Width = speedboat.current_fuel
            End If

            'Mantener el bote dentro del mapa
            If speedboat.Location.X <= 0 Or speedboat.Location.X >= Me.Width - speedboat.Width - 10 Then
                speedboat.ChangeDirection(-speedboat.dirx / 2, speedboat.diry)
            End If

            If speedboat.Location.Y <= 0 Or speedboat.Location.Y >= Me.Height - speedboat.Height - 40 Then
                speedboat.ChangeDirection(speedboat.dirx, -speedboat.diry / 2)
            End If
        End If

        'Mecanismo de combustible
        If btn_fuel_bar IsNot Nothing And speedboat IsNot Nothing Then

            ' speedboat.AddFuel(-1)

            btn_fuel_bar.Width = speedboat.current_fuel

            If speedboat.current_fuel / speedboat.max_fuel >= 0.66 Then
                btn_fuel_bar.BackColor = Color.Lime
            ElseIf speedboat.current_fuel / speedboat.max_fuel < 0.66 And speedboat.current_fuel / speedboat.max_fuel >= 0.33 Then
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

        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")

        'Si no hay gasolina no hacer nada
        If speedboat.current_fuel <= 0 Then
            Exit Function
        End If

        btn_w_key.Image = My.Resources.w_key
        btn_a_key.Image = My.Resources.a_key
        btn_s_key.Image = My.Resources.s_key
        btn_d_key.Image = My.Resources.d_key
        btn_space_key.Image = My.Resources.space

        Select Case keyData
            Case Keys.Up, Keys.W
                speedboat.diry -= speedboat.acceleration
                btn_w_key.Image = My.Resources.w_key_pressed
            Case Keys.Down, Keys.S
                speedboat.diry += speedboat.acceleration
                btn_s_key.Image = My.Resources.s_key_pressed
            Case Keys.Left, Keys.A
                speedboat.dirx -= speedboat.acceleration
                btn_a_key.Image = My.Resources.a_key_pressed
            Case Keys.Right, Keys.D
                speedboat.dirx += speedboat.acceleration
                btn_d_key.Image = My.Resources.d_key_pressed
            Case Keys.Space
                'Simular freno
                speedboat.dirx /= 2
                speedboat.diry /= 2
                btn_space_key.Image = My.Resources.space_pressed

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
        Initialize_Shark()
    End Sub

    Private Sub tmr_swimmer_move_Tick(sender As Object, e As EventArgs) Handles tmr_swimmer_move.Tick
        'Mover los pasajeros

        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")

        If vpic_swimmers IsNot Nothing Then
            For Each swimmer As Swimmer In vpic_swimmers
                swimmer?.MoveEntity()

                If swimmer?.Bounds.IntersectsWith(speedboat.Bounds) Then
                    '  swimmer.ChangeDirection(0, 0)
                    ' swimmer.Location = New Point(Me.Width + swimmer.Width, swimmer.Location.Y)
                    'swimmer.Visible = False
                    ' rescued_swimmers += 1
                    current_points += swimmer.points
                    lbl_current_points.Text = current_points
                End If

                If swimmer?.Bounds.IntersectsWith(lifeboat.Bounds) Then
                    swimmer.ChangeDirection(-swimmer.dirx, -swimmer.diry)
                End If

                If swimmer.Location.X <= 0 Or swimmer.Location.X + swimmer.Width >= Me.Width - 200 Then
                    swimmer.dirx = -swimmer.dirx
                End If

                If swimmer.Location.Y <= pnl_statusbar.Height Or swimmer.Location.Y >= Me.Height - swimmer.Height - pnl_statusbar.Height Then
                    swimmer.diry = -swimmer.diry
                End If

                For Each otherswimmer As Swimmer In vpic_swimmers
                    If swimmer.Name <> otherswimmer.Name And swimmer.Bounds.IntersectsWith(otherswimmer.Bounds) Then

                        Dim old_dirx As Integer = swimmer.dirx
                        Dim old_diry As Integer = swimmer.diry

                        swimmer.ChangeDirection(otherswimmer.dirx, otherswimmer.diry)
                        otherswimmer.ChangeDirection(old_diry, old_diry)
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub tmr_shark_move_Tick(sender As Object, e As EventArgs) Handles tmr_shark_move.Tick
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")

        If vpic_sharks IsNot Nothing Then
            For Each shark As Swimmer In vpic_sharks
                shark?.MoveEntity()

                If shark?.Bounds.IntersectsWith(speedboat.Bounds) Then
                    '  swimmer.ChangeDirection(0, 0)
                    ' swimmer.Location = New Point(Me.Width + swimmer.Width, swimmer.Location.Y)
                    'swimmer.Visible = False
                    ' rescued_swimmers += 1
                    current_points += shark.points
                    lbl_current_points.Text = current_points
                End If

                If shark?.Bounds.IntersectsWith(lifeboat.Bounds) Then
                    shark.ChangeDirection(-shark.dirx, -shark.diry)
                End If

                If shark.Location.X <= 0 Or shark.Location.X + shark.Width >= Me.Width - 200 Then
                    shark.dirx = -shark.dirx
                End If

                If shark.Location.Y <= pnl_statusbar.Height Or shark.Location.Y >= Me.Height - shark.Height - pnl_statusbar.Height Then
                    shark.diry = -shark.diry
                End If

                For Each other_shark As Swimmer In vpic_swimmers
                    If shark.Name <> other_shark.Name And shark.Bounds.IntersectsWith(other_shark.Bounds) Then

                        Dim old_dirx As Integer = shark.dirx
                        Dim old_diry As Integer = shark.diry

                        shark.ChangeDirection(other_shark.dirx, other_shark.diry)
                        other_shark.ChangeDirection(old_diry, old_diry)
                    End If
                Next
            Next
        End If
    End Sub
End Class
