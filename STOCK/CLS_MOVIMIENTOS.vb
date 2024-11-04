Imports System.Data.OleDb


Public Class CLS_MOVIMIENTOS


    Public Function TransferirMercaderia(producto_id As Integer, cantidad As Integer, origen_id As Integer, destino_id As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim transaction As OleDbTransaction = con.BeginTransaction()

                Try
                    Dim sqlEgreso As String = "INSERT INTO egresos (producto_id, cantidad, deposito_id) VALUES (@producto_id, @cantidad, @origen_id)"
                    Using cmdEgreso As New OleDbCommand(sqlEgreso, con, transaction)
                        cmdEgreso.Parameters.AddWithValue("@producto_id", producto_id)
                        cmdEgreso.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdEgreso.Parameters.AddWithValue("@origen_id", origen_id)
                        cmdEgreso.ExecuteNonQuery()
                    End Using

                    Dim sqlIngreso As String = "INSERT INTO ingresos (producto_id, cantidad, deposito_id) VALUES (@producto_id, @cantidad, @destino_id)"
                    Using cmdIngreso As New OleDbCommand(sqlIngreso, con, transaction)
                        cmdIngreso.Parameters.AddWithValue("@producto_id", producto_id)
                        cmdIngreso.Parameters.AddWithValue("@cantidad", cantidad)
                        cmdIngreso.Parameters.AddWithValue("@destino_id", destino_id)
                        cmdIngreso.ExecuteNonQuery()
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
