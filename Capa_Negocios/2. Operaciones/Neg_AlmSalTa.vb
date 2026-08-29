Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmSalTa
    Dim c_AlmSalTa As New Cls_AlmSalTa
    Public Function set_AlmSalTa_Save(ByVal c_Entidades As Ent_AlmSalTa, ByVal Emp As String)
        Return c_AlmSalTa.set_AlmSalTa_Save(c_Entidades, Emp)
    End Function
    Public Function set_GuiaElectronica_Save(c_nro_serie As String, c_nro_guia As String, coptabla As String, vOpt As String) As DataTable
        Return c_AlmSalTa.set_GuiaElectronica_Save(c_nro_serie, c_nro_guia, coptabla, vOpt)
    End Function
    Public Function get_AlmSalTa_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_AlmSalTa.Get_AlmSalTa_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_GuiaElectronica_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTa.Get_GuiaElectronica_Datos(Cadena, vOpt)
    End Function
    Public Function get_AlmSalTa_Rpt(ByVal c_nro_serie As String, ByVal c_nro_salidaTa As String, ByVal c_nro_ingreso As String, ByVal c_fecha_inicio As Date, _
                                     ByVal c_fecha_final As Date, ByVal c_codi_clie As String, ByVal c_anula_reg As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTa.Get_AlmSalTa_Rpt(c_nro_serie, c_nro_salidaTa, c_nro_ingreso, c_fecha_inicio, c_fecha_final, c_codi_clie, c_anula_reg, vOpt)
    End Function
End Class
