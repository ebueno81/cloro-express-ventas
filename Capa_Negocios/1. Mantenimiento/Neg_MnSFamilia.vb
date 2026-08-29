Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnSFamilia
    Dim c_SFamilia As New Cls_MnSFamilia
    Public Function get_sfamilia_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_SFamilia.Get_SFamilia_Datos(Cadena, vOpt)
    End Function
    Public Function get_sFamilia_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_SFamilia.get_SFamilia_Cbo(Cadena, Combo)
    End Function
End Class
