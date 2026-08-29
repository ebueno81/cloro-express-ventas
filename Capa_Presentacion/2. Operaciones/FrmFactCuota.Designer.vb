<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmFactCuota
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFactCuota))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDoc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.CboTpoDoc = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.c_nro_correl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_nro_cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_fecha_cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_monto_cuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtMonCuota2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFec_Emi = New System.Windows.Forms.DateTimePicker()
        Me.TxtTotCuota = New System.Windows.Forms.TextBox()
        Me.TxtTotDoc = New System.Windows.Forms.TextBox()
        Me.TxtCuotas = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(203, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 22)
        Me.Label8.TabIndex = 211
        Me.Label8.Text = "Total Cuotas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(254, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 22)
        Me.Label7.TabIndex = 208
        Me.Label7.Text = "Monto Doc."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.Enabled = False
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(356, 28)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(52, 21)
        Me.CboMon.TabIndex = 207
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(254, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 21)
        Me.Label6.TabIndex = 206
        Me.Label6.Text = "Tipo Moneda"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDoc
        '
        Me.TxtDoc.BackColor = System.Drawing.Color.White
        Me.TxtDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDoc.Enabled = False
        Me.TxtDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDoc.Location = New System.Drawing.Point(154, 28)
        Me.TxtDoc.MaxLength = 7
        Me.TxtDoc.Name = "TxtDoc"
        Me.TxtDoc.Size = New System.Drawing.Size(99, 20)
        Me.TxtDoc.TabIndex = 205
        Me.TxtDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 28)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Anexar Documentos Comisiones"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtSerie
        '
        Me.TxtSerie.BackColor = System.Drawing.Color.White
        Me.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie.Enabled = False
        Me.TxtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie.Location = New System.Drawing.Point(108, 28)
        Me.TxtSerie.MaxLength = 3
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(45, 20)
        Me.TxtSerie.TabIndex = 204
        Me.TxtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboTpoDoc
        '
        Me.CboTpoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboTpoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTpoDoc.Enabled = False
        Me.CboTpoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboTpoDoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTpoDoc.FormattingEnabled = True
        Me.CboTpoDoc.Location = New System.Drawing.Point(108, 5)
        Me.CboTpoDoc.Name = "CboTpoDoc"
        Me.CboTpoDoc.Size = New System.Drawing.Size(300, 22)
        Me.CboTpoDoc.TabIndex = 202
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(7, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 21)
        Me.Label4.TabIndex = 201
        Me.Label4.Text = "Nro.Documento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 21)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Documento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(7, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 21)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Nro. Coutas"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Dgv01)
        Me.Panel1.Controls.Add(Me.Pan01)
        Me.Panel1.Controls.Add(Me.TxtTotCuota)
        Me.Panel1.Controls.Add(Me.TxtTotDoc)
        Me.Panel1.Controls.Add(Me.TxtCuotas)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.CboMon)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtDoc)
        Me.Panel1.Controls.Add(Me.TxtSerie)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.CboTpoDoc)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(1, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 216)
        Me.Panel1.TabIndex = 18
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeight = 22
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_nro_correl, Me.c_nro_cuota, Me.c_fecha_cuota, Me.c_monto_cuota})
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(7, 72)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(410, 117)
        Me.Dgv01.TabIndex = 214
        '
        'c_nro_correl
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.c_nro_correl.DefaultCellStyle = DataGridViewCellStyle2
        Me.c_nro_correl.HeaderText = "Item"
        Me.c_nro_correl.Name = "c_nro_correl"
        Me.c_nro_correl.Width = 60
        '
        'c_nro_cuota
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.c_nro_cuota.DefaultCellStyle = DataGridViewCellStyle3
        Me.c_nro_cuota.HeaderText = "Nro.Cuota"
        Me.c_nro_cuota.Name = "c_nro_cuota"
        Me.c_nro_cuota.Width = 90
        '
        'c_fecha_cuota
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.c_fecha_cuota.DefaultCellStyle = DataGridViewCellStyle4
        Me.c_fecha_cuota.HeaderText = "Fecha Cuota"
        Me.c_fecha_cuota.Name = "c_fecha_cuota"
        Me.c_fecha_cuota.Width = 120
        '
        'c_monto_cuota
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.c_monto_cuota.DefaultCellStyle = DataGridViewCellStyle5
        Me.c_monto_cuota.HeaderText = "Monto"
        Me.c_monto_cuota.Name = "c_monto_cuota"
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtMonCuota2)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.DtpFec_Emi)
        Me.Pan01.Location = New System.Drawing.Point(7, 73)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(410, 30)
        Me.Pan01.TabIndex = 217
        '
        'TxtMonCuota2
        '
        Me.TxtMonCuota2.BackColor = System.Drawing.Color.White
        Me.TxtMonCuota2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMonCuota2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonCuota2.Location = New System.Drawing.Point(289, 3)
        Me.TxtMonCuota2.MaxLength = 20
        Me.TxtMonCuota2.Name = "TxtMonCuota2"
        Me.TxtMonCuota2.Size = New System.Drawing.Size(73, 22)
        Me.TxtMonCuota2.TabIndex = 216
        Me.TxtMonCuota2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(219, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 23)
        Me.Label9.TabIndex = 205
        Me.Label9.Text = "Monto"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(2, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 23)
        Me.Label3.TabIndex = 204
        Me.Label3.Text = "Fecha Couta"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Emi
        '
        Me.DtpFec_Emi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Emi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Emi.Location = New System.Drawing.Point(100, 3)
        Me.DtpFec_Emi.Name = "DtpFec_Emi"
        Me.DtpFec_Emi.Size = New System.Drawing.Size(118, 22)
        Me.DtpFec_Emi.TabIndex = 2
        '
        'TxtTotCuota
        '
        Me.TxtTotCuota.BackColor = System.Drawing.Color.White
        Me.TxtTotCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotCuota.Enabled = False
        Me.TxtTotCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotCuota.Location = New System.Drawing.Point(304, 191)
        Me.TxtTotCuota.MaxLength = 20
        Me.TxtTotCuota.Name = "TxtTotCuota"
        Me.TxtTotCuota.Size = New System.Drawing.Size(92, 20)
        Me.TxtTotCuota.TabIndex = 216
        Me.TxtTotCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTotDoc
        '
        Me.TxtTotDoc.BackColor = System.Drawing.Color.White
        Me.TxtTotDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotDoc.Enabled = False
        Me.TxtTotDoc.Location = New System.Drawing.Point(335, 50)
        Me.TxtTotDoc.MaxLength = 20
        Me.TxtTotDoc.Name = "TxtTotDoc"
        Me.TxtTotDoc.Size = New System.Drawing.Size(73, 20)
        Me.TxtTotDoc.TabIndex = 215
        Me.TxtTotDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCuotas
        '
        Me.TxtCuotas.BackColor = System.Drawing.Color.White
        Me.TxtCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuotas.Location = New System.Drawing.Point(108, 49)
        Me.TxtCuotas.MaxLength = 1
        Me.TxtCuotas.Name = "TxtCuotas"
        Me.TxtCuotas.Size = New System.Drawing.Size(66, 20)
        Me.TxtCuotas.TabIndex = 212
        Me.TxtCuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.BtnCancel)
        Me.Panel10.Controls.Add(Me.BtnEdit)
        Me.Panel10.Location = New System.Drawing.Point(1, 249)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(167, 28)
        Me.Panel10.TabIndex = 30
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(83, 1)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(81, 24)
        Me.BtnCancel.TabIndex = 200
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.Location = New System.Drawing.Point(1, 1)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(81, 24)
        Me.BtnEdit.TabIndex = 199
        Me.BtnEdit.Text = "&Editar"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.BtnCerrar)
        Me.Panel11.Controls.Add(Me.BtnGrabar)
        Me.Panel11.Location = New System.Drawing.Point(259, 249)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(167, 28)
        Me.Panel11.TabIndex = 31
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(83, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 24)
        Me.BtnCerrar.TabIndex = 200
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(81, 24)
        Me.BtnGrabar.TabIndex = 199
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'FrmFactCuota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 279)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFactCuota"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuotas De Documentos"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CboMon As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtDoc As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtSerie As TextBox
    Friend WithEvents CboTpoDoc As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtCuotas As TextBox
    Friend WithEvents TxtTotCuota As TextBox
    Friend WithEvents TxtTotDoc As TextBox
    Friend WithEvents Dgv01 As DataGridView
    Friend WithEvents Panel10 As Panel
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents Panel11 As Panel
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnGrabar As Button
    Friend WithEvents Pan01 As Panel
    Friend WithEvents TxtMonCuota2 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DtpFec_Emi As DateTimePicker
    Friend WithEvents c_nro_correl As DataGridViewTextBoxColumn
    Friend WithEvents c_nro_cuota As DataGridViewTextBoxColumn
    Friend WithEvents c_fecha_cuota As DataGridViewTextBoxColumn
    Friend WithEvents c_monto_cuota As DataGridViewTextBoxColumn
End Class
