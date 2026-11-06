Imports System.Data.OleDb
Imports Capa_Entidades
Public Class Cls_SalAlmContrato

    Dim Conexion As New Cls_Conexion
    Dim Conex As New OleDbConnection(Conexion.GetConexion_Sql)
    Dim cmd As New OleDbCommand

    Public Function set_SalAlmContrato_Save(
        ByVal ent As Ent_SalAlmContrato) As Integer

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_SalAlmContrato_Save"

        Dim IdGenerado As Integer = 0

        Try

            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@vOpt", OleDbType.VarChar, 3).Value = ent.vOpt

            cmd.Parameters.Add("@IdOrdenContrato", OleDbType.Integer).Value = ent.IdOrdenContrato

            cmd.Parameters.Add("@SerieOT", OleDbType.VarChar, 5).Value = ent.SerieOT

            cmd.Parameters.Add("@NroOT", OleDbType.VarChar, 10).Value = ent.NroOT

            cmd.Parameters.Add("@IdContratoExterno", OleDbType.Integer).Value = ent.IdContratoExterno

            cmd.Parameters.Add("@CodigoContrato", OleDbType.VarChar, 30).Value = ent.CodigoContrato

            cmd.Parameters.Add(
                "@FechaInicioContrato",
                OleDbType.Date
            ).Value = ent.FechaInicioContrato


            cmd.Parameters.Add(
                "@FechaFinContrato",
                OleDbType.Date
            ).Value = ent.FechaFinContrato


            cmd.Parameters.Add(
                "@MontoMensual",
                OleDbType.Decimal,
                18,
                2
            ).Value = ent.MontoMensual


            cmd.Parameters.Add(
                "@Moneda",
                OleDbType.VarChar,
                3
            ).Value = ent.Moneda


            cmd.Parameters.Add(
                "@PeriodoDesde",
                OleDbType.Date
            ).Value = ent.PeriodoDesde


            cmd.Parameters.Add(
                "@PeriodoHasta",
                OleDbType.Date
            ).Value = ent.PeriodoHasta


            cmd.Parameters.Add(
                "@Ubicaciones",
                OleDbType.VarChar,
                1000
            ).Value = ent.Ubicaciones


            cmd.Parameters.Add(
                "@Observacion",
                OleDbType.VarChar,
                1000
            ).Value = ent.Observacion


            Dim Resultado As Object

            Resultado = cmd.ExecuteScalar()

            If Resultado IsNot Nothing AndAlso
               Resultado IsNot DBNull.Value Then

                IdGenerado = CInt(Resultado)

            End If

        Catch ex As Exception

            MsgBox("Error al grabar contrato de la Orden de Trabajo: " &
                   ex.Message)

        Finally

            If Conex.State = ConnectionState.Open Then
                Conex.Close()
            End If

        End Try

        Return IdGenerado

    End Function

    Public Function set_SalAlmContrato_Facturar(ByVal ent As Ent_SalAlmContratoFactura) As Integer

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_SalAlmContrato_Facturar"

        Dim ResultadoActualizacion As Integer = 0

        Try

            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            cmd.Parameters.Clear()

            cmd.Parameters.Add(
            "@IdOrdenContrato",
            OleDbType.Integer
        ).Value = ent.IdOrdenContrato

            cmd.Parameters.Add(
            "@SerieFactura",
            OleDbType.VarChar,
            5
        ).Value = ent.SerieFactura

            cmd.Parameters.Add(
            "@NumeroFactura",
            OleDbType.VarChar,
            15
        ).Value = ent.NumeroFactura

            cmd.Parameters.Add(
            "@FechaEmision",
            OleDbType.Date
        ).Value = ent.FechaEmision


            Dim Resultado As Object

            Resultado = cmd.ExecuteScalar()

            If Resultado IsNot Nothing AndAlso
           Resultado IsNot DBNull.Value Then

                ResultadoActualizacion = CInt(Resultado)

            End If

        Catch ex As Exception

            MsgBox("Error al actualizar la factura del contrato: " &
               ex.Message)

        Finally

            If Conex.State = ConnectionState.Open Then
                Conex.Close()
            End If

        End Try

        Return ResultadoActualizacion

    End Function

    Public Function get_SalAlmContrato_Datos(
        ByVal SerieOT As String,
        ByVal NroOT As String) As DataTable

        Dim Dt As New DataTable

        cmd.Connection = Conex
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Sp_Scal_Fa_SalAlmContrato_Datos"

        Try

            If Conex.State = ConnectionState.Closed Then
                Conex.Open()
            End If

            cmd.Parameters.Clear()

            cmd.Parameters.Add("@SerieOT", OleDbType.VarChar, 5).Value = SerieOT

            cmd.Parameters.Add("@NroOT", OleDbType.VarChar, 10).Value = NroOT

            Dim Da As New OleDbDataAdapter(cmd)

            Da.Fill(Dt)

        Catch ex As Exception

            MsgBox("Error al consultar contrato de la Orden de Trabajo: " &
                   ex.Message)

        Finally

            If Conex.State = ConnectionState.Open Then
                Conex.Close()
            End If

        End Try

        Return Dt

    End Function

End Class

