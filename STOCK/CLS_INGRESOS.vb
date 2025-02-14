Imports System.Data.OleDb
Imports System.IO

Public Class CLS_INGRESOS
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Dim mstream As New System.IO.MemoryStream()
    Function AgregaINGRESO(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad As Integer, ByVal destino As String, ByVal tipo As String) As Boolean
        Dim con As New OleDbConnection(RutaDB_STOCK)
        Try
            con.Open()
            Sql = "INSERT INTO INGRESOS (ID_PRODUCTO, NOMBRE, CANTIDAD, ID_OBRA, FECHA, TIPO) VALUES (@id_producto, @nombre, @cantidad, @id_obra, @fecha, @tipo)"
            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.Add("@id_producto", OleDbType.Integer).Value = id_producto
                .Parameters.Add("@nombre", OleDbType.VarChar).Value = nombre.ToUpper()
                .Parameters.Add("@cantidad", OleDbType.Integer).Value = cantidad
                .Parameters.Add("@id_obra", OleDbType.VarChar).Value = destino
                .Parameters.Add("@fecha", OleDbType.Date).Value = DateTime.Now
                .Parameters.Add("@tipo", OleDbType.VarChar).Value = tipo
                .ExecuteNonQuery()
            End With
            Return True
        Catch exsql As OleDbException
            MsgBox(exsql.Message)
            Return False
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Close()
        End Try
    End Function


    Function EliminaINGRESO(ByVal id As Integer) As Boolean
        Dim con As New OleDbConnection(RutaDB_STOCK)
        Try
            con.Open()
            Sql = "DELETE FROM INGRESOS WHERE id = @id_ingreso"
            ComandoSql = New OleDbCommand(Sql, con)
            ComandoSql.Parameters.AddWithValue("@id_ingreso", id)
            ComandoSql.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            con.Close()
        End Try
    End Function

End Class
