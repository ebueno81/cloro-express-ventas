Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Inventario_Det
    Dim c_Inventario_Det As New Cls_Inventario_Det
    Public Function set_Inventario_Det_Save(ByVal c_Entidades As Ent_Inventario_Det)
        Return c_Inventario_Det.set_Inventario_Det_SAVE(c_Entidades)
    End Function
    Public Function get_Inventario_Det_Datos(ByVal Cadena As String) As DataTable
        Return c_Inventario_Det.Get_Inventario_Det_Datos(Cadena)
    End Function
    Public Function get_Inventario_Det_Rpt(ByVal Cadena As String) As DataTable
        Return c_Inventario_Det.Get_Inventario_Det_Rpt(Cadena)
    End Function
End Class
