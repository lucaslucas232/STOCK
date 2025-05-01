Imports System.Data.OleDb

Public Class FILTRO_HERRAMIENTAS
    Sub carga_productos()
        Try
            Dim SQL As String
            SQL = "SELECT PRODUCTOS.NOMBRE, PRODUCTOS.ID_PRODUCTO FROM PRODUCTOS ORDER BY NOMBRE"
            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            ListBoxproductos.Items.Clear()
            For Each dr As DataRow In dt.Rows
                Dim item As New LISTBOXITEM(dr("NOMBRE").ToString(), dr("ID_PRODUCTO"))
                ListBoxProductos.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error al cargar los productos: " & ex.Message)
        End Try
    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView)
        Dim daIngresos As OleDbDataAdapter
        Dim daEgresos As OleDbDataAdapter
        Dim dtIngresos As DataTable
        Dim dtEgresos As DataTable
        Dim consultaIngresos As String
        Dim consultaEgresos As String
        Dim id_producto As Integer
        Try
            If ListBoxproductos.SelectedItem Is Nothing Then
                MsgBox("Por favor, selecciona un producto.")
                Exit Sub
            End If
            id_producto = CInt(DirectCast(ListBoxproductos.SelectedItem, LISTBOXITEM).Tag)

            consultaIngresos = "SELECT OBRAS.NOMBRE AS Obra, Sum(INGRESOS.CANTIDAD) AS TotalIngresos
            FROM INGRESOS INNER JOIN OBRAS ON INGRESOS.ID_OBRA = OBRAS.ID_OBRA
            WHERE INGRESOS.ID_PRODUCTO = " & id_producto & "
            GROUP BY OBRAS.NOMBRE"
            daIngresos = New OleDbDataAdapter(consultaIngresos, RutaDB_STOCK)
            dtIngresos = New DataTable
            daIngresos.Fill(dtIngresos)

            consultaEgresos = "SELECT OBRAS.NOMBRE AS Obra, Sum(EGRESOS.CANTIDAD) AS TotalEgresos
            FROM EGRESOS INNER JOIN OBRAS ON EGRESOS.ID_OBRA = OBRAS.ID_OBRA
            WHERE EGRESOS.ID_PRODUCTO = " & id_producto & "
            GROUP BY OBRAS.NOMBRE"
            daEgresos = New OleDbDataAdapter(consultaEgresos, RutaDB_STOCK)
            dtEgresos = New DataTable
            daEgresos.Fill(dtEgresos)

            Dim dtResultado As New DataTable
            dtResultado.Columns.Add("Obra")
            dtResultado.Columns.Add("Ingresos", GetType(Integer))
            dtResultado.Columns.Add("Egresos", GetType(Integer))
            dtResultado.Columns.Add("Saldo", GetType(Integer))

            For Each obra In dtIngresos.AsEnumerable()
                Dim nombreObra As String = obra("Obra").ToString()
                Dim totalIngresos As Integer = obra("TotalIngresos")
                Dim totalEgresos As Integer = dtEgresos.AsEnumerable().
                Where(Function(r) r("Obra").ToString() = nombreObra).
                Select(Function(r) CInt(r("TotalEgresos"))).FirstOrDefault()
                Dim saldo As Integer = totalIngresos - totalEgresos
                dtResultado.Rows.Add(nombreObra, totalIngresos, totalEgresos, saldo)
            Next

            grilla.DataSource = dtResultado
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub FILTRO_HERRAMIENTAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_productos()
    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        ActualizarTabla(DGV1)
        DGV1.Columns("INGRESOS").Visible = False
        DGV1.Columns("EGRESOS").Visible = False
        DGV1.AutoResizeColumns()
        DGV1.AutoResizeRows()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txt_nombre_producto.TextChanged
        Try
            Dim SQL As String
            Dim DATO As String
            DATO = txt_nombre_producto.Text & "%"

            SQL = "SELECT PRODUCTOS.NOMBRE, PRODUCTOS.ID_PRODUCTO FROM PRODUCTOS where productos.NOMBRE LIKE '" & DATO & "';"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            ListBoxproductos.Items.Clear()

            For Each dr As DataRow In dt.Rows
                Dim item As New LISTBOXITEM(dr("NOMBRE").ToString(), dr("ID_producto"))
                ListBoxproductos.Items.Add(item)
            Next
        Catch ex As Exception
            MsgBox("Error al filtrar los productos: " & ex.Message)
        End Try

    End Sub
    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        DGV1.DataSource = Nothing
        DGV1.Rows.Clear()
    End Sub
End Class