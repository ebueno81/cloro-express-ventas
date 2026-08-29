<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBolAnexo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBolAnexo))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtItem = New System.Windows.Forms.TextBox()
        Me.TxtSerieDocAnexo = New System.Windows.Forms.TextBox()
        Me.TxtSerieDoc = New System.Windows.Forms.TextBox()
        Me.txtCodClie = New System.Windows.Forms.TextBox()
        Me.TxtVar = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtDocActa = New System.Windows.Forms.TextBox()
        Me.TxtNroDocAnexo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnGenerarFactura = New System.Windows.Forms.Button()
        Me.TxtNroDoc2 = New System.Windows.Forms.TextBox()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.TxtTotalDoc = New System.Windows.Forms.TextBox()
        Me.TxtSaldo = New System.Windows.Forms.TextBox()
        Me.TxtActa = New System.Windows.Forms.TextBox()
        Me.TxtNroDoc = New System.Windows.Forms.TextBox()
        Me.TxtSerieDoc2 = New System.Windows.Forms.TextBox()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtClie = New System.Windows.Forms.TextBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pan02.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnNuevo)
        Me.Pan02.Controls.Add(Me.BtnEditar)
        Me.Pan02.Controls.Add(Me.BtnEliminar)
        Me.Pan02.Location = New System.Drawing.Point(3, 208)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(260, 29)
        Me.Pan02.TabIndex = 233
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(84, 23)
        Me.BtnNuevo.TabIndex = 175
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(87, 2)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEditar.TabIndex = 177
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(172, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Anular"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(3, 31)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(694, 120)
        Me.Dgv01.TabIndex = 8
        '
        'TxtItem
        '
        Me.TxtItem.BackColor = System.Drawing.Color.White
        Me.TxtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItem.Location = New System.Drawing.Point(313, 77)
        Me.TxtItem.MaxLength = 7
        Me.TxtItem.Name = "TxtItem"
        Me.TxtItem.Size = New System.Drawing.Size(72, 21)
        Me.TxtItem.TabIndex = 226
        Me.TxtItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerieDocAnexo
        '
        Me.TxtSerieDocAnexo.BackColor = System.Drawing.Color.White
        Me.TxtSerieDocAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerieDocAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerieDocAnexo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerieDocAnexo.Location = New System.Drawing.Point(504, 4)
        Me.TxtSerieDocAnexo.MaxLength = 4
        Me.TxtSerieDocAnexo.Name = "TxtSerieDocAnexo"
        Me.TxtSerieDocAnexo.Size = New System.Drawing.Size(49, 21)
        Me.TxtSerieDocAnexo.TabIndex = 5
        Me.TxtSerieDocAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerieDoc
        '
        Me.TxtSerieDoc.BackColor = System.Drawing.Color.White
        Me.TxtSerieDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerieDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerieDoc.Enabled = False
        Me.TxtSerieDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerieDoc.Location = New System.Drawing.Point(319, 4)
        Me.TxtSerieDoc.MaxLength = 7
        Me.TxtSerieDoc.Name = "TxtSerieDoc"
        Me.TxtSerieDoc.Size = New System.Drawing.Size(51, 21)
        Me.TxtSerieDoc.TabIndex = 2
        Me.TxtSerieDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCodClie
        '
        Me.txtCodClie.BackColor = System.Drawing.Color.White
        Me.txtCodClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodClie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodClie.Location = New System.Drawing.Point(255, 216)
        Me.txtCodClie.MaxLength = 7
        Me.txtCodClie.Name = "txtCodClie"
        Me.txtCodClie.Size = New System.Drawing.Size(72, 21)
        Me.txtCodClie.TabIndex = 238
        Me.txtCodClie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtCodClie.Visible = False
        '
        'TxtVar
        '
        Me.TxtVar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtVar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVar.Enabled = False
        Me.TxtVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtVar.Location = New System.Drawing.Point(270, 211)
        Me.TxtVar.Name = "TxtVar"
        Me.TxtVar.ReadOnly = True
        Me.TxtVar.Size = New System.Drawing.Size(57, 20)
        Me.TxtVar.TabIndex = 239
        Me.TxtVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtVar.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(547, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 21)
        Me.Label4.TabIndex = 222
        Me.Label4.Text = "Saldo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(401, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 21)
        Me.Label3.TabIndex = 220
        Me.Label3.Text = "Acta."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(205, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 21)
        Me.Label2.TabIndex = 218
        Me.Label2.Text = "Total Documento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDocActa
        '
        Me.TxtDocActa.BackColor = System.Drawing.Color.White
        Me.TxtDocActa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDocActa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocActa.Location = New System.Drawing.Point(616, 4)
        Me.TxtDocActa.MaxLength = 15
        Me.TxtDocActa.Name = "TxtDocActa"
        Me.TxtDocActa.Size = New System.Drawing.Size(64, 21)
        Me.TxtDocActa.TabIndex = 7
        Me.TxtDocActa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNroDocAnexo
        '
        Me.TxtNroDocAnexo.BackColor = System.Drawing.Color.White
        Me.TxtNroDocAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNroDocAnexo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroDocAnexo.Location = New System.Drawing.Point(554, 4)
        Me.TxtNroDocAnexo.MaxLength = 7
        Me.TxtNroDocAnexo.Name = "TxtNroDocAnexo"
        Me.TxtNroDocAnexo.Size = New System.Drawing.Size(61, 21)
        Me.TxtNroDocAnexo.TabIndex = 6
        Me.TxtNroDocAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnGenerarFactura)
        Me.Panel1.Location = New System.Drawing.Point(307, 208)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 29)
        Me.Panel1.TabIndex = 240
        '
        'BtnGenerarFactura
        '
        Me.BtnGenerarFactura.BackColor = System.Drawing.Color.White
        Me.BtnGenerarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGenerarFactura.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGenerarFactura.Image = CType(resources.GetObject("BtnGenerarFactura.Image"), System.Drawing.Image)
        Me.BtnGenerarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGenerarFactura.Location = New System.Drawing.Point(2, 2)
        Me.BtnGenerarFactura.Name = "BtnGenerarFactura"
        Me.BtnGenerarFactura.Size = New System.Drawing.Size(187, 23)
        Me.BtnGenerarFactura.TabIndex = 24
        Me.BtnGenerarFactura.Text = "Generar Factura Electrónica"
        Me.BtnGenerarFactura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnGenerarFactura.UseVisualStyleBackColor = False
        '
        'TxtNroDoc2
        '
        Me.TxtNroDoc2.BackColor = System.Drawing.Color.White
        Me.TxtNroDoc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNroDoc2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroDoc2.Location = New System.Drawing.Point(269, 216)
        Me.TxtNroDoc2.MaxLength = 7
        Me.TxtNroDoc2.Name = "TxtNroDoc2"
        Me.TxtNroDoc2.Size = New System.Drawing.Size(32, 21)
        Me.TxtNroDoc2.TabIndex = 242
        Me.TxtNroDoc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtNroDoc2.Visible = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnCerrar)
        Me.Pan03.Controls.Add(Me.BtnGrabar)
        Me.Pan03.Location = New System.Drawing.Point(502, 208)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(200, 29)
        Me.Pan03.TabIndex = 234
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.White
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(100, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(95, 23)
        Me.BtnCerrar.TabIndex = 25
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.White
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(97, 23)
        Me.BtnGrabar.TabIndex = 24
        Me.BtnGrabar.Text = "   &Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'TxtTotalDoc
        '
        Me.TxtTotalDoc.BackColor = System.Drawing.Color.White
        Me.TxtTotalDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotalDoc.Enabled = False
        Me.TxtTotalDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDoc.Location = New System.Drawing.Point(441, 4)
        Me.TxtTotalDoc.MaxLength = 20
        Me.TxtTotalDoc.Name = "TxtTotalDoc"
        Me.TxtTotalDoc.Size = New System.Drawing.Size(62, 21)
        Me.TxtTotalDoc.TabIndex = 4
        Me.TxtTotalDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSaldo.Enabled = False
        Me.TxtSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtSaldo.Location = New System.Drawing.Point(619, 182)
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.ReadOnly = True
        Me.TxtSaldo.Size = New System.Drawing.Size(76, 20)
        Me.TxtSaldo.TabIndex = 237
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtActa
        '
        Me.TxtActa.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtActa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtActa.Enabled = False
        Me.TxtActa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtActa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtActa.Location = New System.Drawing.Point(473, 182)
        Me.TxtActa.Name = "TxtActa"
        Me.TxtActa.ReadOnly = True
        Me.TxtActa.Size = New System.Drawing.Size(76, 20)
        Me.TxtActa.TabIndex = 236
        Me.TxtActa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNroDoc
        '
        Me.TxtNroDoc.BackColor = System.Drawing.Color.White
        Me.TxtNroDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNroDoc.Enabled = False
        Me.TxtNroDoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroDoc.Location = New System.Drawing.Point(371, 4)
        Me.TxtNroDoc.MaxLength = 7
        Me.TxtNroDoc.Name = "TxtNroDoc"
        Me.TxtNroDoc.Size = New System.Drawing.Size(69, 21)
        Me.TxtNroDoc.TabIndex = 3
        Me.TxtNroDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerieDoc2
        '
        Me.TxtSerieDoc2.BackColor = System.Drawing.Color.White
        Me.TxtSerieDoc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerieDoc2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerieDoc2.Location = New System.Drawing.Point(269, 216)
        Me.TxtSerieDoc2.MaxLength = 7
        Me.TxtSerieDoc2.Name = "TxtSerieDoc2"
        Me.TxtSerieDoc2.Size = New System.Drawing.Size(32, 21)
        Me.TxtSerieDoc2.TabIndex = 241
        Me.TxtSerieDoc2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtSerieDoc2.Visible = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.SeaShell
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.Dgv01)
        Me.Pan01.Controls.Add(Me.TxtItem)
        Me.Pan01.Controls.Add(Me.TxtSerieDocAnexo)
        Me.Pan01.Controls.Add(Me.TxtSerieDoc)
        Me.Pan01.Controls.Add(Me.Label4)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.TxtDocActa)
        Me.Pan01.Controls.Add(Me.TxtNroDocAnexo)
        Me.Pan01.Controls.Add(Me.TxtTotalDoc)
        Me.Pan01.Controls.Add(Me.TxtNroDoc)
        Me.Pan01.Controls.Add(Me.TxtClie)
        Me.Pan01.Controls.Add(Me.TxtFecha)
        Me.Pan01.Location = New System.Drawing.Point(2, 28)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(703, 177)
        Me.Pan01.TabIndex = 231
        '
        'TxtClie
        '
        Me.TxtClie.BackColor = System.Drawing.Color.White
        Me.TxtClie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtClie.Enabled = False
        Me.TxtClie.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClie.Location = New System.Drawing.Point(98, 4)
        Me.TxtClie.MaxLength = 20
        Me.TxtClie.Name = "TxtClie"
        Me.TxtClie.Size = New System.Drawing.Size(220, 21)
        Me.TxtClie.TabIndex = 1
        Me.TxtClie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtFecha
        '
        Me.TxtFecha.BackColor = System.Drawing.Color.White
        Me.TxtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha.Location = New System.Drawing.Point(22, 4)
        Me.TxtFecha.MaxLength = 7
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Size = New System.Drawing.Size(75, 21)
        Me.TxtFecha.TabIndex = 0
        Me.TxtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TxtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtTotal.Location = New System.Drawing.Point(327, 182)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.Size = New System.Drawing.Size(76, 20)
        Me.TxtTotal.TabIndex = 235
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(701, 25)
        Me.Label1.TabIndex = 232
        Me.Label1.Text = "Anexar Documentos - Adelantos"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmBolAnexo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 238)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.txtCodClie)
        Me.Controls.Add(Me.TxtVar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtNroDoc2)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.TxtSaldo)
        Me.Controls.Add(Me.TxtActa)
        Me.Controls.Add(Me.TxtSerieDoc2)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBolAnexo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos Anexos"
        Me.Pan02.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Pan03.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pan02 As Panel
    Friend WithEvents BtnNuevo As Button
    Friend WithEvents BtnEditar As Button
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents Dgv01 As DataGridView
    Friend WithEvents TxtItem As TextBox
    Friend WithEvents TxtSerieDocAnexo As TextBox
    Friend WithEvents TxtSerieDoc As TextBox
    Friend WithEvents txtCodClie As TextBox
    Friend WithEvents TxtVar As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtDocActa As TextBox
    Friend WithEvents TxtNroDocAnexo As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnGenerarFactura As Button
    Friend WithEvents TxtNroDoc2 As TextBox
    Friend WithEvents Pan03 As Panel
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnGrabar As Button
    Friend WithEvents TxtTotalDoc As TextBox
    Friend WithEvents TxtSaldo As TextBox
    Friend WithEvents TxtActa As TextBox
    Friend WithEvents TxtNroDoc As TextBox
    Friend WithEvents TxtSerieDoc2 As TextBox
    Friend WithEvents Pan01 As Panel
    Friend WithEvents TxtClie As TextBox
    Friend WithEvents TxtFecha As TextBox
    Friend WithEvents TxtTotal As TextBox
    Friend WithEvents Label1 As Label
End Class
