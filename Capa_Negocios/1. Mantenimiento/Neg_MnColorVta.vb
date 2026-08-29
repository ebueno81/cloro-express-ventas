Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_MnColorVta
    Dim c_colorVta As New Cls_MnLstPrecios
    Public Function set_ColorVta_Save(ByVal c_Entidades As Ent_MnLstPrecios)
        Return c_colorVta.set_ColorVta_Save(c_Entidades)
    End Function
    Public Function get_ColorVta_Dgv(ByVal Cadena As String) As DataTable
        Return c_colorVta.Get_ColoresVta_Grid(Cadena)
    End Function
    Public Function get_ColorVta_Datos(ByVal Cadena As String) As DataTable
        Return c_colorVta.Get_ColoresVta_Datos(Cadena)
    End Function
End Class
