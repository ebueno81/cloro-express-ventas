Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnSeriesGuias
    Dim c_Series As New Cls_MnSeriesGuias
    Public Function set_Series_Save(ByVal c_Entidades As Ent_MnSeriesGuia, ByVal Emp As String)
        Return c_Series.set_Series_Save(c_Entidades, Emp)
    End Function
    Public Function get_Series_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_Series.Get_Series_Datos(Cadena, vOpt, Emp)
    End Function
    'Cargamos a 1 combo
    Public Function get_Series_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox, ByVal Emp As String)
        Return c_Series.get_Series_Cbo(Cadena, Combo1, Emp)
    End Function
End Class
