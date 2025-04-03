<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FILTRO_HERRAMIENTAS
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_nombre_producto = New System.Windows.Forms.TextBox()
        Me.ListBoxproductos = New System.Windows.Forms.ListBox()
        Me.BTN_CANCELAR = New System.Windows.Forms.Button()
        Me.BTN_BUSCAR = New System.Windows.Forms.Button()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 25)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Nombre producto:"
        '
        'txt_nombre_producto
        '
        Me.txt_nombre_producto.Location = New System.Drawing.Point(210, 26)
        Me.txt_nombre_producto.Name = "txt_nombre_producto"
        Me.txt_nombre_producto.Size = New System.Drawing.Size(166, 20)
        Me.txt_nombre_producto.TabIndex = 44
        '
        'ListBoxproductos
        '
        Me.ListBoxproductos.FormattingEnabled = True
        Me.ListBoxproductos.Location = New System.Drawing.Point(41, 77)
        Me.ListBoxproductos.Name = "ListBoxproductos"
        Me.ListBoxproductos.Size = New System.Drawing.Size(94, 238)
        Me.ListBoxproductos.TabIndex = 43
        '
        'BTN_CANCELAR
        '
        Me.BTN_CANCELAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CANCELAR.Location = New System.Drawing.Point(604, 130)
        Me.BTN_CANCELAR.Name = "BTN_CANCELAR"
        Me.BTN_CANCELAR.Size = New System.Drawing.Size(103, 35)
        Me.BTN_CANCELAR.TabIndex = 42
        Me.BTN_CANCELAR.Text = "CANCELAR"
        Me.BTN_CANCELAR.UseVisualStyleBackColor = True
        '
        'BTN_BUSCAR
        '
        Me.BTN_BUSCAR.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_BUSCAR.Location = New System.Drawing.Point(604, 77)
        Me.BTN_BUSCAR.Name = "BTN_BUSCAR"
        Me.BTN_BUSCAR.Size = New System.Drawing.Size(103, 35)
        Me.BTN_BUSCAR.TabIndex = 41
        Me.BTN_BUSCAR.Text = "BUSCAR"
        Me.BTN_BUSCAR.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(178, 77)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(409, 286)
        Me.DGV1.TabIndex = 40
        '
        'FILTRO_HERRAMIENTAS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 383)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_nombre_producto)
        Me.Controls.Add(Me.ListBoxproductos)
        Me.Controls.Add(Me.BTN_CANCELAR)
        Me.Controls.Add(Me.BTN_BUSCAR)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "FILTRO_HERRAMIENTAS"
        Me.Text = "FILTRO_HERRAMIENTAS"
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents txt_nombre_producto As TextBox
    Friend WithEvents ListBoxproductos As ListBox
    Friend WithEvents BTN_CANCELAR As Button
    Friend WithEvents BTN_BUSCAR As Button
    Friend WithEvents DGV1 As DataGridView
End Class
