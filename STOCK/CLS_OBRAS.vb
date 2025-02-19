
Imports System.Data.OleDb
Public Class CLS_OBRAS
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Function AgregaOBRA(ByVal nombre As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Sql = "Insert into OBRAS (nombre) " _
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
    Public Function ModificaOBRA(ByVal nombre As String, ByVal id As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "UPDATE obras SET nombre = @nombre WHERE id_obra = @id"
                Using cmd As New OleDbCommand(sql, con)
                    'MessageBox.Show("Valor de 'nombre': " & nombre)
                    cmd.Parameters.AddWithValue("@nombre", nombre.ToUpper)
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.ExecuteNonQuery()
                End Using
                Return True
            End Using
        Catch exsql As OleDbException
            MessageBox.Show("Error en SQL: " & exsql.Message)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        End Try
    End Function

    Function EliminaOBRA(ByVal id As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()

                ' Eliminar registros relacionados en la tabla "egresos"
                Dim sqlEgresos As String = "DELETE FROM egresos WHERE id_obra = @id"
                Using ComandoSqlEgresos As New OleDbCommand(sqlEgresos, con)
                    ComandoSqlEgresos.Parameters.AddWithValue("@id", id)
                    ComandoSqlEgresos.ExecuteNonQuery()
                End Using

                ' Eliminar registro en la tabla "OBRAS"
                Dim sqlObras As String = "DELETE FROM OBRAS WHERE id_obra = @id"
                Using ComandoSqlObras As New OleDbCommand(sqlObras, con)
                    ComandoSqlObras.Parameters.AddWithValue("@id", id)
                    Dim rowsAffected As Integer = ComandoSqlObras.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return True
                    Else
                        MessageBox.Show("No se encontró el registro a eliminar.")
                        Return False
                    End If
                End Using
            End Using
        Catch ex As OleDbException
            MessageBox.Show("Error en SQL: " & ex.Message)
            Return False
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            Return False
        End Try
    End Function
End Class

