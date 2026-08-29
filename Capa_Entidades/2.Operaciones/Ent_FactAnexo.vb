Public Class Ent_FactAnexo
    Dim _c_nro_correl As Integer
    Dim _c_nro_serie As String
    Dim _c_nro_factura As String
    Dim _c_total_factura As String
    Dim _c_serie_anexo As String
    Dim _c_factura_anexo As String
    Dim _c_monto_anexo As Decimal
    Dim _c_obs As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_correl() As Integer
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As Integer)
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
    Public Property c_nro_factura() As String
        Get
            Return _c_nro_factura
        End Get
        Set(ByVal value As String)
            _c_nro_factura = value
        End Set
    End Property
    Public Property c_total_factura() As Decimal
        Get
            Return _c_total_factura
        End Get
        Set(ByVal value As Decimal)
            _c_total_factura = value
        End Set
    End Property
    Public Property c_serie_anexo() As String
        Get
            Return _c_serie_anexo
        End Get
        Set(ByVal value As String)
            _c_serie_anexo = value
        End Set
    End Property
    Public Property c_factura_anexo() As String
        Get
            Return _c_factura_anexo
        End Get
        Set(ByVal value As String)
            _c_factura_anexo = value
        End Set
    End Property
    Public Property c_monto_anexo() As Decimal
        Get
            Return _c_monto_anexo
        End Get
        Set(ByVal value As Decimal)
            _c_monto_anexo = value
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
