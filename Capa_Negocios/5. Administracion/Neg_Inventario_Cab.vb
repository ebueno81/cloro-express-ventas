Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Inventario_Cab
    Dim c_Inventario_Cab As New Cls_Inventario_Cab
    Public Function set_Inventario_Cab_Save(ByVal c_Entidades As Ent_Inventario_Cab)
        Return c_Inventario_Cab.set_Inventario_Cab_SAVE(c_Entidades)
    End Function
    Public Function get_Inventario_Cab_Datos(ByVal Cadena As String) As DataTable
        Return c_Inventario_Cab.Get_Inventario_Cab_Datos(Cadena)
    End Function
    Public Function get_Inventario_Tot_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Inventario_Cab.Get_Inventario_Tot_Datos(Cadena, vOpt)
    End Function
End Class
