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
    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView)
        Dim da1 As OleDbDataAdapter
        Dim dt1 As DataTable
        Dim dt2 As DataTable
        Dim dt3 As DataTable
        Dim consulta As String
        Dim consulta2 As String
        Dim consulta3 As String
        Dim id_obra As Integer
        Try
            If ListBox1.SelectedItem Is Nothing Then
                MsgBox("Por favor, selecciona un depósito.")
                Exit Sub
            End If
            id_obra = CInt(DirectCast(ListBox1.SelectedItem, LISTBOXITEM).Tag)
            consulta = "SELECT ingresos.ID_PRODUCTO, ingresos.NOMBRE, Sum(ingresos.cantidad) AS SumaDecantidad
                    FROM ingresos
                    WHERE (((ingresos.ID_OBRA)=" & id_obra & " ))
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

            If dt1.Rows.Count > 0 Or dt2.Rows.Count > 0 Then
                For i = 0 To Math.Min(dt1.Rows.Count, dt2.Rows.Count) - 1
                    Dim id_producto As Integer
                    Dim nombre_producto As String
                    Dim saldo As Integer
                    Dim total_i As Integer
                    Dim total_e As Integer

                    Dim dr_ingreso As DataRow = dt1.Rows(i)
                    id_producto = dr_ingreso("ID_PRODUCTO")
                    nombre_producto = dr_ingreso("NOMBRE")
                    total_i = dr_ingreso("SumaDecantidad")

                    If i < dt2.Rows.Count Then
                        Dim dr_egreso As DataRow = dt2.Rows(i)
                        total_e = dr_egreso("SumaDecantidad")
                    Else
                        total_e = 0
                    End If

                    saldo = total_i - total_e

                    Try
                        consulta3 = "SELECT temp.id_pro, temp.Nombre, 
                                 Sum(temp.Total_ingresos) AS Ingresos, 
                                 Sum(temp.Total_egresos) AS Egresos, 
                                 Sum(temp.Total_ingresos - temp.Total_egresos) AS Saldo
                                 FROM temp
                                 GROUP BY temp.id_pro, temp.nombre;"
                        da1 = New OleDbDataAdapter(consulta3, RutaDB_STOCK)
                        dt3 = New DataTable
                        da1.Fill(dt3)
                        grilla.DataSource = dt3
                        grilla.ReadOnly = True
                    Catch ex As OleDbException
                        MsgBox("Error al acceder a la base de datos: " & ex.Message)
                    Catch ex As Exception
                        MsgBox("Error general: " & ex.Message)
                    End Try
                Next
            Else
                MsgBox("No hay datos disponibles en las tablas de ingresos o egresos.")
            End If
            If DGV1.Columns.Contains("id_pro") Then
                DGV1.Columns("id_pro").Visible = False
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub BTN_CANCELAR_Click(sender As Object, e As EventArgs) Handles BTN_CANCELAR.Click
        DGV1.DataSource = Nothing
        DGV1.Rows.Clear()
    End Sub
End Class