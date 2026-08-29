Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_Asientos_Cab
    Dim c_AsientosCab As New Cls_Asientos_Cab
    Public Function get_AsientosCab_Datos(ByVal c_codi_doc As String, ByVal c_Fecha_Inicio As Date, ByVal c_Fecha_final As Date) As DataTable
        Return c_AsientosCab.get_AsientosCab_Datos(c_codi_doc, c_Fecha_Inicio, c_Fecha_final)
    End Function
    Public Function set_AsientosCab_Save(ByVal c_nro_Serie As String, ByVal c_nro_factura As String, ByVal c_nro_concar As String, _
                                         ByVal c_codi_doc As String, ByVal cOpcion As String)
        Return c_AsientosCab.Sca_AsientosCab_Save(c_nro_Serie, c_nro_factura, c_nro_concar, c_codi_doc, cOpcion)
    End Function
End Class
