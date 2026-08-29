Public Class Ent_AlmTransforDet
    Private _c_nro_correl As String
    Private _c_nro_tranforma As String
    Private _c_tpo_mov As String
    Private _c_codi_articulo As String
    Private _c_codi_mon As String
    Private _c_codi_unimed As String
    Private _c_nro_cant As String
    Private _c_prec_unit As String
    Private _c_imp_total As String
    Private _c_opc_transespecial As String
    Private _copcion As String
    Public Property c_nro_correl() As String
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As String)
            _c_nro_correl = value
        End Set
    End Property
    Public Property c_nro_transforma() As String
        Get
            Return _c_nro_tranforma
        End Get
        Set(ByVal value As String)
            _c_nro_tranforma = value
        End Set
    End Property
    Public Property c_tpo_mov() As String
        Get
            Return _c_tpo_mov
        End Get
        Set(ByVal value As String)
            _c_tpo_mov = value
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
    Public Property c_codi_mon() As String
        Get
            Return _c_codi_mon
        End Get
        Set(ByVal value As String)
            _c_codi_mon = value
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
    Public Property c_opc_transespecial() As String
        Get
            Return _c_opc_transespecial
        End Get
        Set(ByVal value As String)
            _c_opc_transespecial = value
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
