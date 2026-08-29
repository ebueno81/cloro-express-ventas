Public Class Ent_ComisDet
    Dim _c_nro_correl As String
    Dim _c_nro_comis As String
    Dim _c_codi_doc As String
    Dim _c_serie_doc As String
    Dim _c_nro_doc As String
    Dim _c_fecha_emi As Date
    Dim _c_codi_mon As String
    Dim _c_codi_clie As String
    Dim _c_tpo_cambio As Decimal
    Dim _c_imp_doc As Decimal
    Dim _c_igv_doc As Decimal
    Dim _c_tot_doc As Decimal
    Dim _c_imp_comis As Decimal
    Dim _c_imp_saldo As Decimal
    Dim _c_desc_estado As String
    Dim _c_codi_vende As String
    Dim _c_porc_comis As Decimal
    Dim _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_comis() As String
        Get
            Return _c_nro_comis
        End Get
        Set(ByVal value As String)
            _c_nro_comis = value
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
    Public Property c_serie_doc() As String
        Get
            Return _c_serie_doc
        End Get
        Set(ByVal value As String)
            _c_serie_doc = value
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
    Public Property c_codi_clie() As String
        Get
            Return _c_codi_clie
        End Get
        Set(ByVal value As String)
            _c_codi_clie = value
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
    Public Property c_imp_doc() As Decimal
        Get
            Return _c_imp_doc
        End Get
        Set(ByVal value As Decimal)
            _c_imp_doc = value
        End Set
    End Property
    Public Property c_igv_doc() As Decimal
        Get
            Return _c_igv_doc
        End Get
        Set(ByVal value As Decimal)
            _c_igv_doc = value
        End Set
    End Property
    Public Property c_tot_doc() As Decimal
        Get
            Return _c_tot_doc
        End Get
        Set(ByVal value As Decimal)
            _c_tot_doc = value
        End Set
    End Property
    Public Property c_imp_comis() As Decimal
        Get
            Return _c_imp_comis
        End Get
        Set(ByVal value As Decimal)
            _c_imp_comis = value
        End Set
    End Property
    Public Property c_imp_saldo() As Decimal
        Get
            Return _c_imp_saldo
        End Get
        Set(ByVal value As Decimal)
            _c_imp_saldo = value
        End Set
    End Property
    Public Property c_desc_estado() As String
        Get
            Return _c_desc_estado
        End Get
        Set(ByVal value As String)
            _c_desc_estado = value
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
    Public Property c_porc_comis() As Decimal
        Get
            Return _c_porc_comis
        End Get
        Set(ByVal value As Decimal)
            _c_porc_comis = value
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
