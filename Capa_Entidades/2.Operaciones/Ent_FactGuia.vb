Public Class Ent_FactGuia
    Dim _c_nro_correl As String
    Dim _c_serie_guia As String
    Dim _c_nro_guia As String
    Dim _c_serie_factura As String
    Dim _c_nro_factura As String
    Dim _c_fecha_emi As Date
    Dim _c_total_guia As Decimal
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_serie_guia() As String
        Get
            Return _c_serie_guia
        End Get
        Set(ByVal value As String)
            _c_serie_guia = value
        End Set
    End Property
    Public Property c_nro_guia() As String
        Get
            Return _c_nro_guia
        End Get
        Set(ByVal value As String)
            _c_nro_guia = value
        End Set
    End Property
    Public Property c_serie_factura() As String
        Get
            Return _c_serie_factura
        End Get
        Set(ByVal value As String)
            _c_serie_factura = value
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
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
        End Set
    End Property
    Public Property c_total_guia() As Decimal
        Get
            Return _c_total_guia
        End Get
        Set(ByVal value As Decimal)
            _c_total_guia = value
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
