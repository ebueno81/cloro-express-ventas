Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_IngAlmIQDet
    Dim c_IngAlmDetIQ As New Cls_IngAlmIQDet
    Public Function get_IngAlmIQDet_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        Return c_IngAlmDetIQ.Get_IngAlmDet_DATOS(Cadena, c_codi_emp, vOpt)
    End Function
End Class
