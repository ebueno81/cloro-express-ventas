Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnUniMed
    Dim c_UniMed As New Cls_MnUniMed
    Public Function get_UniMed_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_UniMed.Get_UniMed_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_UniMed_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_UniMed.Get_Cargar_Linea_Cbo(Cadena, Combo)
    End Function
End Class
