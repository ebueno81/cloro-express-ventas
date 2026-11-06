<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSalAlmContrato
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PnlTitulo = New System.Windows.Forms.Panel()
        Me.LblSubTitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.GrpOrdenTrabajo = New System.Windows.Forms.GroupBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtNroOT = New System.Windows.Forms.TextBox()
        Me.LblNroOT = New System.Windows.Forms.Label()
        Me.TxtSerieOT = New System.Windows.Forms.TextBox()
        Me.LblSerieOT = New System.Windows.Forms.Label()
        Me.GrpContrato = New System.Windows.Forms.GroupBox()
        Me.CboContrato = New System.Windows.Forms.ComboBox()
        Me.TxtUbicaciones = New System.Windows.Forms.TextBox()
        Me.LblUbicaciones = New System.Windows.Forms.Label()
        Me.CboMoneda = New System.Windows.Forms.ComboBox()
        Me.LblMoneda = New System.Windows.Forms.Label()
        Me.TxtMontoMensual = New System.Windows.Forms.TextBox()
        Me.LblMontoMensual = New System.Windows.Forms.Label()
        Me.DtpFechaFinContrato = New System.Windows.Forms.DateTimePicker()
        Me.LblHastaContrato = New System.Windows.Forms.Label()
        Me.DtpFechaInicioContrato = New System.Windows.Forms.DateTimePicker()
        Me.LblVigencia = New System.Windows.Forms.Label()
        Me.LblCodigoContrato = New System.Windows.Forms.Label()
        Me.GrpPeriodo = New System.Windows.Forms.GroupBox()
        Me.LblAyudaPeriodo = New System.Windows.Forms.Label()
        Me.DtpPeriodoHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblPeriodoHasta = New System.Windows.Forms.Label()
        Me.DtpPeriodoDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblPeriodoDesde = New System.Windows.Forms.Label()
        Me.GrpObservacion = New System.Windows.Forms.GroupBox()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.PnlBotones = New System.Windows.Forms.Panel()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.PnlTitulo.SuspendLayout()
        Me.GrpOrdenTrabajo.SuspendLayout()
        Me.GrpContrato.SuspendLayout()
        Me.GrpPeriodo.SuspendLayout()
        Me.GrpObservacion.SuspendLayout()
        Me.PnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlTitulo
        '
        Me.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.PnlTitulo.Controls.Add(Me.LblSubTitulo)
        Me.PnlTitulo.Controls.Add(Me.LblTitulo)
        Me.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitulo.Name = "PnlTitulo"
        Me.PnlTitulo.Size = New System.Drawing.Size(850, 72)
        Me.PnlTitulo.TabIndex = 0
        '
        'LblSubTitulo
        '
        Me.LblSubTitulo.AutoSize = True
        Me.LblSubTitulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LblSubTitulo.Location = New System.Drawing.Point(26, 43)
        Me.LblSubTitulo.Name = "LblSubTitulo"
        Me.LblSubTitulo.Size = New System.Drawing.Size(295, 15)
        Me.LblSubTitulo.TabIndex = 1
        Me.LblSubTitulo.Text = "Información contractual asociada a la orden de trabajo"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(24, 12)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(388, 28)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Contrato de Alquiler - Orden de Trabajo"
        '
        'GrpOrdenTrabajo
        '
        Me.GrpOrdenTrabajo.Controls.Add(Me.TxtCliente)
        Me.GrpOrdenTrabajo.Controls.Add(Me.LblCliente)
        Me.GrpOrdenTrabajo.Controls.Add(Me.TxtNroOT)
        Me.GrpOrdenTrabajo.Controls.Add(Me.LblNroOT)
        Me.GrpOrdenTrabajo.Controls.Add(Me.TxtSerieOT)
        Me.GrpOrdenTrabajo.Controls.Add(Me.LblSerieOT)
        Me.GrpOrdenTrabajo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpOrdenTrabajo.Location = New System.Drawing.Point(20, 86)
        Me.GrpOrdenTrabajo.Name = "GrpOrdenTrabajo"
        Me.GrpOrdenTrabajo.Size = New System.Drawing.Size(810, 82)
        Me.GrpOrdenTrabajo.TabIndex = 1
        Me.GrpOrdenTrabajo.TabStop = False
        Me.GrpOrdenTrabajo.Text = "Orden de Trabajo"
        '
        'TxtCliente
        '
        Me.TxtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCliente.Location = New System.Drawing.Point(260, 42)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(525, 23)
        Me.TxtCliente.TabIndex = 2
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblCliente.Location = New System.Drawing.Point(260, 23)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(44, 15)
        Me.LblCliente.TabIndex = 3
        Me.LblCliente.Text = "Cliente"
        '
        'TxtNroOT
        '
        Me.TxtNroOT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtNroOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtNroOT.Location = New System.Drawing.Point(125, 42)
        Me.TxtNroOT.Name = "TxtNroOT"
        Me.TxtNroOT.ReadOnly = True
        Me.TxtNroOT.Size = New System.Drawing.Size(120, 23)
        Me.TxtNroOT.TabIndex = 1
        Me.TxtNroOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblNroOT
        '
        Me.LblNroOT.AutoSize = True
        Me.LblNroOT.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblNroOT.Location = New System.Drawing.Point(125, 23)
        Me.LblNroOT.Name = "LblNroOT"
        Me.LblNroOT.Size = New System.Drawing.Size(48, 15)
        Me.LblNroOT.TabIndex = 4
        Me.LblNroOT.Text = "Nro. OT"
        '
        'TxtSerieOT
        '
        Me.TxtSerieOT.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtSerieOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtSerieOT.Location = New System.Drawing.Point(20, 42)
        Me.TxtSerieOT.Name = "TxtSerieOT"
        Me.TxtSerieOT.ReadOnly = True
        Me.TxtSerieOT.Size = New System.Drawing.Size(90, 23)
        Me.TxtSerieOT.TabIndex = 0
        Me.TxtSerieOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblSerieOT
        '
        Me.LblSerieOT.AutoSize = True
        Me.LblSerieOT.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblSerieOT.Location = New System.Drawing.Point(20, 23)
        Me.LblSerieOT.Name = "LblSerieOT"
        Me.LblSerieOT.Size = New System.Drawing.Size(50, 15)
        Me.LblSerieOT.TabIndex = 5
        Me.LblSerieOT.Text = "Serie OT"
        '
        'GrpContrato
        '
        Me.GrpContrato.Controls.Add(Me.CboContrato)
        Me.GrpContrato.Controls.Add(Me.TxtUbicaciones)
        Me.GrpContrato.Controls.Add(Me.LblUbicaciones)
        Me.GrpContrato.Controls.Add(Me.CboMoneda)
        Me.GrpContrato.Controls.Add(Me.LblMoneda)
        Me.GrpContrato.Controls.Add(Me.TxtMontoMensual)
        Me.GrpContrato.Controls.Add(Me.LblMontoMensual)
        Me.GrpContrato.Controls.Add(Me.DtpFechaFinContrato)
        Me.GrpContrato.Controls.Add(Me.LblHastaContrato)
        Me.GrpContrato.Controls.Add(Me.DtpFechaInicioContrato)
        Me.GrpContrato.Controls.Add(Me.LblVigencia)
        Me.GrpContrato.Controls.Add(Me.LblCodigoContrato)
        Me.GrpContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpContrato.Location = New System.Drawing.Point(20, 178)
        Me.GrpContrato.Name = "GrpContrato"
        Me.GrpContrato.Size = New System.Drawing.Size(810, 177)
        Me.GrpContrato.TabIndex = 2
        Me.GrpContrato.TabStop = False
        Me.GrpContrato.Text = "Datos del Contrato"
        '
        'CboContrato
        '
        Me.CboContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CboContrato.FormattingEnabled = True
        Me.CboContrato.Location = New System.Drawing.Point(20, 44)
        Me.CboContrato.Name = "CboContrato"
        Me.CboContrato.Size = New System.Drawing.Size(319, 23)
        Me.CboContrato.TabIndex = 13
        '
        'TxtUbicaciones
        '
        Me.TxtUbicaciones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtUbicaciones.Location = New System.Drawing.Point(365, 99)
        Me.TxtUbicaciones.Multiline = True
        Me.TxtUbicaciones.Name = "TxtUbicaciones"
        Me.TxtUbicaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtUbicaciones.Size = New System.Drawing.Size(420, 55)
        Me.TxtUbicaciones.TabIndex = 6
        '
        'LblUbicaciones
        '
        Me.LblUbicaciones.AutoSize = True
        Me.LblUbicaciones.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblUbicaciones.Location = New System.Drawing.Point(365, 80)
        Me.LblUbicaciones.Name = "LblUbicaciones"
        Me.LblUbicaciones.Size = New System.Drawing.Size(193, 15)
        Me.LblUbicaciones.TabIndex = 7
        Me.LblUbicaciones.Text = "Ubicaciones / Espacios contratados"
        '
        'CboMoneda
        '
        Me.CboMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMoneda.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CboMoneda.FormattingEnabled = True
        Me.CboMoneda.Location = New System.Drawing.Point(185, 99)
        Me.CboMoneda.Name = "CboMoneda"
        Me.CboMoneda.Size = New System.Drawing.Size(154, 23)
        Me.CboMoneda.TabIndex = 5
        '
        'LblMoneda
        '
        Me.LblMoneda.AutoSize = True
        Me.LblMoneda.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblMoneda.Location = New System.Drawing.Point(185, 80)
        Me.LblMoneda.Name = "LblMoneda"
        Me.LblMoneda.Size = New System.Drawing.Size(51, 15)
        Me.LblMoneda.TabIndex = 8
        Me.LblMoneda.Text = "Moneda"
        '
        'TxtMontoMensual
        '
        Me.TxtMontoMensual.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtMontoMensual.Location = New System.Drawing.Point(20, 99)
        Me.TxtMontoMensual.Name = "TxtMontoMensual"
        Me.TxtMontoMensual.Size = New System.Drawing.Size(150, 23)
        Me.TxtMontoMensual.TabIndex = 4
        Me.TxtMontoMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMontoMensual
        '
        Me.LblMontoMensual.AutoSize = True
        Me.LblMontoMensual.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblMontoMensual.Location = New System.Drawing.Point(20, 80)
        Me.LblMontoMensual.Name = "LblMontoMensual"
        Me.LblMontoMensual.Size = New System.Drawing.Size(91, 15)
        Me.LblMontoMensual.TabIndex = 9
        Me.LblMontoMensual.Text = "Monto mensual"
        '
        'DtpFechaFinContrato
        '
        Me.DtpFechaFinContrato.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaFinContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaFinContrato.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaFinContrato.Location = New System.Drawing.Point(535, 44)
        Me.DtpFechaFinContrato.Name = "DtpFechaFinContrato"
        Me.DtpFechaFinContrato.Size = New System.Drawing.Size(120, 23)
        Me.DtpFechaFinContrato.TabIndex = 3
        '
        'LblHastaContrato
        '
        Me.LblHastaContrato.AutoSize = True
        Me.LblHastaContrato.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblHastaContrato.Location = New System.Drawing.Point(494, 48)
        Me.LblHastaContrato.Name = "LblHastaContrato"
        Me.LblHastaContrato.Size = New System.Drawing.Size(35, 15)
        Me.LblHastaContrato.TabIndex = 10
        Me.LblHastaContrato.Text = "hasta"
        '
        'DtpFechaInicioContrato
        '
        Me.DtpFechaInicioContrato.CustomFormat = "dd/MM/yyyy"
        Me.DtpFechaInicioContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpFechaInicioContrato.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpFechaInicioContrato.Location = New System.Drawing.Point(365, 44)
        Me.DtpFechaInicioContrato.Name = "DtpFechaInicioContrato"
        Me.DtpFechaInicioContrato.Size = New System.Drawing.Size(120, 23)
        Me.DtpFechaInicioContrato.TabIndex = 2
        '
        'LblVigencia
        '
        Me.LblVigencia.AutoSize = True
        Me.LblVigencia.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblVigencia.Location = New System.Drawing.Point(365, 25)
        Me.LblVigencia.Name = "LblVigencia"
        Me.LblVigencia.Size = New System.Drawing.Size(52, 15)
        Me.LblVigencia.TabIndex = 11
        Me.LblVigencia.Text = "Vigencia"
        '
        'LblCodigoContrato
        '
        Me.LblCodigoContrato.AutoSize = True
        Me.LblCodigoContrato.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblCodigoContrato.Location = New System.Drawing.Point(20, 25)
        Me.LblCodigoContrato.Name = "LblCodigoContrato"
        Me.LblCodigoContrato.Size = New System.Drawing.Size(54, 15)
        Me.LblCodigoContrato.TabIndex = 12
        Me.LblCodigoContrato.Text = "Contrato"
        '
        'GrpPeriodo
        '
        Me.GrpPeriodo.Controls.Add(Me.LblAyudaPeriodo)
        Me.GrpPeriodo.Controls.Add(Me.DtpPeriodoHasta)
        Me.GrpPeriodo.Controls.Add(Me.LblPeriodoHasta)
        Me.GrpPeriodo.Controls.Add(Me.DtpPeriodoDesde)
        Me.GrpPeriodo.Controls.Add(Me.LblPeriodoDesde)
        Me.GrpPeriodo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpPeriodo.Location = New System.Drawing.Point(20, 365)
        Me.GrpPeriodo.Name = "GrpPeriodo"
        Me.GrpPeriodo.Size = New System.Drawing.Size(810, 103)
        Me.GrpPeriodo.TabIndex = 3
        Me.GrpPeriodo.TabStop = False
        Me.GrpPeriodo.Text = "Periodo a Facturar"
        '
        'LblAyudaPeriodo
        '
        Me.LblAyudaPeriodo.AutoSize = True
        Me.LblAyudaPeriodo.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LblAyudaPeriodo.ForeColor = System.Drawing.Color.DimGray
        Me.LblAyudaPeriodo.Location = New System.Drawing.Point(365, 48)
        Me.LblAyudaPeriodo.Name = "LblAyudaPeriodo"
        Me.LblAyudaPeriodo.Size = New System.Drawing.Size(332, 15)
        Me.LblAyudaPeriodo.TabIndex = 0
        Me.LblAyudaPeriodo.Text = "El periodo debe encontrarse dentro de la vigencia del contrato."
        '
        'DtpPeriodoHasta
        '
        Me.DtpPeriodoHasta.CustomFormat = "dd/MM/yyyy"
        Me.DtpPeriodoHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpPeriodoHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPeriodoHasta.Location = New System.Drawing.Point(190, 44)
        Me.DtpPeriodoHasta.Name = "DtpPeriodoHasta"
        Me.DtpPeriodoHasta.Size = New System.Drawing.Size(150, 23)
        Me.DtpPeriodoHasta.TabIndex = 1
        '
        'LblPeriodoHasta
        '
        Me.LblPeriodoHasta.AutoSize = True
        Me.LblPeriodoHasta.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblPeriodoHasta.Location = New System.Drawing.Point(190, 25)
        Me.LblPeriodoHasta.Name = "LblPeriodoHasta"
        Me.LblPeriodoHasta.Size = New System.Drawing.Size(37, 15)
        Me.LblPeriodoHasta.TabIndex = 2
        Me.LblPeriodoHasta.Text = "Hasta"
        '
        'DtpPeriodoDesde
        '
        Me.DtpPeriodoDesde.CustomFormat = "dd/MM/yyyy"
        Me.DtpPeriodoDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpPeriodoDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPeriodoDesde.Location = New System.Drawing.Point(20, 44)
        Me.DtpPeriodoDesde.Name = "DtpPeriodoDesde"
        Me.DtpPeriodoDesde.Size = New System.Drawing.Size(150, 23)
        Me.DtpPeriodoDesde.TabIndex = 0
        '
        'LblPeriodoDesde
        '
        Me.LblPeriodoDesde.AutoSize = True
        Me.LblPeriodoDesde.Font = New System.Drawing.Font("Segoe UI", 8.5!)
        Me.LblPeriodoDesde.Location = New System.Drawing.Point(20, 25)
        Me.LblPeriodoDesde.Name = "LblPeriodoDesde"
        Me.LblPeriodoDesde.Size = New System.Drawing.Size(39, 15)
        Me.LblPeriodoDesde.TabIndex = 3
        Me.LblPeriodoDesde.Text = "Desde"
        '
        'GrpObservacion
        '
        Me.GrpObservacion.Controls.Add(Me.TxtObservacion)
        Me.GrpObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpObservacion.Location = New System.Drawing.Point(20, 478)
        Me.GrpObservacion.Name = "GrpObservacion"
        Me.GrpObservacion.Size = New System.Drawing.Size(810, 92)
        Me.GrpObservacion.TabIndex = 4
        Me.GrpObservacion.TabStop = False
        Me.GrpObservacion.Text = "Observación"
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtObservacion.Location = New System.Drawing.Point(20, 24)
        Me.TxtObservacion.Multiline = True
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObservacion.Size = New System.Drawing.Size(765, 50)
        Me.TxtObservacion.TabIndex = 0
        '
        'PnlBotones
        '
        Me.PnlBotones.BackColor = System.Drawing.Color.White
        Me.PnlBotones.Controls.Add(Me.BtnCancelar)
        Me.PnlBotones.Controls.Add(Me.BtnGuardar)
        Me.PnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnlBotones.Location = New System.Drawing.Point(0, 585)
        Me.PnlBotones.Name = "PnlBotones"
        Me.PnlBotones.Size = New System.Drawing.Size(850, 65)
        Me.PnlBotones.TabIndex = 5
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.White
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BtnCancelar.Location = New System.Drawing.Point(600, 16)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(105, 34)
        Me.BtnCancelar.TabIndex = 0
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.BtnGuardar.FlatAppearance.BorderSize = 0
        Me.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnGuardar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnGuardar.ForeColor = System.Drawing.Color.White
        Me.BtnGuardar.Location = New System.Drawing.Point(715, 16)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(115, 34)
        Me.BtnGuardar.TabIndex = 1
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'FrmSalAlmContrato
        '
        Me.AcceptButton = Me.BtnGuardar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CancelButton = Me.BtnCancelar
        Me.ClientSize = New System.Drawing.Size(850, 650)
        Me.Controls.Add(Me.GrpObservacion)
        Me.Controls.Add(Me.GrpPeriodo)
        Me.Controls.Add(Me.GrpContrato)
        Me.Controls.Add(Me.GrpOrdenTrabajo)
        Me.Controls.Add(Me.PnlTitulo)
        Me.Controls.Add(Me.PnlBotones)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSalAlmContrato"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Contrato de Alquiler - Orden de Trabajo"
        Me.PnlTitulo.ResumeLayout(False)
        Me.PnlTitulo.PerformLayout()
        Me.GrpOrdenTrabajo.ResumeLayout(False)
        Me.GrpOrdenTrabajo.PerformLayout()
        Me.GrpContrato.ResumeLayout(False)
        Me.GrpContrato.PerformLayout()
        Me.GrpPeriodo.ResumeLayout(False)
        Me.GrpPeriodo.PerformLayout()
        Me.GrpObservacion.ResumeLayout(False)
        Me.GrpObservacion.PerformLayout()
        Me.PnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents PnlTitulo As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblSubTitulo As Label

    Friend WithEvents GrpOrdenTrabajo As GroupBox
    Friend WithEvents LblSerieOT As Label
    Friend WithEvents TxtSerieOT As TextBox
    Friend WithEvents LblNroOT As Label
    Friend WithEvents TxtNroOT As TextBox
    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtCliente As TextBox

    Friend WithEvents GrpContrato As GroupBox
    Friend WithEvents LblCodigoContrato As Label
    Friend WithEvents LblVigencia As Label
    Friend WithEvents DtpFechaInicioContrato As DateTimePicker
    Friend WithEvents LblHastaContrato As Label
    Friend WithEvents DtpFechaFinContrato As DateTimePicker
    Friend WithEvents LblMontoMensual As Label
    Friend WithEvents TxtMontoMensual As TextBox
    Friend WithEvents LblMoneda As Label
    Friend WithEvents CboMoneda As ComboBox
    Friend WithEvents LblUbicaciones As Label
    Friend WithEvents TxtUbicaciones As TextBox

    Friend WithEvents GrpPeriodo As GroupBox
    Friend WithEvents LblPeriodoDesde As Label
    Friend WithEvents DtpPeriodoDesde As DateTimePicker
    Friend WithEvents LblPeriodoHasta As Label
    Friend WithEvents DtpPeriodoHasta As DateTimePicker
    Friend WithEvents LblAyudaPeriodo As Label

    Friend WithEvents GrpObservacion As GroupBox
    Friend WithEvents TxtObservacion As TextBox

    Friend WithEvents PnlBotones As Panel
    Friend WithEvents BtnCancelar As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents CboContrato As ComboBox
End Class