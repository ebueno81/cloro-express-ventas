Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_NotaD
    Dim c_NotaD As New Cls_NotaD
    Public Function set_NotaD_Save(ByVal c_Entidades As Ent_NotaD, ByVal Emp As String)
        Return c_NotaD.sca_NotaD_SAVE(c_Entidades, Emp)
    End Function
    Public Function get_NotaD_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_NotaD.Sca_NotaD_Datos(Cadena, vOpt, Emp)
    End Function
End Class
