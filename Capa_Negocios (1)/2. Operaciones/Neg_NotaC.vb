Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_NotaC
    Dim c_NotaC As New Cls_NotaC
    Public Function set_NotaC_Save(ByVal c_Entidades As Ent_NotaC, ByVal Emp As String)
        Return c_NotaC.sca_NotaC_SAVE(c_Entidades, Emp)
    End Function
    Public Function get_NotaC_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_NotaC.Sca_NotaC_Datos(Cadena, vOpt, Emp)
    End Function
End Class
