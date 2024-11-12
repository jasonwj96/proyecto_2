Public Class Vehicle
    Inherits GameEntity

    Private _fuel As Integer = 650 'Tamaño en pixeles de la barra de combustible

    Public Property fuel As Integer
        Get
            Return _fuel
        End Get
        Set(value As Integer)
            _fuel = value
        End Set
    End Property


    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer)
        MyBase.New(name, type, posx, posy, width, height)
    End Sub

End Class
