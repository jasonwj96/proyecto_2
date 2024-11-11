Public Class RescateMarino
    Private Sub RescateMarino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(1800, 1300)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False


        Dim posx As Integer = (Me.Width / 2) - 100 / 2
        Dim posy As Integer = (Me.Height / 2) - 100 / 2
        Dim speedboat As New GameEntity("pic_speedboat", GameEntity.EntityType.SPEEDBOAT, posx, posy, 100, 100)

        Me.Controls.Add(speedboat)

        posx = 1600
        posy = -330

        Dim lifeboat As New GameEntity("pic_lifeboat", GameEntity.EntityType.LIFEBOAT, posx, posy, 150, 330)
        lifeboat.dirx = 0
        lifeboat.diry = 2

        Me.Controls.Add(speedboat)
        Me.Controls.Add(lifeboat)

        'Centrar la lacha de rescate en la pantalla

        tmr_speedboat.Enabled = True

    End Sub

    Private Sub tmr_game_Tick(sender As Object, e As EventArgs) Handles tmr_game.Tick

    End Sub

    Private Sub tmr_speedboat_Tick(sender As Object, e As EventArgs) Handles tmr_speedboat.Tick
        Dim speedboat As GameEntity = Me.Controls("pic_speedboat")
        Dim lifeboat As GameEntity = Me.Controls("pic_lifeboat")

        If speedboat IsNot Nothing Then
            speedboat.Location = New Point(speedboat.Location.X + speedboat.dirx, speedboat.Location.Y + speedboat.diry)

            If speedboat.Bounds.IntersectsWith(lifeboat.Bounds) Then
                speedboat.dirx = -speedboat.dirx
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
            Case Keys.Up
                speedboat.diry -= 2
            Case Keys.Down
                speedboat.diry += 2
            Case Keys.Left
                speedboat.dirx -= 2
            Case Keys.Right
                speedboat.dirx += 2
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

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class
