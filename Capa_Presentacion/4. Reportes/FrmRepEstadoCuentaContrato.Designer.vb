<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRepEstadoCuentaContrato
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer


    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PnlTitulo = New System.Windows.Forms.Panel()
        Me.LblSubTitulo = New System.Windows.Forms.Label()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.GrpCriterios = New System.Windows.Forms.GroupBox()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblHasta = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblContrato = New System.Windows.Forms.Label()
        Me.TxtContrato = New System.Windows.Forms.TextBox()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtCodCliente = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnCliente = New System.Windows.Forms.Button()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.GrpDetalle = New System.Windows.Forms.GroupBox()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.PnlPie = New System.Windows.Forms.Panel()
        Me.GrpResumen = New System.Windows.Forms.GroupBox()
        Me.LblFacturado = New System.Windows.Forms.Label()
        Me.LblPendiente = New System.Windows.Forms.Label()
        Me.LblSoles = New System.Windows.Forms.Label()
        Me.LblDolares = New System.Windows.Forms.Label()
        Me.TxtFacturadoMN = New System.Windows.Forms.TextBox()
        Me.TxtFacturadoME = New System.Windows.Forms.TextBox()
        Me.TxtPendienteMN = New System.Windows.Forms.TextBox()
        Me.TxtPendienteME = New System.Windows.Forms.TextBox()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.PgbExportar = New System.Windows.Forms.ProgressBar()
        Me.PnlTitulo.SuspendLayout()
        Me.GrpCriterios.SuspendLayout()
        Me.GrpDetalle.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlPie.SuspendLayout()
        Me.GrpResumen.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlTitulo
        '
        Me.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(36, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.PnlTitulo.Controls.Add(Me.LblSubTitulo)
        Me.PnlTitulo.Controls.Add(Me.LblTitulo)
        Me.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitulo.Name = "PnlTitulo"
        Me.PnlTitulo.Size = New System.Drawing.Size(1280, 92)
        Me.PnlTitulo.TabIndex = 3
        '
        'LblSubTitulo
        '
        Me.LblSubTitulo.AutoSize = True
        Me.LblSubTitulo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblSubTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblSubTitulo.Location = New System.Drawing.Point(29, 54)
        Me.LblSubTitulo.Name = "LblSubTitulo"
        Me.LblSubTitulo.Size = New System.Drawing.Size(444, 15)
        Me.LblSubTitulo.TabIndex = 0
        Me.LblSubTitulo.Text = "Consulta del cronograma de cuotas y facturación de contratos de almacenamiento"
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(27, 17)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(390, 30)
        Me.LblTitulo.TabIndex = 1
        Me.LblTitulo.Text = "ESTADO DE CUENTA DE CONTRATOS"
        '
        'GrpCriterios
        '
        Me.GrpCriterios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpCriterios.Controls.Add(Me.LblDesde)
        Me.GrpCriterios.Controls.Add(Me.DtpDesde)
        Me.GrpCriterios.Controls.Add(Me.LblHasta)
        Me.GrpCriterios.Controls.Add(Me.DtpHasta)
        Me.GrpCriterios.Controls.Add(Me.LblContrato)
        Me.GrpCriterios.Controls.Add(Me.TxtContrato)
        Me.GrpCriterios.Controls.Add(Me.LblCliente)
        Me.GrpCriterios.Controls.Add(Me.TxtCodCliente)
        Me.GrpCriterios.Controls.Add(Me.TxtCliente)
        Me.GrpCriterios.Controls.Add(Me.BtnCliente)
        Me.GrpCriterios.Controls.Add(Me.BtnMostrar)
        Me.GrpCriterios.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpCriterios.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GrpCriterios.Location = New System.Drawing.Point(15, 103)
        Me.GrpCriterios.Name = "GrpCriterios"
        Me.GrpCriterios.Size = New System.Drawing.Size(1250, 120)
        Me.GrpCriterios.TabIndex = 2
        Me.GrpCriterios.TabStop = False
        Me.GrpCriterios.Text = "CRITERIOS DE CONSULTA"
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LblDesde.Location = New System.Drawing.Point(23, 35)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(118, 15)
        Me.LblDesde.TabIndex = 0
        Me.LblDesde.Text = "Inicio contrato desde"
        '
        'DtpDesde
        '
        Me.DtpDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDesde.Location = New System.Drawing.Point(150, 31)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(115, 23)
        Me.DtpDesde.TabIndex = 1
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LblHasta.Location = New System.Drawing.Point(293, 35)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(37, 15)
        Me.LblHasta.TabIndex = 2
        Me.LblHasta.Text = "Hasta"
        '
        'DtpHasta
        '
        Me.DtpHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(338, 31)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(115, 23)
        Me.DtpHasta.TabIndex = 3
        '
        'LblContrato
        '
        Me.LblContrato.AutoSize = True
        Me.LblContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblContrato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LblContrato.Location = New System.Drawing.Point(490, 35)
        Me.LblContrato.Name = "LblContrato"
        Me.LblContrato.Size = New System.Drawing.Size(54, 15)
        Me.LblContrato.TabIndex = 4
        Me.LblContrato.Text = "Contrato"
        '
        'TxtContrato
        '
        Me.TxtContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtContrato.Location = New System.Drawing.Point(555, 31)
        Me.TxtContrato.Name = "TxtContrato"
        Me.TxtContrato.Size = New System.Drawing.Size(180, 23)
        Me.TxtContrato.TabIndex = 5
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblCliente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.LblCliente.Location = New System.Drawing.Point(23, 80)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(44, 15)
        Me.LblCliente.TabIndex = 6
        Me.LblCliente.Text = "Cliente"
        '
        'TxtCodCliente
        '
        Me.TxtCodCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCodCliente.Location = New System.Drawing.Point(75, 76)
        Me.TxtCodCliente.Name = "TxtCodCliente"
        Me.TxtCodCliente.Size = New System.Drawing.Size(90, 23)
        Me.TxtCodCliente.TabIndex = 7
        '
        'TxtCliente
        '
        Me.TxtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCliente.Location = New System.Drawing.Point(171, 76)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(430, 23)
        Me.TxtCliente.TabIndex = 8
        '
        'BtnCliente
        '
        Me.BtnCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.BtnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCliente.Location = New System.Drawing.Point(607, 75)
        Me.BtnCliente.Name = "BtnCliente"
        Me.BtnCliente.Size = New System.Drawing.Size(50, 25)
        Me.BtnCliente.TabIndex = 9
        Me.BtnCliente.Text = "..."
        Me.BtnCliente.UseVisualStyleBackColor = False
        '
        'BtnMostrar
        '
        Me.BtnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnMostrar.FlatAppearance.BorderSize = 0
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnMostrar.ForeColor = System.Drawing.Color.White
        Me.BtnMostrar.Location = New System.Drawing.Point(1080, 72)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(145, 38)
        Me.BtnMostrar.TabIndex = 10
        Me.BtnMostrar.Text = "MOSTRAR"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'GrpDetalle
        '
        Me.GrpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpDetalle.Controls.Add(Me.LblRegistros)
        Me.GrpDetalle.Controls.Add(Me.Dgv01)
        Me.GrpDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GrpDetalle.Location = New System.Drawing.Point(15, 232)
        Me.GrpDetalle.Name = "GrpDetalle"
        Me.GrpDetalle.Size = New System.Drawing.Size(1250, 300)
        Me.GrpDetalle.TabIndex = 1
        Me.GrpDetalle.TabStop = False
        Me.GrpDetalle.Text = "ESTADO DE CUENTA"
        '
        'LblRegistros
        '
        Me.LblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRegistros.AutoSize = True
        Me.LblRegistros.Location = New System.Drawing.Point(1160, 2)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(72, 15)
        Me.LblRegistros.TabIndex = 0
        Me.LblRegistros.Text = "Registros: 0"
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.AllowUserToResizeRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        Me.Dgv01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Dgv01.ColumnHeadersHeight = 30
        Me.Dgv01.Location = New System.Drawing.Point(0, 23)
        Me.Dgv01.MultiSelect = False
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersVisible = False
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(1250, 280)
        Me.Dgv01.TabIndex = 1
        '
        'PnlPie
        '
        Me.PnlPie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlPie.Controls.Add(Me.GrpResumen)
        Me.PnlPie.Controls.Add(Me.BtnExportar)
        Me.PnlPie.Controls.Add(Me.BtnImprimir)
        Me.PnlPie.Controls.Add(Me.BtnCerrar)
        Me.PnlPie.Controls.Add(Me.PgbExportar)
        Me.PnlPie.Location = New System.Drawing.Point(15, 542)
        Me.PnlPie.Name = "PnlPie"
        Me.PnlPie.Size = New System.Drawing.Size(1250, 115)
        Me.PnlPie.TabIndex = 0
        '
        'GrpResumen
        '
        Me.GrpResumen.Controls.Add(Me.LblFacturado)
        Me.GrpResumen.Controls.Add(Me.LblPendiente)
        Me.GrpResumen.Controls.Add(Me.LblSoles)
        Me.GrpResumen.Controls.Add(Me.LblDolares)
        Me.GrpResumen.Controls.Add(Me.TxtFacturadoMN)
        Me.GrpResumen.Controls.Add(Me.TxtFacturadoME)
        Me.GrpResumen.Controls.Add(Me.TxtPendienteMN)
        Me.GrpResumen.Controls.Add(Me.TxtPendienteME)
        Me.GrpResumen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpResumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.GrpResumen.Location = New System.Drawing.Point(0, 0)
        Me.GrpResumen.Name = "GrpResumen"
        Me.GrpResumen.Size = New System.Drawing.Size(500, 105)
        Me.GrpResumen.TabIndex = 0
        Me.GrpResumen.TabStop = False
        Me.GrpResumen.Text = "RESUMEN DEL CONTRATO"
        '
        'LblFacturado
        '
        Me.LblFacturado.AutoSize = True
        Me.LblFacturado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.LblFacturado.Location = New System.Drawing.Point(245, 20)
        Me.LblFacturado.Name = "LblFacturado"
        Me.LblFacturado.Size = New System.Drawing.Size(77, 15)
        Me.LblFacturado.TabIndex = 0
        Me.LblFacturado.Text = "FACTURADO"
        '
        'LblPendiente
        '
        Me.LblPendiente.AutoSize = True
        Me.LblPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPendiente.Location = New System.Drawing.Point(390, 20)
        Me.LblPendiente.Name = "LblPendiente"
        Me.LblPendiente.Size = New System.Drawing.Size(70, 15)
        Me.LblPendiente.TabIndex = 1
        Me.LblPendiente.Text = "PENDIENTE"
        '
        'LblSoles
        '
        Me.LblSoles.AutoSize = True
        Me.LblSoles.ForeColor = System.Drawing.Color.Black
        Me.LblSoles.Location = New System.Drawing.Point(17, 48)
        Me.LblSoles.Name = "LblSoles"
        Me.LblSoles.Size = New System.Drawing.Size(119, 15)
        Me.LblSoles.TabIndex = 2
        Me.LblSoles.Text = "NUEVOS SOLES (S/.)"
        '
        'LblDolares
        '
        Me.LblDolares.AutoSize = True
        Me.LblDolares.ForeColor = System.Drawing.Color.Black
        Me.LblDolares.Location = New System.Drawing.Point(17, 78)
        Me.LblDolares.Name = "LblDolares"
        Me.LblDolares.Size = New System.Drawing.Size(81, 15)
        Me.LblDolares.TabIndex = 3
        Me.LblDolares.Text = "DÓLARES ($.)"
        '
        'TxtFacturadoMN
        '
        Me.TxtFacturadoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TxtFacturadoMN.Location = New System.Drawing.Point(220, 43)
        Me.TxtFacturadoMN.Name = "TxtFacturadoMN"
        Me.TxtFacturadoMN.ReadOnly = True
        Me.TxtFacturadoMN.Size = New System.Drawing.Size(120, 23)
        Me.TxtFacturadoMN.TabIndex = 4
        Me.TxtFacturadoMN.Text = "0.00"
        Me.TxtFacturadoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFacturadoME
        '
        Me.TxtFacturadoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.TxtFacturadoME.Location = New System.Drawing.Point(220, 73)
        Me.TxtFacturadoME.Name = "TxtFacturadoME"
        Me.TxtFacturadoME.ReadOnly = True
        Me.TxtFacturadoME.Size = New System.Drawing.Size(120, 23)
        Me.TxtFacturadoME.TabIndex = 5
        Me.TxtFacturadoME.Text = "0.00"
        Me.TxtFacturadoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPendienteMN
        '
        Me.TxtPendienteMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TxtPendienteMN.Location = New System.Drawing.Point(365, 43)
        Me.TxtPendienteMN.Name = "TxtPendienteMN"
        Me.TxtPendienteMN.ReadOnly = True
        Me.TxtPendienteMN.Size = New System.Drawing.Size(120, 23)
        Me.TxtPendienteMN.TabIndex = 6
        Me.TxtPendienteMN.Text = "0.00"
        Me.TxtPendienteMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPendienteME
        '
        Me.TxtPendienteME.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TxtPendienteME.Location = New System.Drawing.Point(365, 73)
        Me.TxtPendienteME.Name = "TxtPendienteME"
        Me.TxtPendienteME.ReadOnly = True
        Me.TxtPendienteME.Size = New System.Drawing.Size(120, 23)
        Me.TxtPendienteME.TabIndex = 7
        Me.TxtPendienteME.Text = "0.00"
        Me.TxtPendienteME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.BtnExportar.FlatAppearance.BorderSize = 0
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.ForeColor = System.Drawing.Color.White
        Me.BtnExportar.Location = New System.Drawing.Point(755, 45)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(145, 40)
        Me.BtnExportar.TabIndex = 1
        Me.BtnExportar.Text = "EXPORTAR EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.ForeColor = System.Drawing.Color.White
        Me.BtnImprimir.Location = New System.Drawing.Point(910, 45)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(145, 40)
        Me.BtnImprimir.TabIndex = 2
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.BtnCerrar.FlatAppearance.BorderSize = 0
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCerrar.ForeColor = System.Drawing.Color.White
        Me.BtnCerrar.Location = New System.Drawing.Point(1065, 45)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(145, 40)
        Me.BtnCerrar.TabIndex = 3
        Me.BtnCerrar.Text = "CERRAR"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'PgbExportar
        '
        Me.PgbExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgbExportar.Location = New System.Drawing.Point(755, 91)
        Me.PgbExportar.Name = "PgbExportar"
        Me.PgbExportar.Size = New System.Drawing.Size(455, 8)
        Me.PgbExportar.TabIndex = 4
        Me.PgbExportar.Visible = False
        '
        'FrmRepEstadoCuentaContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 661)
        Me.Controls.Add(Me.PnlPie)
        Me.Controls.Add(Me.GrpDetalle)
        Me.Controls.Add(Me.GrpCriterios)
        Me.Controls.Add(Me.PnlTitulo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1100, 700)
        Me.Name = "FrmRepEstadoCuentaContrato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado de Cuenta de Contratos"
        Me.PnlTitulo.ResumeLayout(False)
        Me.PnlTitulo.PerformLayout()
        Me.GrpCriterios.ResumeLayout(False)
        Me.GrpCriterios.PerformLayout()
        Me.GrpDetalle.ResumeLayout(False)
        Me.GrpDetalle.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlPie.ResumeLayout(False)
        Me.GrpResumen.ResumeLayout(False)
        Me.GrpResumen.PerformLayout()
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents PnlTitulo As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblSubTitulo As Label

    Friend WithEvents GrpCriterios As GroupBox

    Friend WithEvents LblDesde As Label
    Friend WithEvents DtpDesde As DateTimePicker

    Friend WithEvents LblHasta As Label
    Friend WithEvents DtpHasta As DateTimePicker

    Friend WithEvents LblContrato As Label
    Friend WithEvents TxtContrato As TextBox

    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtCodCliente As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents BtnCliente As Button

    Friend WithEvents BtnMostrar As Button

    Friend WithEvents GrpDetalle As GroupBox
    Friend WithEvents LblRegistros As Label
    Friend WithEvents Dgv01 As DataGridView

    Friend WithEvents PnlPie As Panel
    Friend WithEvents GrpResumen As GroupBox

    Friend WithEvents LblFacturado As Label
    Friend WithEvents LblPendiente As Label

    Friend WithEvents LblSoles As Label
    Friend WithEvents LblDolares As Label

    Friend WithEvents TxtFacturadoMN As TextBox
    Friend WithEvents TxtFacturadoME As TextBox

    Friend WithEvents TxtPendienteMN As TextBox
    Friend WithEvents TxtPendienteME As TextBox

    Friend WithEvents BtnExportar As Button
    Friend WithEvents BtnImprimir As Button
    Friend WithEvents BtnCerrar As Button

    Friend WithEvents PgbExportar As ProgressBar

End Class