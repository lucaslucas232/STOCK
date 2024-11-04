Imports System.Data.OleDb
Public Class REGISTRO_USUARIOS
    Dim id As Integer

    Dim obj_USUARIO As New CLS_USUARIOS
    Dim n As Integer


    Function ValidarDatos() As Boolean


        If txt_USUARIO.Text.Trim = "" Then
            MsgBox("error en el usuario...")
            txt_USUARIO.Focus()
            Return False
            Exit Function
        End If

        If TXT_CONTRASEÑA.Text.Trim = "" Then
            MsgBox("error en el usuario...")
            TXT_CONTRASEÑA.Focus()
            Return False
            Exit Function
        End If

    End Function

    Function ObtenerCampo(ByVal grilla As DataGridView, ByVal indice_columna As Byte)
        Try
            If Not IsDBNull(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value) Then
                Return CStr(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function
    Private Sub DGV1_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV1.MouseClick
        If DGV1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar un usuario para poder editarlo", MsgBoxStyle.Critical, "Error")
            DGV1.Focus()
        Else
            'Me.ModoModificacion()
            txt_USUARIO.Text = ObtenerCampo(Me.DGV1, 1)
            TXT_CONTRASEÑA.Text = ObtenerCampo(Me.DGV1, 2)
            CMB_TIPO.Text = ObtenerCampo(Me.DGV1, 3)
            id = ObtenerCampo(Me.DGV1, 0)
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True

            ' txtNombre.Focus()
            '   Label6.Text = dgv1.CurrentRow.Index + 1
            'ini = dgv1.CurrentRow.Index

        End If

    End Sub


    Sub ActualizarTabla(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                        ByVal campoSql As String, ByVal C_ORDEN As String)
        Try
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim consulta As String
            consulta = "Select "
            If campoSql = "" Then
                consulta += "*"
            Else
                consulta += campoSql
            End If
            consulta += " From " & nombre_tabla & " ORDER BY " & C_ORDEN
            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub REGISTRO_USUARIOS_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        STOCK.muestra()
    End Sub

    Private Sub REGISTRO_USUARIOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarTabla(Me.DGV1, "USUARIOS", "", "id") 'tabla usuarios ordenado por apellido        ' Label9.Text = n

    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            'If ValidarDatos() Then
            If obj_USUARIO.AgregaUsuario(txt_USUARIO.Text, TXT_CONTRASEÑA.Text, CMB_TIPO.Text) = True Then

                MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                'Me.LimpiarCampos()
                ActualizarTabla(Me.DGV1, "usuarios", "", "ID")
            Else
                MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
            End If
            'End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
        'Me.ModoInsercion()

    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Try
            Dim i = MsgBox("¿Desea modificar ese registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")

            If i = MsgBoxResult.Yes Then

                If ValidarDatos() Then
                    If obj_USUARIO.Modificausuario(txt_USUARIO.Text, TXT_CONTRASEÑA.Text, CMB_TIPO.Text, id) = True Then
                        MsgBox("Registro actualizado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                        'Me.LimpiarCampos()
                        ActualizarTabla(Me.DGV1, "usuarios", "", "id")

                        'Me.ModoInsercion()
                    Else
                        MsgBox("Error al modificar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If
            ' Me.LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try


    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim i = MsgBox("¿Desea eliminar este usuario?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            Try

                If obj_USUARIO.EliminaUsuarios(id) = True Then
                    MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    'Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "usuarios", "", "id")
                    'Me.ModoInsercion()
                    'Me.LimpiarCampos()
                Else
                    MsgBox("Error al eliminar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        Else
        End If


    End Sub
End Class