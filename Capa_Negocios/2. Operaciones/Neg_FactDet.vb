Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_FactDet
    Dim c_FactDet As New Cls_FactDet
    Public Function set_FactDet_Save(ByVal c_Entidades As Ent_FactDet, ByVal Emp As String)
        Return c_FactDet.sca_FactDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_FactDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_FactDet.Get_FactDet_Datos(Cadena, vOpt, Emp)
    End Function

End Class
