Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_BolCab
    Dim c_BolCab As New Cls_BolCab
    Public Function set_BolCab_Save(ByVal c_Entidades As Ent_BolCab, ByVal Emp As String)
        Return c_BolCab.Sca_BolCab_Save(c_Entidades, Emp)
    End Function
    Public Function set_BolCabAsientos_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal Ccompro As String, ByVal Copcion As String)
        Return c_BolCab.Sca_BolCabAsientos_Save(c_nro_serie, c_nro_factura, Ccompro, Copcion)
    End Function

    Public Function get_BolCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_BolCab.Get_BolCab_Datos(Cadena, vOpt, Emp)
    End Function

End Class
