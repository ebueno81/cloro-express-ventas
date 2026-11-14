<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRptFacturacionContrato
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
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblSubTitulo = New System.Windows.Forms.Label()
        Me.GrpFiltros = New System.Windows.Forms.GroupBox()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.DtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.LblHasta = New System.Windows.Forms.Label()
        Me.DtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.TxtCodCliente = New System.Windows.Forms.TextBox()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.BtnBuscarCliente = New System.Windows.Forms.Button()
        Me.LblContrato = New System.Windows.Forms.Label()
        Me.TxtContrato = New System.Windows.Forms.TextBox()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.RdbTodos = New System.Windows.Forms.RadioButton()
        Me.RdbFacturados = New System.Windows.Forms.RadioButton()
        Me.RdbPendienteFacturar = New System.Windows.Forms.RadioButton()
        Me.RdbPendienteOT = New System.Windows.Forms.RadioButton()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.PnlResultadoTitulo = New System.Windows.Forms.Panel()
        Me.LblResultado = New System.Windows.Forms.Label()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.PnlResumen = New System.Windows.Forms.Panel()
        Me.LblResumen = New System.Windows.Forms.Label()
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
        Me.GrpFiltros.SuspendLayout()
        Me.PnlResultadoTitulo.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlResumen.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlTitulo
        '
        Me.PnlTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.PnlTitulo.Controls.Add(Me.LblTitulo)
        Me.PnlTitulo.Controls.Add(Me.LblSubTitulo)
        Me.PnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitulo.Name = "PnlTitulo"
        Me.PnlTitulo.Size = New System.Drawing.Size(1280, 72)
        Me.PnlTitulo.TabIndex = 0
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(22, 10)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(477, 30)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "CONTROL DE FACTURACIÓN DE CONTRATOS"
        '
        'LblSubTitulo
        '
        Me.LblSubTitulo.AutoSize = True
        Me.LblSubTitulo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.LblSubTitulo.Location = New System.Drawing.Point(24, 44)
        Me.LblSubTitulo.Name = "LblSubTitulo"
        Me.LblSubTitulo.Size = New System.Drawing.Size(425, 15)
        Me.LblSubTitulo.TabIndex = 1
        Me.LblSubTitulo.Text = "Consulta de períodos facturados y pendientes de contratos de almacenamiento"
        '
        'GrpFiltros
        '
        Me.GrpFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpFiltros.BackColor = System.Drawing.Color.White
        Me.GrpFiltros.Controls.Add(Me.LblDesde)
        Me.GrpFiltros.Controls.Add(Me.DtpDesde)
        Me.GrpFiltros.Controls.Add(Me.LblHasta)
        Me.GrpFiltros.Controls.Add(Me.DtpHasta)
        Me.GrpFiltros.Controls.Add(Me.LblCliente)
        Me.GrpFiltros.Controls.Add(Me.TxtCodCliente)
        Me.GrpFiltros.Controls.Add(Me.TxtCliente)
        Me.GrpFiltros.Controls.Add(Me.BtnBuscarCliente)
        Me.GrpFiltros.Controls.Add(Me.LblContrato)
        Me.GrpFiltros.Controls.Add(Me.TxtContrato)
        Me.GrpFiltros.Controls.Add(Me.LblEstado)
        Me.GrpFiltros.Controls.Add(Me.RdbTodos)
        Me.GrpFiltros.Controls.Add(Me.RdbFacturados)
        Me.GrpFiltros.Controls.Add(Me.RdbPendienteFacturar)
        Me.GrpFiltros.Controls.Add(Me.RdbPendienteOT)
        Me.GrpFiltros.Controls.Add(Me.BtnMostrar)
        Me.GrpFiltros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GrpFiltros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GrpFiltros.Location = New System.Drawing.Point(15, 82)
        Me.GrpFiltros.Name = "GrpFiltros"
        Me.GrpFiltros.Size = New System.Drawing.Size(1250, 145)
        Me.GrpFiltros.TabIndex = 1
        Me.GrpFiltros.TabStop = False
        Me.GrpFiltros.Text = "  CRITERIOS DE CONSULTA  "
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblDesde.Location = New System.Drawing.Point(20, 30)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(39, 15)
        Me.LblDesde.TabIndex = 0
        Me.LblDesde.Text = "Desde"
        '
        'DtpDesde
        '
        Me.DtpDesde.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpDesde.Location = New System.Drawing.Point(75, 26)
        Me.DtpDesde.Name = "DtpDesde"
        Me.DtpDesde.Size = New System.Drawing.Size(115, 23)
        Me.DtpDesde.TabIndex = 1
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblHasta.Location = New System.Drawing.Point(215, 30)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(37, 15)
        Me.LblHasta.TabIndex = 2
        Me.LblHasta.Text = "Hasta"
        '
        'DtpHasta
        '
        Me.DtpHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpHasta.Location = New System.Drawing.Point(265, 26)
        Me.DtpHasta.Name = "DtpHasta"
        Me.DtpHasta.Size = New System.Drawing.Size(115, 23)
        Me.DtpHasta.TabIndex = 3
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = True
        Me.LblCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblCliente.Location = New System.Drawing.Point(20, 66)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(44, 15)
        Me.LblCliente.TabIndex = 6
        Me.LblCliente.Text = "Cliente"
        '
        'TxtCodCliente
        '
        Me.TxtCodCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCodCliente.Location = New System.Drawing.Point(75, 62)
        Me.TxtCodCliente.MaxLength = 6
        Me.TxtCodCliente.Name = "TxtCodCliente"
        Me.TxtCodCliente.Size = New System.Drawing.Size(90, 23)
        Me.TxtCodCliente.TabIndex = 7
        '
        'TxtCliente
        '
        Me.TxtCliente.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtCliente.Location = New System.Drawing.Point(170, 62)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(430, 23)
        Me.TxtCliente.TabIndex = 8
        Me.TxtCliente.TabStop = False
        '
        'BtnBuscarCliente
        '
        Me.BtnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnBuscarCliente.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BtnBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBuscarCliente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnBuscarCliente.Location = New System.Drawing.Point(605, 61)
        Me.BtnBuscarCliente.Name = "BtnBuscarCliente"
        Me.BtnBuscarCliente.Size = New System.Drawing.Size(50, 25)
        Me.BtnBuscarCliente.TabIndex = 9
        Me.BtnBuscarCliente.Text = "..."
        Me.BtnBuscarCliente.UseVisualStyleBackColor = False
        '
        'LblContrato
        '
        Me.LblContrato.AutoSize = True
        Me.LblContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblContrato.Location = New System.Drawing.Point(410, 30)
        Me.LblContrato.Name = "LblContrato"
        Me.LblContrato.Size = New System.Drawing.Size(54, 15)
        Me.LblContrato.TabIndex = 4
        Me.LblContrato.Text = "Contrato"
        '
        'TxtContrato
        '
        Me.TxtContrato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContrato.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TxtContrato.Location = New System.Drawing.Point(475, 26)
        Me.TxtContrato.MaxLength = 30
        Me.TxtContrato.Name = "TxtContrato"
        Me.TxtContrato.Size = New System.Drawing.Size(180, 23)
        Me.TxtContrato.TabIndex = 5
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.LblEstado.Location = New System.Drawing.Point(20, 106)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(42, 15)
        Me.LblEstado.TabIndex = 10
        Me.LblEstado.Text = "Estado"
        '
        'RdbTodos
        '
        Me.RdbTodos.AutoSize = True
        Me.RdbTodos.Checked = True
        Me.RdbTodos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RdbTodos.Location = New System.Drawing.Point(75, 104)
        Me.RdbTodos.Name = "RdbTodos"
        Me.RdbTodos.Size = New System.Drawing.Size(57, 19)
        Me.RdbTodos.TabIndex = 11
        Me.RdbTodos.TabStop = True
        Me.RdbTodos.Text = "Todos"
        Me.RdbTodos.UseVisualStyleBackColor = True
        '
        'RdbFacturados
        '
        Me.RdbFacturados.AutoSize = True
        Me.RdbFacturados.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RdbFacturados.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.RdbFacturados.Location = New System.Drawing.Point(150, 104)
        Me.RdbFacturados.Name = "RdbFacturados"
        Me.RdbFacturados.Size = New System.Drawing.Size(83, 19)
        Me.RdbFacturados.TabIndex = 12
        Me.RdbFacturados.Text = "Facturados"
        Me.RdbFacturados.UseVisualStyleBackColor = True
        '
        'RdbPendienteFacturar
        '
        Me.RdbPendienteFacturar.AutoSize = True
        Me.RdbPendienteFacturar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RdbPendienteFacturar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RdbPendienteFacturar.Location = New System.Drawing.Point(255, 104)
        Me.RdbPendienteFacturar.Name = "RdbPendienteFacturar"
        Me.RdbPendienteFacturar.Size = New System.Drawing.Size(101, 19)
        Me.RdbPendienteFacturar.TabIndex = 13
        Me.RdbPendienteFacturar.Text = "Pend. Facturar"
        Me.RdbPendienteFacturar.UseVisualStyleBackColor = True
        '
        'RdbPendienteOT
        '
        Me.RdbPendienteOT.AutoSize = True
        Me.RdbPendienteOT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RdbPendienteOT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.RdbPendienteOT.Location = New System.Drawing.Point(390, 104)
        Me.RdbPendienteOT.Name = "RdbPendienteOT"
        Me.RdbPendienteOT.Size = New System.Drawing.Size(73, 19)
        Me.RdbPendienteOT.TabIndex = 14
        Me.RdbPendienteOT.Text = "Pend. OT"
        Me.RdbPendienteOT.UseVisualStyleBackColor = True
        '
        'BtnMostrar
        '
        Me.BtnMostrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.BtnMostrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMostrar.FlatAppearance.BorderSize = 0
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMostrar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.BtnMostrar.ForeColor = System.Drawing.Color.White
        Me.BtnMostrar.Location = New System.Drawing.Point(1080, 87)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(145, 38)
        Me.BtnMostrar.TabIndex = 15
        Me.BtnMostrar.Text = "MOSTRAR"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'PnlResultadoTitulo
        '
        Me.PnlResultadoTitulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlResultadoTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PnlResultadoTitulo.Controls.Add(Me.LblResultado)
        Me.PnlResultadoTitulo.Controls.Add(Me.LblRegistros)
        Me.PnlResultadoTitulo.Location = New System.Drawing.Point(15, 237)
        Me.PnlResultadoTitulo.Name = "PnlResultadoTitulo"
        Me.PnlResultadoTitulo.Size = New System.Drawing.Size(1250, 34)
        Me.PnlResultadoTitulo.TabIndex = 2
        '
        'LblResultado
        '
        Me.LblResultado.AutoSize = True
        Me.LblResultado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblResultado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.LblResultado.Location = New System.Drawing.Point(10, 9)
        Me.LblResultado.Name = "LblResultado"
        Me.LblResultado.Size = New System.Drawing.Size(145, 15)
        Me.LblResultado.TabIndex = 0
        Me.LblResultado.Text = "DETALLE DE CONTRATOS"
        '
        'LblRegistros
        '
        Me.LblRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblRegistros.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblRegistros.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.LblRegistros.Location = New System.Drawing.Point(1070, 8)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(165, 18)
        Me.LblRegistros.TabIndex = 1
        Me.LblRegistros.Text = "Registros: 0"
        Me.LblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.Dgv01.ColumnHeadersHeight = 32
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv01.Location = New System.Drawing.Point(15, 271)
        Me.Dgv01.MultiSelect = False
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersVisible = False
        Me.Dgv01.RowTemplate.Height = 25
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(1250, 360)
        Me.Dgv01.TabIndex = 3
        '
        'PnlResumen
        '
        Me.PnlResumen.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlResumen.BackColor = System.Drawing.Color.White
        Me.PnlResumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlResumen.Controls.Add(Me.PgbExportar)
        Me.PnlResumen.Controls.Add(Me.LblResumen)
        Me.PnlResumen.Controls.Add(Me.LblFacturado)
        Me.PnlResumen.Controls.Add(Me.LblPendiente)
        Me.PnlResumen.Controls.Add(Me.LblSoles)
        Me.PnlResumen.Controls.Add(Me.LblDolares)
        Me.PnlResumen.Controls.Add(Me.TxtFacturadoMN)
        Me.PnlResumen.Controls.Add(Me.TxtFacturadoME)
        Me.PnlResumen.Controls.Add(Me.TxtPendienteMN)
        Me.PnlResumen.Controls.Add(Me.TxtPendienteME)
        Me.PnlResumen.Controls.Add(Me.BtnExportar)
        Me.PnlResumen.Controls.Add(Me.BtnImprimir)
        Me.PnlResumen.Controls.Add(Me.BtnCerrar)
        Me.PnlResumen.Location = New System.Drawing.Point(15, 641)
        Me.PnlResumen.Name = "PnlResumen"
        Me.PnlResumen.Size = New System.Drawing.Size(1250, 115)
        Me.PnlResumen.TabIndex = 4
        '
        'LblResumen
        '
        Me.LblResumen.AutoSize = True
        Me.LblResumen.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LblResumen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.LblResumen.Location = New System.Drawing.Point(12, 10)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(165, 15)
        Me.LblResumen.TabIndex = 0
        Me.LblResumen.Text = "RESUMEN DE FACTURACIÓN"
        '
        'LblFacturado
        '
        Me.LblFacturado.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LblFacturado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.LblFacturado.Location = New System.Drawing.Point(220, 12)
        Me.LblFacturado.Name = "LblFacturado"
        Me.LblFacturado.Size = New System.Drawing.Size(120, 18)
        Me.LblFacturado.TabIndex = 1
        Me.LblFacturado.Text = "FACTURADO"
        Me.LblFacturado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblPendiente
        '
        Me.LblPendiente.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LblPendiente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPendiente.Location = New System.Drawing.Point(360, 12)
        Me.LblPendiente.Name = "LblPendiente"
        Me.LblPendiente.Size = New System.Drawing.Size(120, 18)
        Me.LblPendiente.TabIndex = 2
        Me.LblPendiente.Text = "PENDIENTE"
        Me.LblPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblSoles
        '
        Me.LblSoles.AutoSize = True
        Me.LblSoles.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LblSoles.Location = New System.Drawing.Point(15, 42)
        Me.LblSoles.Name = "LblSoles"
        Me.LblSoles.Size = New System.Drawing.Size(119, 15)
        Me.LblSoles.TabIndex = 3
        Me.LblSoles.Text = "NUEVOS SOLES (S/.)"
        '
        'LblDolares
        '
        Me.LblDolares.AutoSize = True
        Me.LblDolares.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold)
        Me.LblDolares.Location = New System.Drawing.Point(15, 75)
        Me.LblDolares.Name = "LblDolares"
        Me.LblDolares.Size = New System.Drawing.Size(81, 15)
        Me.LblDolares.TabIndex = 4
        Me.LblDolares.Text = "DÓLARES ($.)"
        '
        'TxtFacturadoMN
        '
        Me.TxtFacturadoMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TxtFacturadoMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFacturadoMN.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.TxtFacturadoMN.Location = New System.Drawing.Point(220, 37)
        Me.TxtFacturadoMN.Name = "TxtFacturadoMN"
        Me.TxtFacturadoMN.ReadOnly = True
        Me.TxtFacturadoMN.Size = New System.Drawing.Size(120, 24)
        Me.TxtFacturadoMN.TabIndex = 5
        Me.TxtFacturadoMN.TabStop = False
        Me.TxtFacturadoMN.Text = "0.00"
        Me.TxtFacturadoMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtFacturadoME
        '
        Me.TxtFacturadoME.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.TxtFacturadoME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFacturadoME.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.TxtFacturadoME.Location = New System.Drawing.Point(220, 70)
        Me.TxtFacturadoME.Name = "TxtFacturadoME"
        Me.TxtFacturadoME.ReadOnly = True
        Me.TxtFacturadoME.Size = New System.Drawing.Size(120, 24)
        Me.TxtFacturadoME.TabIndex = 6
        Me.TxtFacturadoME.TabStop = False
        Me.TxtFacturadoME.Text = "0.00"
        Me.TxtFacturadoME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPendienteMN
        '
        Me.TxtPendienteMN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TxtPendienteMN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPendienteMN.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.TxtPendienteMN.Location = New System.Drawing.Point(360, 37)
        Me.TxtPendienteMN.Name = "TxtPendienteMN"
        Me.TxtPendienteMN.ReadOnly = True
        Me.TxtPendienteMN.Size = New System.Drawing.Size(120, 24)
        Me.TxtPendienteMN.TabIndex = 7
        Me.TxtPendienteMN.TabStop = False
        Me.TxtPendienteMN.Text = "0.00"
        Me.TxtPendienteMN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPendienteME
        '
        Me.TxtPendienteME.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.TxtPendienteME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPendienteME.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.TxtPendienteME.Location = New System.Drawing.Point(360, 70)
        Me.TxtPendienteME.Name = "TxtPendienteME"
        Me.TxtPendienteME.ReadOnly = True
        Me.TxtPendienteME.Size = New System.Drawing.Size(120, 24)
        Me.TxtPendienteME.TabIndex = 8
        Me.TxtPendienteME.TabStop = False
        Me.TxtPendienteME.Text = "0.00"
        Me.TxtPendienteME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnExportar
        '
        Me.BtnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnExportar.BackColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.BtnExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExportar.FlatAppearance.BorderSize = 0
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExportar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnExportar.ForeColor = System.Drawing.Color.White
        Me.BtnExportar.Location = New System.Drawing.Point(755, 58)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(145, 38)
        Me.BtnExportar.TabIndex = 9
        Me.BtnExportar.Text = "EXPORTAR EXCEL"
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'BtnImprimir
        '
        Me.BtnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnImprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.BtnImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnImprimir.FlatAppearance.BorderSize = 0
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprimir.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnImprimir.ForeColor = System.Drawing.Color.White
        Me.BtnImprimir.Location = New System.Drawing.Point(910, 58)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(145, 38)
        Me.BtnImprimir.TabIndex = 10
        Me.BtnImprimir.Text = "IMPRIMIR"
        Me.BtnImprimir.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(115, Byte), Integer))
        Me.BtnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCerrar.FlatAppearance.BorderSize = 0
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCerrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCerrar.ForeColor = System.Drawing.Color.White
        Me.BtnCerrar.Location = New System.Drawing.Point(1065, 58)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(160, 38)
        Me.BtnCerrar.TabIndex = 11
        Me.BtnCerrar.Text = "CERRAR"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'PgbExportar
        '
        Me.PgbExportar.Location = New System.Drawing.Point(755, 29)
        Me.PgbExportar.Name = "PgbExportar"
        Me.PgbExportar.Size = New System.Drawing.Size(145, 23)
        Me.PgbExportar.TabIndex = 12
        Me.PgbExportar.Visible = False
        '
        'FrmRptFacturacionContrato
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1280, 770)
        Me.Controls.Add(Me.PnlResumen)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.PnlResultadoTitulo)
        Me.Controls.Add(Me.GrpFiltros)
        Me.Controls.Add(Me.PnlTitulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(1100, 700)
        Me.Name = "FrmRptFacturacionContrato"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Facturación de Contratos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PnlTitulo.ResumeLayout(False)
        Me.PnlTitulo.PerformLayout()
        Me.GrpFiltros.ResumeLayout(False)
        Me.GrpFiltros.PerformLayout()
        Me.PnlResultadoTitulo.ResumeLayout(False)
        Me.PnlResultadoTitulo.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlResumen.ResumeLayout(False)
        Me.PnlResumen.PerformLayout()
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents PnlTitulo As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblSubTitulo As Label

    Friend WithEvents GrpFiltros As GroupBox

    Friend WithEvents LblDesde As Label
    Friend WithEvents DtpDesde As DateTimePicker

    Friend WithEvents LblHasta As Label
    Friend WithEvents DtpHasta As DateTimePicker

    Friend WithEvents LblCliente As Label
    Friend WithEvents TxtCodCliente As TextBox
    Friend WithEvents TxtCliente As TextBox
    Friend WithEvents BtnBuscarCliente As Button

    Friend WithEvents LblContrato As Label
    Friend WithEvents TxtContrato As TextBox

    Friend WithEvents LblEstado As Label
    Friend WithEvents RdbTodos As RadioButton
    Friend WithEvents RdbFacturados As RadioButton
    Friend WithEvents RdbPendienteFacturar As RadioButton
    Friend WithEvents RdbPendienteOT As RadioButton

    Friend WithEvents BtnMostrar As Button

    Friend WithEvents PnlResultadoTitulo As Panel
    Friend WithEvents LblResultado As Label
    Friend WithEvents LblRegistros As Label

    Friend WithEvents Dgv01 As DataGridView

    Friend WithEvents PnlResumen As Panel

    Friend WithEvents LblResumen As Label

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