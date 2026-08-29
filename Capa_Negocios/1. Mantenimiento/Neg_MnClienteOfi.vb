Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnClienteOfi
    Dim c_ClienteOfi As New Cls_MnClienteOfi
    Public Function get_ClienteOfi_Save(ByVal c_Entidades As Ent_MnClienteOfi)
        Return c_ClienteOfi.sca_ClienteOfi_Save(c_Entidades)
    End Function
    Public Function get_ClienteOfi_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_ClienteOfi.Get_ClienteOfi_Datos(Cadena, vOpt)
    End Function
    'Cargamos clientes al Combo
    Public Function get_ClienteOfi_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Return c_ClienteOfi.get_ClienteOfi_Cbo(Cadena, Combo1)
    End Function
End Class
