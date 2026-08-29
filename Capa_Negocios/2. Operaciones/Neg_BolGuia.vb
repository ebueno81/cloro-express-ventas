Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_BolGuia
    Dim c_BolGuia As New Cls_BolGuia
    Public Function set_BolGuia_Save(ByVal c_Entidades As Ent_BolGuia, ByVal Emp As String)
        Return c_BolGuia.sca_BolGuia_Save(c_Entidades, Emp)
    End Function
    Public Function get_BolGuia_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_BolGuia.Get_BolGuia_Datos(Cadena, vOpt, Emp)
    End Function
End Class
