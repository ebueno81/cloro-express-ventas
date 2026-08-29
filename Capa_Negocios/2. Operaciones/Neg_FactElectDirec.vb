Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_FactElectDirec
    Dim c_FactElectDirec As New Cls_FactElectDirec
    Public Function set_FactElectDirec_Save(ByVal c_nro_serie As String, ByVal c_nro_factura As String, ByVal c_codi_doc As String,
                                          ByVal vOpt As String)
        Return c_FactElectDirec.sca_FactElectDirec_Save(c_nro_serie, c_nro_factura, c_codi_doc, vOpt)
    End Function
    Public Function get_FactElecDirec_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_FactElectDirec.Get_FactElectDirec_Datos(Cadena, vOpt)
    End Function
End Class
