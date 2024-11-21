Public Class Swimmer
    Inherits GameEntity

    Private _score As Integer = 0
    Private _points As Integer = 0

    Public Property score As Integer
        Get
            Return _score
        End Get
        Set(value As Integer)
            _score = value
        End Set
    End Property

    Public Property points As Integer
        Get
            Return _points
        End Get
        Set(value As Integer)
            _points = value
        End Set
    End Property

    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer, points As Integer, max_speed As Integer, acceleration As Integer)
        MyBase.New(name, type, posx, posy, width, height)

        Me.points = points
        Me.max_speed = max_speed
        Me.acceleration = acceleration
    End Sub

End Class
