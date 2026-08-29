Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnGamaCol
    Dim c_GamaCol As New Cls_MnGamaCol
    Public Function get_GamaCol_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_GamaCol.Get_GamaCol_Datos(Cadena, vOpt)
    End Function
    'Cargamos a combo
    Public Function get_GamaCol_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        Return c_GamaCol.get_GamaCol_Cbo(Cadena, Combo1)
    End Function
End Class
