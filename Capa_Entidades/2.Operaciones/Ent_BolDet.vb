Public Class Ent_BolDet
    Dim _c_nro_correl As String
    Dim _c_nro_serie As String
    Dim _c_nro_boleta As String
    Dim _c_nro_lote As String
    Dim _c_codi_articulo As String
    Dim _c_codi_unimed As String
    Dim _c_cant_caja As Integer
    Dim _c_nro_cant As Decimal
    Dim _c_prec_venta As Decimal
    Dim _c_total_bol As Decimal
    Dim _c_opc_afecto As Integer
    Dim _c_correl_guia As String
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
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
    Public Property c_nro_lote() As String
        Get
            Return _c_nro_lote
        End Get
        Set(ByVal value As String)
            _c_nro_lote = value
        End Set
    End Property
    Public Property c_codi_articulo() As String
        Get
            Return _c_codi_articulo
        End Get
        Set(ByVal value As String)
            _c_codi_articulo = value
        End Set
    End Property
    Public Property c_codi_unimed() As String
        Get
            Return _c_codi_unimed
        End Get
        Set(ByVal value As String)
            _c_codi_unimed = value
        End Set
    End Property
    Public Property c_cant_caja() As Integer
        Get
            Return _c_cant_caja
        End Get
        Set(ByVal value As Integer)
            _c_cant_caja = value
        End Set
    End Property
    Public Property c_nro_cant() As Decimal
        Get
            Return _c_nro_cant
        End Get
        Set(ByVal value As Decimal)
            _c_nro_cant = value
        End Set
    End Property
    Public Property c_prec_venta() As Decimal
        Get
            Return _c_prec_venta
        End Get
        Set(ByVal value As Decimal)
            _c_prec_venta = value
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
    Public Property c_opc_afecto() As Integer
        Get
            Return _c_opc_afecto
        End Get
        Set(ByVal value As Integer)
            _c_opc_afecto = value
        End Set
    End Property
    Public Property c_correl_guia() As String
        Get
            Return _c_correl_guia
        End Get
        Set(ByVal value As String)
            _c_correl_guia = value
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
