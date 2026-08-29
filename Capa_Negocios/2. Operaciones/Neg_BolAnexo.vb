Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_BolAnexo
    Dim c_BolAnexo As New Cls_BolAnexo
    Public Function set_BolAnexo_Save(ByVal c_Entidades As Ent_BolAnexo)
        Return c_BolAnexo.sca_BolAnexo_SAVE(c_Entidades)
    End Function
    Public Function get_BolAnexo_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_BolAnexo.Sca_BolAnexo_Datos(Cadena, vOpt)
    End Function
End Class
