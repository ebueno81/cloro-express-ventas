Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmTransforCab
    Dim c_AlmTransforCab As New Cls_AlmTransforCab
    Public Function get_AlmTransforCab_Datos(ByVal c_nro_transforma As String, ByVal vOpt As String) As DataTable
        Return c_AlmTransforCab.Get_AlmTransformaCab_Datos(c_nro_transforma, vOpt)
    End Function
    Public Function get_RptTransformaVentas_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String,
                                                ByVal c_codi_cd As String, ByVal c_codi_articulo As String, ByVal c_codi_alm As String,
                                                  ByVal vOpt As String) As DataTable
        Return c_AlmTransforCab.Get_RptTransformaVenta_Datos(c_fecha_inicio, c_fecha_final, c_codi_tg, c_codi_cd, c_codi_articulo, c_codi_alm, vOpt)
    End Function
End Class
