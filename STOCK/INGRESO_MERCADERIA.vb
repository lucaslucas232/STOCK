Imports System.Data.OleDb
Public Class INGRESO_MERCADERIA
    Dim id As Integer
    Dim obj_INGRESOS As New CLS_INGRESOS
    Dim n As Integer
    Private Sub INGRESO_MERCADERIA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtProductos As DataTable = ObtenerProductos()
        If dtProductos IsNot Nothing Then
            cmbproducto.DataSource = dtProductos
            cmbproducto.DisplayMember = "nombre"
            cmbproducto.ValueMember = "id_PRODUCTO"
        End If
        ActualizarTabla(Me.DGV1, "INGRESOS", "", "id_ingresos")

    End Sub
    Sub ActualizarTabla(ByVal grilla As DataGridView, ByVal nombre_tabla As String,
                        ByVal campoSql As String, ByVal C_ORDEN As String)
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
            n = dt.Rows.Count

            grilla.DataSource = dt
            grilla.ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If DGV1.Columns.Contains("id_ingresos") Then
            DGV1.Columns("id_ingresos").Visible = False
        End If
        If DGV1.Columns.Contains("id_producto") Then
            DGV1.Columns("id_producto").Visible = False
        End If

    End Sub
    Private Sub BTN_AGREGAR_Click(sender As Object, e As EventArgs) Handles BTN_AGREGAR.Click
        Try
            'If ValidarDatos() Then
            If obj_INGRESOS.AgregaINGRESO(cmbproducto.Text) = True Then

                MsgBox("Registro ingresado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                'Me.LimpiarCampos()
                ActualizarTabla(Me.DGV1, "INGRESOS", "", "id")
            Else
                MsgBox("Error al ingresar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
            End If
            'End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
        End Try
        'Me.ModoInsercion()

    End Sub

    Private Sub BTN_ELIMINAR_Click(sender As Object, e As EventArgs) Handles BTN_ELIMINAR.Click
        Dim i = MsgBox("¿Desea eliminar este usuario?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Confirmación")
        If i = MsgBoxResult.Yes Then
            Try

                If obj_INGRESOS.EliminaINGRESO(id) = True Then
                    MsgBox("Registro Eliminado satisfactoriamente", MsgBoxStyle.Information, "Confirmacion")
                    'Me.LimpiarCampos()
                    ActualizarTabla(Me.DGV1, "INGRESOS", "", "id")
                    'Me.ModoInsercion()
                    'Me.LimpiarCampos()
                Else
                    MsgBox("Error al eliminar el registro, reintente la accion", MsgBoxStyle.Critical, "Error")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error de Validación de datos")
            End Try
        Else
        End If

    End Sub
    Private Sub INGRESO_MERCADERIA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        STOCK.Muestra()
    End Sub

    Private Sub DGV1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV1.CellContentClick

    End Sub
End Class