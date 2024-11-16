Public Class Vehicle
    Inherits GameEntity

    Private _max_fuel As Integer = 1 'Tamaño en pixeles de la barra de combustible
    Private _current_fuel As Integer = 1 'Tamaño en pixeles de la barra de combustible

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

    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer)
        MyBase.New(name, type, posx, posy, width, height)
    End Sub

    Public Sub AddFuel(fuel_amount As Integer)
        If fuel_amount >= 0 And fuel_amount <= max_fuel Then
            Me.current_fuel = fuel_amount
        End If
    End Sub
End Class
