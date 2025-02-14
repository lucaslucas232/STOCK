Imports System.Data.OleDb
Public Class INGRESO_MERCADERIA
    Dim id As Integer
    Dim obj_INGRESOS As New CLS_INGRESOS
    Dim n As Integer

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
    Function ObtenerCampo(ByVal grilla As DataGridView, ByVal indice_columna As Byte)
        Try
            If Not IsDBNull(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value) Then
                Return CStr(grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub LimpiarCampos()
        TXT_CANTIDAD.Text = ""
        cmbproducto.SelectedIndex = -1
        CMB_DESTINO.SelectedIndex = -1
    End Sub

    Function ValidarDatos() As Boolean
        If cmbproducto.Text.Trim = "" Then
            MsgBox("El campo Producto está vacío. Por favor, ingrese un producto.", MsgBoxStyle.Critical, "Error")
            cmbproducto.Focus()
            Return False
        End If
        If TXT_CANTIDAD.Text = "" Then
            MsgBox("El campo cantidad está vacío. Por favor, seleccione una cantidad.", MsgBoxStyle.Critical, "Error")
            TXT_CANTIDAD.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub INGRESO_MERCADERIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGA_PRODUCTOS()
        CARGA_OBRAS()
        DateTimePicker1.Enabled = False
        TXT_CANTIDAD.Enabled = False
        cmbproducto.Enabled = False
        CMB_DESTINO.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_AGREGAR.Enabled = False
        BTN_CANCELAR.Enabled = False
        cmbproducto.DropDownStyle = ComboBoxStyle.DropDownList
        cmbproducto.SelectedIndex = 0
        BTN_NUEVO.Focus()

        ActualizarTabla(Me.DGV1, "INGRESOS", "", "id_ingresos")
    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                        ByVal campoSql As String, ByVal C_ORDEN As String)
        If grilla.Columns.Contains("id_ingresos") Then
            grilla.Columns("id_ingresos").Visible = False
        End If
        If grilla.Columns.Contains("id_producto") Then
            grilla.Columns("id_producto").Visible = False
        End If

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
        If DGV1.Columns.Contains("id_ingresos") Then
            DGV1.Columns("id_ingresos").Visible = False
        End If
        If DGV1.Columns.Contains("id_producto") Then
            DGV1.Columns("id_producto").Visible = False
        End If
    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If ValidarDatos() Then
                Dim id_producto As Integer = CInt(cmbproducto.SelectedValue)
                Dim nombre As String = cmbproducto.Text
                Dim cantidad As Integer = CInt(TXT_CANTIDAD.Text)
                Dim destino As String = CMB_DESTINO.Text
                Dim tipo As String = "Tipo de Producto" ' Ajusta esto según tus necesidades

                If obj_INGRESOS.AgregaINGRESO(id_producto, nombre, cantidad, destino, tipo) Then
                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmación")
                    LimpiarCampos()

                    ActualizarTabla(Me.DGV1, "INGRESOS", "", "id_ingresos")
                    BTN_AGREGAR.Enabled = False
                    BTN_CANCELAR.Enabled = False
                    BTN_ELIMINAR.Enabled = False
                    BTN_NUEVO.Enabled = True
                    BTN_MODIFICAR.Enabled = False
                    BTN_NUEVO.Focus()

                Else
                    MsgBox("Error al ingresar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
    End Sub
    Private Function ObtenerIdSeleccionado() As Integer
        Try
            ' Supongamos que la columna ID está en la primera columna del DataGridView
            Dim id As Integer = CInt(DGV1.CurrentRow.Cells(0).Value)
            Return id
        Catch ex As Exception
            MsgBox("No se pudo obtener el ID seleccionado. Por favor, seleccione un registro válido.", MsgBoxStyle.Critical, "Error")
            Return -1
        End Try
    End Function


    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim id As Integer = ObtenerIdSeleccionado() ' Asegúrate de obtener el ID seleccionado
        If id <= 0 Then
            MsgBox("El ID proporcionado no es válido.", MsgBoxStyle.Critical, "Error")
            Return
        End If

        Dim i = MsgBox("¿Desea eliminar esta herramienta?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            MsgBox("ID a eliminar: " & id) ' Verifica que el id es correcto
            Try
                If obj_INGRESOS.EliminaINGRESO(id) Then
                    MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "productos", "", "id_producto")
                    BTN_AGREGAR.Enabled = False
                    cmbproducto.Enabled = False
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


    Private Sub INGRESO_MERCADERIA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        STOCK.Muestra()
    End Sub
    Sub CARGA_PRODUCTOS()
        Try
            Dim sql As String = "SELECT [Id_PRODUCTO], [NOMBRE] FROM PRODUCTOS"
            Dim da As New OleDbDataAdapter(sql, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            cmbproducto.DataSource = dt
            cmbproducto.DisplayMember = "NOMBRE"
            cmbproducto.ValueMember = "Id_PRODUCTO"
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al cargar productos")
        End Try
    End Sub
    Sub CARGA_OBRAS()

        Dim sql As String
        sql = "SELECT OBRAS.[Id_OBRA], OBRAS.[NOMBRE]
FROM OBRAS;"


        Dim da As New OleDbDataAdapter(sql, RutaDB_STOCK)
        Dim dt As New DataTable
        da.Fill(dt)
        CMB_DESTINO.Items.Clear()
        For i = 0 To dt.Rows.Count - 1
            Dim dr As DataRow 'dr datarow
            dr = dt.Rows(i)
            CMB_DESTINO.Items.Add(dr(1))
        Next

    End Sub

    Private Sub DGV1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub

    Private Sub DGV1_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV1.MouseClick
        If DGV1.SelectedRows.Count = 0 Then
            MsgBox("Debe seleccionar una herramienta para poder editarla", MsgBoxStyle.Critical, "Error")
            DGV1.Focus()
        Else
            cmbproducto.Enabled = True
            CMB_DESTINO.Enabled = True
            'Me.ModoModificacion()
            id = ObtenerCampo(Me.DGV1, 0)
            cmbproducto.Text = ObtenerCampo(Me.DGV1, 1)
            'cmbproducto.Text = ObtenerCampo(Me.DGV1, 2)
            BTN_CANCELAR.Enabled = True
            BTN_NUEVO.Enabled = False
            BTN_AGREGAR.Enabled = False
            BTN_ELIMINAR.Enabled = True
            cmbproducto.Focus()
        End If
    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        LimpiarCampos()
        BTN_CANCELAR.Enabled = False
        BTN_MODIFICAR.Enabled = False
        BTN_ELIMINAR.Enabled = False
        BTN_NUEVO.Enabled = True
        BTN_AGREGAR.Enabled = False
        cmbproducto.Enabled = False
        CMB_DESTINO.Enabled = False
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
            TXT_CANTIDAD.Enabled = True

            BTN_NUEVO.Enabled = False
            BTN_MODIFICAR.Enabled = False
            BTN_ELIMINAR.Enabled = False
            BTN_CANCELAR.Enabled = True
            cmbproducto.Enabled = True
            cmbproducto.Focus()
            cmbproducto.Enabled = True
            CMB_DESTINO.Enabled = True

            LimpiarCampos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
