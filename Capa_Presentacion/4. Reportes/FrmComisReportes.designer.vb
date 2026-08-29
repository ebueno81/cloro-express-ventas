<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComisReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComisReportes))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CboEstado = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CboDoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboCliente = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CboVende = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CboTipo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.TxtNro_Comision = New System.Windows.Forms.TextBox()
        Me.TxtImp_Mn = New System.Windows.Forms.TextBox()
        Me.TxtComis_Mn = New System.Windows.Forms.TextBox()
        Me.TxtComis_Us = New System.Windows.Forms.TextBox()
        Me.TxtImp_Us = New System.Windows.Forms.TextBox()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CboEstado)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.CboDoc)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.CboCliente)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.CboVende)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CboTipo)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(0, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(477, 105)
        Me.Panel2.TabIndex = 1
        '
        'CboEstado
        '
        Me.CboEstado.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Items.AddRange(New Object() {"(TODOS)", "AMORTIZADO", "CANCELADO", "PENDIENTE"})
        Me.CboEstado.Location = New System.Drawing.Point(327, 75)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(141, 22)
        Me.CboEstado.TabIndex = 205
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(253, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 21)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "Estado"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboDoc
        '
        Me.CboDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboDoc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDoc.FormattingEnabled = True
        Me.CboDoc.Location = New System.Drawing.Point(109, 75)
        Me.CboDoc.Name = "CboDoc"
        Me.CboDoc.Size = New System.Drawing.Size(141, 22)
        Me.CboDoc.TabIndex = 203
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(8, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 21)
        Me.Label6.TabIndex = 202
        Me.Label6.Text = "Tipo Docu."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboCliente
        '
        Me.CboCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboCliente.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCliente.FormattingEnabled = True
        Me.CboCliente.Location = New System.Drawing.Point(109, 51)
        Me.CboCliente.Name = "CboCliente"
        Me.CboCliente.Size = New System.Drawing.Size(359, 22)
        Me.CboCliente.TabIndex = 201
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(8, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 21)
        Me.Label5.TabIndex = 200
        Me.Label5.Text = "Cliente"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboVende
        '
        Me.CboVende.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboVende.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboVende.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboVende.FormattingEnabled = True
        Me.CboVende.Location = New System.Drawing.Point(109, 27)
        Me.CboVende.Name = "CboVende"
        Me.CboVende.Size = New System.Drawing.Size(359, 22)
        Me.CboVende.TabIndex = 199
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 21)
        Me.Label2.TabIndex = 198
        Me.Label2.Text = "Vendedor"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboTipo
        '
        Me.CboTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboTipo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTipo.FormattingEnabled = True
        Me.CboTipo.Items.AddRange(New Object() {"1. Informe por Vendedor Agrupado por Cliente", "2. Informe por Vendedor Detallado por Cliente", "3. Informe por Vendedor Detallado por Artículos"})
        Me.CboTipo.Location = New System.Drawing.Point(109, 3)
        Me.CboTipo.Name = "CboTipo"
        Me.CboTipo.Size = New System.Drawing.Size(359, 22)
        Me.CboTipo.TabIndex = 197
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 21)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Tipo de Informe"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImp
        '
        Me.BtnImp.BackColor = System.Drawing.SystemColors.Control
        Me.BtnImp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnImp.Location = New System.Drawing.Point(343, 110)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(65, 50)
        Me.BtnImp.TabIndex = 14
        Me.BtnImp.Text = "Reporte"
        Me.BtnImp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnImp.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCerrar.Location = New System.Drawing.Point(409, 110)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(65, 50)
        Me.BtnCerrar.TabIndex = 15
        Me.BtnCerrar.Text = "Cerrar"
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'TxtNro_Comision
        '
        Me.TxtNro_Comision.Location = New System.Drawing.Point(0, 110)
        Me.TxtNro_Comision.Name = "TxtNro_Comision"
        Me.TxtNro_Comision.Size = New System.Drawing.Size(100, 20)
        Me.TxtNro_Comision.TabIndex = 16
        Me.TxtNro_Comision.Visible = False
        '
        'TxtImp_Mn
        '
        Me.TxtImp_Mn.Location = New System.Drawing.Point(106, 110)
        Me.TxtImp_Mn.Name = "TxtImp_Mn"
        Me.TxtImp_Mn.Size = New System.Drawing.Size(63, 20)
        Me.TxtImp_Mn.TabIndex = 17
        Me.TxtImp_Mn.Visible = False
        '
        'TxtComis_Mn
        '
        Me.TxtComis_Mn.Location = New System.Drawing.Point(106, 129)
        Me.TxtComis_Mn.Name = "TxtComis_Mn"
        Me.TxtComis_Mn.Size = New System.Drawing.Size(63, 20)
        Me.TxtComis_Mn.TabIndex = 18
        Me.TxtComis_Mn.Visible = False
        '
        'TxtComis_Us
        '
        Me.TxtComis_Us.Location = New System.Drawing.Point(175, 129)
        Me.TxtComis_Us.Name = "TxtComis_Us"
        Me.TxtComis_Us.Size = New System.Drawing.Size(63, 20)
        Me.TxtComis_Us.TabIndex = 20
        Me.TxtComis_Us.Visible = False
        '
        'TxtImp_Us
        '
        Me.TxtImp_Us.Location = New System.Drawing.Point(175, 110)
        Me.TxtImp_Us.Name = "TxtImp_Us"
        Me.TxtImp_Us.Size = New System.Drawing.Size(63, 20)
        Me.TxtImp_Us.TabIndex = 19
        Me.TxtImp_Us.Visible = False
        '
        'FrmComisReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 161)
        Me.Controls.Add(Me.TxtComis_Us)
        Me.Controls.Add(Me.TxtImp_Us)
        Me.Controls.Add(Me.TxtComis_Mn)
        Me.Controls.Add(Me.TxtImp_Mn)
        Me.Controls.Add(Me.TxtNro_Comision)
        Me.Controls.Add(Me.BtnCerrar)
        Me.Controls.Add(Me.BtnImp)
        Me.Controls.Add(Me.Panel2)
        Me.KeyPreview = True
        Me.Name = "FrmComisReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Comisiones"
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CboDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CboVende As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents TxtNro_Comision As System.Windows.Forms.TextBox
    Friend WithEvents TxtImp_Mn As TextBox
    Friend WithEvents TxtComis_Mn As TextBox
    Friend WithEvents TxtComis_Us As TextBox
    Friend WithEvents TxtImp_Us As TextBox
End Class
