<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFechas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFechas))
        Me.grb01 = New System.Windows.Forms.GroupBox
        Me.CboCriterio3 = New System.Windows.Forms.ComboBox
        Me.chkimp = New System.Windows.Forms.CheckBox
        Me.Chkopcion2 = New System.Windows.Forms.CheckBox
        Me.txtobs = New System.Windows.Forms.TextBox
        Me.chkopcion = New System.Windows.Forms.CheckBox
        Me.lblestado = New System.Windows.Forms.Label
        Me.cbocriterio2 = New System.Windows.Forms.ComboBox
        Me.lblopciones = New System.Windows.Forms.Label
        Me.cbocriterio = New System.Windows.Forms.ComboBox
        Me.lbltipo = New System.Windows.Forms.Label
        Me.lblobs = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnopen = New System.Windows.Forms.Button
        Me.btngrabar = New System.Windows.Forms.Button
        Me.txtruta = New System.Windows.Forms.TextBox
        Me.btnvis = New System.Windows.Forms.Button
        Me.fecha2 = New System.Windows.Forms.DateTimePicker
        Me.fecha1 = New System.Windows.Forms.DateTimePicker
        Me.lblfecha2 = New System.Windows.Forms.Label
        Me.lblfecha1 = New System.Windows.Forms.Label
        Me.Open01 = New System.Windows.Forms.OpenFileDialog
        Me.folder01 = New System.Windows.Forms.FolderBrowserDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbltot = New System.Windows.Forms.ToolStripStatusLabel
        Me.pro01 = New System.Windows.Forms.ToolStripProgressBar
        Me.grb01.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grb01
        '
        Me.grb01.Controls.Add(Me.CboCriterio3)
        Me.grb01.Controls.Add(Me.chkimp)
        Me.grb01.Controls.Add(Me.Chkopcion2)
        Me.grb01.Controls.Add(Me.txtobs)
        Me.grb01.Controls.Add(Me.chkopcion)
        Me.grb01.Controls.Add(Me.lblestado)
        Me.grb01.Controls.Add(Me.cbocriterio2)
        Me.grb01.Controls.Add(Me.lblopciones)
        Me.grb01.Controls.Add(Me.cbocriterio)
        Me.grb01.Controls.Add(Me.lbltipo)
        Me.grb01.Controls.Add(Me.lblobs)
        Me.grb01.Controls.Add(Me.Label1)
        Me.grb01.Controls.Add(Me.btnopen)
        Me.grb01.Controls.Add(Me.btngrabar)
        Me.grb01.Controls.Add(Me.txtruta)
        Me.grb01.Controls.Add(Me.btnvis)
        Me.grb01.Controls.Add(Me.fecha2)
        Me.grb01.Controls.Add(Me.fecha1)
        Me.grb01.Controls.Add(Me.lblfecha2)
        Me.grb01.Controls.Add(Me.lblfecha1)
        Me.grb01.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grb01.Location = New System.Drawing.Point(3, 1)
        Me.grb01.Name = "grb01"
        Me.grb01.Size = New System.Drawing.Size(429, 200)
        Me.grb01.TabIndex = 0
        Me.grb01.TabStop = False
        '
        'CboCriterio3
        '
        Me.CboCriterio3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboCriterio3.FormattingEnabled = True
        Me.CboCriterio3.Location = New System.Drawing.Point(69, 76)
        Me.CboCriterio3.Name = "CboCriterio3"
        Me.CboCriterio3.Size = New System.Drawing.Size(137, 21)
        Me.CboCriterio3.TabIndex = 2
        Me.CboCriterio3.Visible = False
        '
        'chkimp
        '
        Me.chkimp.AutoSize = True
        Me.chkimp.Checked = True
        Me.chkimp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkimp.ForeColor = System.Drawing.Color.Navy
        Me.chkimp.Location = New System.Drawing.Point(9, 178)
        Me.chkimp.Name = "chkimp"
        Me.chkimp.Size = New System.Drawing.Size(144, 17)
        Me.chkimp.TabIndex = 20
        Me.chkimp.Text = "Seleccionar Impresora..."
        Me.chkimp.UseVisualStyleBackColor = True
        '
        'Chkopcion2
        '
        Me.Chkopcion2.AutoSize = True
        Me.Chkopcion2.Location = New System.Drawing.Point(292, 80)
        Me.Chkopcion2.Name = "Chkopcion2"
        Me.Chkopcion2.Size = New System.Drawing.Size(120, 17)
        Me.Chkopcion2.TabIndex = 19
        Me.Chkopcion2.Text = "Stock Mayor a Cero"
        Me.Chkopcion2.UseVisualStyleBackColor = True
        Me.Chkopcion2.Visible = False
        '
        'txtobs
        '
        Me.txtobs.Location = New System.Drawing.Point(69, 77)
        Me.txtobs.Name = "txtobs"
        Me.txtobs.Size = New System.Drawing.Size(137, 21)
        Me.txtobs.TabIndex = 18
        Me.txtobs.Visible = False
        '
        'chkopcion
        '
        Me.chkopcion.AutoSize = True
        Me.chkopcion.Location = New System.Drawing.Point(69, 80)
        Me.chkopcion.Name = "chkopcion"
        Me.chkopcion.Size = New System.Drawing.Size(218, 17)
        Me.chkopcion.TabIndex = 17
        Me.chkopcion.Text = "Mostrar solo Productos con Movimientos"
        Me.chkopcion.UseVisualStyleBackColor = True
        Me.chkopcion.Visible = False
        '
        'lblestado
        '
        Me.lblestado.AutoSize = True
        Me.lblestado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblestado.Location = New System.Drawing.Point(215, 50)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(40, 13)
        Me.lblestado.TabIndex = 16
        Me.lblestado.Text = "Estado"
        Me.lblestado.Visible = False
        '
        'cbocriterio2
        '
        Me.cbocriterio2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocriterio2.FormattingEnabled = True
        Me.cbocriterio2.Location = New System.Drawing.Point(278, 47)
        Me.cbocriterio2.Name = "cbocriterio2"
        Me.cbocriterio2.Size = New System.Drawing.Size(137, 21)
        Me.cbocriterio2.TabIndex = 1
        Me.cbocriterio2.Visible = False
        '
        'lblopciones
        '
        Me.lblopciones.AutoSize = True
        Me.lblopciones.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblopciones.Location = New System.Drawing.Point(9, 50)
        Me.lblopciones.Name = "lblopciones"
        Me.lblopciones.Size = New System.Drawing.Size(58, 13)
        Me.lblopciones.TabIndex = 14
        Me.lblopciones.Text = "Opciones :"
        '
        'cbocriterio
        '
        Me.cbocriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocriterio.FormattingEnabled = True
        Me.cbocriterio.Location = New System.Drawing.Point(69, 45)
        Me.cbocriterio.Name = "cbocriterio"
        Me.cbocriterio.Size = New System.Drawing.Size(137, 21)
        Me.cbocriterio.TabIndex = 0
        '
        'lbltipo
        '
        Me.lbltipo.AutoSize = True
        Me.lbltipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltipo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lbltipo.Location = New System.Drawing.Point(9, 16)
        Me.lbltipo.Name = "lbltipo"
        Me.lbltipo.Size = New System.Drawing.Size(103, 15)
        Me.lbltipo.TabIndex = 12
        Me.lbltipo.Text = "Exportar Facturas"
        '
        'lblobs
        '
        Me.lblobs.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblobs.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblobs.Location = New System.Drawing.Point(11, 135)
        Me.lblobs.Name = "lblobs"
        Me.lblobs.Size = New System.Drawing.Size(248, 40)
        Me.lblobs.TabIndex = 11
        Me.lblobs.Text = "Seleccione un Rango de Fechas para poder generar el informe..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(9, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Exportar :"
        '
        'btnopen
        '
        Me.btnopen.Image = CType(resources.GetObject("btnopen.Image"), System.Drawing.Image)
        Me.btnopen.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnopen.Location = New System.Drawing.Point(390, 104)
        Me.btnopen.Name = "btnopen"
        Me.btnopen.Size = New System.Drawing.Size(25, 24)
        Me.btnopen.TabIndex = 9
        Me.btnopen.UseVisualStyleBackColor = True
        '
        'btngrabar
        '
        Me.btngrabar.Image = CType(resources.GetObject("btngrabar.Image"), System.Drawing.Image)
        Me.btngrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btngrabar.Location = New System.Drawing.Point(344, 132)
        Me.btngrabar.Name = "btngrabar"
        Me.btngrabar.Size = New System.Drawing.Size(73, 47)
        Me.btngrabar.TabIndex = 8
        Me.btngrabar.Text = "Grabar"
        Me.btngrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btngrabar.UseVisualStyleBackColor = True
        '
        'txtruta
        '
        Me.txtruta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtruta.Location = New System.Drawing.Point(69, 106)
        Me.txtruta.Name = "txtruta"
        Me.txtruta.ReadOnly = True
        Me.txtruta.Size = New System.Drawing.Size(321, 21)
        Me.txtruta.TabIndex = 7
        Me.txtruta.Text = "C:\Documentos_Emitidos.xls"
        '
        'btnvis
        '
        Me.btnvis.Image = CType(resources.GetObject("btnvis.Image"), System.Drawing.Image)
        Me.btnvis.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnvis.Location = New System.Drawing.Point(266, 132)
        Me.btnvis.Name = "btnvis"
        Me.btnvis.Size = New System.Drawing.Size(72, 47)
        Me.btnvis.TabIndex = 5
        Me.btnvis.Text = "&Vista Previa"
        Me.btnvis.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnvis.UseVisualStyleBackColor = True
        '
        'fecha2
        '
        Me.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha2.Location = New System.Drawing.Point(203, 77)
        Me.fecha2.Name = "fecha2"
        Me.fecha2.Size = New System.Drawing.Size(87, 21)
        Me.fecha2.TabIndex = 4
        '
        'fecha1
        '
        Me.fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fecha1.Location = New System.Drawing.Point(69, 77)
        Me.fecha1.Name = "fecha1"
        Me.fecha1.Size = New System.Drawing.Size(87, 21)
        Me.fecha1.TabIndex = 3
        '
        'lblfecha2
        '
        Me.lblfecha2.AutoSize = True
        Me.lblfecha2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblfecha2.Location = New System.Drawing.Point(162, 81)
        Me.lblfecha2.Name = "lblfecha2"
        Me.lblfecha2.Size = New System.Drawing.Size(45, 13)
        Me.lblfecha2.TabIndex = 2
        Me.lblfecha2.Text = "&Hasta : "
        '
        'lblfecha1
        '
        Me.lblfecha1.AutoSize = True
        Me.lblfecha1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblfecha1.Location = New System.Drawing.Point(9, 81)
        Me.lblfecha1.Name = "lblfecha1"
        Me.lblfecha1.Size = New System.Drawing.Size(47, 13)
        Me.lblfecha1.TabIndex = 1
        Me.lblfecha1.Text = "&Desde : "
        '
        'Open01
        '
        Me.Open01.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbltot, Me.pro01})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 204)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(435, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbltot
        '
        Me.lbltot.Name = "lbltot"
        Me.lbltot.Size = New System.Drawing.Size(94, 17)
        Me.lbltot.Text = "Total de Registros"
        '
        'pro01
        '
        Me.pro01.Name = "pro01"
        Me.pro01.Size = New System.Drawing.Size(100, 16)
        '
        'FrmFechas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 226)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grb01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFechas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar"
        Me.grb01.ResumeLayout(False)
        Me.grb01.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grb01 As System.Windows.Forms.GroupBox
    Friend WithEvents fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblfecha2 As System.Windows.Forms.Label
    Friend WithEvents lblfecha1 As System.Windows.Forms.Label
    Friend WithEvents btnvis As System.Windows.Forms.Button
    Friend WithEvents txtruta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnopen As System.Windows.Forms.Button
    Friend WithEvents btngrabar As System.Windows.Forms.Button
    Friend WithEvents lblobs As System.Windows.Forms.Label
    Friend WithEvents Open01 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lbltipo As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbltot As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pro01 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblopciones As System.Windows.Forms.Label
    Friend WithEvents cbocriterio As System.Windows.Forms.ComboBox
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents cbocriterio2 As System.Windows.Forms.ComboBox
    Friend WithEvents chkopcion As System.Windows.Forms.CheckBox
    Friend WithEvents txtobs As System.Windows.Forms.TextBox
    Friend WithEvents Chkopcion2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkimp As System.Windows.Forms.CheckBox
    Friend WithEvents CboCriterio3 As System.Windows.Forms.ComboBox
End Class
