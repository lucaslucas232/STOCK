Imports System.Windows.Forms

Public Class STOCK

    Private Sub Logout()
        Dim loginForm As New LOGIN()
        AddHandler loginForm.FormClosed, AddressOf OnLoginFormClosed
        loginForm.ShowDialog()
    End Sub

    Private Sub OnLoginFormClosed(sender As Object, e As FormClosedEventArgs)
        While Me.MdiChildren.Length > 0
            Me.MdiChildren(0).Close()
        End While

        Me.Close()
    End Sub

    Private Function Carga_formulario(ByVal form As Form) As Boolean
        For Each f As Form In Application.OpenForms
            If f.Name = form.Name Then
                form.Select()
                Return False
            End If
        Next
        form.MdiParent = Me
        AddHandler form.FormClosed, AddressOf FormClosedHandler
        form.Show()
        Return True
    End Function

    Private Sub FormClosedHandler(sender As Object, e As FormClosedEventArgs)
        Muestra()
    End Sub

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
        BTN_MOVIMIENTOS.Show()
        BTN_INVENTARIO.Show()
    End Sub

    Public Sub Oculta()
        btn_ingreso.Hide()
        btn_trans.Hide()
        btnlogout.Hide()
        BTN_MOVIMIENTOS.Hide()
        BTN_INVENTARIO.Hide()
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

    Private Sub BTN_MOVIMIENTOS_Click(sender As Object, e As EventArgs) Handles BTN_MOVIMIENTOS.Click
        Carga_formulario(MOVIMIENTOS)
        Oculta()
    End Sub

    Private Sub BTN_INVENTARIO_Click(sender As Object, e As EventArgs) Handles BTN_INVENTARIO.Click
        Carga_formulario(INVENTARIO)
        Oculta()
    End Sub

    Private Sub STOCK_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        While Me.MdiChildren.Length > 0
            Me.MdiChildren(0).Close()
        End While
    End Sub
End Class
