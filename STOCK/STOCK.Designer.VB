<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class STOCK
    Inherits System.Windows.Forms.Form
    Protected Overrides Sub Dispose(disposing As Boolean)
        ' Código de limpieza aquí
    End Sub
    '<System.Diagnostics.DebuggerNonUserCode()>
    'Protected Overrides Sub Dispose(disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub


    'Form reemplaza a Dispose para limpiar la lista de componentes.
    '<System.Diagnostics.DebuggerNonUserCode()>
    'Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    '    Try
    '        If disposing AndAlso components IsNot Nothing Then
    '            components.Dispose()
    '        End If
    '    Finally
    '        MyBase.Dispose(disposing)
    '    End Try
    'End Sub

    'Requerido por el Diseñador de Windows Forms
    'Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_ingreso = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btn_registro = New System.Windows.Forms.ToolStripMenuItem()
        Me.USUARIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCTOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OBRAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.BTN_MOVIMIENTOS = New System.Windows.Forms.Button()
        Me.BTN_INVENTARIO = New System.Windows.Forms.Button()
        Me.BTN_EGRESO = New System.Windows.Forms.Button()
        Me.BTN_FILTRO = New System.Windows.Forms.Button()

        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_ingreso
        '
        Me.btn_ingreso.Location = New System.Drawing.Point(49, 54)
        Me.btn_ingreso.Name = "btn_ingreso"
        Me.btn_ingreso.Size = New System.Drawing.Size(120, 41)
        Me.btn_ingreso.TabIndex = 1
        Me.btn_ingreso.Text = "INGRESO DE STOCK"
        Me.btn_ingreso.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_registro})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(545, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btn_registro
        '
        Me.btn_registro.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USUARIOToolStripMenuItem, Me.PRODUCTOToolStripMenuItem, Me.OBRAToolStripMenuItem})
        Me.btn_registro.Name = "btn_registro"
        Me.btn_registro.Size = New System.Drawing.Size(71, 20)
        Me.btn_registro.Text = "REGISTRO"
        '
        'USUARIOToolStripMenuItem
        '
        Me.USUARIOToolStripMenuItem.Name = "USUARIOToolStripMenuItem"
        Me.USUARIOToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.USUARIOToolStripMenuItem.Text = "USUARIO"
        '
        'PRODUCTOToolStripMenuItem
        '
        Me.PRODUCTOToolStripMenuItem.Name = "PRODUCTOToolStripMenuItem"
        Me.PRODUCTOToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.PRODUCTOToolStripMenuItem.Text = "PRODUCTO"
        '
        'OBRAToolStripMenuItem
        '
        Me.OBRAToolStripMenuItem.Name = "OBRAToolStripMenuItem"
        Me.OBRAToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OBRAToolStripMenuItem.Text = "OBRA"
        '
        'btnlogout
        '
        Me.btnlogout.Location = New System.Drawing.Point(388, 192)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(75, 23)
        Me.btnlogout.TabIndex = 5
        Me.btnlogout.Text = "LOG OUT"
        Me.btnlogout.UseVisualStyleBackColor = True
        '
        'BTN_MOVIMIENTOS
        '
        Me.BTN_MOVIMIENTOS.Location = New System.Drawing.Point(197, 54)
        Me.BTN_MOVIMIENTOS.Name = "BTN_MOVIMIENTOS"
        Me.BTN_MOVIMIENTOS.Size = New System.Drawing.Size(120, 41)
        Me.BTN_MOVIMIENTOS.TabIndex = 7
        Me.BTN_MOVIMIENTOS.Text = "MOVIMIENTOS"
        Me.BTN_MOVIMIENTOS.UseVisualStyleBackColor = True
        '
        'BTN_INVENTARIO
        '
        Me.BTN_INVENTARIO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BTN_INVENTARIO.Location = New System.Drawing.Point(343, 54)
        Me.BTN_INVENTARIO.Name = "BTN_INVENTARIO"
        Me.BTN_INVENTARIO.Size = New System.Drawing.Size(120, 41)
        Me.BTN_INVENTARIO.TabIndex = 9
        Me.BTN_INVENTARIO.Text = "INVENTARIO OBRAS"
        Me.BTN_INVENTARIO.UseVisualStyleBackColor = True
        '
        'BTN_FILTRO
        '
        Me.BTN_FILTRO.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BTN_FILTRO.Location = New System.Drawing.Point(343, 113)
        Me.BTN_FILTRO.Name = "BTN_FILTRO"
        Me.BTN_FILTRO.Size = New System.Drawing.Size(120, 41)
        Me.BTN_FILTRO.TabIndex = 11
        Me.BTN_FILTRO.Text = "INVENTARIO PRODUCTOS"
        Me.BTN_FILTRO.UseVisualStyleBackColor = True
        '
        'BTN_EGRESO
        '
        Me.BTN_EGRESO.Location = New System.Drawing.Point(49, 113)
        Me.BTN_EGRESO.Name = "BTN_EGRESO"
        Me.BTN_EGRESO.Size = New System.Drawing.Size(120, 41)
        Me.BTN_EGRESO.TabIndex = 13
        Me.BTN_EGRESO.Text = "EGRESO DE STOCK"
        Me.BTN_EGRESO.UseVisualStyleBackColor = True
        '
        'STOCK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(545, 243)
        Me.Controls.Add(Me.BTN_EGRESO)
        Me.Controls.Add(Me.BTN_FILTRO)
        Me.Controls.Add(Me.BTN_INVENTARIO)
        Me.Controls.Add(Me.BTN_MOVIMIENTOS)
        Me.Controls.Add(Me.btnlogout)
        Me.Controls.Add(Me.btn_ingreso)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "STOCK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "STOCK"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_ingreso As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents btn_registro As ToolStripMenuItem
    Friend WithEvents USUARIOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PRODUCTOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OBRAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnlogout As Button
    Friend WithEvents BTN_MOVIMIENTOS As Button
    Friend WithEvents BTN_INVENTARIO As Button
    Friend WithEvents BTN_FILTRO As Button
    Friend WithEvents BTN_EGRESO As Button
End Class
