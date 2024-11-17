Imports System.Data.OleDb
Imports System.IO

Public Class CLS_INGRESOS
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Dim mstream As New System.IO.MemoryStream()

    Function AgregaINGRESO(ByVal nombre As String) As Boolean

        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()

            Sql = "Insert into INGRESOS (id_producto) " _
                + "Values (@id_producto)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@id_produto", nombre.ToUpper)

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
    Function EliminaINGRESO(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Sql = "DELETE * FROM ingresos    WHERE id =" & id
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
