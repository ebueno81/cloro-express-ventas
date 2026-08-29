Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_Scaidas
    Dim c_sCaidas As New Cls_MnSCaidas
    Public Function get_sCaidas_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_sCaidas.Get_SCaidas_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_sCaidas_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_sCaidas.Get_Cargar_SCaidas_Cbo(Cadena, Combo)
    End Function
End Class
