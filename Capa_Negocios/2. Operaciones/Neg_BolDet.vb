Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_BolDet
    Dim c_BolDet As New Cls_BolDet
    Public Function set_BolDet_Save(ByVal c_Entidades As Ent_BolDet, ByVal Emp As String)
        Return c_BolDet.sca_BolDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_BolDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_BolDet.Get_BolDet_Datos(Cadena, vOpt, Emp)
    End Function

End Class
