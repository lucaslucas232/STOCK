Imports System.Data.OleDb


Public Class CLS_MOVIMIENTOS
    Public Function TransferirMercaderia(id_producto As Integer, cantidad As Integer, origen_id As Integer, destino_id As Integer, ByVal fecha As DateTime) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim transaction As OleDbTransaction = con.BeginTransaction()
                Try
                    Dim nombre As String = ""
                    Dim sqlObtenerNombre As String = "SELECT nombre FROM productos WHERE id_producto = @id_producto"
                    Using cmdObtenerNombre As New OleDbCommand(sqlObtenerNombre, con, transaction)
                        cmdObtenerNombre.Parameters.AddWithValue("@id_producto", id_producto)
                        Dim resultado As Object = cmdObtenerNombre.ExecuteScalar()
                        If resultado IsNot DBNull.Value AndAlso resultado IsNot Nothing Then
                            nombre = resultado.ToString()
                        Else
                            MessageBox.Show("No se encontró el producto con el ID proporcionado.")
                            Return False
                        End If
                    End Using

                    Dim sqlEgreso As String = "INSERT INTO egresos (id_producto, cantidad, id_obra, NOMBRE, fecha) VALUES (@id_producto, @cantidad, @id_obra, @NOMBRE, @fecha)"
                    Using cmdEgreso As New OleDbCommand(sqlEgreso, con, transaction)
                        cmdEgreso.Parameters.AddWithValue("@id_producto", id_producto)
                        cmdEgreso.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdEgreso.Parameters.AddWithValue("@id_obra", origen_id)
                        cmdEgreso.Parameters.AddWithValue("@NOMBRE", nombre)
                        'cmdEgreso.Parameters.AddWithValue("@fecha", fecha)
                        cmdEgreso.Parameters.Add("@fecha", OleDbType.Date).Value = fecha

                        cmdEgreso.ExecuteNonQuery()
                    End Using
                    'MessageBox.Show("Egreso ejecutado")

                    Dim sqlIngreso As String = "INSERT INTO ingresos (id_producto, cantidad, id_obra, NOMBRE, fecha) VALUES (@id_producto, @cantidad, @id_obra, @NOMBRE, @fecha)"
                    Using cmdIngreso As New OleDbCommand(sqlIngreso, con, transaction)
                        cmdIngreso.Parameters.AddWithValue("@id_producto", id_producto)
                        cmdIngreso.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdIngreso.Parameters.AddWithValue("@id_obra", destino_id)
                        cmdIngreso.Parameters.AddWithValue("@NOMBRE", nombre)
                        'cmdIngreso.Parameters.AddWithValue("@fecha", fecha)
                        cmdIngreso.Parameters.Add("@fecha", OleDbType.Date).Value = fecha
                        cmdIngreso.ExecuteNonQuery()
                    End Using
                    'MessageBox.Show("Ingreso ejecutado")
                    Dim sqlMovimiento As String = "INSERT INTO movimientos (id_producto, producto, obra_origen, obra_destino, cantidad, fecha) VALUES (@id_producto, @producto, @obra_origen, @obra_destino, @cantidad, @fecha)"
                    Using cmdMovimiento As New OleDbCommand(sqlMovimiento, con, transaction)
                        cmdMovimiento.Parameters.AddWithValue("@id_producto", id_producto)
                        cmdMovimiento.Parameters.AddWithValue("@producto", nombre)
                        cmdMovimiento.Parameters.AddWithValue("@obra_origen", origen_id)
                        cmdMovimiento.Parameters.AddWithValue("@obra_destino", destino_id)
                        cmdMovimiento.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdMovimiento.Parameters.Add("@fecha", OleDbType.Date).Value = fecha
                        cmdMovimiento.ExecuteNonQuery()
                    End Using
                    transaction.Commit()

                    Return True
                Catch ex As Exception
                    transaction.Rollback()
                    Return False
                End Try
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ObtenerStockActual(producto_id As Integer) As Integer
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT (ISNULL(SUM(ingresos.cantidad), 0) - ISNULL(SUM(egresos.cantidad), 0)) AS stock_actual FROM ingresos_mercaderia ingresos LEFT JOIN egresos_mercaderia egresos ON ingresos.producto_id = egresos.producto_id WHERE ingresos.producto_id = @producto_id"
                Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("@producto_id", producto_id)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return -1
        End Try
    End Function
End Class
