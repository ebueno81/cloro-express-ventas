Public Class Ent_LetCab
    Dim _c_nro_liq As String
    Dim _c_año_liq As Integer
    Dim _c_sist_bahia As Integer
    Dim _c_nro_letra As String
    Dim _c_renov_letra As Integer
    Dim _c_codi_clie As String
    Dim _c_codi_mon As String
    Dim _c_codi_stletra As String
    Dim _c_valor_letra As String
    Dim _c_nro_dias As Integer
    Dim _c_tpo_cambio As Decimal
    Dim _c_fecha_giro As Date
    Dim _c_fecha_venci As Date
    Dim _c_fecha_presenta As Date
    Dim _c_codi_bco As String
    Dim _c_motivo_anula As String
    Dim _c_cancel_letra As Integer
    Dim _c_imp_letra As Decimal
    Dim _c_fiador_letra As String
    Dim _c_aval_letra As String
    Dim _c_direcc_letra As String
    Dim _c_dni_letra As String
    Dim _c_telf_letra As String
    Dim _c_rep_letra As String
    Dim _c_num_unico As String
    Dim _c_nro_cuenta As String
    Dim _c_sector_bco As String
    Dim _c_imp_pago As Decimal
    Dim _c_porc_pago As Decimal
    Dim _c_fecha_cancel As Date
    Dim _c_pagado_clie As Integer
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_liq() As String
        Get
            Return _c_nro_liq
        End Get
        Set(ByVal value As String)
            _c_nro_liq = value
        End Set
    End Property
    Public Property c_año_liq() As Integer
        Get
            Return _c_año_liq
        End Get
        Set(ByVal value As Integer)
            _c_año_liq = value
        End Set
    End Property
    Public Property c_sist_bahia() As Integer
        Get
            Return _c_sist_bahia
        End Get
        Set(ByVal value As Integer)
            _c_sist_bahia = value
        End Set
    End Property
    Public Property c_nro_letra() As String
        Get
            Return _c_nro_letra
        End Get
        Set(ByVal value As String)
            _c_nro_letra = value
        End Set
    End Property
    Public Property c_renov_letra() As Integer
        Get
            Return _c_renov_letra
        End Get
        Set(ByVal value As Integer)
            _c_renov_letra = value
        End Set
    End Property
    Public Property c_codi_clie() As String
        Get
            Return _c_codi_clie
        End Get
        Set(ByVal value As String)
            _c_codi_clie = value
        End Set
    End Property
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_codi_stletra() As String
        Get
            Return _c_codi_stletra
        End Get
        Set(ByVal value As String)
            _c_codi_stletra = value
        End Set
    End Property
    Public Property c_valor_letra() As String
        Get
            Return _c_valor_letra
        End Get
        Set(ByVal value As String)
            _c_valor_letra = value
        End Set
    End Property
    Public Property c_nro_dias() As Integer
        Get
            Return _c_nro_dias
        End Get
        Set(ByVal value As Integer)
            _c_nro_dias = value
        End Set
    End Property
    Public Property c_tpo_cambio() As Decimal
        Get
            Return _c_tpo_cambio
        End Get
        Set(ByVal value As Decimal)
            _c_tpo_cambio = value
        End Set
    End Property
    Public Property c_fecha_giro() As Date
        Get
            Return _c_fecha_giro
        End Get
        Set(ByVal value As Date)
            _c_fecha_giro = value
        End Set
    End Property
    Public Property c_fecha_venci() As Date
        Get
            Return _c_fecha_venci
        End Get
        Set(ByVal value As Date)
            _c_fecha_venci = value
        End Set
    End Property
    Public Property c_fecha_presenta() As Date
        Get
            Return _c_fecha_presenta
        End Get
        Set(ByVal value As Date)
            _c_fecha_presenta = value
        End Set
    End Property
    Public Property c_codi_bco() As String
        Get
            Return _c_codi_bco
        End Get
        Set(ByVal value As String)
            _c_codi_bco = value
        End Set
    End Property
    Public Property c_motivo_anula() As String
        Get
            Return _c_motivo_anula
        End Get
        Set(ByVal value As String)
            _c_motivo_anula = value
        End Set
    End Property
    Public Property c_cancel_letra() As Integer
        Get
            Return _c_cancel_letra
        End Get
        Set(ByVal value As Integer)
            _c_cancel_letra = value
        End Set
    End Property
    Public Property c_imp_letra() As Decimal
        Get
            Return _c_imp_letra
        End Get
        Set(ByVal value As Decimal)
            _c_imp_letra = value
        End Set
    End Property
    Public Property c_fiador_letra() As String
        Get
            Return _c_fiador_letra
        End Get
        Set(ByVal value As String)
            _c_fiador_letra = value
        End Set
    End Property
    Public Property c_aval_letra() As String
        Get
            Return _c_aval_letra
        End Get
        Set(ByVal value As String)
            _c_aval_letra = value
        End Set
    End Property
    Public Property c_direcc_letra() As String
        Get
            Return _c_direcc_letra
        End Get
        Set(ByVal value As String)
            _c_direcc_letra = value
        End Set
    End Property
    Public Property c_dni_letra() As String
        Get
            Return _c_dni_letra
        End Get
        Set(ByVal value As String)
            _c_dni_letra = value
        End Set
    End Property
    Public Property c_telf_letra() As String
        Get
            Return _c_telf_letra
        End Get
        Set(ByVal value As String)
            _c_telf_letra = value
        End Set
    End Property
    Public Property c_rep_letra() As String
        Get
            Return _c_rep_letra
        End Get
        Set(ByVal value As String)
            _c_rep_letra = value
        End Set
    End Property
    Public Property c_num_unico() As String
        Get
            Return _c_num_unico
        End Get
        Set(ByVal value As String)
            _c_num_unico = value
        End Set
    End Property
    Public Property c_nro_cuenta() As String
        Get
            Return _c_nro_cuenta
        End Get
        Set(ByVal value As String)
            _c_nro_cuenta = value
        End Set
    End Property
    Public Property c_sector_bco() As String
        Get
            Return _c_sector_bco
        End Get
        Set(ByVal value As String)
            _c_sector_bco = value
        End Set
    End Property
    Public Property c_imp_pago() As Decimal
        Get
            Return _c_imp_pago
        End Get
        Set(ByVal value As Decimal)
            _c_imp_pago = value
        End Set
    End Property
    Public Property c_porc_pago() As Decimal
        Get
            Return _c_porc_pago
        End Get
        Set(ByVal value As Decimal)
            _c_porc_pago = value
        End Set
    End Property
    Public Property c_fecha_cancel() As Date
        Get
            Return _c_fecha_cancel
        End Get
        Set(ByVal value As Date)
            _c_fecha_cancel = value
        End Set
    End Property
    Public Property c_pagado_clie() As Integer
        Get
            Return _c_pagado_clie
        End Get
        Set(ByVal value As Integer)
            _c_pagado_clie = value
        End Set
    End Property
    Public Property c_usuario() As String
        Get
            Return _c_usuario
        End Get
        Set(ByVal value As String)
            _c_usuario = value
        End Set
    End Property
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property

End Class
