Imports System.Windows.Forms
Public Class STOCK
    Private Sub Logout()
        For Each childForm As Form In MdiChildren
            childForm.Close()
        Next
        Dim loginForm As New LOGIN With {
            .MdiParent = Me
        }
        loginForm.Show()
    End Sub
    Private Function Carga_formulario(ByVal form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = form.Name Then
                form.Select()
                Return False
            End If
        Next
        form.MdiParent = Me
        AddHandler form.FormClosed, AddressOf FormClosedHandler ' Añadimos el manejador de eventos para el cierre del formulario
        form.Show()
        Return True
    End Function

    Private Sub FormClosedHandler(sender As Object, e As FormClosedEventArgs) ' Mostrar los botones nuevamente al cerrar el formulario Muestra() End Sub
        Muestra()
    End Sub

    'Private Function Carga_formulario(ByVal form As Form) As Boolean
    '    For Each f As Form In Application.OpenForms
    '        If f.Name = form.Name Then
    '            form.Select()
    '            Return False
    '        End If
    '    Next
    '    form.MdiParent = Me
    '    form.Show()
    '    Return True
    'End Function

    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles btnlogout.Click
        Logout()
        Oculta()
        LOGIN.TXT_USER.Clear()
        LOGIN.TXT_PASS.Clear()
    End Sub
    Sub Muestra()
        Debug.WriteLine("Mostrando botones")
        btn_ingreso.Show()
        btn_trans.Show()
        btnlogout.Show()
    End Sub
    Public Sub Oculta()
        btn_ingreso.Hide()
        btn_trans.Hide()
        btnlogout.Hide()
    End Sub
    Private Sub Btn_trans_Click(sender As Object, e As EventArgs) Handles btn_trans.Click
        Carga_formulario(transferencia)
        Oculta()
    End Sub

    Private Sub Btn_ingreso_Click(sender As Object, e As EventArgs) Handles btn_ingreso.Click
        Carga_formulario(INGRESO_MERCADERIA)
        Oculta()
    End Sub
    Private Sub OBRAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OBRAToolStripMenuItem.Click
        Carga_formulario(REGISTRO_OBRAS)
        Oculta()
    End Sub
    Private Sub PRODUCTOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOToolStripMenuItem.Click
        Carga_formulario(REGISTRO_H_Y_I)
        Oculta()
    End Sub
    Private Sub USUARIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USUARIOToolStripMenuItem.Click
        Carga_formulario(REGISTRO_USUARIOS)
        Oculta()
    End Sub
    Private Sub STOCK_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class