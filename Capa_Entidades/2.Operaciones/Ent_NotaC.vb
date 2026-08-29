Public Class Ent_NotaC
    Dim _c_nro_serie As String
    Dim _c_nro_nc As String
    Dim _c_codi_clie As String
    Dim _c_codi_mon As String
    Dim _c_codi_doc As String
    Dim _c_fecha_emi As Date
    Dim _c_fecha_doc As Date
    Dim _c_tpo_cambio As Decimal
    Dim _c_serie_doc As String
    Dim _c_nro_factura As String
    Dim _c_nro_boleta As String
    Dim _c_nro_nd As String
    Dim _c_total_doc As Decimal
    Dim _c_imp_nc As Decimal
    Dim _c_imp_igv As Decimal
    Dim _c_imp_total As Decimal
    Dim _c_cant_igv As Decimal
    Dim _c_motivo_nc As String
    Dim _c_letras_nc As String
    Dim _c_tpo_motivo As String
    Dim _c_opc_inaf As Integer
    Dim _c_opc_exporta As Integer
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
    Public Property c_nro_nc() As String
        Get
            Return _c_nro_nc
        End Get
        Set(ByVal value As String)
            _c_nro_nc = value
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
    Public Property c_codi_doc() As String
        Get
            Return _c_codi_doc
        End Get
        Set(ByVal value As String)
            _c_codi_doc = value
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
    Public Property c_fecha_doc() As Date
        Get
            Return _c_fecha_doc
        End Get
        Set(ByVal value As Date)
            _c_fecha_doc = value
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
    Public Property c_serie_doc() As String
        Get
            Return _c_serie_doc
        End Get
        Set(ByVal value As String)
            _c_serie_doc = value
        End Set
    End Property
    Public Property c_nro_factura() As String
        Get
            Return _c_nro_factura
        End Get
        Set(ByVal value As String)
            _c_nro_factura = value
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
    Public Property c_nro_nd() As String
        Get
            Return _c_nro_nd
        End Get
        Set(ByVal value As String)
            _c_nro_nd = value
        End Set
    End Property
    Public Property c_total_doc() As Decimal
        Get
            Return _c_total_doc
        End Get
        Set(ByVal value As Decimal)
            _c_total_doc = value
        End Set
    End Property
    Public Property c_imp_nc() As Decimal
        Get
            Return _c_imp_nc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_nc = value
        End Set
    End Property
    Public Property c_imp_igv() As Decimal
        Get
            Return _c_imp_igv
        End Get
        Set(ByVal value As Decimal)
            _c_imp_igv = value
        End Set
    End Property
    Public Property c_imp_total() As Decimal
        Get
            Return _c_imp_total
        End Get
        Set(ByVal value As Decimal)
            _c_imp_total = value
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
    Public Property c_letras_nc() As String
        Get
            Return _c_letras_nc
        End Get
        Set(ByVal value As String)
            _c_letras_nc = value
        End Set
    End Property
    Public Property c_motivo_nc() As String
        Get
            Return _c_motivo_nc
        End Get
        Set(ByVal value As String)
            _c_motivo_nc = value
        End Set
    End Property
    Public Property c_tpo_motivo() As String
        Get
            Return _c_tpo_motivo
        End Get
        Set(ByVal value As String)
            _c_tpo_motivo = value
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
    Public Property c_opc_exporta() As Integer
        Get
            Return _c_opc_exporta
        End Get
        Set(ByVal value As Integer)
            _c_opc_exporta = value
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
