Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_ComisDet
    Dim c_ComisDet As New Cls_ComisDet
    Public Function set_ComisDet_Save(ByVal c_Entidades As Ent_ComisDet)
        Return c_ComisDet.sca_ComisDet_SAVE(c_Entidades)
    End Function
    Public Function set_ComisModifica_Save(ByVal c_Entidades As Ent_ComisDet)
        Return c_ComisDet.Sca_Comision_Modificar(c_Entidades)
    End Function
    Public Function get_ComisDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_ComisDet.Sca_ComisDet_Datos(Cadena, vOpt)
    End Function
End Class
