Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactElectCab
    Dim c_FactElectCab As New Cls_FactElectCab
    Public Function set_FactElectCab_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_codi_doc As String,
                                          ByVal vOpt As String)
        Return c_FactElectCab.sca_FactElectCab_Save(c_nro_serie, c_nro_factura, c_codi_doc, vOpt)
    End Function
    Public Function get_FactGuia_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_FactElectCab.Get_FactElectCab_Datos(Cadena, vOpt)
    End Function
    Public Function get_FactElectronico_Datos(ByVal c_nro_serie As String, ByVal c_nro_doc As String, ByVal c_codi_doc As String,
                                           ByVal Copcion As String) As DataTable
        Return c_FactElectCab.Get_FactElectronico_Datos(c_nro_serie, c_nro_doc, c_codi_doc, Copcion)
    End Function
End Class
