Imports System.Windows.Forms

Public Class STOCK
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Logout()
            For Each childForm As Form In MdiChildren
                childForm.Close()
            Next


        Dim loginForm As New LOGIN()
        loginForm.MdiParent = Me
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
            form.Show()
            Return True
        End Function

    'Sub oculta()
    '    BTN_MOVIMIENTOS.Hide()
    '    BTN_ADM_USUARIOS.Hide()
    '    BTN_CREDITOS.Hide()
    '    BTN_REGISTRO.Hide()
    '    BTNLOGOUT.Hide()
    'End Sub
    'Sub muestra()
    '        BTNLOGOUT.Show()
    '        BTN_MOVIMIENTOS.Show()
    '        BTN_ADM_USUARIOS.Show()
    '        BTN_CREDITOS.Show()
    '        BTN_REGISTRO.Show()


    'End Sub


    Private Sub BTNLOGOUT_Click(sender As Object, e As EventArgs) Handles BTNLOGOUT.Click
            Logout()
            oculta()
        LOGIN.TXT_USER.Clear()

        LOGIN.TXT_PASS.Clear()


    End Sub

    Sub muestra()
        btn_ingreso.Show()
        btn_trans.Show()
        btnlogout.Show()
    End Sub

    Sub oculta()
        btn_ingreso.Hide()
        btn_trans.Hide()
        btnlogout.Hide()
    End Sub
    Private Sub btn_trans_Click(sender As Object, e As EventArgs) Handles btn_trans.Click
        Carga_formulario(transferencia)
        oculta()
    End Sub

    Private Sub btn_ingreso_Click(sender As Object, e As EventArgs) Handles btn_ingreso.Click
        Carga_formulario(INGRESO_MERCADERIA)
        oculta()

    End Sub

    Private Sub STOCK_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub OBRAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OBRAToolStripMenuItem.Click
        Carga_formulario(REGISTRO_OBRAS)
        oculta()

    End Sub

    Private Sub PRODUCTOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODUCTOToolStripMenuItem.Click
        Carga_formulario(REGISTRO_H_Y_I)
        oculta()

    End Sub

    Private Sub USUARIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USUARIOToolStripMenuItem.Click
        Carga_formulario(REGISTRO_USUARIOS)
        oculta()


    End Sub
End Class