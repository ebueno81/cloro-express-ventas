Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTeñido
    Dim c_Teñido As New Cls_MnTeñido
    Public Function get_Teñido_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Teñido.Get_Teñido_Datos(Cadena, vOpt)
    End Function
    'Cargamos Tela a dos combos
    Public Function get_Teñido_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Return c_Teñido.get_Teñido_Cbo(Cadena, Combo1)
    End Function
End Class
