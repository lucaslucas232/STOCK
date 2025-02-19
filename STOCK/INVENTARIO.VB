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
                ' Crear un ListBoxItem personalizado con Nombre y almacenar ID_OBRA en Tag
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
        ActualizarTabla(DGV1)
    End Sub

    Sub ActualizarTabla(ByVal grilla As DataGridView)

        Dim da1 As OleDbDataAdapter
        Dim dt1 As DataTable
        Dim dt2 As DataTable

        Dim consulta As String
        Dim consulta2 As String

        Dim fecha1 As String
        Dim fecha2 As String
        Dim id_obra As Integer

        Try
            If ListBox1.SelectedItem Is Nothing Then
                MsgBox("Por favor, selecciona un depósito.")
                Exit Sub
            End If
            id_obra = CInt(DirectCast(ListBox1.SelectedItem, LISTBOXITEM).Tag)

            fecha1 = CDate(DateTimePicker_DESDE.Text).ToString("dd/MM/yyyy")
            fecha2 = CDate(DateTimePicker_HASTA.Text).ToString("dd/MM/yyyy")

            'consulta = "SELECT ingresos.ID_PRODUCTO, " &
            '       "IIf(IsNull(Sum(ingresos.cantidad)), 0, Sum(ingresos.cantidad)) AS TotalIngresos, " &
            '       "IIf(IsNull((SELECT Sum(EGRESOS.CANTIDAD) FROM EGRESOS WHERE EGRESOS.ID_PRODUCTO = ingresos.ID_PRODUCTO AND EGRESOS.ID_OBRA = " & id_obra & " AND EGRESOS.fecha BETWEEN #" & fecha1 & "# AND #" & fecha2 & "#)), 0, (SELECT Sum(EGRESOS.CANTIDAD) FROM EGRESOS WHERE EGRESOS.ID_PRODUCTO = ingresos.ID_PRODUCTO AND EGRESOS.ID_OBRA = " & id_obra & " AND EGRESOS.fecha BETWEEN #" & fecha1 & "# AND #" & fecha2 & "#)) AS TotalEgresos, " &
            '       "IIf(IsNull(Sum(ingresos.cantidad)), 0, Sum(ingresos.cantidad)) - IIf(IsNull((SELECT Sum(EGRESOS.CANTIDAD) FROM EGRESOS WHERE EGRESOS.ID_PRODUCTO = ingresos.ID_PRODUCTO AND EGRESOS.ID_OBRA = " & id_obra & " AND EGRESOS.fecha BETWEEN #" & fecha1 & "# AND #" & fecha2 & "#)), 0, (SELECT Sum(EGRESOS.CANTIDAD) FROM EGRESOS WHERE EGRESOS.ID_PRODUCTO = ingresos.ID_PRODUCTO AND EGRESOS.ID_OBRA = " & id_obra & " AND EGRESOS.fecha BETWEEN #" & fecha1 & "# AND #" & fecha2 & "#)) AS Saldo " &
            '       "FROM ingresos " &
            '       "WHERE ingresos.ID_OBRA = " & id_obra & " AND ingresos.fecha BETWEEN #" & fecha1 & "# AND #" & fecha2 & "# " &
            '       "GROUP BY ingresos.ID_PRODUCTO"

            consulta = "SELECT ingresos.ID_PRODUCTO, Sum(ingresos.cantidad) AS SumaDecantidad
FROM ingresos
WHERE (((ingresos.ID_OBRA)=" & id_obra & "))
GROUP BY ingresos.ID_PRODUCTO;"


            da1 = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt1 = New DataTable
            da1.Fill(dt1)

            consulta2 = "SELECT egresos.ID_PRODUCTO, Sum(egresos.cantidad) AS SumaDecantidad
FROM egresos
WHERE (((egresos.ID_OBRA)=" & id_obra & "))
GROUP BY egresos.ID_PRODUCTO;"
            da1 = New OleDbDataAdapter(consulta2, RutaDB_STOCK)
            dt2 = New DataTable
            da1.Fill(dt2)

            If dt1.Rows.Count > dt2.Rows.Count Then

                MsgBox("error...")
                Exit Sub
            Else

                For i = 0 To dt1.Rows.Count
                    Dim idpro As Integer
                    Dim total_e As Integer
                    Dim saldo As Integer

                    Dim dr As DataRow = dt1.Rows(i)
                    idpro = dr(0)
                    total_e = dr(1)

                    Dim total_s As Integer

                    Dim dr_s As DataRow = dt2.Rows(i)

                    total_s = dr_s(1)
                    saldo = total_e - total_s
                    'agrego a la temp


                    Select Case temp.id_pro, Sum(temp.Total_ingresos) As SumaDeTotal_ingresos, Sum(temp.Total_egresos) As SumaDeTotal_egresos, Sum([temp]![Total_ingresos]-[temp]![Total_egresos]) As saldo
From temp
Group By temp.id_pro;




                Next


            End If


            n = dt1.Rows.Count
            grilla.DataSource = dt1
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try

    End Sub
    Private Sub DGV1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub
End Class