Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactGuia
    Dim c_FactGuia As New Cls_FactGuia
    Public Function set_FactGuia_Save(ByVal c_Entidades As Ent_FactGuia, ByVal Emp As String)
        Return c_FactGuia.sca_FactGuia_Save(c_Entidades, Emp)
    End Function
    Public Function get_FactGuia_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_FactGuia.Get_FactGuia_Datos(Cadena, vOpt, Emp)
    End Function
End Class
