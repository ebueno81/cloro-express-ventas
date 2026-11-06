Public Class Ent_ApiContrato

    Private _IdContrato As Integer
    Private _CodigoContrato As String
    Private _CodigoCliente As String
    Private _FechaInicio As Nullable(Of DateTime)
    Private _FechaFin As Nullable(Of DateTime)
    Private _Moneda As String
    Private _MontoMensual As Nullable(Of Decimal)
    Private _Estado As Nullable(Of Integer)
    Private _Observacion As String
    Private _Ubicaciones As List(Of Ent_ApiUbicacion)

    Public Sub New()
        _Ubicaciones = New List(Of Ent_ApiUbicacion)
    End Sub

    Public Property IdContrato() As Integer
        Get
            Return _IdContrato
        End Get
        Set(ByVal value As Integer)
            _IdContrato = value
        End Set
    End Property

    Public Property CodigoContrato() As String
        Get
            Return _CodigoContrato
        End Get
        Set(ByVal value As String)
            _CodigoContrato = value
        End Set
    End Property

    Public Property CodigoCliente() As String
        Get
            Return _CodigoCliente
        End Get
        Set(ByVal value As String)
            _CodigoCliente = value
        End Set
    End Property

    Public Property FechaInicio() As Nullable(Of DateTime)
        Get
            Return _FechaInicio
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FechaInicio = value
        End Set
    End Property

    Public Property FechaFin() As Nullable(Of DateTime)
        Get
            Return _FechaFin
        End Get
        Set(ByVal value As Nullable(Of DateTime))
            _FechaFin = value
        End Set
    End Property

    Public Property Moneda() As String
        Get
            Return _Moneda
        End Get
        Set(ByVal value As String)
            _Moneda = value
        End Set
    End Property

    Public Property MontoMensual() As Nullable(Of Decimal)
        Get
            Return _MontoMensual
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            _MontoMensual = value
        End Set
    End Property

    Public Property Estado() As Nullable(Of Integer)
        Get
            Return _Estado
        End Get
        Set(ByVal value As Nullable(Of Integer))
            _Estado = value
        End Set
    End Property

    Public Property Observacion() As String
        Get
            Return _Observacion
        End Get
        Set(ByVal value As String)
            _Observacion = value
        End Set
    End Property

    Public Property Ubicaciones() As List(Of Ent_ApiUbicacion)
        Get
            Return _Ubicaciones
        End Get
        Set(ByVal value As List(Of Ent_ApiUbicacion))
            _Ubicaciones = value
        End Set
    End Property

End Class