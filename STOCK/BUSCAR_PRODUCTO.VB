

Imports System.Data.OleDb
Public Class BUSCAR_PRODUCTO

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If DataGridView1.SelectedRows.Count > 0 Then
            'Dim selectedValue As String = DataGridView1.SelectedRows(0).Cells("codigo").Value.ToString()
            Dim selectedValue1 As String = DataGridView1.SelectedRows(0).Cells("nombre").Value.ToString()
            'Dim selectedValue2 As String = DataGridView1.SelectedRows(0).Cells("SALDO").Value.ToString()
            transferencia.RecibirDatos(selectedValue1)
        End If
    End Sub

    Private Sub Buscador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizartabla(Me.DataGridView1, "HERRAMIENTAS", "", "id")
    End Sub

    Sub Actualizartabla(ByVal grilla As DataGridView,
                    ByVal nombre_tabla As String,
                   ByVal campoSql As String,
                  ByVal C_ORDEN As String)
        Try
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim consulta As String
            consulta = "Select "
            If campoSql = "" Then
                consulta += "*"
            Else
                consulta += campoSql
            End If
            consulta += " From " & nombre_tabla & " ORDER BY " & C_ORDEN
            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            Dim SQL As String
            Dim DATO As String

            DATO = TextBox1.Text & "%"
            '                   0                  1
            SQL = "Select HERRAMIENTAS.nombre From HERRAMIENTAS
Where (((HERRAMIENTAS.nombre) Like '" & DATO & "'));"

            Dim da As New OleDbDataAdapter(SQL, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)

            For i = 0 To dt.Rows.Count - 1
                Dim dr As DataRow
                dr = dt.Rows(i)
                DataGridView1.DataSource = dt
                'ListBox1.Items.Add(dr(0) & " - " & dr(1))
                'ListBox2.Items.Add(dr(2))
                'ListBox3.Items.Add(dr(3))

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub btn_agrega_Click(sender As Object, e As EventArgs) Handles btn_agrega.Click
        Me.Close()
    End Sub

End Class