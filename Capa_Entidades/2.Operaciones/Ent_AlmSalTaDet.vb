Public Class Ent_AlmSalTaDet
    Private _c_nro_correl As String
    Private _c_nro_serie As String
    Private _c_nro_salidaTA As String
    Private _c_nro_lote As String
    Private _c_opt_fraccion As Integer
    Private _c_codi_articulo As String
    Private _c_codi_unimed As String
    Private _c_nro_cant As Decimal
    Private _c_cant_caja As Integer
    Private _c_cant_fraccion As String
    Private _c_prec_unit As Decimal
    Private _c_imp_total As Decimal
    Private _c_codi_mon As String
    Private _c_correl_ing As String
    Private _c_obs As String
    Private _copcion As String
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
    Public Property c_nro_salidaTA() As String
        Get
            Return _c_nro_salidaTA
        End Get
        Set(ByVal value As String)
            _c_nro_salidaTA = value
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
    Public Property c_opt_fraccion() As Integer
        Get
            Return _c_opt_fraccion
        End Get
        Set(ByVal value As Integer)
            _c_opt_fraccion = value
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
    Public Property c_nro_cant() As Decimal
        Get
            Return _c_nro_cant
        End Get
        Set(ByVal value As Decimal)
            _c_nro_cant = value
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
    Public Property c_cant_fraccion() As String
        Get
            Return _c_cant_fraccion
        End Get
        Set(ByVal value As String)
            _c_cant_fraccion = value
        End Set
    End Property
    Public Property c_prec_unit() As Decimal
        Get
            Return _c_prec_unit
        End Get
        Set(ByVal value As Decimal)
            _c_prec_unit = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
        End Set
    End Property
    Public Property c_correl_ing() As String
        Get
            Return _c_correl_ing
        End Get
        Set(ByVal value As String)
            _c_correl_ing = value
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
    Public Property copcion() As String
        Get
            Return _copcion
        End Get
        Set(ByVal value As String)
            _copcion = value
        End Set
    End Property

End Class
