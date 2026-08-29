Imports Capa_Acceso
Public Class Neg_ConStockPartida
    Dim c_AlmStockPartida As New Cls_ConStockPartida
    Public Function get_AlmStockPartida_DGV(ByVal Cadena As String) As DataTable
        Return c_AlmStockPartida.Get_AlmStockPartida_Dgv(Cadena)
    End Function
    Public Function get_AlmStockPartida2_DGV(ByVal Cadena As String) As DataTable
        Return c_AlmStockPartida.Get_AlmStockPartida_Dgv2(Cadena)
    End Function
    'Stock valorizado
    Public Function get_AlmStockPartValor_DGV(ByVal Cadena As String) As DataTable
        Return c_AlmStockPartida.Get_AlmStockPartValor_Dgv(Cadena)
    End Function
End Class
