Imports System.Data
Imports System.Data.OleDb
Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmAsientos
    Dim c_Neg_MnTpoDoc As New Neg_MnTpoDoc
    Dim c_Neg_FactCab As New Neg_FactCab : Dim c_Neg_FactDet As New Neg_FactDet
    Dim c_Neg_BolCab As New Neg_BolCab : Dim c_Neg_BolDet As New Neg_BolDet
    Dim c_Neg_Asientos_Cab As New Neg_Asientos_Cab : Dim c_Neg_MnEmpresa As New Neg_MnEmpresa
    Dim c_Neg_Asientos_Det As New Neg_Asientos_Det
    Dim c_Neg_Asientos_Anexos As New Neg_Asientos_Anexos : Dim c_Ent_Asientos_Anexos As New Ent_Asientos_Anexos
    Dim c_Neg_Clientes As New Neg_MnCliente
    'Avanzamos presionando la tecla enter...
    Private Sub FrmAsientos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmAsientos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_codi_doc", CboDoc)
        c_Neg_MnEmpresa.Get_Empresa_Cbo(" and c_anula_reg=0", CboEmpresa)
        Call Validar_Permiso()
    End Sub
    Private Sub Validar_Permiso()
        With FrmMenu.Dgv01
            For i = 0 To .RowCount - 1
                If UCase(.Rows(i).Cells("c_nom_formu").Value.ToString) = UCase(Me.Name) Then
                    If Val(.Rows(i).Cells("c_add_obj").Value) = 0 Then btnmostrar.Enabled = False : BtnNuevo.Enabled = False
                    If Val(.Rows(i).Cells("c_edit_obj").Value) = 0 Then BtnEditar.Enabled = False
                    If Val(.Rows(i).Cells("c_del_obj").Value) = 0 Then BtnAnular.Enabled = False
                    i = .RowCount
                End If
            Next
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnmostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmostrar.Click
        Call Cargar_Documentos()
    End Sub
    Private Sub Cargar_Documentos()
        Dgv01.Columns.Clear()
        Dgv01.DataSource = c_Neg_Asientos_Cab.get_AsientosCab_Datos(CboDoc.SelectedValue, Fecha_1.Text, Fecha_2.Text)
        On Error Resume Next
        Dgv03.DataSource = Nothing

        If Dgv01.RowCount > 0 Then
            BtnGrabar.Enabled = True
            With Dgv01
                For i = 0 To .RowCount - 1
                    If CboDoc.SelectedValue = "01" Then
                        With c_Neg_FactCab.get_FactCab_Datos(" And F.c_nro_serie='" & Strings.Left(Dgv01.Rows(i).Cells("N_Factura").Value, 3) & _
                                                                "' and F.c_nro_factura='" & Strings.Right(Dgv01.Rows(i).Cells("N_Factura").Value, 7) & _
                                                                "' and F.c_anula_reg=0", "DAT", FrmMenu.TxtCod_Emp.Text)
                            If .Rows.Count > 0 Then
                                Call Concar_Buscar_Anexos("C", .Rows(0)("c_Ruc_clie").ToString, Strings.Left(.Rows(0)("c_desc_clie").ToString, 40), _
                                                            Strings.Left(.Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString, 50), FrmMenu.TxtRuta_Concar.Text)
                            End If
                        End With
                    End If 'Buscamos por dni en boletas...
                    If CboDoc.SelectedValue = "02" Then
                        With c_Neg_BolCab.get_BolCab_Datos(" And B.c_nro_serie='" & Strings.Left(Dgv01.Rows(i).Cells("N_Factura").Value, 3) & _
                                                                "' and B.c_nro_boleta='" & Strings.Right(Dgv01.Rows(i).Cells("N_Factura").Value, 7) & "' and B.c_anula_reg=0", "DAT", FrmMenu.TxtCod_Emp.Text)
                            If .Rows.Count > 0 Then
                                Call Concar_Buscar_Anexos("C", .Rows(0)("c_dni_clie").ToString, Strings.Left(.Rows(0)("c_desc_clie").ToString, 40), _
                                                            Strings.Left(.Rows(0)("c_direc_clie").ToString & " " & .Rows(0)("c_dist_clie").ToString, 50), FrmMenu.TxtRuta_Concar.Text)
                            End If
                        End With
                    End If
                Next
                Call Configurar_Grid()
            End With
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            Dgv03.DataSource = c_Neg_Asientos_Anexos.get_AsientosCab_Datos(" ")
        End If
        lbltot.Text = "Total de Registros " & Dgv01.RowCount
    End Sub
    'Configuramos tamaño de columnas
    Private Sub Configurar_Grid()
        With Dgv01
            .Columns("N_Factura").Width = 80
            .Columns("Csubdia").Width = 60
            .Columns("Ccompro").Width = 60
            .Columns("Cfeccom").Width = 60
            .Columns("Ccodmon").Width = 50
            .Columns("Csitua").Width = 50
            .Columns("Ctipcam").Width = 60
            .Columns("Cglosa").Width = 320
            .Columns("Ctotal").Width = 60
            .Columns("Ctipo").Width = 60
            .Columns("Cflag").Width = 50
            .Columns("Cfeccom2").Width = 60
        End With
    End Sub
    'Metodo que nos permite validar la numeracion de comprobantes de pago...
    Private Sub Concar_Buscar_Anexos(ByVal Tipo_Anexo As String, ByVal Ruc As String, ByVal Cliente As String, ByVal Arefane As String, ByVal Ruta_concar As String)
        'Validamos que el ruc o dni ingresado sea correcto, y no ingresar cliente que no tengan el dni o el ruc
        'debidamente ingresados...
        If Val(Ruc) <> 0 Then
            Dim x As Integer = 0
            Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Ruta_concar & " Extended Properties=dBASE IV;")
            Dim sql As String = ""
            conn.Open()
            Dim Sdata As New OleDbDataAdapter("select*from " & TxtAnexo.Text & " Where Avanexo='" & Tipo_Anexo & "' and Trim(Aruc)='" & Ruc & "'", conn)
            Dim Dts As New DataSet
            Sdata.Fill(Dts, "Anexos")
            With Dts.Tables("Anexos")
                If .Rows.Count = 0 Then
                    With c_Ent_Asientos_Anexos
                        .Avanexo = Tipo_Anexo
                        .Acodane = Ruc
                        .Adesane = Cliente
                        .Aruc = Ruc
                        .Aestado = "V"
                        .Arefane = Strings.Left(Arefane, 50)
                        c_Neg_Asientos_Anexos.set_Asientos_anexos_Save(c_Ent_Asientos_Anexos)
                    End With
                End If
            End With
            'eliminamos variables creadas
            conn.Dispose()
            Sdata.Dispose()
        End If
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        Dgv02.Rows.Clear()
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                With c_Neg_Asientos_Det.get_AsientosDet_Datos(" And D.N_Factura='" & .Rows(Fila).Cells("N_Factura").Value & "' order by Dsecue")
                    For i = 0 To .Rows.Count - 1
                        Dgv02.Rows.Add()
                        Dgv02.Rows(i).Cells("N_Factura_2").Value = .Rows(i)("N_Factura").ToString
                        Dgv02.Rows(i).Cells("Dsubdia").Value = .Rows(i)("Dsubdia").ToString
                        Dgv02.Rows(i).Cells("Dcompro").Value = .Rows(i)("Dcompro").ToString
                        Dgv02.Rows(i).Cells("Dsecue").Value = .Rows(i)("Dsecue").ToString
                        Dgv02.Rows(i).Cells("Dfeccom").Value = .Rows(i)("Dfeccom").ToString
                        Dgv02.Rows(i).Cells("Dcuenta").Value = .Rows(i)("Dcuenta").ToString
                        Dgv02.Rows(i).Cells("Dcodane").Value = .Rows(i)("Dcodane").ToString
                        Dgv02.Rows(i).Cells("Dencos").Value = .Rows(i)("Dencos").ToString
                        Dgv02.Rows(i).Cells("Dcodmon").Value = .Rows(i)("Dcodmon").ToString
                        Dgv02.Rows(i).Cells("Ddh").Value = .Rows(i)("Ddh").ToString
                        Dgv02.Rows(i).Cells("Dimport").Value = .Rows(i)("Dimport").ToString
                        Dgv02.Rows(i).Cells("Dtipdoc").Value = .Rows(i)("Dtipdoc").ToString
                        Dgv02.Rows(i).Cells("Dnumdoc").Value = .Rows(i)("dnumdoc").ToString
                        Dgv02.Rows(i).Cells("Dfecdoc").Value = .Rows(i)("Dfecdoc").ToString
                        Dgv02.Rows(i).Cells("Dfecven").Value = .Rows(i)("Dfecven").ToString
                        Dgv02.Rows(i).Cells("Darea").Value = .Rows(i)("Darea").ToString
                        Dgv02.Rows(i).Cells("Dflag").Value = .Rows(i)("Dflag").ToString
                        Dgv02.Rows(i).Cells("Dxglosa").Value = .Rows(i)("Dxglosa").ToString
                        Dgv02.Rows(i).Cells("Dusimpor").Value = .Rows(i)("Dusimpor").ToString
                        Dgv02.Rows(i).Cells("Dmnimpor").Value = .Rows(i)("Dmnimpor").ToString
                        Dgv02.Rows(i).Cells("Dtipcam").Value = .Rows(i)("Dtipcam").ToString
                        Dgv02.Rows(i).Cells("Dfeccom2").Value = .Rows(i)("Dfeccom2").ToString
                        Dgv02.Rows(i).Cells("Dfecdoc2").Value = .Rows(i)("Dfecdoc2").ToString
                        Dgv02.Rows(i).Cells("Dfecven2").Value = .Rows(i)("Dfecven2").ToString
                        Dgv02.Rows(i).Cells("Danexo").Value = .Rows(i)("Danexo").ToString
                    Next
                End With
            End If
        End With
        
    End Sub
    'Grabar Soles...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        'If Validar_Montos(Dgv01) = True Then
        'If Validar_Cuentas(Dgv01) = True Then
        If Dgv01.RowCount > 0 Then
            Dim F As String = MsgBox("¿Los datos son correctos?...", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then Call Grabar_Concar_Cab_fox(TxtCodConcar.Text & Strings.Left(Dgv01.Rows(Dgv01.CurrentCellAddress.Y).Cells("Cfeccom").Value, 2))
        End If
        'Else
        'Call Dgv01_SelectionChanged(Nothing, Nothing)
        'End If
        'Else
        'Call Dgv01_SelectionChanged(Nothing, Nothing)
        'End If
    End Sub
    'Grabamos registros cabeceras en el concar...
    Private Sub Grabar_Concar_Cab_fox(ByVal Tabla As String)
        With Dgv01
            TxtCorrel.Clear()
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '=======================================================================================================================================================================
                    'Buscamos el numero de correlativo...
                    Call Concar_Numeracion(TxtCodConcar.Text & Strings.Left(.Rows(i).Cells("Cfeccom").Value, 2), .Rows(i).Cells("Csubdia").Value, .Rows(i).Cells("Cfeccom").Value, FrmMenu.TxtRuta_Concar.Text, TxtCorrel) 'FACTURAS
                    'MsgBox(TxtCodConcar.Text & Strings.Left(.Rows(i).Cells("Cfeccom").Value, 2))
                        '=======================================================================================================================================================================
                    Dim sql As String = "insert into CCC" & Tabla & " (Csubdia,Ccompro,Cfeccom,Ccodmon,Csitua,Ctipcam,Cglosa,Ctotal,Ctipo,Cflag,Cfeccom2,Cdate,Chora,CUser) Values('" & _
                    .Rows(i).Cells("Csubdia").Value & "','" & TxtCorrel.Text & "','" & .Rows(i).Cells("Cfeccom").Value & "','" & .Rows(i).Cells("Ccodmon").Value & "','" & _
                    .Rows(i).Cells("Csitua").Value & "'," & Val(.Rows(i).Cells("Ctipcam").Value) & ",'" & .Rows(i).Cells("Cglosa").Value & "'," & Val(.Rows(i).Cells("Ctotal").Value) & ",'" & _
                    .Rows(i).Cells("Ctipo").Value & "','" & .Rows(i).Cells("Cflag").Value & "','" & .Rows(i).Cells("Cfeccom2").Value & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & _
                    "','" & FormatDateTime(Date.Now, DateFormat.ShortTime) & "','SIST')"
                    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtRuta_Concar.Text & " Extended Properties=dBASE IV;")
                    conn.Open()
                    Dim cmd As New OleDb.OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    '==============================================================================================================='
                    '===================================Actualizamos En la Tabla FActuras Ventas con el Comprobante del Concar============================================================================
                    Dgv01.Rows(i).Cells("Ccompro").Value = TxtCorrel.Text
                    If CboDoc.SelectedValue = "05" Then
                        c_Neg_Asientos_Cab.set_AsientosCab_Save(Strings.Right(.Rows(i).Cells("N_Factura").Value, 1), Strings.Left(.Rows(i).Cells("N_Factura").Value, 6), TxtCorrel.Text, CboDoc.SelectedValue, "EDI")
                    Else
                        c_Neg_Asientos_Cab.set_AsientosCab_Save(Strings.Left(.Rows(i).Cells("N_Factura").Value, 4), Strings.Right(.Rows(i).Cells("N_Factura").Value, 7), TxtCorrel.Text, CboDoc.SelectedValue, "EDI")
                    End If
                        ' MsgBox(TxtCorrel.Text & " " & .Rows(i).Cells("N_Factura").Value)
                        .Rows(i).Cells("CCompro").Value = TxtCorrel.Text
                        '==============================================================================================================='
                        '==============================================================================================================='
                        conn.Dispose() 'eliminamos variables...

                        Call Grabar_Concar_Det_Fox(Tabla, i)
                Next 'Grabamos registros...
                Call Grabar_Concar_Anexos() 'Grabamos los anexos...
                BtnGrabar.Enabled = False
                BtnAnular.Enabled = False
                MsgBox("Los documentos fueron grabados Correctamente en el Concar...")
            Else
                MsgBox("No existen Registros que grabar en el concar", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    'Grabamos en la cabecera de los archivos del concar...
    Private Sub Grabar_Concar_Det_Fox(ByVal Tabla As String, ByVal Fila As Integer)
        Dgv01.Rows(Fila).Selected = True
        Dgv01.CurrentCell = Dgv01(Dgv01.CurrentCell.ColumnIndex, Fila)
        Dgv01_SelectionChanged(Nothing, Nothing)
        With Dgv02
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    Dim sql As String = ""
                    'validamos si fecha de vencimiento ha sido ingresada.
                    If Len(.Rows(i).Cells("Dfecven2").Value.ToString) > 0 Then 'Registro si contiene fecha de vencimiento...
                        sql = "insert into CCD" & Tabla & " (Dsubdia,Dcompro,Dsecue,Dfeccom,Dcuenta,Dcodane,Dcodmon,Ddh,Dimport,Dtipdoc,Dnumdoc,Dfecdoc,Dfecven,Darea," & _
                        "Dflag,Ddate,Dxglosa,Dusimpor,Dmnimpor,Dfeccom2,Dfecdoc2,Dfecven2,Dvanexo) values('" & .Rows(i).Cells("Dsubdia").Value & "','" & TxtCorrel.Text & "','" & .Rows(i).Cells("Dsecue").Value & "','" & .Rows(i).Cells("Dfeccom").Value & "','" & Trim(.Rows(i).Cells("Dcuenta").Value) & "','" & _
                        .Rows(i).Cells("Dcodane").Value & "','" & .Rows(i).Cells("Dcodmon").Value & "','" & _
                        .Rows(i).Cells("Ddh").Value & "'," & Val(.Rows(i).Cells("Dimport").Value.ToString) & ",'" & .Rows(i).Cells("Dtipdoc").Value & "','" & .Rows(i).Cells("Dnumdoc").Value & "','" & _
                        .Rows(i).Cells("Dfecdoc").Value & "','" & .Rows(i).Cells("Dfecven").Value & "','" & .Rows(i).Cells("Darea").Value & "','" & .Rows(i).Cells("Dflag").Value & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & _
                        .Rows(i).Cells("Dxglosa").Value & "'," & Val(.Rows(i).Cells("Dusimpor").Value.ToString) & "," & Val(.Rows(i).Cells("Dmnimpor").Value.ToString) & ",'" & FormatDateTime(.Rows(i).Cells("Dfeccom2").Value, DateFormat.ShortDate) & "','" & _
                        FormatDateTime(.Rows(i).Cells("Dfecdoc2").Value, DateFormat.ShortDate) & "','" & FormatDateTime(.Rows(i).Cells("Dfecven2").Value, DateFormat.ShortDate) & "','" & .Rows(i).Cells("Danexo").Value & "')"
                    Else 'Registro no contiene fecha de vencimiento
                        sql = "insert into CCD" & Tabla   & " (Dsubdia,Dcompro,Dsecue,Dfeccom,Dcuenta,Dcodane,Dcodmon,Ddh,Dimport,Dtipdoc,Dnumdoc,Dfecdoc,Dfecven,Darea," & _
                        "Dflag,Ddate,Dxglosa,Dusimpor,Dmnimpor,Dfeccom2,Dfecdoc2,Dvanexo) values('" & .Rows(i).Cells("Dsubdia").Value & "','" & TxtCorrel.Text & "','" & .Rows(i).Cells("Dsecue").Value & "','" & .Rows(i).Cells("Dfeccom").Value & "','" & Trim(.Rows(i).Cells("Dcuenta").Value) & "','" & _
                        .Rows(i).Cells("Dcodane").Value & "','" & .Rows(i).Cells("Dcodmon").Value & "','" & _
                        .Rows(i).Cells("Ddh").Value & "'," & Val(.Rows(i).Cells("Dimport").Value.ToString) & ",'" & .Rows(i).Cells("Dtipdoc").Value & "','" & .Rows(i).Cells("Dnumdoc").Value & "','" & _
                        .Rows(i).Cells("Dfecdoc").Value & "','" & .Rows(i).Cells("Dfecven").Value & "','" & .Rows(i).Cells("Darea").Value & "','" & .Rows(i).Cells("Dflag").Value & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & _
                        .Rows(i).Cells("Dxglosa").Value & "'," & Val(.Rows(i).Cells("Dusimpor").Value.ToString) & "," & Val(.Rows(i).Cells("Dmnimpor").Value.ToString) & ",'" & FormatDateTime(.Rows(i).Cells("Dfeccom2").Value, DateFormat.ShortDate) & "','" & _
                         FormatDateTime(.Rows(i).Cells("Dfecdoc2").Value, DateFormat.ShortDate) & "','" & .Rows(i).Cells("Danexo").Value & "')"
                    End If
                    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtRuta_Concar.Text & " Extended Properties=dBASE IV;")
                    conn.Open()
                    Dim cmd As New OleDb.OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery() 'eliminamos variables...
                    conn.Dispose()
                    cmd.Dispose()
                Next
            End If
        End With
    End Sub
    'Buscamos ultima numeracion del concar...
    Private Sub Buscar_Solo_Numeracion(ByVal N_Factura As Integer)
        Dim conex As New OleDbConnection(FrmMenu.TxtRuta_Concar.Text)
        Dim data As New OleDbDataAdapter("select*from Concar_Fac_Cab Where N_Factura=" & N_Factura, conex)
        Dim Dts As New DataSet
        data.Fill(Dts, "Correl")
        With Dts.Tables("Correl")
            TxtCorrel.Clear()
            If .Rows.Count > 0 Then TxtCorrel.Text = .Rows(0)("Ccompro").ToString
        End With
    End Sub
    'Seleccionamos la empresa...
    Private Sub CboEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEmpresa.SelectedIndexChanged
        If CboEmpresa.Items.Count > 0 Then
            On Error Resume Next
            With c_Neg_MnEmpresa.get_Empresa_Datos(" and c_codi_emp='" & CboEmpresa.SelectedValue & "'", "DAT")
                If .Rows.Count > 0 Then
                    TxtCodConcar.Text = .Rows(0)("c_cod_concar").ToString
                    TxtAnexo.Text = .Rows(0)("c_anexo_concar").ToString
                    TxtAnexoDet.Text = .Rows(0)("c_anexodet_concar").ToString
                End If
            End With
        End If
    End Sub
    'Anulamos comprobante...
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim f As String = MsgBox("¿Desea quitar el Documento Seleccionado ?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical)
                If f = vbYes Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    Dim sql As String = ""
                    'sacamos al documentos que no deseamos cargar al concar...
                    If CboDoc.SelectedValue = "01" Then c_Neg_FactCab.set_FactCabAsientos_Save(Strings.Left(.Rows(Fila).Cells("N_Factura").Value, 3), _
                    Strings.Right(.Rows(Fila).Cells("N_Factura").Value, 7), 0, "DEL") ' Facturas
                    If CboDoc.SelectedValue = "02" Then c_Neg_BolCab.set_BolCabAsientos_Save(Strings.Left(.Rows(Fila).Cells("N_Factura").Value, 3), _
                    Strings.Right(.Rows(Fila).Cells("N_Factura").Value, 7), 0, "DEL") ' Boletas
                    If CboDoc.SelectedValue = "03" Then c_Neg_BolCab.set_BolCabAsientos_Save(Strings.Left(.Rows(Fila).Cells("N_Factura").Value, 3), _
                                        Strings.Right(.Rows(Fila).Cells("N_Factura").Value, 7), 0, "DEL") ' Nota de Credito
                    If CboDoc.SelectedValue = "04" Then c_Neg_BolCab.set_BolCabAsientos_Save(Strings.Left(.Rows(Fila).Cells("N_Factura").Value, 3), _
                                                            Strings.Right(.Rows(Fila).Cells("N_Factura").Value, 7), 0, "DEL") ' Nota de Debito
                    btnmostrar_Click(Nothing, Nothing)
                    MsgBox("El documento ya no podra ser cargado en el concar, el retiro se realizo Correctamente...", MsgBoxStyle.Information)
                End If
            End If
        End With
    End Sub
    'Grabamos en la cabecera de los archivos del concar...
    Private Sub Grabar_Concar_Anexos()
        With Dgv03
            For i = 0 To .RowCount - 1
                Call Buscar_Valor_Tablas_Concar("select*from " & TxtAnexo.Text & " where Trim(Acodane)='" & .Rows(i).Cells("Acodane").Value & "'", TxtVar, FrmMenu.TxtRuta_Concar.Text)
                'Validamos si existen Anexos...
                If Val(TxtVar.Text) = 0 Then
                    Dim sql As String = "insert into " & TxtAnexo.Text & " (Avanexo,Acodane,Adesane,Aruc,Aestado,Adate,Ahora,Arefane) values('" & .Rows(i).Cells("Avanexo").Value & "','" & _
                    .Rows(i).Cells("Acodane").Value & "','" & .Rows(i).Cells("Adesane").Value & "','" & _
                    .Rows(i).Cells("Aruc").Value & "','" & .Rows(i).Cells("Aestado").Value & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & _
                    FormatDateTime(System.DateTime.Now, DateFormat.ShortTime) & "','" & .Rows(i).Cells("Arefane").Value & "')"
                    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FrmMenu.TxtRuta_Concar.Text & " Extended Properties=dBASE IV;")
                    conn.Open()
                    Dim cmd As New OleDb.OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery()
                    ''''''''''''''''''''''''''''''''''Detalles de Anexo CAOXX.dbf
                    'Grabamos en detalles de Anexoo


                    'Validamos el tipo de cliente
                    Dim Atiptra As String
                    If Strings.Left(.Rows(i).Cells("Acodane").Value, 2) = "10" Then
                        Atiptra = "N"
                    Else
                        Atiptra = "J"
                    End If

                    sql = "Insert into " & TxtAnexoDet.Text & " (Avanexo,Acodane,Afeccre,Atiptra,Adocide,Anumide,Atippro) values('C','" & .Rows(i).Cells("Acodane").Value & "','" & FormatDateTime(System.DateTime.Now, DateFormat.ShortDate) & "','" & Atiptra & _
                    "','6','" & .Rows(i).Cells("Acodane").Value & "','N')"
                    cmd = New OleDb.OleDbCommand(sql, conn)
                    cmd.ExecuteNonQuery()

                    conn.Dispose()
                    cmd.Dispose()
                End If
            Next
        End With
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dgv01.DataSource = Nothing
        Dgv02.Rows.Clear() : Dgv03.DataSource = Nothing : lbltot.Text = "Total de Registros 0"
        Call Validar_Permiso()
    End Sub
End Class