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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CMBPRODUCTO
        '
        Me.CMBPRODUCTO.FormattingEnabled = True
        Me.CMBPRODUCTO.Location = New System.Drawing.Point(112, 76)
        Me.CMBPRODUCTO.Name = "CMBPRODUCTO"
        Me.CMBPRODUCTO.Size = New System.Drawing.Size(121, 21)
        Me.CMBPRODUCTO.TabIndex = 0
        '
        'CMBORIGEN
        '
        Me.CMBORIGEN.FormattingEnabled = True
        Me.CMBORIGEN.Location = New System.Drawing.Point(112, 127)
        Me.CMBORIGEN.Name = "CMBORIGEN"
        Me.CMBORIGEN.Size = New System.Drawing.Size(121, 21)
        Me.CMBORIGEN.TabIndex = 1
        '
        'CMBDESTINO
        '
        Me.CMBDESTINO.FormattingEnabled = True
        Me.CMBDESTINO.Location = New System.Drawing.Point(112, 186)
        Me.CMBDESTINO.Name = "CMBDESTINO"
        Me.CMBDESTINO.Size = New System.Drawing.Size(121, 21)
        Me.CMBDESTINO.TabIndex = 2
        '
        'TXTCANTIDAD
        '
        Me.TXTCANTIDAD.Location = New System.Drawing.Point(350, 78)
        Me.TXTCANTIDAD.Name = "TXTCANTIDAD"
        Me.TXTCANTIDAD.Size = New System.Drawing.Size(100, 20)
        Me.TXTCANTIDAD.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(561, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(118, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "PRODUCTO"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "ORIGEN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(118, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "DESTINO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(347, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CANTIDAD"
        '
        'MOVIMIENTOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TXTCANTIDAD)
        Me.Controls.Add(Me.CMBDESTINO)
        Me.Controls.Add(Me.CMBORIGEN)
        Me.Controls.Add(Me.CMBPRODUCTO)
        Me.Name = "MOVIMIENTOS"
        Me.Text = "MOVIMIENTOS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CMBPRODUCTO As ComboBox
    Friend WithEvents CMBORIGEN As ComboBox
    Friend WithEvents CMBDESTINO As ComboBox
    Friend WithEvents TXTCANTIDAD As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
