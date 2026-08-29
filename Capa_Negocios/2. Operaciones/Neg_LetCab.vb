Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_LetCab
    Dim c_Letras As New Cls_LetCab
    Public Function set_LetCab_Save(ByVal c_Entidades As Ent_LetCab, ByVal Emp As String)
        Return c_Letras.Sca_LetCab_Save(c_Entidades, Emp)
    End Function
    Public Function get_LetCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_Letras.Sca_LetCab_Datos(Cadena, vOpt, Emp)
    End Function
End Class
