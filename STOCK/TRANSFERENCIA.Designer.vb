<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class transferencia
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CMB_DEPOSTIOORIGEN = New System.Windows.Forms.ComboBox()
        Me.CMB_DEPOSTIODESTINO = New System.Windows.Forms.ComboBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.fecha = New System.Windows.Forms.Label()
        Me.TXT_codigo = New System.Windows.Forms.TextBox()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.BTN_CANCELAR = New System.Windows.Forms.Button()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_nombre_producto = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(35, 55)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(106, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'CMB_DEPOSTIOORIGEN
        '
        Me.CMB_DEPOSTIOORIGEN.FormattingEnabled = True
        Me.CMB_DEPOSTIOORIGEN.Items.AddRange(New Object() {"DEPOSITO HERRAMIENTAS", "DEPOSITO PRODUCTOS"})
        Me.CMB_DEPOSTIOORIGEN.Location = New System.Drawing.Point(177, 55)
        Me.CMB_DEPOSTIOORIGEN.Name = "CMB_DEPOSTIOORIGEN"
        Me.CMB_DEPOSTIOORIGEN.Size = New System.Drawing.Size(121, 21)
        Me.CMB_DEPOSTIOORIGEN.TabIndex = 2
        '
        'CMB_DEPOSTIODESTINO
        '
        Me.CMB_DEPOSTIODESTINO.FormattingEnabled = True
        Me.CMB_DEPOSTIODESTINO.Items.AddRange(New Object() {"Montevideo", "Salto", "Paysandu"})
        Me.CMB_DEPOSTIODESTINO.Location = New System.Drawing.Point(435, 54)
        Me.CMB_DEPOSTIODESTINO.Name = "CMB_DEPOSTIODESTINO"
        Me.CMB_DEPOSTIODESTINO.Size = New System.Drawing.Size(121, 21)
        Me.CMB_DEPOSTIODESTINO.TabIndex = 3
        '
        'dgv1
        '
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(35, 148)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.Size = New System.Drawing.Size(511, 212)
        Me.dgv1.TabIndex = 4
        '
        'fecha
        '
        Me.fecha.AutoSize = True
        Me.fecha.Location = New System.Drawing.Point(32, 26)
        Me.fecha.Name = "fecha"
        Me.fecha.Size = New System.Drawing.Size(45, 13)
        Me.fecha.TabIndex = 5
        Me.fecha.Text = "FECHA:"
        '
        'TXT_codigo
        '
        Me.TXT_codigo.Location = New System.Drawing.Point(35, 112)
        Me.TXT_codigo.Name = "TXT_codigo"
        Me.TXT_codigo.Size = New System.Drawing.Size(100, 20)
        Me.TXT_codigo.TabIndex = 6
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(141, 110)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(29, 23)
        Me.BTN_BUSCAR.TabIndex = 7
        Me.BTN_BUSCAR.Text = "..."
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "CODIGO:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(432, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "DESTINO"
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(575, 177)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(75, 23)
        Me.BTN_ACEPTAR.TabIndex = 10
        Me.BTN_ACEPTAR.Text = "ACEPTAR"
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(575, 206)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(75, 23)
        Me.BTN_CANCELAR.TabIndex = 11
        Me.BTN_CANCELAR.Text = "CANCELAR"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(435, 112)
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(100, 20)
        Me.TXT_CANTIDAD.TabIndex = 12
        '
        'BTN_OK
        '
        Me.BTN_OK.Location = New System.Drawing.Point(541, 110)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(34, 23)
        Me.BTN_OK.TabIndex = 13
        Me.BTN_OK.Text = "OK"
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(436, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "CANTIDAD:"
        '
        'lbl_nombre_producto
        '
        Me.lbl_nombre_producto.AutoSize = True
        Me.lbl_nombre_producto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_nombre_producto.Location = New System.Drawing.Point(201, 106)
        Me.lbl_nombre_producto.Name = "lbl_nombre_producto"
        Me.lbl_nombre_producto.Size = New System.Drawing.Size(71, 25)
        Me.lbl_nombre_producto.TabIndex = 15
        Me.lbl_nombre_producto.Text = "Label4"
        Me.lbl_nombre_producto.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(353, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 25)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = ">"
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_saldo.Location = New System.Drawing.Point(306, 106)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(71, 25)
        Me.lbl_saldo.TabIndex = 17
        Me.lbl_saldo.Text = "Label4"
        Me.lbl_saldo.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(174, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "ORIGEN"
        '
        'transferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(686, 411)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_nombre_producto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTN_OK)
        Me.Controls.Add(Me.TXT_CANTIDAD)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Controls.Add(Me.TXT_codigo)
        Me.Controls.Add(Me.fecha)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.CMB_DEPOSTIODESTINO)
        Me.Controls.Add(Me.CMB_DEPOSTIOORIGEN)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Name = "transferencia"
        Me.Text = "TRANSFERENCIA"
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CMB_DEPOSTIOORIGEN As ComboBox
    Friend WithEvents CMB_DEPOSTIODESTINO As ComboBox
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents fecha As Label
    Friend WithEvents TXT_codigo As TextBox
    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents BTN_OK As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents lbl_nombre_producto As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_saldo As Label
    Friend WithEvents Label5 As Label
End Class
