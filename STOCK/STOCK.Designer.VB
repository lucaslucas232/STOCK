<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class STOCK
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
        Me.btn_trans = New System.Windows.Forms.Button()
        Me.btn_ingreso = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.REGISTROToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.USUARIOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRODUCTOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OBRAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnlogout = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_trans
        '
        Me.btn_trans.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btn_trans.Location = New System.Drawing.Point(151, 54)
        Me.btn_trans.Name = "btn_trans"
        Me.btn_trans.Size = New System.Drawing.Size(120, 33)
        Me.btn_trans.TabIndex = 0
        Me.btn_trans.Text = "TRANSFERENCIA"
        Me.btn_trans.UseVisualStyleBackColor = True
        '
        'btn_ingreso
        '
        Me.btn_ingreso.Location = New System.Drawing.Point(322, 54)
        Me.btn_ingreso.Name = "btn_ingreso"
        Me.btn_ingreso.Size = New System.Drawing.Size(75, 47)
        Me.btn_ingreso.TabIndex = 1
        Me.btn_ingreso.Text = "INGRESO DE STOCK"
        Me.btn_ingreso.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.REGISTROToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(581, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'REGISTROToolStripMenuItem
        '
        Me.REGISTROToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USUARIOToolStripMenuItem, Me.PRODUCTOToolStripMenuItem, Me.OBRAToolStripMenuItem})
        Me.REGISTROToolStripMenuItem.Name = "REGISTROToolStripMenuItem"
        Me.REGISTROToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.REGISTROToolStripMenuItem.Text = "REGISTRO"
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
        Me.btnlogout.Location = New System.Drawing.Point(333, 134)
        Me.btnlogout.Name = "btnlogout"
        Me.btnlogout.Size = New System.Drawing.Size(75, 23)
        Me.btnlogout.TabIndex = 5
        Me.btnlogout.Text = "LOG OUT"
        Me.btnlogout.UseVisualStyleBackColor = True
        '
        'STOCK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(581, 230)
        Me.Controls.Add(Me.btnlogout)
        Me.Controls.Add(Me.btn_ingreso)
        Me.Controls.Add(Me.btn_trans)
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

    Friend WithEvents btn_trans As Button
    Friend WithEvents btn_ingreso As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents REGISTROToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents USUARIOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PRODUCTOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OBRAToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnlogout As Button
End Class
