Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnAreas
    Dim c_Areas As New Cls_MnAreas
    Public Function get_Areas_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Areas.Get_Areas_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Areas_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Areas.Get_Cargar_Areas_Cbo(Cadena, Combo)
    End Function
End Class
