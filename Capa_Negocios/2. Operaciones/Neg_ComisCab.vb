Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_ComisCab
    Dim c_ComisCab As New Cls_ComisCab
    Public Function set_ComisCab_Save(ByVal c_Entidades As Ent_ComisCab)
        Return c_ComisCab.sca_ComisCab_SAVE(c_Entidades)
    End Function
    Public Function set_ComisFactor_Save(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date)
        Return c_ComisCab.sca_ComisFactorDoc_SAVE(c_fecha_inicio, c_fecha_final)
    End Function
    Public Function get_ComisCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_ComisCab.Sca_ComisCab_Datos(Cadena, vOpt)
    End Function
End Class
