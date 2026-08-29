Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_ComisDocs
    Dim c_ComisDocs As New Cls_ComisDocs
    Public Function set_ComisDocs_Save(ByVal c_Entidades As Ent_ComisDocs)
        Return c_ComisDocs.sca_ComisDocs_SAVE(c_Entidades)
    End Function
    Public Function get_ComisDocs_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_ComisDocs.Sca_ComisDocs_Datos(Cadena, vOpt)
    End Function
End Class
