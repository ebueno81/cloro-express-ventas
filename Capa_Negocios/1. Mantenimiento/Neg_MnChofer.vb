Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnChofer
    Dim c_Chofer As New Cls_MnChofer
    Public Function get_Chofer_Save(ByVal c_Entidades As Ent_MnChofer)
        Return c_Chofer.sca_Chofer_Save(c_Entidades)
    End Function
    Public Function get_Chofer_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Chofer.Get_Chofer_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Chofer_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Chofer.Get_Chofer_Cbo(Cadena, Combo)
    End Function
End Class
