Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OC
    Dim c_OC As New Cls_OC
    Public Function get_OC_Dgv(ByVal Cadena As String) As DataTable
        Return c_OC.Get_OC_GRID(Cadena)
    End Function
    Public Function get_OC_Datos(ByVal Cadena As String) As DataTable
        Return c_OC.Get_OC_Datos(Cadena)
    End Function
End Class
