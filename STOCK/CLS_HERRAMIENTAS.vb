
Imports System.Data.OleDb

Public Class cls_herramientas
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Function Agregaherramienta(ByVal nombre As String, ByVal TIPO As String) As Boolean

        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()


            Sql = "Insert into productos (nombre, TIPO) " _
                    + "Values (@nombre,@TIPO)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nombre", nombre.ToUpper)
                .Parameters.AddWithValue("@tipo", TIPO)

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
    Function Modificaherramienta(ByVal nombre As String, ByVal tipo As String, ByVal ID As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "UPDATE productos SET Nombre = ?, tipo = ? WHERE ID_producto = ?"
                Using comandoSql As New OleDbCommand(sql, con)
                    comandoSql.Parameters.AddWithValue("@nombre", nombre.ToUpper())
                    comandoSql.Parameters.AddWithValue("@tipo", tipo)
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
            Sql = "DELETE * FROM productos WHERE id_producto =" & id
            ComandoSql = New OleDbCommand(Sql, con)
            ComandoSql.ExecuteNonQuery()
            ComandoSql.Dispose()
            Sql = String.Empty
            con.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
