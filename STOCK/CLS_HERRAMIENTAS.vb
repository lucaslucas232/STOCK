
Imports System.Data.OleDb

Public Class cls_herramientas
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Function Agregaherramienta(ByVal nombre As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Sql = "Insert into productos (nombre) " _
                    + "Values (@nombre)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nombre", nombre.ToUpper)

                .ExecuteNonQuery()
            End With

            ComandoSql.Dispose()
            Sql = String.Empty
            con.Close()
            Return True

        Catch exsql As OleDbException
            MsgBox(exsql.Message)
            Return False

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try

    End Function
    Function Modificaherramienta(ByVal nombre As String, ByVal ID As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "UPDATE productos SET Nombre = ? WHERE ID_producto = ?"
                Using comandoSql As New OleDbCommand(sql, con)
                    comandoSql.Parameters.AddWithValue("@nombre", nombre.ToUpper())
                    comandoSql.Parameters.AddWithValue("@ID_producto", ID)
                    comandoSql.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch exsql As OleDbException
            MsgBox("Database error: " & exsql.Message, MsgBoxStyle.Critical, "Database Error")
            Return False
        Catch ex As Exception
            MsgBox("General error: " & ex.Message, MsgBoxStyle.Critical, "General Error")
            Return False
        End Try
    End Function


    Function Eliminaherramienta(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()

            ' Eliminar registros relacionados en la tabla ingresos
            Dim SqlIngresos As String = "DELETE FROM ingresos WHERE id_producto =" & id
            Dim ComandoSqlIngresos As New OleDbCommand(SqlIngresos, con)
            ComandoSqlIngresos.ExecuteNonQuery()
            ComandoSqlIngresos.Dispose()

            Dim Sqlegresos As String = "DELETE FROM egresos WHERE id_producto =" & id
            Dim ComandoSqlegresos As New OleDbCommand(Sqlegresos, con)
            ComandoSqlegresos.ExecuteNonQuery()
            ComandoSqlegresos.Dispose()


            ' Eliminar registro en la tabla productos
            Dim SqlProductos As String = "DELETE FROM productos WHERE id_producto =" & id
            Dim ComandoSqlProductos As New OleDbCommand(SqlProductos, con)
            ComandoSqlProductos.ExecuteNonQuery()
            ComandoSqlProductos.Dispose()

            con.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al eliminar el registro")
            Return False
        End Try
    End Function

End Class
