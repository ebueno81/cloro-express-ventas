Imports Capa_Entidades : Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTpoDoc
    Dim c_MnTpoDoc As New Cls_MnTpoDoc
    Public Function get_TpoDoc_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_MnTpoDoc.Get_TpoDoc_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_TpoDoc_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_MnTpoDoc.Get_Cargar_TpoDoc_Cbo(Cadena, Combo)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_TpoDoc_Lsb(ByVal Cadena As String, ByVal Tipo As Integer, ByVal LstBox As ListBox)
        c_MnTpoDoc.Get_Cargar_TpoDoc_Lsb(Cadena, Tipo, LstBox)
    End Function
End Class
