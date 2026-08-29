Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_MnIgv
    Dim c_Neg_MnIgv As New Cls_MnIGV
    Public Function get_Igv_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Neg_MnIgv.Get_Igv_Datos(Cadena, vOpt)
    End Function
    Public Function set_IGV_Save(ByVal c_Entidades As Ent_MnIgv)
        Return c_Neg_MnIgv.set_IGV_Save(c_Entidades)
    End Function
End Class

