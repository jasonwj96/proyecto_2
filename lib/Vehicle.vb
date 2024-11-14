Public Class Vehicle
    Inherits GameEntity

    Private _max_fuel As Integer = 350 'Tamaño en pixeles de la barra de combustible
    Private _current_fuel As Integer = 350 'Tamaño en pixeles de la barra de combustible

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

End Class
