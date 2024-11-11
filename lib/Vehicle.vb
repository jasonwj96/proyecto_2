Public Class Vehicle
    Inherits GameEntity

    Public Sub New(name As String, type As EntityType, posx As Integer, posy As Integer, width As Integer, height As Integer)
        MyBase.New(name, type, posx, posy, width, height)
    End Sub

End Class
