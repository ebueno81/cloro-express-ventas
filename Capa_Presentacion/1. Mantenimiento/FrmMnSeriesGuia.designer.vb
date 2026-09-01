<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnSeriesGuia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnSeriesGuia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.ChkInterno = New System.Windows.Forms.CheckBox()
        Me.ChkElectronico = New System.Windows.Forms.CheckBox()
        Me.TxtDescripcion = New System.Windows.Forms.TextBox()
        Me.TxtNro_Doc = New System.Windows.Forms.TextBox()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.ChkEsMedxpress = New System.Windows.Forms.CheckBox()
        Me.Panel7.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan02.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Controls.Add(Me.Pcb01)
        Me.Panel7.Controls.Add(Me.Label15)
        Me.Panel7.Location = New System.Drawing.Point(2, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(592, 63)
        Me.Panel7.TabIndex = 181
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(78, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(230, 13)
        Me.Label9.TabIndex = 187
        Me.Label9.Text = "Mantenimiento de series de guía de remisión..."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pcb01
        '
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(7, 5)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(51, 49)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 181
        Me.Pcb01.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(77, 5)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(182, 14)
        Me.Label15.TabIndex = 178
        Me.Label15.Text = "Archivo de Número de Series"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.Dgv01)
        Me.Pan01.Controls.Add(Me.ChkEsMedxpress)
        Me.Pan01.Controls.Add(Me.ChkInterno)
        Me.Pan01.Controls.Add(Me.ChkElectronico)
        Me.Pan01.Controls.Add(Me.TxtDescripcion)
        Me.Pan01.Controls.Add(Me.TxtNro_Doc)
        Me.Pan01.Controls.Add(Me.TxtSerie)
        Me.Pan01.Location = New System.Drawing.Point(2, 67)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(592, 238)
        Me.Pan01.TabIndex = 182
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 27)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(585, 207)
        Me.Dgv01.TabIndex = 199
        '
        'ChkInterno
        '
        Me.ChkInterno.AutoSize = True
        Me.ChkInterno.Location = New System.Drawing.Point(418, 5)
        Me.ChkInterno.Name = "ChkInterno"
        Me.ChkInterno.Size = New System.Drawing.Size(59, 17)
        Me.ChkInterno.TabIndex = 204
        Me.ChkInterno.Text = "Interno"
        Me.ChkInterno.UseVisualStyleBackColor = True
        '
        'ChkElectronico
        '
        Me.ChkElectronico.AutoSize = True
        Me.ChkElectronico.Location = New System.Drawing.Point(337, 5)
        Me.ChkElectronico.Name = "ChkElectronico"
        Me.ChkElectronico.Size = New System.Drawing.Size(79, 17)
        Me.ChkElectronico.TabIndex = 203
        Me.ChkElectronico.Text = "Electronico"
        Me.ChkElectronico.UseVisualStyleBackColor = True
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescripcion.Location = New System.Drawing.Point(168, 3)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        Me.TxtDescripcion.Size = New System.Drawing.Size(165, 20)
        Me.TxtDescripcion.TabIndex = 202
        '
        'TxtNro_Doc
        '
        Me.TxtNro_Doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNro_Doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNro_Doc.Location = New System.Drawing.Point(79, 3)
        Me.TxtNro_Doc.MaxLength = 7
        Me.TxtNro_Doc.Name = "TxtNro_Doc"
        Me.TxtNro_Doc.Size = New System.Drawing.Size(89, 20)
        Me.TxtNro_Doc.TabIndex = 201
        Me.TxtNro_Doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerie
        '
        Me.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerie.Location = New System.Drawing.Point(16, 3)
        Me.TxtSerie.MaxLength = 4
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(63, 20)
        Me.TxtSerie.TabIndex = 200
        Me.TxtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnNuevo)
        Me.Pan02.Controls.Add(Me.BtnEditar)
        Me.Pan02.Controls.Add(Me.BtnEliminar)
        Me.Pan02.Location = New System.Drawing.Point(0, 308)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(243, 29)
        Me.Pan02.TabIndex = 200
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(161, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(78, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnGrabar)
        Me.Pan03.Controls.Add(Me.BtnCerrar)
        Me.Pan03.Location = New System.Drawing.Point(420, 308)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(174, 29)
        Me.Pan03.TabIndex = 202
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(87, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(83, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'ChkEsMedxpress
        '
        Me.ChkEsMedxpress.AutoSize = True
        Me.ChkEsMedxpress.Location = New System.Drawing.Point(483, 5)
        Me.ChkEsMedxpress.Name = "ChkEsMedxpress"
        Me.ChkEsMedxpress.Size = New System.Drawing.Size(94, 17)
        Me.ChkEsMedxpress.TabIndex = 205
        Me.ChkEsMedxpress.Text = "Es MedXpress"
        Me.ChkEsMedxpress.UseVisualStyleBackColor = True
        '
        'FrmMnSeriesGuia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 340)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Panel7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnSeriesGuia"
        Me.Text = "Mantenimiento de Series"
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan02.ResumeLayout(False)
        Me.Pan03.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents TxtNro_Doc As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents ChkInterno As CheckBox
    Friend WithEvents ChkElectronico As CheckBox
    Friend WithEvents ChkEsMedxpress As CheckBox
End Class
