Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Modulos
    Dim c_Modulos As New Cls_Modulos
    
    Public Function get_Modulos_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Modulos.Get_Modulos_Datos(Cadena, vOpt)
    End Function
    Public Function set_Usuario_Save(ByVal c_Entidades As Ent_Modulos)
        Return c_Modulos.set_Modulos_Save(c_Entidades)
    End Function
End Class
