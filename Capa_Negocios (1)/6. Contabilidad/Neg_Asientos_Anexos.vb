Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_Asientos_Anexos
    Dim c_Concar_anexos As New Cls_Asientos_Anexos
    Public Function set_Asientos_anexos_Save(ByVal c_Entidades As Ent_Asientos_Anexos)
        Return c_Concar_anexos.sca_Concar_Anexos_Save(c_Entidades)
    End Function
    Public Function get_AsientosCab_Datos(ByVal Cadena As String) As DataTable
        Return c_Concar_anexos.get_Concar_Anexos_Datos(Cadena)
    End Function
End Class
