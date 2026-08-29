Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTurno
    Dim c_Turno As New Cls_MnTurno
    Public Function get_Turno_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Turno.Get_Turno_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Turno_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Turno.Get_Cargar_Turno_Cbo(Cadena, Combo)
    End Function
End Class
