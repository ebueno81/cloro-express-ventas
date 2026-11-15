Public Class Ent_EstadoCuentaContrato

    Public Property IdContrato As Integer
    Public Property CodigoContrato As String

    Public Property CodigoCliente As String
    Public Property NombreCliente As String

    Public Property FechaInicioContrato As Date
    Public Property FechaFinContrato As Date

    Public Property NroCuota As Integer

    Public Property PeriodoDesde As Date
    Public Property PeriodoHasta As Date

    Public Property Ubicaciones As String

    Public Property SerieOT As String
    Public Property NroOT As String

    Public Property Estado As String

    Public Property SerieFactura As String
    Public Property NumeroFactura As String
    Public Property FechaEmision As Nullable(Of Date)

    Public Property Moneda As String
    Public Property Monto As Decimal

End Class