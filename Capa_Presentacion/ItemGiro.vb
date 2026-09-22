Public Class ItemGiro

    Public IdGiro As Integer
    Public Descripcion As String
    Public Modo As String

    Public Overrides Function ToString() As String
        Return Descripcion
    End Function

End Class