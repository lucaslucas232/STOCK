<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class REGISTRO_H_Y_I
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
        Me.txt_producto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_tipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LBL_USUARIO = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.BTN_ELIMINAR = New System.Windows.Forms.Button()
        Me.BTN_CANCELAR = New System.Windows.Forms.Button()
        Me.BTN_MODIFICAR = New System.Windows.Forms.Button()
        Me.BTN_AGREGAR = New System.Windows.Forms.Button()
        Me.BTN_NUEVO = New System.Windows.Forms.Button()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_producto
        '
        Me.txt_producto.Location = New System.Drawing.Point(87, 114)
        Me.txt_producto.Name = "txt_producto"
        Me.txt_producto.Size = New System.Drawing.Size(206, 20)
        Me.txt_producto.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(84, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "NOMBRE PRODUCTO"
        '
        'cmb_tipo
        '
        Me.cmb_tipo.FormattingEnabled = True
        Me.cmb_tipo.Items.AddRange(New Object() {"HERRAMIENTA" & Global.Microsoft.VisualBasic.ChrW(9), "INSUMO"})
        Me.cmb_tipo.Location = New System.Drawing.Point(87, 185)
        Me.cmb_tipo.Name = "cmb_tipo"
        Me.cmb_tipo.Size = New System.Drawing.Size(121, 21)
        Me.cmb_tipo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(84, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TIPO"
        '
        'LBL_USUARIO
        '
        Me.LBL_USUARIO.AutoSize = True
        Me.LBL_USUARIO.Location = New System.Drawing.Point(452, 28)
        Me.LBL_USUARIO.Name = "LBL_USUARIO"
        Me.LBL_USUARIO.Size = New System.Drawing.Size(15, 13)
        Me.LBL_USUARIO.TabIndex = 11
        Me.LBL_USUARIO.Text = "**"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(377, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "USUARIO:"
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(308, 87)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(240, 150)
        Me.DGV1.TabIndex = 13
        '
        'BTN_ELIMINAR
        '
        Me.BTN_ELIMINAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ELIMINAR.Location = New System.Drawing.Point(577, 255)
        Me.BTN_ELIMINAR.Name = "BTN_ELIMINAR"
        Me.BTN_ELIMINAR.Size = New System.Drawing.Size(115, 27)
        Me.BTN_ELIMINAR.TabIndex = 65
        Me.BTN_ELIMINAR.Text = "ELIMINAR"
        Me.BTN_ELIMINAR.UseVisualStyleBackColor = True
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(577, 208)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(115, 27)
        Me.BTN_CANCELAR.TabIndex = 64
        Me.BTN_CANCELAR.Text = "CANCELAR"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'BTN_MODIFICAR
        '
        Me.BTN_MODIFICAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_MODIFICAR.Location = New System.Drawing.Point(577, 161)
        Me.BTN_MODIFICAR.Name = "BTN_MODIFICAR"
        Me.BTN_MODIFICAR.Size = New System.Drawing.Size(115, 27)
        Me.BTN_MODIFICAR.TabIndex = 63
        Me.BTN_MODIFICAR.Text = "MODIFICAR"
        Me.BTN_MODIFICAR.UseVisualStyleBackColor = True
        '
        'BTN_AGREGAR
        '
        Me.BTN_AGREGAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_AGREGAR.Location = New System.Drawing.Point(577, 114)
        Me.BTN_AGREGAR.Name = "BTN_AGREGAR"
        Me.BTN_AGREGAR.Size = New System.Drawing.Size(115, 27)
        Me.BTN_AGREGAR.TabIndex = 62
        Me.BTN_AGREGAR.Text = "AGREGAR"
        Me.BTN_AGREGAR.UseVisualStyleBackColor = True
        '
        'BTN_NUEVO
        '
        Me.BTN_NUEVO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_NUEVO.Location = New System.Drawing.Point(577, 67)
        Me.BTN_NUEVO.Name = "BTN_NUEVO"
        Me.BTN_NUEVO.Size = New System.Drawing.Size(115, 27)
        Me.BTN_NUEVO.TabIndex = 61
        Me.BTN_NUEVO.Text = "NUEVO"
        Me.BTN_NUEVO.UseVisualStyleBackColor = True
        '
        'REGISTRO_H_Y_I
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 326)
        Me.Controls.Add(Me.BTN_ELIMINAR)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.BTN_MODIFICAR)
        Me.Controls.Add(Me.BTN_AGREGAR)
        Me.Controls.Add(Me.BTN_NUEVO)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.LBL_USUARIO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_tipo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txt_producto)
        Me.Name = "REGISTRO_H_Y_I"
        Me.Text = "REGISTRO_H_Y_I"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_producto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmb_tipo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LBL_USUARIO As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DGV1 As DataGridView
    Friend WithEvents BTN_ELIMINAR As Button
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents BTN_MODIFICAR As Button
    Friend WithEvents BTN_AGREGAR As Button
    Friend WithEvents BTN_NUEVO As Button
End Class
