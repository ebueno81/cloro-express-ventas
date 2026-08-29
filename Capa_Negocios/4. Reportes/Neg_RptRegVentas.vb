Imports Capa_Acceso
Public Class Neg_RptRegVentas
    Dim c_RptRegVentas As New Cls_RptRegVentas
    Public Function get_RptRegVentas_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, ByVal c_codi_mon As String) As DataTable
        Return c_RptRegVentas.Get_RptRegVentasas_Rpt(Cadena, Fecha_Inicio, Fecha_final, c_codi_mon)
    End Function
    Public Function get_RptVtasTiendas_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date) As DataTable
        Return c_RptRegVentas.Get_RptVtasTiendas_Rpt(Fecha_Inicio, Fecha_final)
    End Function

End Class
