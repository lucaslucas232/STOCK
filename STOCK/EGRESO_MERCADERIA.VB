Imports System.Data.OleDb
Public Class EGRESO_MERCADERIA
    Dim obj_EGRESOS As New cls_Egreso
    Dim n As Integer
    Sub CARGA_OBRAS()
        Dim sql As String
        sql = "SELECT OBRAS.[Id_OBRA], OBRAS.[NOMBRE] FROM OBRAS;"
        Dim da As New OleDbDataAdapter(sql, RutaDB_STOCK)
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            CMB_ORIGEN.DataSource = dt
            CMB_ORIGEN.DisplayMember = "NOMBRE"
            CMB_ORIGEN.ValueMember = "Id_OBRA"
        Catch
        End Try
    End Sub

    Sub CARGA_PRODUCTOS()
        Try
            Dim sql As String = "SELECT [Id_PRODUCTO], [NOMBRE] FROM PRODUCTOS"
            Dim da As New OleDbDataAdapter(sql, RutaDB_STOCK)
            Dim dt As New DataTable
            da.Fill(dt)
            cmbproducto.DataSource = dt
            cmbproducto.DisplayMember = "NOMBRE"
            cmbproducto.ValueMember = "Id_PRODUCTO"
        Catch ex As Exception
        End Try
    End Sub
    Sub ActualizarTablaEgresos(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                           ByVal campoSql As String, ByVal C_ORDEN As String)
        Try
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim consulta As String
            consulta =
            "SELECT EGRESOS.Id_EGRESOS, EGRESOS.ID_PRODUCTO, EGRESOS.NOMBRE, EGRESOS.CANTIDAD, " &
            "OBRAS.NOMBRE AS OBRA_DESTINO, EGRESOS.ID_OBRA, EGRESOS.FECHA " &
            "FROM EGRESOS " &
            "INNER JOIN OBRAS ON EGRESOS.ID_OBRA = OBRAS.ID_OBRA " &
            "ORDER BY EGRESOS.Id_EGRESOS;"

            da = New OleDbDataAdapter(consulta, RutaDB_STOCK)
            dt = New DataTable
            da.Fill(dt)
            n = dt.Rows.Count
            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error al cargar los datos")
        End Try
    End Sub
    Private Sub EGRESO_MERCADERIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CARGA_PRODUCTOS()
        CARGA_OBRAS()

        'ActualizarTablaEgresos(Me.dgv1, "egresos", "", "id_egreso")
    End Sub
    Private Function ObtenerSaldoDisponible(id_producto As Integer, id_obra As Integer) As Integer
        Dim saldoDisponible As Integer = 0
        Using con As New OleDbConnection(RutaDB_STOCK)
            con.Open()
            ' Obtener el total de ingresos
            Dim sqlIngresos As String = "SELECT SUM(cantidad) FROM Ingresos WHERE id_producto = @IDProducto AND id_obra = @IDObra"
            Using cmdIngresos As New OleDbCommand(sqlIngresos, con)
                cmdIngresos.Parameters.AddWithValue("@IDProducto", id_producto)
                cmdIngresos.Parameters.AddWithValue("@IDObra", id_obra)
                Dim totalIngresos As Object = cmdIngresos.ExecuteScalar()
                If totalIngresos IsNot DBNull.Value AndAlso totalIngresos IsNot Nothing Then
                    saldoDisponible += Convert.ToInt32(totalIngresos)
                End If
            End Using
            ' Obtener el total de egresos
            Dim sqlEgresos As String = "SELECT SUM(cantidad) FROM Egresos WHERE id_producto = @IDProducto AND id_obra = @IDObra"
            Using cmdEgresos As New OleDbCommand(sqlEgresos, con)
                cmdEgresos.Parameters.AddWithValue("@IDProducto", id_producto)
                cmdEgresos.Parameters.AddWithValue("@IDObra", id_obra)
                Dim totalEgresos As Object = cmdEgresos.ExecuteScalar()
                If totalEgresos IsNot DBNull.Value AndAlso totalEgresos IsNot Nothing Then
                    saldoDisponible -= Convert.ToInt32(totalEgresos)
                End If
            End Using
        End Using
        Return saldoDisponible
    End Function


    Private Sub BTN_REGISTRAR_EGRESO_Click(sender As Object, e As EventArgs) Handles BTN_REGISTRAR_EGRESO.Click
        'Try
        ' Validar selección de producto y obra
        If cmbproducto.SelectedIndex = -1 Or CMB_ORIGEN.SelectedIndex = -1 Then
                MessageBox.Show("Debe seleccionar un producto y una obra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

        ' Obtener datos ingresados
        Dim id_Producto As Integer = CInt(cmbproducto.SelectedValue)
        Dim id_Obra As Integer = CInt(CMB_ORIGEN.SelectedValue)
        Dim NOMBRE As String = cmbproducto.Text
        Dim cantidad As Integer
            Dim fecha As DateTime = DateTime.Now

            If Not Integer.TryParse(TXT_CANTIDAD.Text, cantidad) Or cantidad <= 0 Then
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim razon As String = TXT_RAZON.Text
            If String.IsNullOrWhiteSpace(razon) Then
                MessageBox.Show("Debe ingresar una razón para el egreso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

        ' Verificar saldo disponible
        Dim saldoDisponible As Integer = ObtenerSaldoDisponible(id_Producto, id_Obra)
        If cantidad > saldoDisponible Then
                MessageBox.Show($"Saldo insuficiente. Saldo disponible: {saldoDisponible}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        If obj_EGRESOS.RegistrarEgreso(id_producto, NOMBRE, cantidad, id_obra, razon, fecha) Then
            MessageBox.Show("Egreso registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Error al registrar el egreso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            End Sub

End Class
