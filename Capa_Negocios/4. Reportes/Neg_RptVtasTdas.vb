Imports Capa_Acceso
Public Class Neg_RptVtasTdas
    Dim c_RptVtasTdas As New Cls_RptVtasTdas
    Public Function get_RptVtasTdas_Rpt(ByVal Cadena As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, _
                                        ByVal c_codi_mon As String) As DataTable
        Return c_RptVtasTdas.Get_RptVtasTdas_Rpt(Cadena, c_fecha_inicio, c_fecha_final, c_codi_mon)
    End Function
    Public Function get_Comision_Dat(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RptVtasTdas.Get_Comision_Dat(Cadena, vOpt, Emp)
    End Function
    Public Function get_RegVentas_Dat(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_RptVtasTdas.Get_RegVentas_Rpt(Cadena, vOpt)
    End Function
    Public Function get_RegEstadoCuentas_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_clie As String,
                                            ByVal vOpt As String) As DataTable
        Return c_RptVtasTdas.Get_RptEstadoCuenta_Rpt(Fecha_Inicio, Fecha_Final, c_codi_clie, vOpt)
    End Function
End Class
