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
            Dim da As OleDbDataAdapter 'DATAADPTER
            Dim dt As DataTable
            Dim consulta As String 'f9
            consulta = "SELECT obras.nombre
From obras"


            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True 'SOLO DE LECTURA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView)

        Dim da1 As OleDbDataAdapter 'DATAADPTER
        Dim dt1 As DataTable
        Dim consulta As String 'f9
        Dim fecha1 As String
        Dim fecha2 As String

        Try
            fecha1 = CDate(DateTimePicker_DESDE.Text).ToString("MM/dd/yyyy")
            fecha2 = CDate(DateTimePicker_HASTA.Text).ToString("MM/dd/yyyy")


            consulta = "SELECT i.ID_PRODUCTO,
p.Nombre,
SUM(i.cantidad) - IIF(SUM(e.CANTIDAD) Is NULL, 0, SUM(e.CANTIDAD)) AS SALDO 
FROM (ingresos AS i LEFT JOIN EGRESOS AS e ON i.ID_PRODUCTO = e.ID_PRODUCTO) 
INNER JOIN productos AS p ON i.ID_PRODUCTO = p.ID_PRODUCTO
WHERE i.ID_PRODUCTO = 1 AND i.Fecha BETWEEN ? AND ?
GROUP BY i.ID_PRODUCTO, p.Nombre;"

            da1 = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            da1.SelectCommand.Parameters.AddWithValue("?", fecha1)
            da1.SelectCommand.Parameters.AddWithValue("?", fecha2)
            dt1 = New DataTable
            da1.Fill(dt1)
            n = dt1.Rows.Count

            grilla.DataSource = dt1
            grilla.ReadOnly = True 'SOLO DE LECTURA
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




    Sub carga_datos()
        Try
            Dim SQL As String
            '               0                   1
            SQL = "Select OBRAS.NOMBRE, OBRAS.ID_OBRA From OBRAS order by NOMBRE"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable

            da.Fill(dt)

            ListBox1.Items.Clear()

            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow 'dr datarow
                dr = dt.Rows(i)
                ListBox1.Items.Add(dr(0) & " - " & dr(1))
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub REGISTRO_CAJERO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        carga_datos()
        'BTN_BUSCAR.Enabled = False

    End Sub

    Private Sub BTN_BUSCAR_Click(sender As Object, e As EventArgs) Handles BTN_BUSCAR.Click
        'ActualizarTabla(DGV1)

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

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ActualizarTabla(DGV1)

    End Sub


End Class