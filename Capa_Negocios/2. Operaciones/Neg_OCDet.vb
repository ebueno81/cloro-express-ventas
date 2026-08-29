Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OCDet
    Dim c_OCDet As New Cls_OCDet
    
    Public Function get_OCDet_Dgv(ByVal Cadena As String) As DataTable
        'Return c_OC.Get_OC_GRID(Cadena)
    End Function
    Public Function get_OCDet_Datos(ByVal Cadena As String) As DataTable
        Return c_OCDet.Get_OCDet_Datos(Cadena)
    End Function

    Public Function get_OCDetCosto_Datos(ByVal Cadena As String) As DataTable
        Return c_OCDet.Get_OCDetCostos_Datos(Cadena)
    End Function
End Class
