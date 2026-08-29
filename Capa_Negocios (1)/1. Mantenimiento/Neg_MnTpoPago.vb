Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTpoPago
    Dim c_mntpopago As New Cls_MnTpoPagos
    Public Function set_TpoPago_Save(ByVal c_Entidades As Ent_MnTpoPago)
        Return c_mntpopago.scom_TpoPago_Save(c_Entidades)
    End Function
    Public Function get_TpoPago_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_mntpopago.Get_TpoPago_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Fpago_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_mntpopago.get_Fpago_Cbo(Cadena, Combo)
    End Function
End Class
