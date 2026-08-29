Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmSalTaAnexo
    Dim c_CapaDatos As New Cls_AlmSalTaAnexo
    Public Function set_Registro_Save(ByVal c_Entidades As Ent_AlmSalTaAnexo, ByVal vOpt As String)
        Return c_CapaDatos.set_Registro_Save(c_Entidades, vOpt)
    End Function
    Public Function get_Registro_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_CapaDatos.Get_Registro_Datos(Cadena, vOpt)
    End Function


End Class
