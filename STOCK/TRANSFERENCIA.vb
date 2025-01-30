Imports System.Data.OleDb

Public Class transferencia
    Dim dt As New DataTable()

    Private Sub transderencia_closed(sender As Object, e As EventArgs) Handles Me.Closed
        STOCK.Muestra()
    End Sub

    Private Sub transferencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt.Columns.Add("ID")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("Cantidad")
        dt.Columns.Add("Saldo")
        'dt.Columns.Add("Deposito")
        dgv1.DataSource = dt
        dgv1.Columns("saldo").Visible = False

    End Sub
    Private Sub BTN_aceptar_Click(sender As Object, e As EventArgs) Handles BTN_ACEPTAR.Click
        Dim con As New OleDbConnection(RutaDB_STOCK)
        con.Open()

        For Each row As DataRow In dt.Rows
            Dim cantidad As Integer = Convert.ToInt32(row("Cantidad"))
            Dim saldo As Integer = Convert.ToInt32(row("saldo"))
            Dim ID As Integer = Convert.ToInt32(row("id"))
            Dim nuevoSaldo As Integer = saldo - cantidad

            Dim sql As String = "UPDATE herramientas SET saldo = @Saldo WHERE ID = @ID"
            Using cmd As New OleDbCommand(sql, con)
                cmd.Parameters.AddWithValue("@Saldo", nuevoSaldo)
                cmd.Parameters.AddWithValue("@ID", ID)
                cmd.ExecuteNonQuery()
            End Using
        Next

        MessageBox.Show("Saldo actualizado exitosamente")
        dgv1.ClearSelection()
        con.Close()
    End Sub


    Public Sub RecibirDatos(selectedvalue1 As String)
        'lbl_nombre_producto.Text = selectedvalue1
        'TXT_codigo.Text = selectedvalue
        'lbl_saldo.Text = selectedvalue2
        lbl_nombre_producto.Show()
    End Sub
    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs)
        Dim form2 As New BUSCAR_PRODUCTO()
        form2.ShowDialog()
        TXT_CANTIDAD.Focus()
    End Sub

    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click
        Dim nuevaFila As DataRow = dt.NewRow()
        'nuevaFila("ID") = TXT_codigo.Text
        nuevaFila("Cantidad") = Convert.ToInt32(TXT_CANTIDAD.Text)
        nuevaFila("Nombre") = lbl_nombre_producto.Text
        nuevaFila("saldo") = lbl_saldo.Text
        dt.Rows.Add(nuevaFila)
        'TXT_codigo.Clear()
        TXT_CANTIDAD.Clear()
        lbl_nombre_producto.Hide()
    End Sub

    Private Sub CMB_DEPOSTIOORIGEN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMB_DEPOSTIOORIGEN.SelectedIndexChanged
        Try
            Dim SQL As String
            SQL = "SELECT id_producto, nombre, tipo FROM productos WHERE tipo IN ('insumo', 'herramienta');"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)

            cmb_producto.Items.Clear()
            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow
                dr = dt.Rows(i)
                cmb_producto.Items.Add($"{dr("nombre")} ({dr("tipo")})") ' Cargar los nombres de productos y su tipo en el ComboBox
            Next

            ' Verificar si se han añadido herramientas
            Dim hasHerramientas As Boolean = dt.Select("tipo = 'insumo'").Length > 0
            If Not hasHerramientas Then
                MessageBox.Show("No se encontraron herramientas en la base de datos.")
            End If

        Catch ex As Exception
            MessageBox.Show($"Se produjo un error: {ex.Message}")
        End Try
    End Sub

    Private Sub cmb_producto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_producto.SelectedIndexChanged

    End Sub
End Class
