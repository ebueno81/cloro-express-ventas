Public Class Ent_BolCab
    Dim _c_nro_serie As String
    Dim _c_nro_boleta As String
    Dim _c_codi_mon As String
    Dim _c_tpo_cambio As Decimal
    Dim _c_cant_igv As Decimal
    Dim _c_codi_clie As String
    Dim _c_codi_vende As String
    Dim _c_codi_pago As String
    Dim _c_tpo_venta As String

    Dim _c_fecha_emi As Date
    Dim _c_fecha_venci As Date
    Dim _c_motivo_anula As String
    Dim _c_rollos_bol As Integer
    Dim _c_peso_bol As Decimal
    Dim _c_venta_bol As Decimal
    Dim _c_dscto_bol As Decimal
    Dim _c_total_bol As Decimal
    Dim _c_obs As String
    Dim _c_opc_detrac As Integer
    Dim _c_detracc_bol As Decimal
    Dim _c_detracc_por As Decimal
    Dim _c_letras_bol As String
    Dim _c_opc_inaf As Integer

    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
        End Set
    End Property
    Public Property c_nro_boleta() As String
        Get
            Return _c_nro_boleta
        End Get
        Set(ByVal value As String)
            _c_nro_boleta = value
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
    Public Property c_tpo_cambio() As Decimal
        Get
            Return _c_tpo_cambio
        End Get
        Set(ByVal value As Decimal)
            _c_tpo_cambio = value
        End Set
    End Property
    Public Property c_cant_igv() As Decimal
        Get
            Return _c_cant_igv
        End Get
        Set(ByVal value As Decimal)
            _c_cant_igv = value
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
    Public Property c_codi_vende() As String
        Get
            Return _c_codi_vende
        End Get
        Set(ByVal value As String)
            _c_codi_vende = value
        End Set
    End Property
    Public Property c_codi_pago() As String
        Get
            Return _c_codi_pago
        End Get
        Set(ByVal value As String)
            _c_codi_pago = value
        End Set
    End Property
    Public Property c_tpo_venta() As String
        Get
            Return _c_tpo_venta
        End Get
        Set(ByVal value As String)
            _c_tpo_venta = value
        End Set
    End Property
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
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
    Public Property c_motivo_anula() As String
        Get
            Return _c_motivo_anula
        End Get
        Set(ByVal value As String)
            _c_motivo_anula = value
        End Set
    End Property
    Public Property c_rollos_bol() As Integer
        Get
            Return _c_rollos_bol
        End Get
        Set(ByVal value As Integer)
            _c_rollos_bol = value
        End Set
    End Property
    Public Property c_peso_bol() As Decimal
        Get
            Return _c_peso_bol
        End Get
        Set(ByVal value As Decimal)
            _c_peso_bol = value
        End Set
    End Property
    Public Property c_venta_bol() As Decimal
        Get
            Return _c_venta_bol
        End Get
        Set(ByVal value As Decimal)
            _c_venta_bol = value
        End Set
    End Property
    Public Property c_dscto_bol() As Decimal
        Get
            Return _c_dscto_bol
        End Get
        Set(ByVal value As Decimal)
            _c_dscto_bol = value
        End Set
    End Property
    Public Property c_total_bol() As Decimal
        Get
            Return _c_total_bol
        End Get
        Set(ByVal value As Decimal)
            _c_total_bol = value
        End Set
    End Property
    Public Property c_obs() As String
        Get
            Return _c_obs
        End Get
        Set(ByVal value As String)
            _c_obs = value
        End Set
    End Property
    Public Property c_opc_detrac() As Integer
        Get
            Return _c_opc_detrac
        End Get
        Set(ByVal value As Integer)
            _c_opc_detrac = value
        End Set
    End Property
    Public Property c_detracc_bol() As Decimal
        Get
            Return _c_detracc_bol
        End Get
        Set(ByVal value As Decimal)
            _c_detracc_bol = value
        End Set
    End Property
    Public Property c_detracc_por() As Decimal
        Get
            Return _c_detracc_por
        End Get
        Set(ByVal value As Decimal)
            _c_detracc_por = value
        End Set
    End Property
    Public Property c_letras_bol() As String
        Get
            Return _c_letras_bol
        End Get
        Set(ByVal value As String)
            _c_letras_bol = value
        End Set
    End Property
    Public Property c_opc_inaf() As Integer
        Get
            Return _c_opc_inaf
        End Get
        Set(ByVal value As Integer)
            _c_opc_inaf = value
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
