Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Usuario
    Dim c_Usuarios As New Cls_Usuarios
    Public Function get_Usuario_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Usuarios.Get_Usuario_Datos(Cadena, vOpt)
    End Function
    Public Function set_Usuario_Save(ByVal c_Entidades As Ent_Usuario)
        Return c_Usuarios.sca_Usuario_Save(c_Entidades)
    End Function
    'Accesos por medio del Menu...
    Public Function set_UsuaPermiso_Save(ByVal c_Entidades As Ent_UsuaPermiso)
        Return c_Usuarios.sca_UsuaPermiso_Save(c_Entidades)
    End Function
    Public Function get_UsuaPermiso_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Usuarios.Get_UsuaPermiso_Datos(Cadena, vOpt)
    End Function
    Public Function get_UsuaAcceso_Datos(ByVal Cadena As String) As DataTable
        Return c_Usuarios.Get_Usuarios_Acceso(Cadena)
    End Function
End Class
