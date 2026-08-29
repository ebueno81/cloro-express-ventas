Public Class Ent_MnIgv
    Dim _c_codi_igv As String
    Dim _c_por_igv As Decimal
    Dim _c_fecha_emi As Date
    Dim _c_usuario As String
    Dim _copcion As String
    Public Property c_codi_igv() As String
        Get
            Return _c_codi_igv
        End Get
        Set(ByVal value As String)
            _c_codi_igv = value
        End Set
    End Property
    Public Property c_por_igv() As Decimal
        Get
            Return _c_por_igv
        End Get
        Set(ByVal value As Decimal)
            _c_por_igv = value
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
