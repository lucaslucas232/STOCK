<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EGRESO_MERCADERIA
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
        Me.cmbproducto = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_REGISTRAR_EGRESO = New System.Windows.Forms.Button()
        Me.TXT_RAZON = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMB_ORIGEN = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbproducto
        '
        Me.cmbproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbproducto.FormattingEnabled = True
        Me.cmbproducto.Location = New System.Drawing.Point(47, 88)
        Me.cmbproducto.Name = "cmbproducto"
        Me.cmbproducto.Size = New System.Drawing.Size(246, 21)
        Me.cmbproducto.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "FECHA:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(47, 39)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 44
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(47, 142)
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(246, 20)
        Me.TXT_CANTIDAD.TabIndex = 42
        Me.TXT_CANTIDAD.Text = "10"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "CANTIDAD:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "NOMBRE PRODUCTO:"
        '
        'BTN_REGISTRAR_EGRESO
        '
        Me.BTN_REGISTRAR_EGRESO.Location = New System.Drawing.Point(332, 78)
        Me.BTN_REGISTRAR_EGRESO.Name = "BTN_REGISTRAR_EGRESO"
        Me.BTN_REGISTRAR_EGRESO.Size = New System.Drawing.Size(146, 31)
        Me.BTN_REGISTRAR_EGRESO.TabIndex = 48
        Me.BTN_REGISTRAR_EGRESO.Text = "APLICAR CAMBIOS"
        Me.BTN_REGISTRAR_EGRESO.UseVisualStyleBackColor = True
        '
        'TXT_RAZON
        '
        Me.TXT_RAZON.Location = New System.Drawing.Point(47, 249)
        Me.TXT_RAZON.Name = "TXT_RAZON"
        Me.TXT_RAZON.Size = New System.Drawing.Size(246, 20)
        Me.TXT_RAZON.TabIndex = 50
        Me.TXT_RAZON.Text = "gg"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "DETALLE:"
        '
        'CMB_ORIGEN
        '
        Me.CMB_ORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_ORIGEN.FormattingEnabled = True
        Me.CMB_ORIGEN.Location = New System.Drawing.Point(47, 195)
        Me.CMB_ORIGEN.Name = "CMB_ORIGEN"
        Me.CMB_ORIGEN.Size = New System.Drawing.Size(246, 21)
        Me.CMB_ORIGEN.TabIndex = 52
        '
        'EGRESO_MERCADERIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 313)
        Me.Controls.Add(Me.CMB_ORIGEN)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXT_RAZON)
        Me.Controls.Add(Me.BTN_REGISTRAR_EGRESO)
        Me.Controls.Add(Me.cmbproducto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TXT_CANTIDAD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EGRESO_MERCADERIA"
        Me.Text = "EGRESO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbproducto As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_REGISTRAR_EGRESO As Button
    Friend WithEvents TXT_RAZON As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents CMB_ORIGEN As ComboBox
End Class
