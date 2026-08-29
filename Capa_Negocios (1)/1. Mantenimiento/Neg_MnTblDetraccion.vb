Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTblDetraccion
    Dim _cDatos As New Cls_MnTblDetraccion
    Public Function get_MntblDetraccion_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return _cDatos.Get_Detraccion_Datos(Cadena, vOpt)
    End Function
    Public Function Get_MntblDetraccion_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        _cDatos.Get_Cargar_TblDetraccion_Cbo(Cadena, Combo)
    End Function
End Class
