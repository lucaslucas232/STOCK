Imports System.Data.OleDb
Imports System.IO

Public Class CLS_INGRESOS
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Dim mstream As New System.IO.MemoryStream()
    Function AgregaINGRESO(ByVal id_producto As Integer, ByVal nombre As String, ByVal cantidad As Integer, ByVal destino As Integer, ByVal fecha As DateTime) As Boolean
        Dim con As New OleDbConnection(RutaDB_STOCK)
        Try
            con.Open()
            Sql = "INSERT INTO INGRESOS (ID_PRODUCTO, NOMBRE, CANTIDAD, ID_OBRA, FECHA) VALUES (@id_producto, @nombre, @cantidad, @id_obra, @fecha)"
            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@id_producto", id_producto)
                .Parameters.AddWithValue("@nombre", nombre.ToUpper())
                .Parameters.AddWithValue("@cantidad", cantidad)
                .Parameters.AddWithValue("@id_obra", destino)
                .Parameters.AddWithValue("@fecha", fecha)
                .ExecuteNonQuery()
            End With
            Return True
        Catch exsql As OleDbException
            MsgBox("SQL Error: " & exsql.Message & " - " & exsql.ErrorCode.ToString())
            Return False
        Catch ex As Exception
            MsgBox("General Error: " & ex.Message)
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
            MsgBox("Registro eliminado exitosamente")
            Return True
        Catch ex As Exception
            MsgBox("Error en EliminaINGRESO: " & ex.Message, MsgBoxStyle.Critical, "Error de Eliminación")
            Return False
        Finally
            con.Close()
        End Try
    End Function
End Class
