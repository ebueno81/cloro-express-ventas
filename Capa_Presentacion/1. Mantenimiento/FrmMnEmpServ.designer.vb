<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnEmpServ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnEmpServ))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Tbc01 = New System.Windows.Forms.TabControl()
        Me.Tab01 = New System.Windows.Forms.TabPage()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.BtnCerrar2 = New System.Windows.Forms.Button()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Tab02 = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtContacto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtMail = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtWeb = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtRuc = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtCel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDirec = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtDistrito = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtFecha_Modi = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Modi = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtFecha_Crea = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Crea = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtFono = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNroTarjetaCircula = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Tbc01.SuspendLayout()
        Me.Tab01.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab02.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tbc01
        '
        Me.Tbc01.Controls.Add(Me.Tab01)
        Me.Tbc01.Controls.Add(Me.Tab02)
        Me.Tbc01.Location = New System.Drawing.Point(1, 3)
        Me.Tbc01.Name = "Tbc01"
        Me.Tbc01.SelectedIndex = 0
        Me.Tbc01.Size = New System.Drawing.Size(543, 442)
        Me.Tbc01.TabIndex = 1
        '
        'Tab01
        '
        Me.Tab01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab01.Controls.Add(Me.Label11)
        Me.Tab01.Controls.Add(Me.Panel1)
        Me.Tab01.Controls.Add(Me.Panel8)
        Me.Tab01.Controls.Add(Me.Panel10)
        Me.Tab01.Controls.Add(Me.Panel11)
        Me.Tab01.Controls.Add(Me.Dgv01)
        Me.Tab01.Location = New System.Drawing.Point(4, 22)
        Me.Tab01.Name = "Tab01"
        Me.Tab01.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab01.Size = New System.Drawing.Size(535, 416)
        Me.Tab01.TabIndex = 0
        Me.Tab01.Text = "Listado"
        Me.Tab01.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(2, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(529, 19)
        Me.Label11.TabIndex = 202
        Me.Label11.Text = "Empresa de Servicios"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Pcb01)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(531, 57)
        Me.Panel1.TabIndex = 196
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(78, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 14)
        Me.Label2.TabIndex = 174
        Me.Label2.Text = "Aquí se crean las empresas de servicios..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(496, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 173
        Me.PictureBox1.TabStop = False
        '
        'Pcb01
        '
        Me.Pcb01.BackColor = System.Drawing.Color.White
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(3, 3)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(39, 36)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 164
        Me.Pcb01.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(48, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Empresa de Servicios"
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnNuevo)
        Me.Panel8.Controls.Add(Me.BtnEditar)
        Me.Panel8.Controls.Add(Me.BtnEliminar)
        Me.Panel8.Location = New System.Drawing.Point(3, 382)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(243, 29)
        Me.Panel8.TabIndex = 199
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(78, 23)
        Me.BtnNuevo.TabIndex = 175
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(81, 2)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(79, 23)
        Me.BtnEditar.TabIndex = 177
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(161, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(78, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(251, 382)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(187, 29)
        Me.Panel10.TabIndex = 200
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(52, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(80, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(157, 2)
        Me.BtnFin.Name = "BtnFin"
        Me.BtnFin.Size = New System.Drawing.Size(25, 23)
        Me.BtnFin.TabIndex = 175
        Me.BtnFin.UseVisualStyleBackColor = False
        '
        'BtnAva
        '
        Me.BtnAva.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAva.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAva.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAva.Image = CType(resources.GetObject("BtnAva.Image"), System.Drawing.Image)
        Me.BtnAva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAva.Location = New System.Drawing.Point(132, 2)
        Me.BtnAva.Name = "BtnAva"
        Me.BtnAva.Size = New System.Drawing.Size(25, 23)
        Me.BtnAva.TabIndex = 174
        Me.BtnAva.UseVisualStyleBackColor = False
        '
        'BtnAtr
        '
        Me.BtnAtr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAtr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAtr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtr.Image = CType(resources.GetObject("BtnAtr.Image"), System.Drawing.Image)
        Me.BtnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAtr.Location = New System.Drawing.Point(27, 2)
        Me.BtnAtr.Name = "BtnAtr"
        Me.BtnAtr.Size = New System.Drawing.Size(25, 23)
        Me.BtnAtr.TabIndex = 173
        Me.BtnAtr.UseVisualStyleBackColor = False
        '
        'BtnIni
        '
        Me.BtnIni.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIni.Image = CType(resources.GetObject("BtnIni.Image"), System.Drawing.Image)
        Me.BtnIni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIni.Location = New System.Drawing.Point(2, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Panel11
        '
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.BtnCerrar2)
        Me.Panel11.Location = New System.Drawing.Point(441, 382)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(91, 29)
        Me.Panel11.TabIndex = 201
        '
        'BtnCerrar2
        '
        Me.BtnCerrar2.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar2.Image = CType(resources.GetObject("BtnCerrar2.Image"), System.Drawing.Image)
        Me.BtnCerrar2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar2.Location = New System.Drawing.Point(3, 2)
        Me.BtnCerrar2.Name = "BtnCerrar2"
        Me.BtnCerrar2.Size = New System.Drawing.Size(83, 23)
        Me.BtnCerrar2.TabIndex = 176
        Me.BtnCerrar2.Text = "&Cerrar"
        Me.BtnCerrar2.UseVisualStyleBackColor = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 78)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(529, 302)
        Me.Dgv01.TabIndex = 198
        '
        'Tab02
        '
        Me.Tab02.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Tab02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tab02.Controls.Add(Me.Panel7)
        Me.Tab02.Controls.Add(Me.Pan01)
        Me.Tab02.Location = New System.Drawing.Point(4, 22)
        Me.Tab02.Name = "Tab02"
        Me.Tab02.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab02.Size = New System.Drawing.Size(535, 416)
        Me.Tab02.TabIndex = 1
        Me.Tab02.Text = "Actualizar"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnGrabar)
        Me.Panel7.Controls.Add(Me.BtnCancelar)
        Me.Panel7.Location = New System.Drawing.Point(350, 379)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(175, 29)
        Me.Panel7.TabIndex = 1
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.White
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 175
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCancelar
        '
        Me.BtnCancelar.BackColor = System.Drawing.Color.White
        Me.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancelar.Image = CType(resources.GetObject("BtnCancelar.Image"), System.Drawing.Image)
        Me.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancelar.Location = New System.Drawing.Point(87, 2)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(84, 23)
        Me.BtnCancelar.TabIndex = 177
        Me.BtnCancelar.Text = "Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtNroTarjetaCircula)
        Me.Pan01.Controls.Add(Me.Label16)
        Me.Pan01.Controls.Add(Me.TxtContacto)
        Me.Pan01.Controls.Add(Me.Label15)
        Me.Pan01.Controls.Add(Me.TxtMail)
        Me.Pan01.Controls.Add(Me.Label14)
        Me.Pan01.Controls.Add(Me.TxtWeb)
        Me.Pan01.Controls.Add(Me.Label13)
        Me.Pan01.Controls.Add(Me.TxtRuc)
        Me.Pan01.Controls.Add(Me.Label12)
        Me.Pan01.Controls.Add(Me.TxtCel)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.TxtCodigo)
        Me.Pan01.Controls.Add(Me.Label6)
        Me.Pan01.Controls.Add(Me.TxtDirec)
        Me.Pan01.Controls.Add(Me.Label10)
        Me.Pan01.Controls.Add(Me.TxtDistrito)
        Me.Pan01.Controls.Add(Me.Label8)
        Me.Pan01.Controls.Add(Me.TxtFecha_Modi)
        Me.Pan01.Controls.Add(Me.TxtUsua_Modi)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.TxtFecha_Crea)
        Me.Pan01.Controls.Add(Me.TxtUsua_Crea)
        Me.Pan01.Controls.Add(Me.Label7)
        Me.Pan01.Controls.Add(Me.TxtFono)
        Me.Pan01.Controls.Add(Me.Label4)
        Me.Pan01.Controls.Add(Me.TxtEmpresa)
        Me.Pan01.Controls.Add(Me.Label5)
        Me.Pan01.Location = New System.Drawing.Point(7, 18)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(518, 279)
        Me.Pan01.TabIndex = 0
        '
        'TxtContacto
        '
        Me.TxtContacto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtContacto.Location = New System.Drawing.Point(100, 185)
        Me.TxtContacto.MaxLength = 50
        Me.TxtContacto.Name = "TxtContacto"
        Me.TxtContacto.Size = New System.Drawing.Size(401, 20)
        Me.TxtContacto.TabIndex = 10
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(13, 185)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(86, 19)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Contacto"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtMail
        '
        Me.TxtMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.TxtMail.Location = New System.Drawing.Point(100, 164)
        Me.TxtMail.MaxLength = 30
        Me.TxtMail.Name = "TxtMail"
        Me.TxtMail.Size = New System.Drawing.Size(401, 20)
        Me.TxtMail.TabIndex = 9
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(13, 164)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 19)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Mail"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtWeb
        '
        Me.TxtWeb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtWeb.Location = New System.Drawing.Point(100, 142)
        Me.TxtWeb.MaxLength = 50
        Me.TxtWeb.Name = "TxtWeb"
        Me.TxtWeb.Size = New System.Drawing.Size(401, 20)
        Me.TxtWeb.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(13, 142)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 19)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Pagina Web"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtRuc
        '
        Me.TxtRuc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRuc.Location = New System.Drawing.Point(100, 121)
        Me.TxtRuc.MaxLength = 11
        Me.TxtRuc.Name = "TxtRuc"
        Me.TxtRuc.Size = New System.Drawing.Size(111, 20)
        Me.TxtRuc.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(13, 121)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 19)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "R.U.C."
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCel
        '
        Me.TxtCel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCel.Location = New System.Drawing.Point(341, 100)
        Me.TxtCel.MaxLength = 50
        Me.TxtCel.Name = "TxtCel"
        Me.TxtCel.Size = New System.Drawing.Size(160, 20)
        Me.TxtCel.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(264, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 19)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Celular"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Location = New System.Drawing.Point(100, 16)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(48, 20)
        Me.TxtCodigo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(13, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 19)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Código"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDirec
        '
        Me.TxtDirec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDirec.Enabled = False
        Me.TxtDirec.Location = New System.Drawing.Point(100, 79)
        Me.TxtDirec.MaxLength = 40
        Me.TxtDirec.Name = "TxtDirec"
        Me.TxtDirec.Size = New System.Drawing.Size(401, 20)
        Me.TxtDirec.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(13, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 19)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Dirección"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtDistrito
        '
        Me.TxtDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDistrito.Enabled = False
        Me.TxtDistrito.Location = New System.Drawing.Point(100, 58)
        Me.TxtDistrito.MaxLength = 30
        Me.TxtDistrito.Name = "TxtDistrito"
        Me.TxtDistrito.Size = New System.Drawing.Size(241, 20)
        Me.TxtDistrito.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(13, 58)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 19)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Distrito"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFecha_Modi
        '
        Me.TxtFecha_Modi.Enabled = False
        Me.TxtFecha_Modi.Location = New System.Drawing.Point(211, 227)
        Me.TxtFecha_Modi.Name = "TxtFecha_Modi"
        Me.TxtFecha_Modi.Size = New System.Drawing.Size(130, 20)
        Me.TxtFecha_Modi.TabIndex = 14
        '
        'TxtUsua_Modi
        '
        Me.TxtUsua_Modi.Enabled = False
        Me.TxtUsua_Modi.Location = New System.Drawing.Point(100, 227)
        Me.TxtUsua_Modi.Name = "TxtUsua_Modi"
        Me.TxtUsua_Modi.Size = New System.Drawing.Size(111, 20)
        Me.TxtUsua_Modi.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(13, 227)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 19)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Usuario Modi."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFecha_Crea
        '
        Me.TxtFecha_Crea.Enabled = False
        Me.TxtFecha_Crea.Location = New System.Drawing.Point(211, 206)
        Me.TxtFecha_Crea.Name = "TxtFecha_Crea"
        Me.TxtFecha_Crea.Size = New System.Drawing.Size(130, 20)
        Me.TxtFecha_Crea.TabIndex = 12
        '
        'TxtUsua_Crea
        '
        Me.TxtUsua_Crea.Enabled = False
        Me.TxtUsua_Crea.Location = New System.Drawing.Point(100, 206)
        Me.TxtUsua_Crea.Name = "TxtUsua_Crea"
        Me.TxtUsua_Crea.Size = New System.Drawing.Size(111, 20)
        Me.TxtUsua_Crea.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 19)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Usuario Crea."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFono
        '
        Me.TxtFono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFono.Location = New System.Drawing.Point(100, 100)
        Me.TxtFono.MaxLength = 50
        Me.TxtFono.Name = "TxtFono"
        Me.TxtFono.Size = New System.Drawing.Size(164, 20)
        Me.TxtFono.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(13, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Teléfono"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtEmpresa
        '
        Me.TxtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmpresa.Enabled = False
        Me.TxtEmpresa.Location = New System.Drawing.Point(100, 37)
        Me.TxtEmpresa.MaxLength = 120
        Me.TxtEmpresa.Name = "TxtEmpresa"
        Me.TxtEmpresa.Size = New System.Drawing.Size(401, 20)
        Me.TxtEmpresa.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(13, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Empresa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNroTarjetaCircula
        '
        Me.TxtNroTarjetaCircula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroTarjetaCircula.Location = New System.Drawing.Point(341, 121)
        Me.TxtNroTarjetaCircula.MaxLength = 11
        Me.TxtNroTarjetaCircula.Name = "TxtNroTarjetaCircula"
        Me.TxtNroTarjetaCircula.Size = New System.Drawing.Size(160, 20)
        Me.TxtNroTarjetaCircula.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(211, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(129, 19)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "N° Permiso MTC"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMnEmpServ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 446)
        Me.Controls.Add(Me.Tbc01)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnEmpServ"
        Me.Text = "Archivo de Empresa de Servicios"
        Me.Tbc01.ResumeLayout(False)
        Me.Tab01.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab02.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Tbc01 As System.Windows.Forms.TabControl
    Friend WithEvents Tab01 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Tab02 As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtDirec As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtDistrito As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha_Modi As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Modi As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtFecha_Crea As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Crea As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtFono As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMail As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtWeb As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNroTarjetaCircula As TextBox
    Friend WithEvents Label16 As Label
End Class
