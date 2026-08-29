Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_LetDet
    Dim c_LetDet As New Cls_LetDet
    Public Function set_LetDet_Save(ByVal c_Entidades As Ent_LetDet, ByVal Emp As String)
        Return c_LetDet.Sca_LetDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_LetDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_LetDet.Sca_LetDet_Datos(Cadena, vOpt, Emp)
    End Function
End Class
