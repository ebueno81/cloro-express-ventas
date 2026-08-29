Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactAnexo
    Dim c_FactAnexo As New Cls_FactAnexo
    Public Function set_FactAnexo_Save(ByVal c_Entidades As Ent_FactAnexo)
        Return c_FactAnexo.sca_FactAnexo_SAVE(c_Entidades)
    End Function
    Public Function get_FactAnexo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_FactAnexo.Sca_FactAnexo_Datos(Cadena, vOpt)
    End Function
End Class
