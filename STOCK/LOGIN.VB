﻿Imports System.Data.OleDb
Public Class LOGIN
    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click
        Try
            If TXT_USER.Text = "" Or TXT_PASS.Text = "" Then
                MsgBox("Ingrese nombre de usuario y contraseña")
                TXT_USER.Focus()
                Exit Sub
            Else
                Dim SQL1 As String
                '                          0                     1                     2
                SQL1 = "SELECT usuarios.usuario, usuarios.contraseña, usuarios.tipo " _
                    + "FROM usuarios " _
                    + "WHERE usuarios.usuario='" & TXT_USER.Text & "' AND usuarios.contraseña='" & TXT_PASS.Text & "';"
                Dim da As New OleDbDataAdapter(SQL1, RutaDB_STOCK)
                MessageBox.Show("Database Path: " & RutaDB_STOCK)
                Dim dt As New DataTable
                da.Fill(dt)
                If dt.Rows.Count = 0 Then
                    MsgBox("Usuario inexistente o contraseña incorrecta...")
                    TXT_USER.Focus()
                Else
                    Dim dr As DataRow
                    dr = dt.Rows(0)
                    MsgBox("Usuario autentificado correctamente, tipo de usuario: " & dr("tipo"), MsgBoxStyle.OkOnly, "Login")
                    Dim mdiform As New STOCK()

                    If LCase(dr("TIPO")) = "admin" Then
                        mdiform.BTN_REGISTRO.Enabled = True
                    Else
                        mdiform.BTN_REGISTRO.Enabled = False
                        ' Aquí puedes habilitar o deshabilitar controles según el tipo de usuario.
                    End If
                    usuario = dr(0)
                    Me.Hide() ' Oculta el formulario de login
                    mdiform.ShowDialog() ' Abre el formulario de stock
                    Me.Close() ' Muestra nuevamente el formulario de login si se cierra el formulario de stock
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        Me.Close()
    End Sub

    Private Sub LOGIN_CAJERO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TXT_USER.Select()

    End Sub

End Class
