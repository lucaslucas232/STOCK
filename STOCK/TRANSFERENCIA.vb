Imports System.Data.OleDb

Public Class transferencia
    Dim dt As New DataTable()

    Private Sub transderencia_closed(sender As Object, e As EventArgs) Handles Me.Closed
        STOCK.muestra()
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
            'If row.RowState = DataRowState.Modified Then

            Dim cantidad As Integer = Convert.ToInt32(row("Cantidad"))
                Dim saldo As Integer = Convert.ToInt32(row("saldo"))
                Dim ID As Integer = Convert.ToInt32(row("id"))
            Dim nuevoSaldo As Integer = saldo - cantidad

            Dim sql As String = "UPDATE herramientas SET nuevoSaldo = saldo WHERE ID = id "
            Using cmd As New OleDbCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Saldo", nuevoSaldo)
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.ExecuteNonQuery()
                End Using

            'End If
        Next

        MessageBox.Show("Saldo actualizado exitosamente")
        dgv1.ClearSelection()

    End Sub

    Public Sub RecibirDatos(selectedvalue1 As String)
        lbl_nombre_producto.Text = selectedvalue1
        'TXT_codigo.Text = selectedvalue
        'lbl_saldo.Text = selectedvalue2
        lbl_nombre_producto.Show()
    End Sub
    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        Dim form2 As New BUSCAR_PRODUCTO()
        form2.ShowDialog()
        TXT_CANTIDAD.Focus()
    End Sub

    Private Sub BTN_OK_Click(sender As Object, e As EventArgs) Handles BTN_OK.Click
        Dim nuevaFila As DataRow = dt.NewRow()
        nuevaFila("ID") = TXT_codigo.Text
        nuevaFila("Cantidad") = Convert.ToInt32(TXT_CANTIDAD.Text)
        nuevaFila("Nombre") = lbl_nombre_producto.Text
        nuevaFila("saldo") = lbl_saldo.Text

        dt.Rows.Add(nuevaFila)

        TXT_codigo.Clear()
        TXT_CANTIDAD.Clear()
        lbl_nombre_producto.Hide()

    End Sub


End Class
