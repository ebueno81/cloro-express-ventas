Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactCuota
    Dim c_FactCuota As New Cls_FactCouta
    Public Function set_FactCuota_Save(ByVal c_Entidades As Ent_FactCuota)
        Return c_FactCuota.sca_FactCuota_SAVE(c_Entidades)
    End Function
    Public Function get_FactCuota_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_FactCuota.Sca_FactCuota_Datos(Cadena, vOpt)
    End Function
End Class
