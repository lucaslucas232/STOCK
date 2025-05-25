Imports System.Data.OleDb
Public Class MOVIMIENTOS


    Dim obj_MOVIMIENTOS As New CLS_MOVIMIENTOS
    Public Function ObtenerProductos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT id_PRODUCTO, nombre FROM productos"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function ObtenerDepositos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT ID_OBRA, nombre FROM OBRAS"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function FiltrarMovimientos(startDate As Date, endDate As Date) As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT producto, obra_origen, obra_destino, cantidad, fecha FROM movimientos " &
                                "WHERE fecha BETWEEN ? AND ? ORDER BY fecha DESC"

                Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("?", startDate.ToString("dd/MM/yyyy"))
                    cmd.Parameters.AddWithValue("?", endDate.ToString("dd/MM/yyyy"))
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error filtering movements: {ex.Message}")
            Return Nothing
        End Try
    End Function
    Public Function ObtenerMovimientos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT producto, obra_origen, obra_destino, cantidad, fecha FROM movimientos"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al obtener movimientos: {ex.Message}")
            Return Nothing
        End Try

        'Using con As New OleDbConnection(RutaDB_STOCK)
        '    Dim sql As String = "SELECT TOP 10 producto, obra_origen, obra_destino, cantidad, fecha " &
        '            "FROM movimientos WHERE fecha BETWEEN ? AND ? ORDER BY fecha DESC"

        '    Using cmd As New OleDbCommand(sql, con)
        '        cmd.Parameters.AddWithValue("?", dtpinicio.Value.ToString("dd/MM/yyyy")) ' Format for Access
        '        cmd.Parameters.AddWithValue("?", dtpfin.Value.ToString("dd/MM/yyyy")) ' Format for Access

        '        Dim dt As New DataTable()
        '        Using da As New OleDbDataAdapter(cmd)
        '            da.Fill(dt)
        '        End Using
        '        Return dt
        '    End Using

        '------------------------------------------------------------------------------------------------------

        'Dim sql As String = "SELECT top 10 producto, obra_origen, obra_destino, cantidad, fecha " &
        '                "FROM movimientos WHERE fecha BETWEEN @startDate AND @endDate " &
        '                "ORDER BY [fecha] DESC" ' Use LIMIT instead of TOP for databases like SQLite

        'Using cmd As New OleDbCommand(sql, con)
        '    cmd.Parameters.AddWithValue("@startDate", dtpinicio.Value) ' Assuming you have a DateTimePicker named dtpInicio
        '    cmd.Parameters.AddWithValue("@endDate", dtpfin.Value) ' Another DateTimePicker for the end date

        '    Dim dt As New DataTable()
        '    Using da As New OleDbDataAdapter(cmd)
        '        da.Fill(dt)
        '    End Using
        '    Return dt
        'End Using
        'End Using

    End Function

    Public Function ObtenerNombreObra(id_obra As Integer) As String
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT nombre FROM obras WHERE id_obra = @id_obra"
                Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("@id_obra", id_obra)
                    Dim resultado As Object = cmd.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso resultado IsNot DBNull.Value Then
                        Return resultado.ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error al obtener nombre de obra: {ex.Message}")
        End Try
        Return "Desconocido"
    End Function
    Private Sub MOVIMIENTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar columnas del DataGridView
        With DGVMOVIMIENTOS
            .Columns.Clear() ' Esto asegura que las columnas no se dupliquen al reabrir el formulario.
            .Columns.Add("producto", "Producto")
            .Columns.Add("obra_origen", "Obra Origen")
            .Columns.Add("obra_destino", "Obra Destino")
            .Columns.Add("cantidad", "Cantidad")
            .Columns.Add("fecha", "Fecha")
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With

        ' Cargar datos previos desde la tabla 'movimientos'
        Dim dtMovimientos As DataTable = ObtenerMovimientos()
        If dtMovimientos IsNot Nothing AndAlso dtMovimientos.Rows.Count > 0 Then
            For Each row As DataRow In dtMovimientos.Rows
                Dim nombreOrigen As String = ObtenerNombreObra(CInt(row("obra_origen")))
                Dim nombreDestino As String = ObtenerNombreObra(CInt(row("obra_destino")))
                DGVMOVIMIENTOS.Rows.Add(row("producto").ToString(),
                                nombreOrigen,
                                nombreDestino,
                                row("cantidad").ToString(),
                                CDate(row("fecha")).ToString("dd/MM/yyyy"))
            Next
        End If
        ' Continuar con otras inicializaciones
        Dim dtProductos As DataTable = ObtenerProductos()
        If dtProductos IsNot Nothing Then

            CMBPRODUCTO.DataSource = dtProductos
            dtProductos.DefaultView.Sort = "nombre ASC"

            CMBPRODUCTO.DisplayMember = "nombre"
            CMBPRODUCTO.ValueMember = "id_PRODUCTO"
        End If

        Dim dtDepositos As DataTable = ObtenerDepositos()
        If dtDepositos IsNot Nothing Then
            CMBORIGEN.DataSource = dtDepositos.Copy()
            dtDepositos.DefaultView.Sort = "nombre ASC"

            CMBORIGEN.DisplayMember = "nombre"
            CMBORIGEN.ValueMember = "id_OBRA"
            CMBDESTINO.DataSource = dtDepositos
            CMBDESTINO.DisplayMember = "nombre"
            CMBDESTINO.ValueMember = "id_OBRA"
        End If

        DateTimePicker1.Enabled = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        If String.IsNullOrWhiteSpace(TXTCANTIDAD.Text) Then
            MessageBox.Show("El campo 'Cantidad' no puede estar vacío. Por favor, ingrese una cantidad.")
            Return
        End If
        Dim id_producto As Integer = CInt(CMBPRODUCTO.SelectedValue)
        Dim cantidad As Integer = CInt(TXTCANTIDAD.Text)
        Dim origen_ID As Integer = CInt(CMBORIGEN.SelectedValue)
        Dim destino_ID As Integer = CInt(CMBDESTINO.SelectedValue)
        Dim fecha As DateTime = DateTime.Now

        If origen_ID = destino_ID Then
            MessageBox.Show("El origen y el destino no pueden ser iguales. Por favor, seleccione valores diferentes.")
            Return
        End If
        ' Obtener saldo disponible del producto
        Dim saldoDisponible As Integer = ObtenerSaldoDisponible(id_producto, origen_ID)
        ' Verificar si la cantidad solicitada es menor o igual al saldo disponible
        If cantidad > saldoDisponible Then
            MessageBox.Show($"Saldo insuficiente. Saldo disponible: {saldoDisponible}.")
            Return
        End If
        If obj_MOVIMIENTOS.TransferirMercaderia(id_producto, cantidad, origen_ID, destino_ID, fecha) Then
            MessageBox.Show("Transferencia realizada con éxito.")
            DGVMOVIMIENTOS.Rows.Add(CMBPRODUCTO.Text, CMBORIGEN.Text, CMBDESTINO.Text, cantidad, fecha.ToString("dd/MM/yyyy"))
            TXTCANTIDAD.Text = ""
        Else
            MessageBox.Show("Error al realizar la transferencia.")
        End If
    End Sub

    Private Function ObtenerSaldoDisponible(id_producto As Integer, id_obra As Integer) As Integer
        Dim saldoDisponible As Integer = 0
        Using con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            ' Obtener el total de ingresos
            Dim sqlIngresos As String = "SELECT SUM(cantidad) FROM Ingresos WHERE id_producto = @IDProducto AND id_obra = @IDObra"
            Using cmdIngresos As New OleDbCommand(sqlIngresos, con)
                cmdIngresos.Parameters.AddWithValue("@IDProducto", id_producto)
                cmdIngresos.Parameters.AddWithValue("@IDObra", id_obra)
                Dim totalIngresos As Object = cmdIngresos.ExecuteScalar()
                If totalIngresos IsNot DBNull.Value AndAlso totalIngresos IsNot Nothing Then
                    saldoDisponible += Convert.ToInt32(totalIngresos)
                End If
            End Using
            ' Obtener el total de egresos
            Dim sqlEgresos As String = "SELECT SUM(cantidad) FROM Egresos WHERE id_producto = @IDProducto AND id_obra = @IDObra"
            Using cmdEgresos As New OleDbCommand(sqlEgresos, con)
                cmdEgresos.Parameters.AddWithValue("@IDProducto", id_producto)
                cmdEgresos.Parameters.AddWithValue("@IDObra", id_obra)
                Dim totalEgresos As Object = cmdEgresos.ExecuteScalar()
                If totalEgresos IsNot DBNull.Value AndAlso totalEgresos IsNot Nothing Then
                    saldoDisponible -= Convert.ToInt32(totalEgresos)
                End If
            End Using
        End Using
        Return saldoDisponible
    End Function

    Private Sub CMBPRODUCTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBPRODUCTO.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles dtpinicio.ValueChanged

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnfiltrar.Click
        Dim startDate As Date = dtpinicio.Value
        Dim endDate As Date = dtpfin.Value

        DGVMOVIMIENTOS.DataSource = Nothing ' Remove old data
        DGVMOVIMIENTOS.Columns.Clear() ' Clear duplicate columns

        DGVMOVIMIENTOS.DataSource = FiltrarMovimientos(startDate, endDate)
    End Sub
    Private Sub btnCancelar2_Click(sender As Object, e As EventArgs) Handles btncancelar2.Click
        dtpinicio.Value = DateTime.Now.AddMonths(-1)
        dtpfin.Value = DateTime.Now
        dtpinicio.Visible = True
        dtpfin.Visible = True
        DGVMOVIMIENTOS.DataSource = ObtenerMovimientos()
    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        Me.Close()
    End Sub
End Class
