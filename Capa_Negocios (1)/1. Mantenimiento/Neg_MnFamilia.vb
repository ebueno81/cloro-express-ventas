Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnFamilia
    Dim c_Familia As New Cls_MnFamilia
    Public Function get_Familia_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Familia.Get_Familia_Datos(Cadena, vOpt)
    End Function
    'Cargamos Familia a un Combo
    Public Function get_Familia_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_Familia.get_Familia_Cbo(Cadena, Combo)
    End Function
  
End Class
