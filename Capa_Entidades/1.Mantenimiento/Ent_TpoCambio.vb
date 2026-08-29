Public Class Ent_TpoCambio
    Dim _c_fecha_cbo As Date
    Dim _c_compra_sunat As Decimal
    Dim _c_venta_sunat As Decimal
    Public Property c_fecha_cbo() As Date
        Get
            Return _c_fecha_cbo
        End Get
        Set(ByVal value As Date)
            _c_fecha_cbo = value
        End Set
    End Property
    Public Property c_compra_sunat() As Decimal
        Get
            Return _c_compra_sunat
        End Get
        Set(ByVal value As Decimal)
            _c_compra_sunat = value
        End Set
    End Property
    Public Property c_venta_sunat() As Decimal
        Get
            Return _c_venta_sunat
        End Get
        Set(ByVal value As Decimal)
            _c_venta_sunat = value
        End Set
    End Property
End Class
