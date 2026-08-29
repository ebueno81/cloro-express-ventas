Public Class Ent_RetenCab
    Dim _c_nro_ing As String
    Dim _c_nro_serie As String
    Dim _c_nro_reten As String
    Dim _c_direc_reten As String
    Dim _c_fecha_emi As Date
    Dim _c_fecha_prd As Date
    Dim _c_codi_clie As String
    Dim _c_codi_mon As String
    Dim _c_total_doc As Decimal
    Dim _c_total_reten As Decimal
    Dim _c_letras_reten As String
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_ing() As String
        Get
            Return _c_nro_ing
        End Get
        Set(ByVal value As String)
            _c_nro_ing = value
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
    Public Property c_nro_reten() As String
        Get
            Return _c_nro_reten
        End Get
        Set(ByVal value As String)
            _c_nro_reten = value
        End Set
    End Property
    Public Property c_direc_reten() As String
        Get
            Return _c_direc_reten
        End Get
        Set(ByVal value As String)
            _c_direc_reten = value
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
    Public Property c_fecha_emi() As Date
        Get
            Return _c_fecha_emi
        End Get
        Set(ByVal value As Date)
            _c_fecha_emi = value
        End Set
    End Property
    Public Property c_fecha_prd() As Date
        Get
            Return _c_fecha_prd
        End Get
        Set(ByVal value As Date)
            _c_fecha_prd = value
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
    Public Property c_total_reten() As Decimal
        Get
            Return _c_total_reten
        End Get
        Set(ByVal value As Decimal)
            _c_total_reten = value
        End Set
    End Property
    Public Property c_letras_reten() As String
        Get
            Return _c_letras_reten
        End Get
        Set(ByVal value As String)
            _c_letras_reten = value
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
