Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnBcos
    Dim c_Bcos As New Cls_MnBcos
    Public Function get_Bcos_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Bcos.Get_Bcos_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Bcos_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Bcos.Get_Cargar_Bcos_Cbo(Cadena, Combo)
    End Function
End Class
