Imports System.Data.OleDb

Public Class REGISTRO_H_Y_I
    Dim Obj_HERRAMIENTAS As New cls_herramientas
    'Dim n As Integer
    Dim id As Integer
    'Dim ini As Integer
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

    Sub ModoModificacion()
        BTN_AGREGAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_MODIFICAR.Enabled = True
        BTN_CANCELAR.Enabled = True
    End Sub
    Sub LimpiarCampos()
        txt_producto.Text = ""
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
            txt_producto.Enabled = True
            Me.ModoModificacion()
            id = ObtenerCampo(Me.DGV1, 0)
            txt_producto.Text = ObtenerCampo(Me.DGV1, 1)

            BTN_NUEVO.Enabled = False
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True
            txt_producto.Focus()
        End If
    End Sub
    Function ValidarDatos() As Boolean
        If txt_producto.Text.Trim = "" Then
            MsgBox("El campo Producto está vacío. Por favor, ingrese un producto.", MsgBoxStyle.Critical, "Error")
            txt_producto.Focus()
            Return False
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
            'n = dt.Rows.Count
            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If DGV1.Columns.Contains("id_producto") Then
            DGV1.Columns("id_producto").Visible = False
        End If
    End Sub
    Private Sub REGISTRO_H_Y_I_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        STOCK.muestra()
    End Sub
    Private Sub REGISTRO_H_Y_I_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txt_producto.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_AGREGAR.Enabled = False
        BTN_CANCELAR.Enabled = False
        ActualizarTabla(Me.DGV1, "productos", "", "nombre")
        BTN_NUEVO.Focus()
        DGV1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DGV1.ScrollBars = ScrollBars.Horizontal
    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If ValidarDatos() Then
                If obj_HERRAMIENTAS.Agregaherramienta(txt_producto.Text) = True Then
                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "productos", "", "nombre")
                    BTN_AGREGAR.Enabled = False
                    txt_producto.Enabled = False
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
    End Sub

    Private Sub BTN_MODIFICAR_Click(sender As Object, e As EventArgs) Handles BTN_MODIFICAR.Click
        If DGV1.SelectedRows.Count = 0 Then
            MessageBox.Show("Por favor, seleccione una fila para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim i = MsgBox("¿Desea modificar ese registro?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
            If i = MsgBoxResult.Yes Then
                If ValidarDatos() Then
                    Console.WriteLine("Starting modification...")
                    If obj_HERRAMIENTAS.Modificaherramienta(txt_producto.Text, id) = True Then
                        MsgBox("Registro actualizado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                        ActualizarTabla(Me.DGV1, "PRODUCTOS", "", "id_producto")
                        LimpiarCampos()
                        BTN_AGREGAR.Enabled = False
                        txt_producto.Enabled = False
                        txt_producto.Enabled = False
                        BTN_CANCELAR.Enabled = False
                        BTN_ELIMINAR.Enabled = False
                        BTN_NUEVO.Enabled = True
                        BTN_MODIFICAR.Enabled = False
                        BTN_NUEVO.Focus()
                    Else
                        MsgBox("Error al modificar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                    End If
                End If
            End If

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
                    ActualizarTabla(Me.DGV1, "productos", "", "id_producto")
                    BTN_AGREGAR.Enabled = False
                    txt_producto.Enabled = False
                    BTN_CANCELAR.Enabled = False
                    BTN_ELIMINAR.Enabled = False
                    BTN_NUEVO.Enabled = True
                    BTN_MODIFICAR.Enabled = False
                    BTN_NUEVO.Focus()
                Else
                    MsgBox("Error al eliminar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        End If
    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        LimpiarCampos()
        BTN_CANCELAR.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_NUEVO.Enabled = True
        BTN_AGREGAR.Enabled = False
        txt_producto.Enabled = False
        pinta_fila(0)
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
            txt_producto.Enabled = True
            txt_producto.Focus()

            LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGV1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub TxtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtfiltro.TextChanged
        FiltrarRegistros(txtfiltro.Text)
    End Sub
    Private Sub FiltrarRegistros(ByVal criterio As String)
        If TypeOf DGV1.DataSource Is DataTable Then
            Dim dt As DataTable = CType(DGV1.DataSource, DataTable)
            Dim dv As New DataView(dt)
            dv.RowFilter = "nombre LIKE '%" & criterio & "%'"
            DGV1.DataSource = dv
        ElseIf TypeOf DGV1.DataSource Is DataView Then
            Dim dv As DataView = CType(DGV1.DataSource, DataView)
            dv.RowFilter = "nombre LIKE '%" & criterio & "%'"
            ' No es necesario reasignar el DataSource, ya que dv se mantiene.
        Else
            MessageBox.Show("El DataGridView no tiene un DataTable o DataView válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class