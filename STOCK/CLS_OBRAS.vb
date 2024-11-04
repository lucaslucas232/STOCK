Imports System.Data.OleDb
Public Class CLS_OBRAS
    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Function AgregaOBRA(ByVal nombre As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK) 'APUNTA A LA BASE DE DATOS.. CON = CONEXION 
            con.Open()

            Sql = "Insert into OBRAS (nombre) " _
                    + "Values (@nombre)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@nombre", nombre.ToUpper)
                '.Parameters.AddWithValue("@tipo", TIPO)

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

    Function ModificaOBRA(ByVal nombre As String,
                           ByVal ID As Integer) As Boolean
        Try

            Dim con As New OleDbConnection(RutaDB_STOCK)

            con.Open()
            'TOUPPER  MAYUSCULAS  TOLOWER MINUSCULAS
            Sql = "UPDATE OBRAS
SET Nombre = '" & nombre.ToUpper & "' 

WHERE ID=" & ID & ""

            ComandoSql = New OleDbCommand(Sql, con)
            ComandoSql.Parameters.AddWithValue("@nombre", nombre.ToUpper)
            'ComandoSql.Parameters.AddWithValue("@tipo", tipo)
            ComandoSql.Parameters.AddWithValue("@ID", ID)
            ComandoSql.ExecuteNonQuery() 'EJECUTA LOS CAMBIOS
            ComandoSql.Dispose() 'LIMPIA LA VARIABLE 
            Sql = String.Empty 'EMPTY  LIMPIA LA VARIABLE
            con.Close()
            Return True

        Catch exsql As OleDbException
            Return False

        Catch ex As Exception
            Return False
        End Try

    End Function

    Function EliminaOBRA(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Sql = "DELETE * FROM OBRAS WHERE id =" & id
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

