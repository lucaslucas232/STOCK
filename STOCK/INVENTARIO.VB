Imports System.Data.OleDb

Public Class INVENTARIO
    Dim n As Integer

    Sub pinta_fila(ByVal nn As Integer)
        Try
            For i As Integer = 0 To DGV1.Rows.Count - 1
                DGV1.Rows(i).Selected = False
            Next
            If nn > 0 Then
                DGV1.Rows(nn).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ActualizarTabla1(ByVal grilla As DataGridView)
        Try
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim consulta As String
            consulta = "SELECT obras.nombre
From obras"

            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub carga_datos()
        Try
            Dim SQL As String
            SQL = "SELECT OBRAS.NOMBRE, OBRAS.ID_OBRA FROM OBRAS ORDER BY NOMBRE"
            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            ListBox1.Items.Clear()
            For Each dr As DataRow In dt.Rows
                ListBox1.Items.Add(dr("NOMBRE").ToString())
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_obra.TextChanged
        Try
            Dim SQL As String
            Dim DATO As String
            DATO = txt_nombre_obra.Text & "%"
            '                   0                  1
            SQL = "Select obras.nombre From obras
Where (((obras.nombre) Like '" & DATO & "'));"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            ListBox1.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow
                dr = dt.Rows(i)
                ListBox1.Items.Add(dr(0))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub INVENTARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_datos()
    End Sub
    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        ' Verifica que haya una obra seleccionada
        If ListBox1.SelectedItem Is Nothing Then
            MsgBox("Por favor, selecciona una obra.")
            Exit Sub
        End If

        ' Captura el nombre de la obra seleccionada
        Dim selectedObra As String = ListBox1.SelectedItem.ToString()
        MsgBox("Obra seleccionada: " & selectedObra)

        ' Obtén el ID de la obra desde la base de datos utilizando el nombre de la obra seleccionada
        Dim id_obra As Integer
        Using con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            Dim sql As String = "SELECT ID_OBRA FROM OBRAS WHERE NOMBRE = @Nombre"
            Using cmd As New OleDbCommand(sql, con)
                cmd.Parameters.AddWithValue("@Nombre", selectedObra)
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                    id_obra = Convert.ToInt32(result)
                    MsgBox("ID de la obra: " & id_obra.ToString())
                Else
                    MsgBox("No se encontró la obra seleccionada.")
                    Exit Sub
                End If
            End Using
        End Using
        ActualizarTabla(DGV1, id_obra)
    End Sub

    Sub ActualizarTabla(ByVal grilla As DataGridView, ByVal id_obra As Integer)
        Dim da1 As OleDbDataAdapter
        Dim dt1 As DataTable
        Dim consulta As String

        Try
            consulta = "SELECT p.ID_PRODUCTO, p.Nombre, " &
                   "SUM(i.cantidad) - IIF(SUM(e.cantidad) IS NULL, 0, SUM(e.cantidad)) AS SALDO " &
                   "FROM (ingresos AS i LEFT JOIN egresos AS e ON i.ID_PRODUCTO = e.ID_PRODUCTO) " &
                   "INNER JOIN productos AS p ON i.ID_PRODUCTO = p.ID_PRODUCTO " &
                   "WHERE i.ID_OBRA = ? " &
                   "GROUP BY p.ID_PRODUCTO, p.Nombre"

            da1 = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            da1.SelectCommand.Parameters.AddWithValue("?", id_obra)
            dt1 = New DataTable
            da1.Fill(dt1)
            n = dt1.Rows.Count
            MsgBox("Número de filas recuperadas: " & n.ToString())

            grilla.DataSource = dt1
            grilla.ReadOnly = True 'SOLO DE LECTURA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class