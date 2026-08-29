Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnIntenso
    Dim c_Intenso As New Cls_MnIntenso
    Public Function get_Intenso_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Intenso.Get_Intenso_Datos(Cadena, vOpt)
    End Function
    'Cargamos combo enlazado a Base de datos
    Public Function get_Intenso_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Return c_Intenso.get_Intenso_Cbo(Cadena, Combo1)
    End Function
End Class
