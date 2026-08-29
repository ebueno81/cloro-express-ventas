Public Class Ent_MnSeriesDoc
    Dim _c_codi_doc As String
    Dim _c_nro_serie As String
    Dim _c_nro_doc As String
    Dim _c_desc_serie As String
    Dim _copcion As String
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
    Public Property c_desc_serie() As String
        Get
            Return _c_desc_serie
        End Get
        Set(ByVal value As String)
            _c_desc_serie = value
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
