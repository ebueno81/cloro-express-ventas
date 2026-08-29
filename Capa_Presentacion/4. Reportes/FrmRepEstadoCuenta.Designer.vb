<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRepEstadoCuenta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRepEstadoCuenta))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.TxtTot_08 = New System.Windows.Forms.TextBox()
        Me.TxtTot_07 = New System.Windows.Forms.TextBox()
        Me.TxtTot_06 = New System.Windows.Forms.TextBox()
        Me.TxtTot_05 = New System.Windows.Forms.TextBox()
        Me.TxtTot_04 = New System.Windows.Forms.TextBox()
        Me.TxtTot_03 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.TxtTitulo_2 = New System.Windows.Forms.TextBox()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCon1 = New System.Windows.Forms.Button()
        Me.TxtCod_Clie = New System.Windows.Forms.TextBox()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.TxtClie = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Rdb02 = New System.Windows.Forms.RadioButton()
        Me.Rdb01 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtpFec_Final = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFec_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtConta_2 = New System.Windows.Forms.TextBox()
        Me.TxtConta_1 = New System.Windows.Forms.TextBox()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtTitulo_1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel10.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRuta.Location = New System.Drawing.Point(3, 2)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(249, 22)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\ReporteEstadoCuenta.XLS"
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(516, 478)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(223, 29)
        Me.Panel10.TabIndex = 241
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(57, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(105, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.Text = "1/100"
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(188, 2)
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
        Me.BtnAva.Location = New System.Drawing.Point(163, 2)
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
        Me.BtnAtr.Location = New System.Drawing.Point(32, 2)
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
        Me.BtnIni.Location = New System.Drawing.Point(7, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'TxtTot_08
        '
        Me.TxtTot_08.BackColor = System.Drawing.Color.White
        Me.TxtTot_08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_08.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_08.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_08.Location = New System.Drawing.Point(941, 454)
        Me.TxtTot_08.Name = "TxtTot_08"
        Me.TxtTot_08.ReadOnly = True
        Me.TxtTot_08.Size = New System.Drawing.Size(79, 21)
        Me.TxtTot_08.TabIndex = 240
        Me.TxtTot_08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_07
        '
        Me.TxtTot_07.BackColor = System.Drawing.Color.White
        Me.TxtTot_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_07.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_07.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_07.Location = New System.Drawing.Point(941, 434)
        Me.TxtTot_07.Name = "TxtTot_07"
        Me.TxtTot_07.ReadOnly = True
        Me.TxtTot_07.Size = New System.Drawing.Size(79, 21)
        Me.TxtTot_07.TabIndex = 239
        Me.TxtTot_07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_06
        '
        Me.TxtTot_06.BackColor = System.Drawing.Color.White
        Me.TxtTot_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_06.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_06.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_06.Location = New System.Drawing.Point(861, 454)
        Me.TxtTot_06.Name = "TxtTot_06"
        Me.TxtTot_06.ReadOnly = True
        Me.TxtTot_06.Size = New System.Drawing.Size(79, 21)
        Me.TxtTot_06.TabIndex = 238
        Me.TxtTot_06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_05
        '
        Me.TxtTot_05.BackColor = System.Drawing.Color.White
        Me.TxtTot_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_05.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_05.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_05.Location = New System.Drawing.Point(861, 434)
        Me.TxtTot_05.Name = "TxtTot_05"
        Me.TxtTot_05.ReadOnly = True
        Me.TxtTot_05.Size = New System.Drawing.Size(79, 21)
        Me.TxtTot_05.TabIndex = 237
        Me.TxtTot_05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_04
        '
        Me.TxtTot_04.BackColor = System.Drawing.Color.White
        Me.TxtTot_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_04.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_04.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_04.Location = New System.Drawing.Point(779, 454)
        Me.TxtTot_04.Name = "TxtTot_04"
        Me.TxtTot_04.ReadOnly = True
        Me.TxtTot_04.Size = New System.Drawing.Size(81, 21)
        Me.TxtTot_04.TabIndex = 236
        Me.TxtTot_04.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_03
        '
        Me.TxtTot_03.BackColor = System.Drawing.Color.White
        Me.TxtTot_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_03.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_03.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_03.Location = New System.Drawing.Point(779, 434)
        Me.TxtTot_03.Name = "TxtTot_03"
        Me.TxtTot_03.ReadOnly = True
        Me.TxtTot_03.Size = New System.Drawing.Size(81, 21)
        Me.TxtTot_03.TabIndex = 235
        Me.TxtTot_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnCerrar)
        Me.Panel7.Controls.Add(Me.BtnImp)
        Me.Panel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(873, 478)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(159, 29)
        Me.Panel7.TabIndex = 242
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(81, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(74, 22)
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnImp
        '
        Me.BtnImp.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnImp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImp.Location = New System.Drawing.Point(2, 2)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(77, 22)
        Me.BtnImp.TabIndex = 2
        Me.BtnImp.Text = "&Imprimir"
        Me.BtnImp.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label12)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(246, 219)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 243
        Me.Pan02.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(51, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "Cargando el Archivo..."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(6, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(325, 13)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Espere unos Instantes mientras el Sistema Procesa la Información..."
        '
        'Prb01
        '
        Me.Prb01.Location = New System.Drawing.Point(46, 23)
        Me.Prb01.Name = "Prb01"
        Me.Prb01.Size = New System.Drawing.Size(252, 23)
        Me.Prb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Prb01.TabIndex = 209
        Me.Prb01.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BtnExcel)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.BtnExportar)
        Me.Panel5.Location = New System.Drawing.Point(2, 477)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 31)
        Me.Panel5.TabIndex = 244
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.Location = New System.Drawing.Point(321, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(34, 27)
        Me.BtnExcel.TabIndex = 5
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnOpen)
        Me.Panel8.Controls.Add(Me.TxtRuta)
        Me.Panel8.Location = New System.Drawing.Point(1, 1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(286, 27)
        Me.Panel8.TabIndex = 4
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(252, 2)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(31, 22)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpen.UseVisualStyleBackColor = False
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.White
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExportar.Image = CType(resources.GetObject("BtnExportar.Image"), System.Drawing.Image)
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(288, 1)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(68, 27)
        Me.BtnExportar.TabIndex = 6
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'TxtTitulo_2
        '
        Me.TxtTitulo_2.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_2.Location = New System.Drawing.Point(98, 454)
        Me.TxtTitulo_2.Name = "TxtTitulo_2"
        Me.TxtTitulo_2.ReadOnly = True
        Me.TxtTitulo_2.Size = New System.Drawing.Size(680, 21)
        Me.TxtTitulo_2.TabIndex = 232
        Me.TxtTitulo_2.Text = "TOTAL EN DOLARES AMERICANOS ( $. )"
        Me.TxtTitulo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.Panel1)
        Me.Pan01.Location = New System.Drawing.Point(2, 0)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(1030, 93)
        Me.Pan01.TabIndex = 227
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnCon1)
        Me.Panel1.Controls.Add(Me.TxtCod_Clie)
        Me.Panel1.Controls.Add(Me.BtnMostrar)
        Me.Panel1.Controls.Add(Me.TxtClie)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.DtpFec_Final)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpFec_Inicio)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(171, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(655, 67)
        Me.Panel1.TabIndex = 0
        '
        'BtnCon1
        '
        Me.BtnCon1.BackColor = System.Drawing.Color.White
        Me.BtnCon1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon1.Image = CType(resources.GetObject("BtnCon1.Image"), System.Drawing.Image)
        Me.BtnCon1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.Location = New System.Drawing.Point(518, 32)
        Me.BtnCon1.Name = "BtnCon1"
        Me.BtnCon1.Size = New System.Drawing.Size(25, 22)
        Me.BtnCon1.TabIndex = 199
        Me.BtnCon1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.UseVisualStyleBackColor = False
        '
        'TxtCod_Clie
        '
        Me.TxtCod_Clie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Clie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Clie.Location = New System.Drawing.Point(77, 32)
        Me.TxtCod_Clie.Name = "TxtCod_Clie"
        Me.TxtCod_Clie.Size = New System.Drawing.Size(63, 22)
        Me.TxtCod_Clie.TabIndex = 198
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(548, 31)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnMostrar.TabIndex = 8
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'TxtClie
        '
        Me.TxtClie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClie.Enabled = False
        Me.TxtClie.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClie.Location = New System.Drawing.Point(140, 32)
        Me.TxtClie.Name = "TxtClie"
        Me.TxtClie.Size = New System.Drawing.Size(377, 22)
        Me.TxtClie.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Rdb02)
        Me.Panel2.Controls.Add(Me.Rdb01)
        Me.Panel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(20, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(254, 23)
        Me.Panel2.TabIndex = 5
        '
        'Rdb02
        '
        Me.Rdb02.AutoSize = True
        Me.Rdb02.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb02.Location = New System.Drawing.Point(164, 1)
        Me.Rdb02.Name = "Rdb02"
        Me.Rdb02.Size = New System.Drawing.Size(85, 19)
        Me.Rdb02.TabIndex = 2
        Me.Rdb02.Text = "Cancelado"
        Me.Rdb02.UseVisualStyleBackColor = True
        '
        'Rdb01
        '
        Me.Rdb01.AutoSize = True
        Me.Rdb01.Checked = True
        Me.Rdb01.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb01.Location = New System.Drawing.Point(1, 1)
        Me.Rdb01.Name = "Rdb01"
        Me.Rdb01.Size = New System.Drawing.Size(165, 19)
        Me.Rdb01.TabIndex = 1
        Me.Rdb01.TabStop = True
        Me.Rdb01.Text = "Pendientes - Amortizados"
        Me.Rdb01.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.CadetBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(20, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 23)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Cliente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Final
        '
        Me.DtpFec_Final.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Final.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Final.Location = New System.Drawing.Point(440, 9)
        Me.DtpFec_Final.Name = "DtpFec_Final"
        Me.DtpFec_Final.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Final.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.CadetBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(413, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 23)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Al"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Inicio
        '
        Me.DtpFec_Inicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Inicio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Inicio.Location = New System.Drawing.Point(309, 9)
        Me.DtpFec_Inicio.Name = "DtpFec_Inicio"
        Me.DtpFec_Inicio.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Inicio.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.CadetBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(276, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 23)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Del"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtConta_2
        '
        Me.TxtConta_2.BackColor = System.Drawing.Color.White
        Me.TxtConta_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_2.Location = New System.Drawing.Point(2, 454)
        Me.TxtConta_2.Name = "TxtConta_2"
        Me.TxtConta_2.ReadOnly = True
        Me.TxtConta_2.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_2.TabIndex = 230
        Me.TxtConta_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_1
        '
        Me.TxtConta_1.BackColor = System.Drawing.Color.White
        Me.TxtConta_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_1.Location = New System.Drawing.Point(2, 434)
        Me.TxtConta_1.Name = "TxtConta_1"
        Me.TxtConta_1.ReadOnly = True
        Me.TxtConta_1.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_1.TabIndex = 229
        Me.TxtConta_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 116)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(1030, 317)
        Me.Dgv01.TabIndex = 228
        '
        'TxtTitulo_1
        '
        Me.TxtTitulo_1.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_1.Location = New System.Drawing.Point(98, 434)
        Me.TxtTitulo_1.Name = "TxtTitulo_1"
        Me.TxtTitulo_1.ReadOnly = True
        Me.TxtTitulo_1.Size = New System.Drawing.Size(680, 21)
        Me.TxtTitulo_1.TabIndex = 231
        Me.TxtTitulo_1.Text = "TOTAL EN NUEVOS SOLES ( S/. )"
        Me.TxtTitulo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(2, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1030, 22)
        Me.Label3.TabIndex = 245
        Me.Label3.Text = "Estado de Cuenta de Clientes"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmRepEstadoCuenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 509)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.TxtTot_08)
        Me.Controls.Add(Me.TxtTot_07)
        Me.Controls.Add(Me.TxtTot_06)
        Me.Controls.Add(Me.TxtTot_05)
        Me.Controls.Add(Me.TxtTot_04)
        Me.Controls.Add(Me.TxtTot_03)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.TxtTitulo_2)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.TxtConta_2)
        Me.Controls.Add(Me.TxtConta_1)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.TxtTitulo_1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRepEstadoCuenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Estado de Cuentas - [CLIENTES]"
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Pan01.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtRuta As TextBox
    Friend WithEvents Panel10 As Panel
    Friend WithEvents TxtReg As TextBox
    Friend WithEvents BtnFin As Button
    Friend WithEvents BtnAva As Button
    Friend WithEvents BtnAtr As Button
    Friend WithEvents BtnIni As Button
    Friend WithEvents TxtTot_08 As TextBox
    Friend WithEvents TxtTot_07 As TextBox
    Friend WithEvents TxtTot_06 As TextBox
    Friend WithEvents TxtTot_05 As TextBox
    Friend WithEvents TxtTot_04 As TextBox
    Friend WithEvents TxtTot_03 As TextBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnImp As Button
    Friend WithEvents Folder01 As FolderBrowserDialog
    Friend WithEvents Pan02 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Prb01 As ProgressBar
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnExcel As Button
    Friend WithEvents Panel8 As Panel
    Friend WithEvents BtnOpen As Button
    Friend WithEvents BtnExportar As Button
    Friend WithEvents TxtTitulo_2 As TextBox
    Friend WithEvents Pan01 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnCon1 As Button
    Friend WithEvents TxtCod_Clie As TextBox
    Friend WithEvents BtnMostrar As Button
    Friend WithEvents TxtClie As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Rdb02 As RadioButton
    Friend WithEvents Rdb01 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents DtpFec_Final As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DtpFec_Inicio As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtConta_2 As TextBox
    Friend WithEvents TxtConta_1 As TextBox
    Friend WithEvents Dgv01 As DataGridView
    Friend WithEvents TxtTitulo_1 As TextBox
    Friend WithEvents Label3 As Label
End Class
