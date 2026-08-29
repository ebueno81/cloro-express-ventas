Public Class Ent_FactCuota
    Dim _c_nro_correl As Integer
    Dim _c_nro_serie As String
    Dim _c_nro_doc As String
    Dim _c_fecha_cuota As String
    Dim _c_monto_cuota As Decimal
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_nro_correl() As Integer
        Get
            Return _c_nro_correl
        End Get
        Set(ByVal value As Integer)
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
    Public Property c_nro_doc() As String
        Get
            Return _c_nro_doc
        End Get
        Set(ByVal value As String)
            _c_nro_doc = value
        End Set
    End Property
    Public Property c_fecha_cuota() As Date
        Get
            Return _c_fecha_cuota
        End Get
        Set(ByVal value As Date)
            _c_fecha_cuota = value
        End Set
    End Property
    Public Property c_monto_cuota() As Decimal
        Get
            Return _c_monto_cuota
        End Get
        Set(ByVal value As Decimal)
            _c_monto_cuota = value
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
