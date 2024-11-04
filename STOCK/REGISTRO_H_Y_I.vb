Imports System.Data.OleDb

Public Class REGISTRO_H_Y_I
    Dim obj_HERRAMIENTAS As New cls_herramientas
    Dim n As Integer
    Dim id As Integer
    Dim ini As Integer

    Sub pinta_fila(ByVal nn As Integer)
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

    Sub ModoInsercion()
        BTN_CANCELAR.Enabled = True
        BTN_NUEVO.Enabled = True
        BTN_ELIMINAR.Enabled = False
        BTN_MODIFICAR.Enabled = True
        BTN_AGREGAR.Enabled = True
    End Sub

    Sub ModoModificacion()
        BTN_AGREGAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_MODIFICAR.Enabled = True
        BTN_CANCELAR.Enabled = True
    End Sub

    Sub LimpiarCampos()
        txt_producto.Text = ""
        cmb_tipo.Text = ""
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
            Me.ModoModificacion()
            id = ObtenerCampo(Me.DGV1, 0)
            txt_producto.Text = ObtenerCampo(Me.DGV1, 1)
            cmb_tipo.Text = ObtenerCampo(Me.DGV1, 2)

            BTN_NUEVO.Enabled = False
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True

        End If

    End Sub

    Function ValidarDatos() As Boolean


        If txt_producto.Text.Trim = "" Then
            MsgBox("error en el producto...")
            txt_producto.Focus()
            Return False
            Exit Function
        End If

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
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub REGISTRO_H_Y_I_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        STOCK.muestra()
    End Sub


    Private Sub REGISTRO_H_Y_I_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarTabla(Me.DGV1, "HERRAMIENTAS", "", "id") 'tabla usuarios ordenado por apellido        ' Label9.Text = n

    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            'If ValidarDatos() Then
            If obj_HERRAMIENTAS.Agregaherramienta(txt_producto.Text, cmb_tipo.Text) = True Then

                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "herramientas", "", "ID")
                Else
                    MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            'End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
        Me.ModoInsercion()


    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        Try
            Dim i = MsgBox("¿Desea modificar ese registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")

            If i = MsgBoxResult.Yes Then

                'If ValidarDatos() Then
                If obj_HERRAMIENTAS.Modificaherramienta(txt_producto.Text, cmb_tipo.Text, id) = True Then
                    MsgBox("Registro actualizado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "herramientas", "", "id")

                    Me.ModoInsercion()
                Else
                    MsgBox("Error al modificar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                End If
            End If
            'End If
            Me.LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try


    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim i = MsgBox("¿Desea eliminar esta herramienta?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            Try

                If obj_HERRAMIENTAS.Eliminaherramienta(id) = True Then
                    MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "herramientas", "", "id")
                    Me.ModoInsercion()
                    Me.LimpiarCampos()
                Else
                    MsgBox("Error al eliminar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        Else
        End If

    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        LimpiarCampos()
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_NUEVO.Enabled = True
        BTN_AGREGAR.Enabled = True
        pinta_fila(0)
        If id > 0 Then
            id = DGV1.Item(0, 0).Value
        End If


    End Sub

End Class