Public Class Vehicle
    Inherits GameEntity

    Private _max_fuel As Integer = 10000 'Tamaño en pixeles de la barra de combustible
    Private _current_fuel As Integer = 10000 'Tamaño en pixeles de la barra de combustible
    Private _max_passengers As Integer = 3
    Private _current_passengers As Integer = 0
    Private _current_score = 0
    Private _max_lives = 5

    Public Property current_fuel As Integer
        Get
            Return _current_fuel
        End Get
        Set(value As Integer)
            _current_fuel = value
        End Set
    End Property

    Public Property max_fuel As Integer
        Get
            Return _max_fuel
        End Get
        Set(value As Integer)
            _max_fuel = value
        End Set
    End Property

    Public Property max_passengers As Integer
        Get
            Return _max_passengers
        End Get
        Set(value As Integer)
            _max_passengers = value
        End Set
    End Property

    Public Property current_score As Integer
        Get
            Return _current_score
        End Get
        Set(value As Integer)
            _current_score = value
        End Set
    End Property

    Public Property current_passengers As Integer
        Get
            Return _current_passengers
        End Get
        Set(value As Integer)
            _current_passengers = value
        End Set
    End Property

    Public Property max_lives As Integer
        Get
            Return _max_lives
        End Get
        Set(value As Integer)
            _max_lives = value
        End Set
    End Property


    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer)
        MyBase.New(name, type, posx, posy, width, height)
    End Sub

    Public Sub AddFuel(fuel_amount As Double)
        Me.current_fuel += fuel_amount

        If Me.current_fuel < 0 Then
            Me.current_fuel = 0
        ElseIf Me.current_fuel > Me.max_fuel Then
            Me.current_fuel = Me.max_fuel
        End If

    End Sub
    Public Sub AddPassenger(passenger As Swimmer)
        If current_passengers < max_passengers And passenger.Visible And passenger.Tag <> "dead" Then
            current_passengers += 1
            current_score += passenger.points
            passenger.ChangeDirection(0, 0)
            passenger.Location = New Point(Me.Width + passenger.Width, passenger.Location.Y)
            passenger.Visible = False
        End If
    End Sub
End Class