Imports Capa_Acceso

Public Class Neg_Conexion

    Private Datos As New Cls_Conexion

    Public Function GetTipoConexion() As String
        Return Datos.GetTipoConexion()
    End Function

    Public Sub GuardarTipoConexion(ByVal tipo As String)
        Datos.GuardarTipoConexion(tipo)
    End Sub

    Public Function LeerConfiguracion(ByVal clave As String) As String
        Return Datos.LeerConfiguracion(clave)
    End Function

    Public Function GetServidorActual() As String
        Return Datos.GetServidorActual()
    End Function

    Public Function GetServidorReportes() As String
        Return Datos.GetServidorReportes()
    End Function

    Public Function GetConexionSql() As String
        Return Datos.GetConexion_Sql()
    End Function

    Public Function ProbarConexion(ByRef mensaje As String) As Boolean
        Return Datos.ProbarConexion(mensaje)
    End Function
End Class
