Imports System.Data.OleDb
Imports System.IO

Public Class CLS_USUARIOS

    Dim ComandoSql As OleDbCommand
    Dim Sql As String
    Dim mstream As New System.IO.MemoryStream()

    Function AgregaUsuario(ByVal USUARIO As String, ByVal CONTRASEÑA As String, ByVal TIPO As String) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK) 'APUNTA A LA BASE DE DATOS.. CON = CONEXION 
            con.Open()



            Sql = "Insert into usuarios (usuario, contraseña, TIPO) " _
                    + "Values (@usuario,@contraseña,@TIPO)"

            ComandoSql = New OleDbCommand
            With ComandoSql
                .Connection = con
                .CommandText = Sql
                .Parameters.AddWithValue("@usuario", USUARIO.ToUpper)

                .Parameters.AddWithValue("@contraseña", CONTRASEÑA)
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

    Function Modificausuario(ByVal USUARIO As String, ByVal CONTRASEÑA As String, ByVal TIPO As String, ByVal id As String) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "UPDATE usuarios SET usuario = @USUARIO, tipo = @TIPO, contraseña = @CONTRASEÑA WHERE ID = @id"
                Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("@USUARIO", USUARIO.ToUpper)
                    cmd.Parameters.AddWithValue("@TIPO", TIPO)
                    cmd.Parameters.AddWithValue("@CONTRASEÑA", CONTRASEÑA)
                    cmd.Parameters.AddWithValue("@id", id)
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


    Function EliminaUsuarios(ByVal id As Integer) As Boolean
        Try
            Dim con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Sql = "DELETE * FROM usuarios WHERE id =" & id
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

    Friend Function Modificausuario(text1 As String, text2 As String, text3 As String, id As Integer, pictureBox1 As PictureBox, text4 As String) As Boolean
        Throw New NotImplementedException()
    End Function
End Class
