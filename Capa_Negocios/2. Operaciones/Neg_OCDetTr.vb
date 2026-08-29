Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OCDetTr
    Dim c_OCDetTr As New Cls_OCDetTR
    Public Function get_OCDetTr_Dgv(ByVal Cadena As String) As DataTable
        'Return c_OC.Get_OC_GRID(Cadena)
    End Function
    Public Function get_OCDetTr_Datos(ByVal Cadena As String) As DataTable
        Return c_OCDetTr.Get_OCDetTR_Datos(Cadena)
    End Function
End Class
