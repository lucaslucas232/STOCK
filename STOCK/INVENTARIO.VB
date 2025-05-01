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

                Dim item As New LISTBOXITEM(dr("NOMBRE").ToString(), dr("ID_OBRA"))
                ListBox1.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message)
        End Try
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_obra.TextChanged
        Try
            Dim SQL As String
            Dim DATO As String
            DATO = txt_nombre_obra.Text & "%"

            SQL = "SELECT OBRAS.NOMBRE, OBRAS.ID_OBRA FROM OBRAS WHERE OBRAS.NOMBRE LIKE '" & DATO & "';"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            ListBox1.Items.Clear()

            For Each dr As DataRow In dt.Rows
                Dim item As New LISTBOXITEM(dr("NOMBRE").ToString(), dr("ID_OBRA"))
                ListBox1.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error al filtrar las obras: " & ex.Message)
        End Try
    End Sub
    Private Sub INVENTARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_datos()
    End Sub
    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        ActualizarTabla(Me.DGV1)
        DGV1.Columns("id_producto").Visible = False
        DGV1.Columns("total_ingresos").Visible = False
        DGV1.Columns("total_egresos").Visible = False
        DGV1.AutoResizeColumns()
        DGV1.AutoResizeRows()

    End Sub

    Sub ActualizarTabla(ByVal grilla As DataGridView)
        Dim da1 As OleDbDataAdapter
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim consulta As String
        Dim consulta2 As String
        Dim id_obra As Integer
        Try
            If ListBox1.SelectedItem Is Nothing Then
                MsgBox("Por favor, selecciona un depósito.")
                Exit Sub
            End If
            id_obra = CInt(DirectCast(ListBox1.SelectedItem, LISTBOXITEM).Tag)

            consulta = "SELECT ingresos.ID_PRODUCTO, ingresos.NOMBRE, Sum(ingresos.cantidad) AS SumaDecantidad
                FROM ingresos
                WHERE (((ingresos.ID_OBRA)=" & id_obra & "))
                GROUP BY ingresos.ID_PRODUCTO, ingresos.NOMBRE;"
            da1 = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt1 = New DataTable
            da1.Fill(dt1)

            consulta2 = "SELECT egresos.ID_PRODUCTO, egresos.NOMBRE, Sum(egresos.cantidad) AS SumaDecantidad
                 FROM egresos
                 WHERE (((egresos.ID_OBRA)=" & id_obra & "))
                 GROUP BY egresos.ID_PRODUCTO, egresos.NOMBRE;"
            da1 = New OleDbDataAdapter(consulta2, RutaDB_STOCK)
            dt2 = New DataTable
            da1.Fill(dt2)

            Dim limpiarTemp As String = "DELETE FROM temp"
            Dim cmd As New OleDbCommand(limpiarTemp, New OleDbConnection(RutaDB_STOCK))
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()

            ' Manejar ingresos sin egresos y viceversa
            Dim allProducts = New Dictionary(Of Integer, String)()
            For Each dr In dt1.Rows
                allProducts(dr("ID_PRODUCTO")) = dr("NOMBRE")
            Next
            For Each dr In dt2.Rows
                If Not allProducts.ContainsKey(dr("ID_PRODUCTO")) Then
                    allProducts(dr("ID_PRODUCTO")) = dr("NOMBRE")
                End If
            Next

            For Each kvp In allProducts
                Dim id_producto As Integer = kvp.Key
                Dim nombre_producto As String = kvp.Value
                Dim total_i As Integer = 0
                Dim total_e As Integer = 0
                Dim saldo As Integer

                Dim ingresoRow = dt1.AsEnumerable().FirstOrDefault(Function(r) r("ID_PRODUCTO") = id_producto)
                Dim egresoRow = dt2.AsEnumerable().FirstOrDefault(Function(r) r("ID_PRODUCTO") = id_producto)

                If ingresoRow IsNot Nothing Then
                    total_i = ingresoRow("SumaDecantidad")
                End If
                If egresoRow IsNot Nothing Then
                    total_e = egresoRow("SumaDecantidad")
                End If

                saldo = total_i - total_e

                Dim insertarTemp As String = "INSERT INTO temp (ID_PRODUCTO, NOMBRE, TOTAL_INGRESOS, TOTAL_EGRESOS, SALDO) VALUES (" &
                                         id_producto & ", '" & nombre_producto & "', " & total_i & ", " & total_e & ", " & saldo & ")"
                cmd = New OleDbCommand(insertarTemp, New OleDbConnection(RutaDB_STOCK))
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                cmd.Connection.Close()
            Next

            ' Consultar los datos recién insertados en la tabla temp
            Dim consultaTemp As String = "SELECT ID_PRODUCTO, NOMBRE, TOTAL_INGRESOS, TOTAL_EGRESOS, SALDO FROM temp"
            Dim dtTemp As New DataTable
            Dim daTemp As New OleDbDataAdapter(consultaTemp, RutaDB_STOCK)
            daTemp.Fill(dtTemp)

            ' Asignar los datos al DataGridView
            grilla.DataSource = dtTemp
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub
    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        DGV1.DataSource = Nothing
        DGV1.Rows.Clear()
    End Sub
End Class