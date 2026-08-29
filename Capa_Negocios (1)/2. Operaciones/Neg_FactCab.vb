Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_FactCab
    Dim c_FactCab As New Cls_FactCab
    Public Function set_FactCab_Save(ByVal c_Entidades As Ent_FactCab, ByVal Emp As String)
        Return c_FactCab.Sca_FactCab_Save(c_Entidades, Emp)
    End Function
    Public Function set_FactCabAsientos_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal Ccompro As String, ByVal Copcion As String)
        Return c_FactCab.Sca_FactCabAsientos_Save(c_nro_serie, c_nro_factura, Ccompro, Copcion)
    End Function
   
    Public Function get_FactCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_FactCab.Get_FactCab_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function set_FactElectronico_Save(ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String,
                                         ByVal Copcion As String)
        Return c_FactCab.Set_FactElectronico_Save(c_nro_serie, c_nro_doc, c_codi_doc, Copcion)
    End Function
End Class
