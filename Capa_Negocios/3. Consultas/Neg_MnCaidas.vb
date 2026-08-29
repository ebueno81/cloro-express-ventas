Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnCaidas
    Dim c_Caidas As New Cls_MnCaidas
    Public Function get_Caidas_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Caidas.Get_Caidas_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Caidas_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Caidas.Get_Cargar_Caidas_Cbo(Cadena, Combo)
    End Function
End Class
