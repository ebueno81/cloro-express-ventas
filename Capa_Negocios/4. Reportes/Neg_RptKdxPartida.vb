Imports Capa_Acceso
Public Class Neg_RptKdxGral
    Dim c_RptKdxGral As New Cls_RptKdxGral
    Public Function get_RptKdxGral_Rpt(ByVal Cadena As String) As DataTable
        'Return c_RptKdxgral.Get_AlmKdxGral_Rpt(Cadena)
    End Function
    Public Function get_RptKdxPartida_DGV(ByVal Cadena As String) As DataTable
        Return c_RptKdxGral.Get_AlmKdxGral_Dgv(Cadena)
    End Function

End Class
