Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmSalTaDet
    Dim c_AlmSalTaDet As New Cls_AlmSalTaDet
    Public Function set_AlmSalTaDet_Save(ByVal c_Entidades As Ent_AlmSalTaDet, ByVal Emp As String)
        Return c_AlmSalTaDet.set_AlmSalTaDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_AlmSalTaDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalTaDet_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_AlmSalEnvases_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String, _
                                            ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, _
                                            ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                            ByVal c_nro_guia As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalEnvases_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_mt, c_codi_linea, c_codi_familia, c_codi_sfamilia, _
                                                   c_codi_articulo, c_serie_guia, c_nro_guia, vOpt)
    End Function
    Public Function get_AlmSalArt_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                           ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                           ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                           ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                        ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalArt_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_mt, c_codi_linea, c_codi_familia, c_codi_sfamilia,
                                                   c_codi_articulo, c_serie_guia, c_nro_guia, c_codi_mon, c_opc_noingsal, c_codi_alm, vOpt)
    End Function
    Public Function get_AlmSalArtValor_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                           ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                           ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                           ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                             ByVal c_opc_transforma As String, ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalArtValor_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_mt, c_codi_linea, c_codi_familia, c_codi_sfamilia,
                                                   c_codi_articulo, c_serie_guia, c_nro_guia, c_codi_mon, c_opc_noingsal,
                                                      c_opc_transforma, c_codi_alm, vOpt)
    End Function
    Public Function get_AlmSalGerencial_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                           ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                           ByVal c_codi_scd As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalArtGerencial_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_tg, c_codi_cd, c_codi_scd,
                                                   vOpt)
    End Function
    Public Function get_AlmSalArtTotal_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String, _
                                          ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String, _
                                          ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                          ByVal c_nro_guia As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalArtTotal_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_mt, c_codi_linea, c_codi_familia, c_codi_sfamilia, _
                                                   c_codi_articulo, c_serie_guia, c_nro_guia, vOpt)
    End Function
    ' salida por cliente
    Public Function get_AlmSalClie_Datos(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_clie As String,
                                          ByVal c_codi_mt As String, ByVal c_codi_linea As String, ByVal c_codi_familia As String,
                                          ByVal c_codi_sfamilia As String, ByVal c_codi_articulo As String, ByVal c_serie_guia As String,
                                          ByVal c_nro_guia As String, ByVal c_codi_mon As String, ByVal c_opc_noingsal As String,
                                         ByVal c_opc_transforma As String, ByVal c_codi_alm As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalClie_Datos(c_fecha_inicio, c_fecha_final, c_codi_clie, c_codi_mt, c_codi_linea, c_codi_familia, c_codi_sfamilia,
                                                   c_codi_articulo, c_serie_guia, c_nro_guia, c_codi_mon, c_opc_noingsal, c_opc_transforma,
                                                  c_codi_alm, vOpt)
    End Function
End Class
