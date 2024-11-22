Public Class RescateMarino

    'Constantes
    Dim FORM_WIDTH = 1900
    Dim FORM_HEIGHT = 1400
    Dim STATUSBAR_HEIGHT As Integer = 85
    Dim MAX_SWIMMERS As Integer = 10
    Dim MAX_SHARKS As Integer = 10
    Dim SWIMMER_SPRITE_SIZE As Integer = 75
    Dim HEART_SPRITE_SIZE As Integer = 50
    Dim FUELBAR_WIDTH As Integer = 450
    Dim LIFEBOAT_WIDTH As Integer = 150
    Dim LIFEBOAT_HEIGHT As Integer = 350
    Dim SPAWN_PADDING As Integer = 50

    Dim SWIMMER_POINTS = 10

    'Variables de la ronda
    Dim current_round As Integer = 1
    Dim current_points As Integer = 0
    Dim rescued_swimmers As Integer = 0
    Dim current_lives As Integer = 1

    Dim RESPAWN_TIME_SECS = 2
    Dim REMAINING_RESPAWN_TIME = RESPAWN_TIME_SECS

    'Limites de la pantalla
    Dim X_LEFT_BOUND As Integer = SPAWN_PADDING
    Dim X_RIGHT_BOUND As Integer = FORM_WIDTH - LIFEBOAT_WIDTH - SPAWN_PADDING - SWIMMER_SPRITE_SIZE
    Dim Y_TOP_BOUND As Integer = STATUSBAR_HEIGHT
    Dim Y_BOTTOM_BOUND As Integer = FORM_HEIGHT - SWIMMER_SPRITE_SIZE

    Dim vpic_swimmers As New List(Of PictureBox)
    Dim vpic_sharks As New List(Of PictureBox)

    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(1300, 800)

        Me.Size = New Size(FORM_WIDTH, FORM_HEIGHT)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False

        pnl_statusbar.Width = FORM_WIDTH
        pnl_statusbar.Height = STATUSBAR_HEIGHT

        Initialize_Speedboat()
        Initialize_Lifeboat()
        Initialize_Hearts()

        tmr_game.Enabled = True
        tmr_swimmer_spawn.Enabled = True
        tmr_swimmer_move.Enabled = True
    End Sub


    Private Sub Initialize_Hearts()
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")

        Dim SPAWN_PADDING = 100
        Dim HEART_PADDING = 5

        Dim posx = Me.Width - SPAWN_PADDING
        Dim posy = (pnl_statusbar.Height) / 2 - (HEART_SPRITE_SIZE / 2)

        For i = 0 To speedboat.max_lives
            Dim heart As New PictureBox With {
                .Name = "pic_heart_" & i,
                .Width = HEART_SPRITE_SIZE,
                .Height = HEART_SPRITE_SIZE,
                .Location = New Point(posx - (i * HEART_PADDING) - (i * HEART_SPRITE_SIZE), posy),
                .Image = My.Resources.heart_sprite,
                .SizeMode = PictureBoxSizeMode.Zoom,
                .BackColor = Color.Gold
            }

            pnl_statusbar.SendToBack()
            heart.BringToFront()
            lifeboat.SendToBack()

            Me.Controls.Add(heart)
        Next
    End Sub

    Private Sub Initialize_Speedboat()

        If Me.Controls.ContainsKey("pic_speedboat") Then
            Me.Controls.RemoveByKey("pic_speedboat")
        End If

        'Colocar el bote en el centro de la pantalla
        Dim speedboat As New Vehicle("pic_speedboat", GameEntity.EntityType.SPEEDBOAT,
            (Me.Width / 2) - 100 / 2,
            (Me.Height / 2) - 100 / 2,
            SWIMMER_SPRITE_SIZE, SWIMMER_SPRITE_SIZE)

        speedboat.BackColor = Color.Transparent
        speedboat.max_speed = 5
        speedboat.acceleration = 1
        speedboat.Visible = True

        Me.Controls.Add(speedboat)

        btn_fuel_bar.Width = CInt(FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel))
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

    Private Sub Initialize_Swimmer(type As GameEntity.EntityType)

        Dim rand As New Random()
        Dim new_swimmer As Swimmer
        Dim swimmer_speed = 20
        Dim swimmer_acceleration = 5
        Dim current_list As List(Of PictureBox)
        Dim name_prefix As String = ""
        Dim tag As String = ""

        Select Case type
            Case GameEntity.EntityType.SHARK
                current_list = vpic_sharks
                name_prefix = "shark_"
                tag = "shark"
            Case Else
                current_list = vpic_swimmers
                name_prefix = "swimmer_"
                tag = "human"
        End Select

        'TODO: Logica de posx y posy para tiburones

        If current_list.Count < MAX_SWIMMERS Then

            new_swimmer = New Swimmer(name_prefix & current_list.Count + 1,
                                      type,
                                      rand.Next(X_LEFT_BOUND, X_RIGHT_BOUND),
                                      rand.Next(Y_TOP_BOUND, Y_BOTTOM_BOUND),
                                      SWIMMER_SPRITE_SIZE,
                                      SWIMMER_SPRITE_SIZE,
                                      SWIMMER_POINTS,
                                      swimmer_speed,
                                      swimmer_acceleration)

            new_swimmer.Tag = Tag

            new_swimmer.ChangeDirection(If(rand.Next(0, 2) = 0, -1, 1),
                                        If(rand.Next(0, 2) = 0, -1, 1))

            current_list.Add(new_swimmer)
            Me.Controls.Add(new_swimmer)
        End If

    End Sub

    Private Sub tmr_game_Tick(sender As Object, e As EventArgs) Handles tmr_game.Tick
        Move_Lifeboat()
        Move_Speedboat()
        Handle_fuel()
    End Sub

    Private Sub Move_Lifeboat()

        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If lifeboat IsNot Nothing Then
            lifeboat.Location = New Point(lifeboat.Location.X, lifeboat.Location.Y + lifeboat.diry)
        End If

        If lifeboat.Location.Y > Me.Height Then
            lifeboat.Location = New Point(lifeboat.Location.X, -lifeboat.Height)
        End If
    End Sub

    Private Sub Move_Speedboat()
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        'Mover lancha
        If speedboat.current_fuel > 0 Then
            speedboat.MoveEntity()
        End If

        If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Or speedboat.Bounds.IntersectsWith(pnl_statusbar.Bounds) Then
            speedboat.ChangeDirection(-speedboat.dirx, -speedboat.diry)
        End If

        If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Then

            If Math.Abs(speedboat.dirx) >= 5 Or Math.Abs(speedboat.diry) >= 5 Then
                Destroy_Speedboat()
            End If

            speedboat.AddFuel(speedboat.max_fuel)
            btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)
            speedboat.current_passengers = 0
            Refresh_points()
        End If

        'Mantener el bote dentro del mapa
        If speedboat.Location.X <= 0 Or speedboat.Location.X >= Me.Width - speedboat.Width - 10 Then
            speedboat.ChangeDirection(-speedboat.dirx / 2, speedboat.diry)
        End If

        If speedboat.Location.Y <= 0 Or speedboat.Location.Y >= Me.Height - speedboat.Height - 40 Then
            speedboat.ChangeDirection(speedboat.dirx, -speedboat.diry / 2)
        End If
    End Sub

    Private Sub Handle_fuel()
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")

        'Mecanismo de combustible
        speedboat.AddFuel(-1)

        btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)

        If speedboat.current_fuel / speedboat.max_fuel >= 0.66 Then
            btn_fuel_bar.BackColor = Color.Lime
        ElseIf speedboat.current_fuel / speedboat.max_fuel < 0.66 And speedboat.current_fuel / speedboat.max_fuel >= 0.33 Then
            btn_fuel_bar.BackColor = Color.Yellow
        Else
            btn_fuel_bar.BackColor = Color.Red
        End If
    End Sub


    Private Sub Refresh_points()
        If tmr_respawn.Enabled = False Then
            Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
            lbl_current_points.Text = speedboat.current_score
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")

        'Si no hay gasolina no hacer nada
        If speedboat.current_fuel <= 0 Or tmr_respawn.Enabled Then
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
        Initialize_Swimmer(GameEntity.EntityType.HUMAN)
        'Initialize_Shark()
    End Sub

    Private Sub tmr_swimmer_move_Tick(sender As Object, e As EventArgs) Handles tmr_swimmer_move.Tick
        'Mover los pasajeros

        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        Dim lifeboat As Vehicle = Me.Controls("pic_lifeboat")

        For Each swimmer As Swimmer In vpic_swimmers

            If swimmer.Location.X <= 0 Or swimmer.Location.X + swimmer.Width >= Me.Width - LIFEBOAT_WIDTH Then
                swimmer.dirx = -swimmer.dirx
            End If

            If swimmer.Location.Y <= pnl_statusbar.Height Or swimmer.Location.Y >= Me.Height - swimmer.Height - pnl_statusbar.Height Then
                swimmer.diry = -swimmer.diry
            End If

            swimmer?.MoveEntity()

            If swimmer?.Bounds.IntersectsWith(speedboat.Bounds) Then
                speedboat.AddPassenger(swimmer)
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
    End Sub

    Private Sub Destroy_Speedboat()
        Dim speedboat As Vehicle = Me.Controls("pic_speedboat")
        speedboat.current_passengers = 0
        speedboat.ChangeDirection(0, 0)
        speedboat.Image = My.Resources.explosion_sprite1
        speedboat.acceleration = 0
        speedboat.current_fuel = 0
        btn_fuel_bar.Width = FUELBAR_WIDTH * (speedboat.current_fuel / speedboat.max_fuel)
        REMAINING_RESPAWN_TIME = RESPAWN_TIME_SECS
        tmr_respawn.Enabled = True

        If current_lives > 0 Then
            current_lives -= 1

            For i = 0 To speedboat.max_lives - current_lives - 1
                Dim heart As PictureBox = Me.Controls("pic_heart_" & i)
                Me.Controls.Remove(heart)
            Next
        End If
    End Sub

    Private Sub tmr_respawn_Tick(sender As Object, e As EventArgs) Handles tmr_respawn.Tick
        If REMAINING_RESPAWN_TIME = 0 Then
            Initialize_Speedboat()
            tmr_respawn.Enabled = False
        ElseIf REMAINING_RESPAWN_TIME > 0 Then
            REMAINING_RESPAWN_TIME -= 1
        End If
    End Sub
End Class
