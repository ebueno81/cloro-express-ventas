Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmTransforDet
    Dim c_AlmTranforDet As New Cls_AlmTransforDet
    Public Function set_AlmTransforDet_Save(ByVal c_Entidades As Ent_AlmTransforDet)
        Return c_AlmTranforDet.set_AlmTransforDet_Save(c_Entidades)
    End Function
    Public Function set_AlmTransforDetCoeficiente_Save(ByVal c_nro_transforma As String, ByVal c_nro_coeficiente As Decimal)
        Return c_AlmTranforDet.set_AlmTransforDetCoeficiente_Save(c_nro_transforma, c_nro_coeficiente)
    End Function
    Public Function get_AlmTransforDet_Datos(ByVal c_nro_transforma As String, ByVal vOpt As String) As DataTable
        Return c_AlmTranforDet.Get_AlmTransforDet_Datos(c_nro_transforma, vOpt)
    End Function
    Public Function get_AlmTransforDet_Rpt(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String,
                                           ByVal c_codi_cd As String, ByVal c_codi_Articulo As String,
                                            ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        Return c_AlmTranforDet.Get_AlmTransforDet_Rpt(c_fecha_inicio, c_fecha_final, c_codi_tg, c_codi_cd, c_codi_Articulo, c_codi_alm, vOpt)
    End Function

End Class
