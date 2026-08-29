Imports Capa_Acceso
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Neg_MnTransporte
    Dim c_Transporte As New Cls_MnTransporte
    Public Function set_Transporte_Save(ByVal c_Entidades As Ent_MnTransporte)
        Return c_Transporte.set_Transporte_Save(c_Entidades)
    End Function
    Public Function get_Transporte_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Transporte.Get_Transporte_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Transporte_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Transporte.Get_Cargar_Transporte_Cbo(Cadena, Combo)
    End Function
End Class
