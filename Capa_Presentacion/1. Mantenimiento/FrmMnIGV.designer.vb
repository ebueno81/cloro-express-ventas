<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnIGV
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnIGV))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.TxtCodigo = New System.Windows.Forms.TextBox()
        Me.TxtPorc = New System.Windows.Forms.TextBox()
        Me.DtpFec_Emision = New System.Windows.Forms.DateTimePicker()
        Me.Pan03 = New System.Windows.Forms.Panel()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(453, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Configuración del IGV"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv01.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 34)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Dgv01.RowTemplate.Height = 18
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgv01.Size = New System.Drawing.Size(453, 132)
        Me.Dgv01.TabIndex = 189
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.BtnNuevo)
        Me.Pan01.Controls.Add(Me.BtnEditar)
        Me.Pan01.Controls.Add(Me.BtnEliminar)
        Me.Pan01.Location = New System.Drawing.Point(1, 168)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(260, 29)
        Me.Pan01.TabIndex = 191
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
        Me.BtnNuevo.Size = New System.Drawing.Size(84, 23)
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
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(172, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnGrabar)
        Me.Pan02.Controls.Add(Me.BtnCerrar)
        Me.Pan02.Location = New System.Drawing.Point(282, 168)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(172, 29)
        Me.Pan02.TabIndex = 192
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(87, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Enabled = False
        Me.TxtCodigo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = New System.Drawing.Point(1, 1)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(86, 21)
        Me.TxtCodigo.TabIndex = 193
        Me.TxtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtPorc
        '
        Me.TxtPorc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPorc.Location = New System.Drawing.Point(87, 1)
        Me.TxtPorc.Name = "TxtPorc"
        Me.TxtPorc.Size = New System.Drawing.Size(98, 21)
        Me.TxtPorc.TabIndex = 194
        '
        'DtpFec_Emision
        '
        Me.DtpFec_Emision.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Emision.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Emision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Emision.Location = New System.Drawing.Point(185, 1)
        Me.DtpFec_Emision.Name = "DtpFec_Emision"
        Me.DtpFec_Emision.Size = New System.Drawing.Size(120, 21)
        Me.DtpFec_Emision.TabIndex = 195
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.TxtPorc)
        Me.Pan03.Controls.Add(Me.DtpFec_Emision)
        Me.Pan03.Controls.Add(Me.TxtCodigo)
        Me.Pan03.Location = New System.Drawing.Point(1, 36)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(452, 25)
        Me.Pan03.TabIndex = 196
        '
        'FrmMnIGV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 198)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "FrmMnIGV"
        Me.Text = "Impuesto General a las Ventas (I.G.V.)"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan02.ResumeLayout(False)
        Me.Pan03.ResumeLayout(False)
        Me.Pan03.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TxtPorc As System.Windows.Forms.TextBox
    Friend WithEvents DtpFec_Emision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
End Class
