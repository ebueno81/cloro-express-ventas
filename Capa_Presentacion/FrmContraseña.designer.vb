<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContraseña
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContraseña))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.TxtClave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblCopy = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtClave_Confirma = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtClave_Nueva = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtClave_Ant = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCopy2 = New System.Windows.Forms.Label()
        Me.Cancel2 = New System.Windows.Forms.Button()
        Me.Ok2 = New System.Windows.Forms.Button()
        Me.Opcion = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CboEmpresa = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(468, 78)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese Contraseña"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtUser
        '
        Me.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUser.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(123, 93)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(336, 22)
        Me.TxtUser.TabIndex = 3
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(5, 91)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(118, 23)
        Me.UsernameLabel.TabIndex = 2
        Me.UsernameLabel.Text = "&Nombre de usuario :"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtClave
        '
        Me.TxtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtClave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave.Location = New System.Drawing.Point(123, 119)
        Me.TxtClave.MaxLength = 10
        Me.TxtClave.Name = "TxtClave"
        Me.TxtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtClave.Size = New System.Drawing.Size(194, 22)
        Me.TxtClave.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Contraseña           :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 23)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Tipo C&onexion       :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(2, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(466, 2)
        Me.Label5.TabIndex = 13
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Black
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Yellow
        Me.Label4.Location = New System.Drawing.Point(120, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 17)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Sistema de Ventas - SysVentAS 3.0"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(121, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(342, 1)
        Me.Label6.TabIndex = 16
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblCopy
        '
        Me.LblCopy.AutoSize = True
        Me.LblCopy.BackColor = System.Drawing.Color.Transparent
        Me.LblCopy.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCopy.ForeColor = System.Drawing.Color.Blue
        Me.LblCopy.Location = New System.Drawing.Point(2, 208)
        Me.LblCopy.Name = "LblCopy"
        Me.LblCopy.Size = New System.Drawing.Size(182, 10)
        Me.LblCopy.TabIndex = 17
        Me.LblCopy.Text = "Copyright © Todos los derechos reservados  2005"
        Me.LblCopy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(4, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(469, 77)
        Me.Label8.TabIndex = 18
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.TxtClave_Ant)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(19, 223)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(449, 114)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cambio de Clave"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TxtClave_Confirma)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TxtClave_Nueva)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(66, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(308, 64)
        Me.Panel1.TabIndex = 7
        '
        'TxtClave_Confirma
        '
        Me.TxtClave_Confirma.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave_Confirma.Location = New System.Drawing.Point(133, 30)
        Me.TxtClave_Confirma.MaxLength = 8
        Me.TxtClave_Confirma.Name = "TxtClave_Confirma"
        Me.TxtClave_Confirma.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtClave_Confirma.Size = New System.Drawing.Size(111, 22)
        Me.TxtClave_Confirma.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(12, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 23)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Confirme Paswoord"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtClave_Nueva
        '
        Me.TxtClave_Nueva.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave_Nueva.Location = New System.Drawing.Point(133, 5)
        Me.TxtClave_Nueva.MaxLength = 8
        Me.TxtClave_Nueva.Name = "TxtClave_Nueva"
        Me.TxtClave_Nueva.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtClave_Nueva.Size = New System.Drawing.Size(111, 22)
        Me.TxtClave_Nueva.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(12, 4)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 23)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Nuevo Paswoord"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtClave_Ant
        '
        Me.TxtClave_Ant.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClave_Ant.Location = New System.Drawing.Point(201, 18)
        Me.TxtClave_Ant.MaxLength = 8
        Me.TxtClave_Ant.Name = "TxtClave_Ant"
        Me.TxtClave_Ant.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtClave_Ant.Size = New System.Drawing.Size(111, 22)
        Me.TxtClave_Ant.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(82, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 23)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Password Anterior"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCopy2
        '
        Me.LblCopy2.AutoSize = True
        Me.LblCopy2.BackColor = System.Drawing.Color.Transparent
        Me.LblCopy2.Font = New System.Drawing.Font("Tahoma", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCopy2.ForeColor = System.Drawing.Color.Blue
        Me.LblCopy2.Location = New System.Drawing.Point(2, 376)
        Me.LblCopy2.Name = "LblCopy2"
        Me.LblCopy2.Size = New System.Drawing.Size(182, 10)
        Me.LblCopy2.TabIndex = 23
        Me.LblCopy2.Text = "Copyright © Todos los derechos reservados  2005"
        Me.LblCopy2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Cancel2
        '
        Me.Cancel2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel2.Image = CType(resources.GetObject("Cancel2.Image"), System.Drawing.Image)
        Me.Cancel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel2.Location = New System.Drawing.Point(222, 342)
        Me.Cancel2.Name = "Cancel2"
        Me.Cancel2.Size = New System.Drawing.Size(94, 25)
        Me.Cancel2.TabIndex = 21
        Me.Cancel2.Text = "&Cancelar"
        '
        'Ok2
        '
        Me.Ok2.Image = CType(resources.GetObject("Ok2.Image"), System.Drawing.Image)
        Me.Ok2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Ok2.Location = New System.Drawing.Point(122, 342)
        Me.Ok2.Name = "Ok2"
        Me.Ok2.Size = New System.Drawing.Size(94, 25)
        Me.Ok2.TabIndex = 20
        Me.Ok2.Text = "&Aceptar"
        '
        'Opcion
        '
        Me.Opcion.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Opcion.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Opcion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Opcion.Image = CType(resources.GetObject("Opcion.Image"), System.Drawing.Image)
        Me.Opcion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Opcion.Location = New System.Drawing.Point(374, 179)
        Me.Opcion.Name = "Opcion"
        Me.Opcion.Size = New System.Drawing.Size(94, 25)
        Me.Opcion.TabIndex = 9
        Me.Opcion.Text = "&Opciones"
        '
        'Cancel
        '
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel.Image = CType(resources.GetObject("Cancel.Image"), System.Drawing.Image)
        Me.Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cancel.Location = New System.Drawing.Point(219, 179)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(94, 25)
        Me.Cancel.TabIndex = 8
        Me.Cancel.Text = "&Cancelar"
        '
        'OK
        '
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OK.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.Image = CType(resources.GetObject("OK.Image"), System.Drawing.Image)
        Me.OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OK.Location = New System.Drawing.Point(123, 179)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 25)
        Me.OK.TabIndex = 7
        Me.OK.Text = "&Aceptar"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(19, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(67, 61)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'CboEmpresa
        '
        Me.CboEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboEmpresa.FormattingEnabled = True
        Me.CboEmpresa.Items.AddRange(New Object() {"Acceso Local", "Acceso Remoto"})
        Me.CboEmpresa.Location = New System.Drawing.Point(124, 146)
        Me.CboEmpresa.Name = "CboEmpresa"
        Me.CboEmpresa.Size = New System.Drawing.Size(193, 21)
        Me.CboEmpresa.TabIndex = 6
        '
        'FrmContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 221)
        Me.Controls.Add(Me.CboEmpresa)
        Me.Controls.Add(Me.LblCopy2)
        Me.Controls.Add(Me.Cancel2)
        Me.Controls.Add(Me.Ok2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblCopy)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Opcion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label8)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmContraseña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login..."
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtUser As System.Windows.Forms.TextBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents TxtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Opcion As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblCopy As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtClave_Confirma As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtClave_Nueva As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtClave_Ant As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Cancel2 As System.Windows.Forms.Button
    Friend WithEvents Ok2 As System.Windows.Forms.Button
    Friend WithEvents LblCopy2 As System.Windows.Forms.Label
    Friend WithEvents CboEmpresa As System.Windows.Forms.ComboBox
End Class
