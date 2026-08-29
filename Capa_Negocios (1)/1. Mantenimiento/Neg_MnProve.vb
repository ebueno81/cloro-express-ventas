Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnProve
    Dim c_Proveedor As New Cls_MnProve
    Public Function get_Prove_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Proveedor.Get_Proveedor_Datos(Cadena, vOpt)
    End Function
    Public Function get_MtProve_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_Proveedor.Get_Cargar_MtProve_Cbo(Cadena, Combo)
    End Function
End Class
