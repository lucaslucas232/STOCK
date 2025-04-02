<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MOVIMIENTOS
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
        Me.CMBPRODUCTO = New System.Windows.Forms.ComboBox()
        Me.CMBORIGEN = New System.Windows.Forms.ComboBox()
        Me.CMBDESTINO = New System.Windows.Forms.ComboBox()
        Me.TXTCANTIDAD = New System.Windows.Forms.TextBox()
        Me.BTN_ACEPTAR = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_CANCELAR = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DGVMOVIMIENTOS = New System.Windows.Forms.DataGridView()
        CType(Me.DGVMOVIMIENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMBPRODUCTO
        '
        Me.CMBPRODUCTO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBPRODUCTO.FormattingEnabled = True
        Me.CMBPRODUCTO.Location = New System.Drawing.Point(42, 99)
        Me.CMBPRODUCTO.Name = "CMBPRODUCTO"
        Me.CMBPRODUCTO.Size = New System.Drawing.Size(194, 21)
        Me.CMBPRODUCTO.TabIndex = 0
        '
        'CMBORIGEN
        '
        Me.CMBORIGEN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBORIGEN.FormattingEnabled = True
        Me.CMBORIGEN.Location = New System.Drawing.Point(42, 153)
        Me.CMBORIGEN.Name = "CMBORIGEN"
        Me.CMBORIGEN.Size = New System.Drawing.Size(194, 21)
        Me.CMBORIGEN.TabIndex = 1
        '
        'CMBDESTINO
        '
        Me.CMBDESTINO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBDESTINO.FormattingEnabled = True
        Me.CMBDESTINO.Location = New System.Drawing.Point(275, 154)
        Me.CMBDESTINO.Name = "CMBDESTINO"
        Me.CMBDESTINO.Size = New System.Drawing.Size(194, 21)
        Me.CMBDESTINO.TabIndex = 2
        '
        'TXTCANTIDAD
        '
        Me.TXTCANTIDAD.Location = New System.Drawing.Point(275, 100)
        Me.TXTCANTIDAD.Name = "TXTCANTIDAD"
        Me.TXTCANTIDAD.Size = New System.Drawing.Size(100, 20)
        Me.TXTCANTIDAD.TabIndex = 3
        '
        'BTN_ACEPTAR
        '
        Me.BTN_ACEPTAR.Location = New System.Drawing.Point(513, 100)
        Me.BTN_ACEPTAR.Name = "BTN_ACEPTAR"
        Me.BTN_ACEPTAR.Size = New System.Drawing.Size(99, 23)
        Me.BTN_ACEPTAR.TabIndex = 4
        Me.BTN_ACEPTAR.Text = "ACEPTAR"
        Me.BTN_ACEPTAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "PRODUCTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ORIGEN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "DESTINO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(281, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CANTIDAD"
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(513, 151)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(99, 23)
        Me.BTN_CANCELAR.TabIndex = 9
        Me.BTN_CANCELAR.Text = "CANCELAR"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(42, 49)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(99, 20)
        Me.DateTimePicker1.TabIndex = 10
        Me.DateTimePicker1.Value = New Date(2025, 3, 30, 0, 0, 0, 0)
        '
        'DGVMOVIMIENTOS
        '
        Me.DGVMOVIMIENTOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVMOVIMIENTOS.Location = New System.Drawing.Point(42, 206)
        Me.DGVMOVIMIENTOS.Name = "DGVMOVIMIENTOS"
        Me.DGVMOVIMIENTOS.Size = New System.Drawing.Size(491, 150)
        Me.DGVMOVIMIENTOS.TabIndex = 11
        '
        'MOVIMIENTOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 403)
        Me.Controls.Add(Me.DGVMOVIMIENTOS)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_ACEPTAR)
        Me.Controls.Add(Me.TXTCANTIDAD)
        Me.Controls.Add(Me.CMBDESTINO)
        Me.Controls.Add(Me.CMBORIGEN)
        Me.Controls.Add(Me.CMBPRODUCTO)
        Me.Name = "MOVIMIENTOS"
        Me.Text = "MOVIMIENTOS"
        CType(Me.DGVMOVIMIENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CMBPRODUCTO As ComboBox
    Friend WithEvents CMBORIGEN As ComboBox
    Friend WithEvents CMBDESTINO As ComboBox
    Friend WithEvents TXTCANTIDAD As TextBox
    Friend WithEvents BTN_ACEPTAR As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents DGVMOVIMIENTOS As DataGridView
End Class
