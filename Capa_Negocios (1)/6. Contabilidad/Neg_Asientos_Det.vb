Imports Capa_Acceso
Public Class Neg_Asientos_Det
    Dim c_AsientosDet As New Cls_Asientos_Det
    Public Function get_AsientosDet_Datos(ByVal Cadena As String) As DataTable
        Return c_AsientosDet.Get_AsientosDet_Datos(Cadena)
    End Function
    Public Function get_AsientosDet_Valida(ByVal N_Factura As String, ByVal Dif As Decimal, ByVal vOpt As String) As DataTable
        Return c_AsientosDet.Get_AsientosDet_Valida(N_Factura, Dif, vOpt)
    End Function
End Class
