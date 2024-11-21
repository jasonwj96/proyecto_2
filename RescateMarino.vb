Public Class RescateMarino

    Dim MAX_SWIMMERS = 10
    Dim MAX_SHARKS = 10
    Dim SWIMMER_SPRITE_SIZE = 75
    Dim FUELBAR_WIDTH = 450
    Dim LIFEBOAT_WIDTH = 150
    Dim LIFEBOAT_HEIGHT = 350

    Dim current_swimmers = 0
    Dim current_sharks = 0
    Dim current_points = 0
    Dim current_round = 1
    Dim rescued_swimmers = 0

    Dim vpic_swimmers As New List(Of PictureBox)

    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(1300, 800)

        Me.Size = New Size(1900, 1400)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        pnl_statusbar.Width = Me.Width

        Initialize_Speedboat()
        Initialize_Lifeboat()

        tmr_game.Enabled = True
        tmr_lifeboat.Enabled = True
        tmr_swimmer_spawn.Enabled = True
        tmr_swimmer_move.Enabled = True
    End Sub

    Private Sub Initialize_Speedboat()
        'Colocar el bote en el centro de la pantalla
        Dim speedboat As New Vehicle("pic_speedboat", GameEntity.EntityType.SPEEDBOAT,
            (Me.Width / 2) - 100 / 2,
            (Me.Height / 2) - 100 / 2,
            SWIMMER_SPRITE_SIZE, SWIMMER_SPRITE_SIZE)

        speedboat.BackColor = Color.Transparent
        speedboat.max_speed = 5
        speedboat.acceleration = 1

        Me.Controls.Add(speedboat)

        btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)
    End Sub

    Private Sub Initialize_Lifeboat()

        Dim LIFEBOAT_SPAWN_PADDING = 40

        Dim lifeboat As New Vehicle("pic_lifeboat", GameEntity.EntityType.LIFEBOAT,
                                    Me.Width - LIFEBOAT_WIDTH - LIFEBOAT_SPAWN_PADDING,
                                    -LIFEBOAT_HEIGHT,
                                    LIFEBOAT_WIDTH,
                                    LIFEBOAT_HEIGHT)

        lifeboat.BackColor = Color.Transparent
        lifeboat.ChangeDirection(0, 2)

        Me.Controls.Add(lifeboat)
    End Sub

    Private Sub Initialize_Swimmer()

        Dim SPAWN_PADDING As Integer = 50

        Dim rand As New Random()
        Dim new_swimmer As Swimmer
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If current_swimmers < MAX_SWIMMERS Then

            new_swimmer = New Swimmer("swimmer_" & vpic_swimmers.Count + 1,
                                      GameEntity.EntityType.HUMAN,
                                      rand.Next(SPAWN_PADDING, Me.Width - SPAWN_PADDING - LIFEBOAT_WIDTH - SWIMMER_SPRITE_SIZE),
                                      rand.Next(pnl_statusbar.Height + SPAWN_PADDING, Me.Height - SPAWN_PADDING - SWIMMER_SPRITE_SIZE),
                                      SWIMMER_SPRITE_SIZE,
                                      SWIMMER_SPRITE_SIZE,
                                      10) With {
                .BackColor = Color.Transparent,
                .max_speed = 20,
                .acceleration = 5
            }

            new_swimmer.ChangeDirection(If(rand.Next(0, 2) = 0, -1, 1),
                                        If(rand.Next(0, 2) = 0, -1, 1))

            vpic_swimmers.Add(new_swimmer)
            Me.Controls.Add(new_swimmer)

            current_swimmers += 1
        End If

        If current_sharks < MAX_SHARKS Then
            new_swimmer = New Swimmer("shark_" & vpic_swimmers.Count + 1,
                                      GameEntity.EntityType.SHARK,
                                      rand.Next(SPAWN_PADDING, Me.Width - SPAWN_PADDING - lifeboat.Width - SWIMMER_SPRITE_SIZE),
                                      rand.Next(pnl_statusbar.Height + SPAWN_PADDING, Me.Height - SPAWN_PADDING - SWIMMER_SPRITE_SIZE),
                                      SWIMMER_SPRITE_SIZE, SWIMMER_SPRITE_SIZE, 10) With {
                .BackColor = Color.Transparent,
                .max_speed = 20,
                .acceleration = 5
            }

            new_swimmer.ChangeDirection(If(rand.Next(0, 2) = 0, -1, 1),
                                        If(rand.Next(0, 2) = 0, -1, 1))

            vpic_swimmers.Add(new_swimmer)
            Me.Controls.Add(new_swimmer)

            current_sharks += 1
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
                btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)
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

            speedboat.AddFuel(-1)

            btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)

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
    End Sub

    Private Sub tmr_swimmer_move_Tick(sender As Object, e As EventArgs) Handles tmr_swimmer_move.Tick
        'Mover los pasajeros

        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")

        If vpic_swimmers IsNot Nothing Then

            For Each swimmer As Swimmer In vpic_swimmers

                If swimmer.Location.X <= 0 Or swimmer.Location.X + swimmer.Width >= Me.Width - 200 Then
                    swimmer.dirx = -swimmer.dirx
                End If

                If swimmer.Location.Y <= pnl_statusbar.Height Or swimmer.Location.Y >= Me.Height - swimmer.Height - pnl_statusbar.Height Then
                    swimmer.diry = -swimmer.diry
                End If

                swimmer?.MoveEntity()

                If swimmer?.Bounds.IntersectsWith(speedboat.Bounds) Then
                    'swimmer.ChangeDirection(0, 0)
                    'swimmer.Location = New Point(Me.Width + swimmer.Width, swimmer.Location.Y)
                    'swimmer.Visible = False
                    ' rescued_swimmers += 1
                    current_points += swimmer.points
                    lbl_current_points.Text = current_points
                End If

                If swimmer?.Bounds.IntersectsWith(lifeboat.Bounds) Then
                    swimmer.ChangeDirection(-swimmer.dirx, -swimmer.diry)
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
End Class
