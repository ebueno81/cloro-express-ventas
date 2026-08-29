Public Class Ent_MnVendedor
    Private _c_codi_vende As String
    Private _c_nom_vende As String
    Private _c_dni_vende As String
    Private _c_direc_vende As String
    Private _c_dist_vende As String
    Private _c_telf_vende As String
    Private _c_cel_vende As String
    Private _c_mail_vende As String
    Private _c_afecto_comi As Integer
    Private _c_porc_comi As Decimal

    Private _c_usuario As String
    Private _copcion As String
    Public Property c_codi_vende() As String
        Get
            Return _c_codi_vende
        End Get
        Set(ByVal value As String)
            _c_codi_vende = value
        End Set
    End Property
    Public Property c_nom_vende() As String
        Get
            Return _c_nom_vende
        End Get
        Set(ByVal value As String)
            _c_nom_vende = value
        End Set
    End Property
    Public Property c_dni_vende() As String
        Get
            Return _c_dni_vende
        End Get
        Set(ByVal value As String)
            _c_dni_vende = value
        End Set
    End Property
    Public Property c_direc_vende() As String
        Get
            Return _c_direc_vende
        End Get
        Set(ByVal value As String)
            _c_direc_vende = value
        End Set
    End Property
    Public Property c_dist_vende() As String
        Get
            Return _c_dist_vende
        End Get
        Set(ByVal value As String)
            _c_dist_vende = value
        End Set
    End Property
    Public Property c_telf_vende() As String
        Get
            Return _c_telf_vende
        End Get
        Set(ByVal value As String)
            _c_telf_vende = value
        End Set
    End Property
    Public Property c_cel_vende() As String
        Get
            Return _c_cel_vende
        End Get
        Set(ByVal value As String)
            _c_cel_vende = value
        End Set
    End Property
    Public Property c_mail_vende() As String
        Get
            Return _c_mail_vende
        End Get
        Set(ByVal value As String)
            _c_mail_vende = value
        End Set
    End Property
    Public Property c_afecto_comi() As Integer
        Get
            Return _c_afecto_comi
        End Get
        Set(ByVal value As Integer)
            _c_afecto_comi = value
        End Set
    End Property
    Public Property c_porc_comi() As Decimal
        Get
            Return _c_porc_comi
        End Get
        Set(ByVal value As Decimal)
            _c_porc_comi = value
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
