Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_Retencion
    Dim c_Retencion As New Cls_Retencion
    Public Function get_Retencion_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Retencion.Get_Retencion_Datos(Cadena, vOpt)
    End Function
    Public Function get_Retencion_Liberar(ByVal c_nro_correl As String, ByVal vOpt As String) As DataTable
        Return c_Retencion.Get_Retencion_Liberar(c_nro_correl, vOpt)
    End Function
End Class
