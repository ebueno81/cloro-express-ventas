Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnMtMov
    Dim c_MtMov As New Cls_MnMtMov
    Public Function set_MnMtMov_Save(ByVal c_Entidades As Ent_MnMtMov)
        Return c_MtMov.set_MtMovSal(c_Entidades)
    End Function
    Public Function get_MtMov_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_MtMov.Get_MtMov_Datos(Cadena, vOpt)
    End Function
    Public Function get_MtMov_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_MtMov.Get_Cargar_MtMov_Cbo(Cadena, Combo)
    End Function
End Class
