Imports System.Data.OleDb
Public Class REGISTRO_OBRAS
    Dim obj_OBRAS As New CLS_OBRAS
    Dim n As Integer
    Dim id As Integer
    Dim ini As Integer
    Sub Pinta_fila(ByVal nn As Integer)
        Try
            For i As Integer = 0 To DGV1.Rows.Count - 1
                DGV1.Rows(i).Selected = False
            Next
            If nn > 0 Then
                DGV1.Rows(nn).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub ModoInsercion()
    '    BTN_CANCELAR.Enabled = True
    '    BTN_NUEVO.Enabled = True
    '    BTN_ELIMINAR.Enabled = True
    '    BTN_MODIFICAR.Enabled = True
    '    BTN_AGREGAR.Enabled = True
    'End Sub
    Sub ModoModificacion()
        BTN_AGREGAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_MODIFICAR.Enabled = True
        BTN_CANCELAR.Enabled = True
    End Sub
    Sub LimpiarCampos()
        TXT_OBRA.Text = ""
    End Sub
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
            MsgBox("Debe seleccionar una herramienta para poder editarla", MsgBoxStyle.Critical, "Error")
            DGV1.Focus()
        Else
            TXT_OBRA.Enabled = True
            Me.ModoModificacion()
            id = ObtenerCampo(Me.DGV1, 0)
            TXT_OBRA.Text = ObtenerCampo(Me.DGV1, 1)
            BTN_NUEVO.Enabled = False
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True
            TXT_OBRA.Focus()
        End If
    End Sub

    Function ValidarDatos() As Boolean
        If TXT_OBRA.Text.Trim = "" Then
            MsgBox("El campo Obra está vacío. Por favor, ingrese un producto.", MsgBoxStyle.Critical, "Error")
            TXT_OBRA.Focus()
            Return False

            Exit Function
        End If
        Return True

    End Function

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
            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error al cargar los datos")
        End Try
        If DGV1.Columns.Contains("id_obra") Then
            DGV1.Columns("id_obra").Visible = False
        End If
    End Sub
    Private Sub REGISTRO_H_Y_I_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BTN_NUEVO.Focus()
        TXT_OBRA.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_AGREGAR.Enabled = False
        BTN_CANCELAR.Enabled = False
        ActualizarTabla(Me.DGV1, "OBRAS", "", "id_obra")
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If ValidarDatos() Then
                If obj_OBRAS.AgregaOBRA(TXT_OBRA.Text) = True Then
                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "OBRAS", "", "ID_obra")
                    BTN_AGREGAR.Enabled = False
                    TXT_OBRA.Enabled = False
                    BTN_CANCELAR.Enabled = False
                    BTN_ELIMINAR.Enabled = False
                    BTN_NUEVO.Enabled = True
                    BTN_MODIFICAR.Enabled = False
                    BTN_NUEVO.Focus()
                Else
                    MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
        'Me.ModoInsercion()
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Try
            If DGV1.SelectedRows.Count = 0 Then
                MessageBox.Show("Por favor, seleccione una fila para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Try
                Dim i = MsgBox("¿Desea modificar ese registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
                If i = MsgBoxResult.Yes Then
                    If obj_OBRAS Is Nothing Then
                        MessageBox.Show("obj_obras no está inicializado")
                        Return
                    End If
                    'MessageBox.Show("ID del registro a modificar: " & id)
                    If obj_OBRAS.ModificaOBRA(TXT_OBRA.Text, id) Then
                        MessageBox.Show("Registro actualizado satisfactoriamente")
                        ActualizarTabla(Me.DGV1, "obras", "", "id_obra")
                        Me.LimpiarCampos()
                        BTN_AGREGAR.Enabled = False
                        TXT_OBRA.Enabled = False
                        BTN_CANCELAR.Enabled = False
                        BTN_ELIMINAR.Enabled = False
                        BTN_NUEVO.Enabled = True
                        BTN_MODIFICAR.Enabled = False
                        BTN_NUEVO.Focus()
                    Else
                        MessageBox.Show("Error al modificar el registro, reintente la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Validación de datos fallida")
                End If
            Catch ex As Exception
                MessageBox.Show("Error de Validación de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch ex As Exception
            MessageBox.Show("Error de Validación de datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        LimpiarCampos()
        BTN_CANCELAR.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_NUEVO.Enabled = True
        BTN_AGREGAR.Enabled = False
        TXT_OBRA.Enabled = False
        Pinta_fila(0)
        If id > 0 Then
            id = DGV1.Item(0, 0).Value
        Else
            id = -1
        End If
    End Sub
    Private Sub BTN_NUEVO_Click(sender As Object, e As EventArgs) Handles BTN_NUEVO.Click
        Try
            BTN_AGREGAR.Enabled = True
            BTN_NUEVO.Enabled = False
            BTN_MODIFICAR.Enabled = False
            BTN_ELIMINAR.Enabled = False
            BTN_CANCELAR.Enabled = True
            TXT_OBRA.Enabled = True
            TXT_OBRA.Focus()
            LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGV1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim result = MsgBox("¿Desea eliminar esta herramienta?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If result = MsgBoxResult.Yes Then
            Try
                'MessageBox.Show("ID del registro a eliminar: " & id)
                If obj_OBRAS.EliminaOBRA(id) Then
                    MsgBox("Registro eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmación")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "OBRAS", "", "ID_obra")
                    BTN_AGREGAR.Enabled = False
                    TXT_OBRA.Enabled = False
                    BTN_CANCELAR.Enabled = False
                    BTN_ELIMINAR.Enabled = False
                    BTN_NUEVO.Enabled = True
                    BTN_MODIFICAR.Enabled = False
                    BTN_NUEVO.Focus()
                Else
                    MsgBox("Error al eliminar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        End If
    End Sub

End Class



