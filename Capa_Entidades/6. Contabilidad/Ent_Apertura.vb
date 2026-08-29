Public Class Ent_Apertura
    Dim _c_nro_apertura As String
    Dim _c_codi_doc As String
    Dim _c_nro_serie As String
    Dim _c_nro_doc As String
    Dim _c_codi_clie As String
    Dim _c_fecha_emi As Date
    Dim _c_codi_mon As String
    Dim _c_imp_doc As Decimal
    Dim _c_codi_bco As String
    Dim _c_codi_stletra As String
    Dim _c_pagado_clie As Integer
    Dim _c_opc_reten As Integer
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_apertura() As String
        Get
            Return _c_nro_apertura
        End Get
        Set(ByVal value As String)
            _c_nro_apertura = value
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
    Public Property c_nro_serie() As String
        Get
            Return _c_nro_serie
        End Get
        Set(ByVal value As String)
            _c_nro_serie = value
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
    Public Property c_codi_clie() As String
        Get
            Return _c_codi_clie
        End Get
        Set(ByVal value As String)
            _c_codi_clie = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
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
    Public Property c_codi_bco() As String
        Get
            Return _c_codi_bco
        End Get
        Set(ByVal value As String)
            _c_codi_bco = value
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
    Public Property c_pagado_clie() As Integer
        Get
            Return _c_pagado_clie
        End Get
        Set(ByVal value As Integer)
            _c_pagado_clie = value
        End Set
    End Property
    Public Property c_opc_reten() As Integer
        Get
            Return _c_opc_reten
        End Get
        Set(ByVal value As Integer)
            _c_opc_reten = value
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
