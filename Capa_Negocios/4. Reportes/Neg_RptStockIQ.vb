Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_RptStockIQ
    Dim c_RptStockIQ As New Cls_RptStockIQ
    Public Function get_StockIQ_Datos(ByVal Cadena As String, ByVal c_año_stock As Integer, ByVal c_mes_stocck As Integer, _
                                      ByVal c_codi_alm As String, ByVal c_codi_mon As String, ByVal vOpt As String) As DataTable
        Return c_RptStockIQ.Get_StockIQ_Datos(Cadena, c_año_stock, c_mes_stocck, c_codi_alm, c_codi_mon, vOpt)
    End Function
    
End Class
