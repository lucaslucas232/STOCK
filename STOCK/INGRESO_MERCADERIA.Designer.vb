<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class INGRESO_MERCADERIA
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXT_CANTIDAD = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LBL_USUARIO = New System.Windows.Forms.Label()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.BTN_CANCELAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_NUEVO = New System.Windows.Forms.Button()
        Me.cmbproducto = New System.Windows.Forms.ComboBox()
        Me.CMB_DESTINO = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NOMBRE PRODUCTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "CANTIDAD"
        '
        'TXT_CANTIDAD
        '
        Me.TXT_CANTIDAD.Location = New System.Drawing.Point(76, 206)
        Me.TXT_CANTIDAD.Name = "TXT_CANTIDAD"
        Me.TXT_CANTIDAD.Size = New System.Drawing.Size(220, 20)
        Me.TXT_CANTIDAD.TabIndex = 3
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(76, 94)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(96, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(73, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "FECHA"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(561, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "USUARIO:"
        '
        'LBL_USUARIO
        '
        Me.LBL_USUARIO.AutoSize = True
        Me.LBL_USUARIO.Location = New System.Drawing.Point(636, 27)
        Me.LBL_USUARIO.Name = "LBL_USUARIO"
        Me.LBL_USUARIO.Size = New System.Drawing.Size(15, 13)
        Me.LBL_USUARIO.TabIndex = 9
        Me.LBL_USUARIO.Text = "**"
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(302, 78)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV1.Size = New System.Drawing.Size(328, 230)
        Me.DGV1.TabIndex = 5
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(657, 235)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(97, 27)
        Me.BTN_CANCELAR.TabIndex = 35
        Me.BTN_CANCELAR.Text = "CANCELAR"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(657, 187)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(97, 28)
        Me.BTN_MODIFICAR.TabIndex = 34
        Me.BTN_MODIFICAR.Text = "MODIFICAR"
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = True
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(657, 140)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(97, 27)
        Me.BTN_AGREGAR.TabIndex = 33
        Me.BTN_AGREGAR.Text = "AGREGAR"
        Me.BTN_AGREGAR.UseVisualStyleBackColor = True
        '
        'BTN_NUEVO
        '
        Me.BTN_NUEVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_NUEVO.Location = New System.Drawing.Point(657, 93)
        Me.BTN_NUEVO.Name = "BTN_NUEVO"
        Me.BTN_NUEVO.Size = New System.Drawing.Size(97, 27)
        Me.BTN_NUEVO.TabIndex = 1
        Me.BTN_NUEVO.Text = "NUEVO"
        Me.BTN_NUEVO.UseVisualStyleBackColor = True
        '
        'cmbproducto
        '
        Me.cmbproducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbproducto.FormattingEnabled = True
        Me.cmbproducto.Location = New System.Drawing.Point(76, 150)
        Me.cmbproducto.Name = "cmbproducto"
        Me.cmbproducto.Size = New System.Drawing.Size(169, 21)
        Me.cmbproducto.TabIndex = 2
        '
        'CMB_DESTINO
        '
        Me.CMB_DESTINO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_DESTINO.FormattingEnabled = True
        Me.CMB_DESTINO.Location = New System.Drawing.Point(76, 273)
        Me.CMB_DESTINO.Name = "CMB_DESTINO"
        Me.CMB_DESTINO.Size = New System.Drawing.Size(169, 21)
        Me.CMB_DESTINO.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 249)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "DESTINO"
        '
        'INGRESO_MERCADERIA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CMB_DESTINO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbproducto)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_NUEVO)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.LBL_USUARIO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TXT_CANTIDAD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "INGRESO_MERCADERIA"
        Me.Text = "INGRESO_MERCADERIA"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_CANTIDAD As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LBL_USUARIO As Label
    Friend WithEvents DGV1 As DataGridView
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_NUEVO As Button
    Friend WithEvents cmbproducto As ComboBox
    Friend WithEvents CMB_DESTINO As ComboBox
    Friend WithEvents Label3 As Label
End Class
