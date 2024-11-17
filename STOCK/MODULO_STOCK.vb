Imports System.Data.OleDb

Module MODULO_STOCK
    Public RutaDB_STOCK As String = "provider=microsoft.ace.oledb.12.0; data source=" & My.Application.Info.DirectoryPath & "\STOCK.accdb"

    'Public usuario As String = ""

    Public Function ObtenerProductos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT id_PRODUCTO, nombre FROM productos"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function Carga_formulario(ByVal form As Form) As Boolean
        For Each f In Application.OpenForms
            If f.Name = form.Name Then
                form.Select()
                Return False
            End If
        Next
        form.MdiParent = STOCK
        form.Show()
        Return True
    End Function


End Module
