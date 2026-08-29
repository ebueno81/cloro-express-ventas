Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactElectDet
    Dim c_FactElectDet As New Cls_FactElectDet
    Public Function set_FactElectDet_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_codi_doc As String,
                                          ByVal vOpt As String)
        Return c_FactElectDet.sca_FactElectDet_Save(c_nro_serie, c_nro_factura, c_codi_doc, vOpt)
    End Function
    Public Function get_FactElectDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_FactElectDet.Get_FactElectDet_Datos(Cadena, vOpt)
    End Function
End Class
