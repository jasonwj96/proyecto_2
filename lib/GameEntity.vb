Public Class GameEntity
    Inherits PictureBox

    Private type As EntityType
    Private _dirx As Integer = 0
    Private _diry As Integer = 0
    Private _max_speed As Integer = 5
    Public Enum EntityType
        SPEEDBOAT
        LIFEBOAT
        SHARK
        HUMAN
    End Enum

    Public Property dirx As Integer
        Get
            Return _dirx
        End Get
        Set(value As Integer)
            _dirx = value
        End Set
    End Property

    Public Property diry As Integer
        Get
            Return _diry
        End Get
        Set(value As Integer)
            _diry = value
        End Set
    End Property

    Public Property max_speed As Integer
        Get
            Return _max_speed
        End Get
        Set(value As Integer)
            _max_speed = value
        End Set
    End Property

    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer)
        Select Case type
            Case EntityType.SPEEDBOAT
                Me.Image = My.Resources.speedboat_sprite
            Case EntityType.LIFEBOAT
                Me.Image = My.Resources.lifeboar_sprite_2
            Case EntityType.HUMAN
                Me.Image = My.Resources.raft_sprite
            Case EntityType.SHARK
                Me.Image = My.Resources.shark_sprite_3
        End Select

        Me.Name = name
        Me.SizeMode = PictureBoxSizeMode.Zoom
        Me.BackColor = Color.Transparent
        Me.DoubleBuffered = True
        Me.Location = New Point(posx, posy)
        Me.Width = width
        Me.Height = height
    End Sub
End Class
