Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_Apertura
    Dim c_Apertura As New Cls_Apertura
    Public Function set_Apertura_Save(ByVal c_Entidades As Ent_Apertura)
        Return c_Apertura.sca_Apertura_SAVE(c_Entidades)
    End Function
    Public Function get_Apertura_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Apertura.Sca_Apertura_Datos(Cadena, vOpt)
    End Function
End Class
