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
    Function ObtenerCampo(ByVal grilla As DataGridView, ByVal indice_columna As Byte) As String
        Try
            Dim valor As Object = grilla.Item(indice_columna, grilla.CurrentCell.RowIndex).Value
            If Not IsDBNull(valor) Then
                Return CStr(valor)
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return String.Empty
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
        Dim fechaCompleta As Date = Now
        Dim soloFecha As String = fechaCompleta.ToString("dd/MM/yyyy")
        Console.WriteLine(soloFecha)
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
        ActualizarTabla(Me.DGV1, "ingresos", "", "id_ingreso")
        DGV1.Columns("id_ingresos").Visible = False
        DGV1.Columns("id_producto").Visible = False
        DGV1.Columns("id_obra").Visible = False

    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                    ByVal campoSql As String, ByVal C_ORDEN As String)
        Try

            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim consulta As String

            'consulta = "SELECT "
            'If campoSql = "" Then
            '    consulta += "*"
            'Else
            '    consulta += campoSql
            'End If
            'consulta += " From " & nombre_tabla & " ORDER BY " & C_ORDEN

            consulta = "Select INGRESOS.Id_INGRESOS, INGRESOS.ID_PRODUCTO, INGRESOS.NOMBRE, INGRESOS.CANTIDAD, INGRESOS.ID_OBRA, INGRESOS.FECHA From INGRESOS Order By INGRESOS.Id_INGRESOS;"


            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count
            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error al cargar los datos")
        End Try

    End Sub

    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            If ValidarDatos() Then
                Dim id_producto As Integer
                Dim cantidad As Integer
                Dim destino As Integer
                If Not IsDBNull(cmbproducto.SelectedValue) Then
                    id_producto = CInt(cmbproducto.SelectedValue)
                Else
                    id_producto = 0 ' O un valor por defecto adecuado
                End If

                If Not IsDBNull(TXT_CANTIDAD.Text) AndAlso Integer.TryParse(TXT_CANTIDAD.Text, cantidad) Then
                    cantidad = CInt(TXT_CANTIDAD.Text)
                Else
                    cantidad = 0 ' O un valor por defecto adecuado
                End If

                If Not IsDBNull(CMB_DESTINO.SelectedValue) Then
                    destino = CInt(CMB_DESTINO.SelectedValue)
                Else
                    destino = 0 ' O un valor por defecto adecuado
                End If
                MsgBox("ID_Producto: " & id_producto)
                MsgBox("Cantidad: " & cantidad)
                MsgBox("Destino (ID_Obra): " & destino)
                MsgBox("Fecha: " & DateTime.Now)
                Dim nombre As String = cmbproducto.Text
                Dim fecha As DateTime = DateTime.Now
                If obj_INGRESOS.AgregaINGRESO(id_producto, nombre, cantidad, destino, fecha) Then
                    MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmación")
                    LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "INGRESOS", "", "id_ingreso")
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
    'Private Function ObtenerIdSeleccionado() As Integer
    '    Try
    '        Dim id As Integer = CInt(DGV1.CurrentRow.Cells(0).Value)
    '        Return id
    '    Catch ex As Exception
    '        MsgBox("No se pudo obtener el ID seleccionado. Por favor, seleccione un registro válido.", MsgBoxStyle.Critical, "Error")
    '        Return -1
    '    End Try
    'End Function
    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim i = MsgBox("¿Desea eliminar este ingreso?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            'Try
            '    If obj_INGRESOS.EliminaINGRESO(id) Then
            '        MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmación")
            '        Me.LimpiarCampos()
            '        ActualizarTabla(Me.DGV1, "ingresos", "", "id_ingreso")
            '        BTN_AGREGAR.Enabled = False
            '        cmbproducto.Enabled = False
            '        BTN_CANCELAR.Enabled = False
            '        BTN_ELIMINAR.Enabled = False
            '        BTN_NUEVO.Enabled = True
            '        BTN_MODIFICAR.Enabled = False
            '        BTN_NUEVO.Focus()
            '    Else
            '        MsgBox("Error al eliminar el registro, reintente la acción", MsgBoxStyle.Critical, "Error")
            '    End If
            'Catch ex As Exception
            '    MsgBox("Error en BTN_ELIMINAR_Click: " & ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            'End Try
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
        End Try
    End Sub

    Sub CARGA_OBRAS()
        Dim sql As String
        sql = "SELECT OBRAS.[Id_OBRA], OBRAS.[NOMBRE] FROM OBRAS;"
        Dim da As New OleDbDataAdapter(sql, RutaDB_STOCK)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            CMB_DESTINO.DataSource = dt
            CMB_DESTINO.DisplayMember = "NOMBRE"
            CMB_DESTINO.ValueMember = "Id_OBRA"
        Catch

        End Try
    End Sub

    Private Sub DGV1_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV1.MouseClick
        Try
            If DGV1.SelectedRows.Count = 0 Then
                MsgBox("Debe seleccionar un registro para poder editarlo.", MsgBoxStyle.Critical, "Error")
                DGV1.Focus()
            Else
                cmbproducto.Enabled = True
                CMB_DESTINO.Enabled = True
                TXT_CANTIDAD.Enabled = True
                Dim idProducto As Integer = CInt(DGV1.CurrentRow.Cells("id_producto").Value)
                Dim cantidad As Integer = CInt(DGV1.CurrentRow.Cells("cantidad").Value)
                Dim idObra As Integer = CInt(DGV1.CurrentRow.Cells("id_obra").Value)
                cmbproducto.SelectedValue = idProducto
                TXT_CANTIDAD.Text = cantidad.ToString()
                CMB_DESTINO.SelectedValue = idObra
                BTN_CANCELAR.Enabled = True
                BTN_NUEVO.Enabled = False
                BTN_AGREGAR.Enabled = False
                BTN_ELIMINAR.Enabled = True
                cmbproducto.Focus()
            End If
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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
