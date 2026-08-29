Public Class FrmLiquidac

    Private Sub FrmLiquidac_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub FrmLiquidac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmLiquidac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv02.Columns.Clear() : Dgv03.Columns.Clear() : Dgv04.Rows.Add() : Dgv05.Rows.Add()
        Call Validar_Permiso(Me.Name, BtnImp, BtnEditar, BtnEli)
    End Sub
    ' Metodo para cargar grid '
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_Liquidac.get_Liquidac_Datos(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            .Columns("Liquidacion").Width = 90
            .Columns("Año").Width = 70
            .Columns("Cliente").Width = 400
            .Columns("Monto").Width = 70
            .Columns("Fecha").Width = 180
            ' Alineacion de Columnas '
            .Columns("Liquidacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Año").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Color Amarillo '
            .Columns("Liquidacion").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Liquidacion").HeaderCell.Style.ForeColor = Color.Blue
            ' Metodo Visible '
            .Columns("c_anula_reg").Visible = False
            ' llamamos al metodo seleccion '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub
    ' Coloreamos columnas inactivas '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    ' Seleccion '
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub

    Private Sub TxtBus_Liq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Liq.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Liq.Text) > 0 Then
                TxtBus_Liq.Text = Strings.Right(Val(TxtBus_Liq.Text) + 10000000, 7)
                Call Cargar_Grid(" and L.c_nro_liq='" & TxtBus_Liq.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_Liq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Liq.TextChanged

    End Sub
    ' Buscamos por numero de letra...
    Private Sub TxtBus_Letra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Letra.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Letra.Text) > 0 Then
                TxtBus_Letra.Text = Strings.Right(Val(TxtBus_Letra.Text) + 10000000, 6)
                With c_Neg_LetCab.get_LetCab_Datos(" And L.c_nro_letra='" & TxtBus_Letra.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        Call Cargar_Grid(" and L.c_nro_liq='" & .Rows(0)("c_nro_liq").ToString & "'")
                    Else
                        MsgBox("Letra ingresada no existe, revisar...",vbCritical,Compañia)
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub TxtBus_Letra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Letra.TextChanged

    End Sub

    Private Sub BtnMos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMos.Click
        Call Cargar_Grid(" And Cl.c_desc_clie like '" & TxtBus_Clie.Text & "%'   And L.c_fecha_crea>='" & DtpFec_Inicio.Text & "' and L.c_fecha_crea<='" & DateAdd("d", 1, DtpFec_Fin.Text) & "' order by L.c_nro_liq")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Mostramos datos al dar doble click '
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Tbc01.SelectedTab = Tab02
                    Call Mostrar_Letras(.Rows(Fila).Cells("Liquidacion").Value, Val(.Rows(Fila).Cells("Año").Value))
                End If
            End If
        End With
    End Sub
    ' Metodo para mostrar detalles '
    Private Sub Mostrar_Letras(ByVal c_nro_liq As String, ByVal c_año_liq As Integer)
        With Dgv02
            .DataSource = c_Neg_LetCab.get_LetCab_Datos(" and L.c_nro_liq='" & c_nro_liq & "' and L.c_año_liq=" & c_año_liq & " order by L.c_nro_liq", "DGV", FrmMenu.TxtCod_Emp.Text)
            TxtNro_Liq.Text = c_nro_liq
            .Columns("Letra").Width = 60
            .Columns("Renov").Width = 45
            .Columns("Status").Width = 130
            .Columns("Valor").Width = 150
            .Columns("Dias").Width = 40
            .Columns("Fecha de Giro").Width = 120
            .Columns("Fecha de Vencimiento").Width = 140
            .Columns("Banco").Width = 130
            .Columns("Importe").Width = 50
            ' Alineacion '
            .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Renov").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha de Giro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha de Vencimiento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Mostramos documentos amarrados a la letra '
            With Dgv03
                .DataSource = c_Neg_LetDet.get_LetDet_Datos(" And L.c_nro_liq='" & c_nro_liq & "' And L.c_año_liq=" & c_año_liq, "DGV", FrmMenu.TxtCod_Emp.Text)
                .Columns("Tipo").Width = 120
                .Columns("Nro. Documento").Width = 140
                .Columns("Importe").Width = 80
                ' Columnas Alineacion
                .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Nro. Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("c_codi_doc").Visible = False
            End With
            ' Metodo para calcular los detalles '
            Call Calcular_Totales_Letra()
        End With
        ' Mostramos detalles de la liquidacion
        With c_Neg_Liquidac.get_Liquidac_Datos(" And L.c_nro_liq='" & TxtNro_Liq.Text & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                TxtAño.Text = .Rows(0)("c_año_liq").ToString
                TxtTotal.Text = Format(Val(.Rows(0)("c_total_liq").ToString), Forma_2_2)
                TxtCod_Clie.Text = .Rows(0)("c_codi_clie").ToString
                TxtClie.Text = .Rows(0)("c_desc_clie").ToString
                TxtMon.Text = .Rows(0)("c_nick_mon").ToString
                LblMon.Text = .Rows(0)("c_nick_mon").ToString
                LblMon2.Text = .Rows(0)("c_nick_mon").ToString
                TxtPor_Reten.Text = Format(Val(.Rows(0)("c_reten_liq").ToString), Forma_1_2)
                TxtTot_Ret.Text = Format(Val(.Rows(0)("c_cant_reten").ToString), Forma_1_2)
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub
    ' Metodo que nos permite calcular el total de letras '
    Private Sub Calcular_Totales_Letra()
        With Dgv02
            Dim Tot_letra As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_letra = Tot_letra + Val(.Rows(i).Cells("Importe").Value)
            Next
            Dgv04.Rows(0).Cells("Importe_Det").Value = Format(Tot_letra, Forma_1_2)
            Dgv04.Rows(0).Cells("Titulo_1").Value = "Nro de Letras"
            Dgv04.Rows(0).Cells("Total_1").Value = Dgv02.RowCount
            ' Alineacion '
            Dgv04.Columns("Total_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgv04.Columns("Importe_det").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        With Dgv03
            Dim Tot_letra As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_letra = Tot_letra + Val(.Rows(i).Cells("Importe").Value)
            Next
            Dgv05.Rows(0).Cells("Tot_Det2").Value = Format(Tot_letra, Forma_1_2)
            Dgv05.Rows(0).Cells("Titulo_2").Value = "Nro de Documentos"
            Dgv05.Rows(0).Cells("Total_2").Value = Dgv03.RowCount
            Dgv05.Columns("Total_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Dgv05.Columns("Tot_Det2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Tbc01.SelectedTab = Tab01
        Call Validar_Permiso(Me.Name, BtnImp, BtnEditar, BtnEli)
    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub
    ' Imprimir '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmReportes.Reporte_Planilla_Letras("Liquidación / Tintorería Nro. " & .Rows(Fila).Cells("Liquidacion").Value & " - " & .Rows(Fila).Cells("Año").Value, _
                                                        .Rows(Fila).Cells("Liquidacion").Value)
                End If
            End If
        End With
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click

    End Sub

    Private Sub Tbc01_Click(sender As Object, e As System.EventArgs) Handles Tbc01.Click

    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click

    End Sub

    Private Sub BtnEli_Click(sender As Object, e As EventArgs) Handles BtnEli.Click

    End Sub
End Class