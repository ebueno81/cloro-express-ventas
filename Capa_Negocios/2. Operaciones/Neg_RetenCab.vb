Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_RetenCab
    Dim c_RetenCab As New Cls_RetenCab
    Public Function set_RetenCab_Save(ByVal c_Entidades As Ent_RetenCab, ByVal c_codi_emp As String)
        Return c_RetenCab.Sca_RetenCab_Save(c_Entidades, c_codi_emp)
    End Function
    Public Function get_RetenCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal c_codi_emp As String) As DataTable
        Return c_RetenCab.Get_RetenCab_Datos(Cadena, vOpt, c_codi_emp)
    End Function
    Public Function get_RetenCab_Rpt(ByVal c_codi_clie As String, ByVal vOpt As String, ByVal c_fecha_inicio As Date) As DataTable
        Return c_RetenCab.Get_RetenCab_Rpt(c_codi_clie, vOpt, c_fecha_inicio)
    End Function
    Public Function get_RetenFact_Rpt(ByVal c_codi_clie As String, ByVal vOpt As String) As DataTable
        Return c_RetenCab.Get_RetenFact_Rpt(c_codi_clie, vOpt)
    End Function

End Class
