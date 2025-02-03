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

    Private Sub MOVIMIENTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dbHelper As New DatabaseHelper()
        ' Llenar ComboBox de Productos
        Dim dtProductos As DataTable = ObtenerProductos()
        If dtProductos IsNot Nothing Then
            CMBPRODUCTO.DataSource = dtProductos
            CMBPRODUCTO.DisplayMember = "nombre"
            CMBPRODUCTO.ValueMember = "id_PRODUCTO"
        End If
        ' Llenar ComboBox de Depósitos (Origen y Destino)
        Dim dtDepositos As DataTable = ObtenerDepositos()
        If dtDepositos IsNot Nothing Then
            CMBORIGEN.DataSource = dtDepositos.Copy()
            CMBORIGEN.DisplayMember = "nombre"
            CMBORIGEN.ValueMember = "id_OBRA"
            CMBDESTINO.DataSource = dtDepositos
            CMBDESTINO.DisplayMember = "nombre"
            CMBDESTINO.ValueMember = "id_OBRA"
        End If
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
        ' Verificar que origen_ID y destino_ID no sean iguales
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

        If obj_MOVIMIENTOS.TransferirMercaderia(id_producto, cantidad, origen_ID, destino_ID) Then
            MessageBox.Show("Transferencia realizada con éxito.")
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
End Class
