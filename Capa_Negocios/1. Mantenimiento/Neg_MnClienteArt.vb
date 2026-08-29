Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnClienteArt
    Dim c_ClienteArt As New Cls_MnClienteArt
    Public Function get_ClienteArt_Save(ByVal c_Entidades As Ent_MnClienteArt)
        Return c_ClienteArt.sca_ClienteArt_Save(c_Entidades)
    End Function
    Public Function get_ClienteArt_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_ClienteArt.Get_ClienteArt_Datos(Cadena, vOpt)
    End Function

End Class
