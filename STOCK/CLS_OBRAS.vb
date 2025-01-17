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

    'Function ModificaOBRA(ByVal nombre As String,
    '                       ByVal ID As Integer) As Boolean
    '    Try

    '        Dim con As New OleDbConnection(RutaDB_STOCK)
    '        con.Open()
    '        Sql = "UPDATE OBRAS
    'SET Nombre = '" & nombre.ToUpper & "' 

    'WHERE ID=" & ID & ""

    '        ComandoSql = New OleDbCommand(Sql, con)
    '        ComandoSql.Parameters.AddWithValue("@nombre", nombre.ToUpper)
    '        'ComandoSql.Parameters.AddWithValue("@tipo", tipo)
    '        ComandoSql.Parameters.AddWithValue("@ID", ID)
    '        ComandoSql.ExecuteNonQuery() 'EJECUTA LOS CAMBIOS
    '        ComandoSql.Dispose() 'LIMPIA LA VARIABLE 
    '        Sql = String.Empty 'EMPTY  LIMPIA LA VARIABLE
    '        con.Close()
    '        Return True

    '    Catch exsql As OleDbException
    '        Return False

    '    Catch ex As Exception
    '        Return False
    '    End Try

    'End Function
    Function ModificaOBRA(ByVal nombre As String, ByVal ID As Integer) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()

                ' TOUPPER  MAYUSCULAS  TOLOWER MINUSCULAS
                Dim sql As String = "UPDATE obras SET nombre = @nombre WHERE ID = @id"

                Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("@nombre", nombre)

                    cmd.Parameters.AddWithValue("@id", ID)

                    cmd.ExecuteNonQuery() ' EJECUTA LOS CAMBIOS
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
                Dim sql As String = "DELETE FROM OBRAS WHERE ID = @id_obra"

                Using ComandoSql As New OleDbCommand(sql, con)
                    ComandoSql.Parameters.AddWithValue("@id", id)

                    ' Ejecutar la consulta y verificar el número de filas afectadas
                    Dim rowsAffected As Integer = ComandoSql.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("Registro eliminado satisfactoriamente.")
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

