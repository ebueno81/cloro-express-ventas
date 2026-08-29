Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnVendedor
    Dim c_Vendedor As New Cls_MnVendedor
    Public Function set_Cliente_Save(ByVal c_Entidades As Ent_MnVendedor)
        Return c_Vendedor.sca_Vendedor_Save(c_Entidades)
    End Function
    Public Function get_Vendedor_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Vendedor.Get_Vendedor_Datos(Cadena, vOpt)
    End Function
    'Cargamos a combo
    Public Function get_Vendedor_Combo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Return c_Vendedor.get_Vendedor_Cbo(Cadena, Combo1)
    End Function
End Class
