Public Class Ent_LetDet
    Dim _c_nro_liq As String
    Dim _c_año_liq As Integer
    Dim _c_sist_bahia As Integer
    Dim _c_nro_doc As String
    Dim _c_codi_doc As String
    Dim _c_codi_mon As String
    Dim _c_nro_serie As String
    Dim _c_nro_factura As String
    Dim _c_nro_boleta As String
    Dim _c_nro_nd As String
    Dim _c_imp_doc As Decimal
    Dim _c_cant_detracc As Decimal
    Dim _c_nro_letra As String
    Dim _c_renov_letra As Integer
    Dim _c_opc_apertura As Integer
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
    Public Property c_nro_doc() As String
        Get
            Return _c_nro_doc
        End Get
        Set(ByVal value As String)
            _c_nro_doc = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
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
    Public Property c_imp_doc() As Decimal
        Get
            Return _c_imp_doc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_doc = value
        End Set
    End Property
    Public Property c_cant_detracc() As Decimal
        Get
            Return _c_cant_detracc
        End Get
        Set(ByVal value As Decimal)
            _c_cant_detracc = value
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
    Public Property c_opc_apertura() As Integer
        Get
            Return _c_opc_apertura
        End Get
        Set(ByVal value As Integer)
            _c_opc_apertura = value
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
