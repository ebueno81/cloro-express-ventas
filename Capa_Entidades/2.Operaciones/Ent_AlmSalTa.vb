Public Class Ent_AlmSalTa
    Private _c_nro_serie As String
    Private _c_nro_salidaTa As String
    Private _c_nro_ing As String
    Private _c_codi_clie As String
    Private _c_codi_prov As String
    Private _c_fecha_sal As Date
    Private _c_fecha_traslado As Date
    Private _c_nro_os As String

    Private _c_codi_alm As String
    Private _c_codi_mt As String
    Private _c_codi_placa As String
    Private _c_codi_ubigeo As String
    Private _c_codi_oficina As String
    Private _c_direcc_trp As String
    Private _c_dist_trp As String
    Private _c_prov_trp As String
    Private _c_dpto_trp As String
    Private _c_chofer_trp As String
    Private _c_ape_chofer As String
    Private _c_vehiculo_trp As String
    Private _c_color_trp As String
    Private _c_abrevcte_trp As String
    Private _c_desccte_trp As String
    Private _c_ruc_trp As String
    Private _c_nro_lic As String
    Private _c_nro_dni As String
    Private _c_peso_neto As Decimal
    Private _c_cajas_total As Integer
    Private _c_total_guia As Decimal
    Private _c_codi_doc As String
    Private _c_serie_doc As String
    Private _c_nro_doc As String
    Private _c_obs As String
    Private _c_usuario As String
    Private _copcion As String
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
            Return _c_nro_salidaTa
        End Get
        Set(ByVal value As String)
            _c_nro_salidaTa = value
        End Set
    End Property
    Public Property c_nro_ing() As String
        Get
            Return _c_nro_ing
        End Get
        Set(ByVal value As String)
            _c_nro_ing = value
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
    Public Property c_codi_prov() As String
        Get
            Return _c_codi_prov
        End Get
        Set(ByVal value As String)
            _c_codi_prov = value
        End Set
    End Property
    Public Property c_fecha_sal() As Date
        Get
            Return _c_fecha_sal
        End Get
        Set(ByVal value As Date)
            _c_fecha_sal = value
        End Set
    End Property
    Public Property c_fecha_traslado() As Date
        Get
            Return _c_fecha_traslado
        End Get
        Set(ByVal value As Date)
            _c_fecha_traslado = value
        End Set
    End Property
    Public Property c_nro_os() As String
        Get
            Return _c_nro_os
        End Get
        Set(ByVal value As String)
            _c_nro_os = value
        End Set
    End Property
    Public Property c_codi_alm() As String
        Get
            Return _c_codi_alm
        End Get
        Set(ByVal value As String)
            _c_codi_alm = value
        End Set
    End Property
    Public Property c_codi_mt() As String
        Get
            Return _c_codi_mt
        End Get
        Set(ByVal value As String)
            _c_codi_mt = value
        End Set
    End Property
    Public Property c_codi_placa() As String
        Get
            Return _c_codi_placa
        End Get
        Set(ByVal value As String)
            _c_codi_placa = value
        End Set
    End Property

    Public Property c_codi_ubigeo() As String
        Get
            Return _c_codi_ubigeo
        End Get
        Set(ByVal value As String)
            _c_codi_ubigeo = value
        End Set
    End Property
    Public Property c_codi_oficina() As String
        Get
            Return _c_codi_oficina
        End Get
        Set(ByVal value As String)
            _c_codi_oficina = value
        End Set
    End Property
    Public Property c_direcc_trp() As String
        Get
            Return _c_direcc_trp
        End Get
        Set(ByVal value As String)
            _c_direcc_trp = value
        End Set
    End Property
    Public Property c_dist_trp() As String
        Get
            Return _c_dist_trp
        End Get
        Set(ByVal value As String)
            _c_dist_trp = value
        End Set
    End Property

    Public Property c_prov_trp() As String
        Get
            Return _c_prov_trp
        End Get
        Set(ByVal value As String)
            _c_prov_trp = value
        End Set
    End Property
    Public Property c_dpto_trp() As String
        Get
            Return _c_dpto_trp
        End Get
        Set(ByVal value As String)
            _c_dpto_trp = value
        End Set
    End Property
    Public Property c_chofer_trp() As String
        Get
            Return _c_chofer_trp
        End Get
        Set(ByVal value As String)
            _c_chofer_trp = value
        End Set
    End Property
    Public Property c_ape_chofer() As String
        Get
            Return _c_ape_chofer
        End Get
        Set(ByVal value As String)
            _c_ape_chofer = value
        End Set
    End Property
    Public Property c_vehiculo_trp() As String
        Get
            Return _c_vehiculo_trp
        End Get
        Set(ByVal value As String)
            _c_vehiculo_trp = value
        End Set
    End Property
    Public Property c_color_trp() As String
        Get
            Return _c_color_trp
        End Get
        Set(ByVal value As String)
            _c_color_trp = value
        End Set
    End Property
    Public Property c_abrevcte_trp() As String
        Get
            Return _c_abrevcte_trp
        End Get
        Set(ByVal value As String)
            _c_abrevcte_trp = value
        End Set
    End Property
    Public Property c_desccte_trp() As String
        Get
            Return _c_desccte_trp
        End Get
        Set(ByVal value As String)
            _c_desccte_trp = value
        End Set
    End Property
    Public Property c_ruc_trp() As String
        Get
            Return _c_ruc_trp
        End Get
        Set(ByVal value As String)
            _c_ruc_trp = value
        End Set
    End Property
    Public Property c_nro_lic() As String
        Get
            Return _c_nro_lic
        End Get
        Set(ByVal value As String)
            _c_nro_lic = value
        End Set
    End Property
    Public Property c_nro_dni() As String
        Get
            Return _c_nro_dni
        End Get
        Set(ByVal value As String)
            _c_nro_dni = value
        End Set
    End Property
    Public Property c_peso_neto() As Decimal
        Get
            Return _c_peso_neto
        End Get
        Set(ByVal value As Decimal)
            _c_peso_neto = value
        End Set
    End Property
    Public Property c_cajas_total() As Decimal
        Get
            Return _c_cajas_total
        End Get
        Set(ByVal value As Decimal)
            _c_cajas_total = value
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
