Imports Capa_Acceso
Public Class Neg_RptKdxPartida
    Dim c_RptKdxPartida As New Cls_RptKdxPartida
    Public Function get_RptKdxPartida_Rpt(ByVal Cadena As String) As DataTable
        Return c_RptKdxPartida.Get_AlmKdxPartida_Rpt(Cadena)
    End Function
    Public Function get_RptKdxPartida_DGV(ByVal Cadena As String) As DataTable
        Return c_RptKdxPartida.Get_AlmKdxPartida_Dgv(Cadena)
    End Function

End Class
