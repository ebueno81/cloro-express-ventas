Public Class Ent_AlmSalTaAnexo
    Private _c_nro_correl As Integer
    Private _c_serie_guia As String
    Private _c_nro_guia As String
    Private _c_codi_doc As String
    Private _c_nro_serie As String
    Private _c_nro_doc As String

    Public Property C_nro_correl As Integer
        Get
            Return _c_nro_correl
        End Get
        Set(value As Integer)
            _c_nro_correl = value
        End Set
    End Property

    Public Property C_serie_guia As String
        Get
            Return _c_serie_guia
        End Get
        Set(value As String)
            _c_serie_guia = value
        End Set
    End Property

    Public Property C_nro_guia As String
        Get
            Return _c_nro_guia
        End Get
        Set(value As String)
            _c_nro_guia = value
        End Set
    End Property

    Public Property C_codi_doc As String
        Get
            Return _c_codi_doc
        End Get
        Set(value As String)
            _c_codi_doc = value
        End Set
    End Property

    Public Property C_nro_serie As String
        Get
            Return _c_nro_serie
        End Get
        Set(value As String)
            _c_nro_serie = value
        End Set
    End Property

    Public Property C_nro_doc As String
        Get
            Return _c_nro_doc
        End Get
        Set(value As String)
            _c_nro_doc = value
        End Set
    End Property
End Class
