Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_Liquidac
    Dim c_Liquidac As New Cls_Liquidac
    Public Function set_Liquidac_Save(ByVal c_Entidades As Ent_Liquidac, ByVal Emp As String)
        Return c_Liquidac.Sca_Liquidac_Save(c_Entidades, Emp)
    End Function
    Public Function get_Liquidac_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_Liquidac.Sca_Liquidac_Datos(Cadena, vOpt, Emp)
    End Function
End Class
