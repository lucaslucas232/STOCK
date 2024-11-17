Imports System.Data.OleDb


Public Class MOVIMIENTOS
    Dim obj_MOVIMIENTOS As New CLS_MOVIMIENTOS

    Public Function ObtenerProductos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT id_PRODUCTO, nombre FROM productos"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function ObtenerDepositos() As DataTable
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim sql As String = "SELECT ID_OBRA, nombre FROM OBRAS"
                Using cmd As New OleDbCommand(sql, con)
                    Dim dt As New DataTable()
                    Using da As New OleDbDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub MOVIMIENTOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim dbHelper As New DatabaseHelper()

        ' Llenar ComboBox de Productos
        Dim dtProductos As DataTable = ObtenerProductos()
        If dtProductos IsNot Nothing Then
            CMBPRODUCTO.DataSource = dtProductos
            CMBPRODUCTO.DisplayMember = "nombre"
            CMBPRODUCTO.ValueMember = "id_PRODUCTO"
        End If

        ' Llenar ComboBox de Depósitos (Origen y Destino)
        Dim dtDepositos As DataTable = ObtenerDepositos()
        If dtDepositos IsNot Nothing Then
            CMBORIGEN.DataSource = dtDepositos.Copy()
            CMBORIGEN.DisplayMember = "nombre"
            CMBORIGEN.ValueMember = "id_OBRA"

            CMBDESTINO.DataSource = dtDepositos
            CMBDESTINO.DisplayMember = "nombre"
            CMBDESTINO.ValueMember = "id_OBRA"
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim id_producto As Integer = CInt(CMBPRODUCTO.SelectedValue)
        Dim cantidad As Integer = CInt(TXTCANTIDAD.Text)
        Dim origen_ID As Integer = CInt(CMBORIGEN.SelectedValue)
        Dim destino_ID As Integer = CInt(CMBDESTINO.SelectedValue)
        If obj_MOVIMIENTOS.TransferirMercaderia(id_producto, cantidad, origen_ID, destino_ID) Then
            MessageBox.Show("Transferencia realizada con éxito.")
        Else
            MessageBox.Show("Error al realizar la transferencia.")
        End If
    End Sub

    Private Sub CMBPRODUCTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CMBPRODUCTO.SelectedIndexChanged

    End Sub
End Class