Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnStatusLetra
    Dim c_MnStatusLetra As New Cls_MnStatusLetra
    'Cargamos Registros al ComboBox...
    Public Function Get_StatusLetra_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_MnStatusLetra.Get_Cargar_StatusLetra_Cbo(Cadena, Combo)
    End Function
End Class
