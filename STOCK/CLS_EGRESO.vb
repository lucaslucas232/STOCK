Imports System.Data.OleDb


Public Class cls_Egreso
    Public Property Id_Producto As Integer
    Public Property id_obra As Integer
    Public Property NOMBRE As String

    Public Property Cantidad As Integer
    Public Property Razon As String
    Public Property Fecha As DateTime

    Public Function RegistrarEgreso(id_producto As Integer, nombre As String, cantidad As Integer, id_obra As Integer, razon As String, fecha As Date) As Boolean
        Try
            Using con As New OleDbConnection(RutaDB_STOCK)
                con.Open()
                Dim query As String = "INSERT INTO EGRESOS (id_producto, nombre, cantidad, id_obra, razon, fecha) 
                                   VALUES (@id_producto, @nombre, @cantidad, @id_obra, @razon, @fecha)"
                Using cmd As New OleDbCommand(query, con)
                    ' Asignación de parámetros con validación de tipos
                    cmd.Parameters.AddWithValue("@id_producto", Convert.ToInt32(id_producto))
                    cmd.Parameters.AddWithValue("@nombre", Convert.ToString(nombre))
                    cmd.Parameters.AddWithValue("@cantidad", Convert.ToInt32(cantidad))
                    cmd.Parameters.AddWithValue("@id_obra", Convert.ToInt32(id_obra))
                    cmd.Parameters.AddWithValue("@razon", Convert.ToString(razon))
                    cmd.Parameters.AddWithValue("@fecha", fecha.ToString("dd-MM-yyyy HH:mm:ss"))
                    ' Depuración de valores
                    Console.WriteLine($"id_producto={id_producto}, nombre={nombre}, cantidad={cantidad}, id_obra={id_obra}, razon={razon}, fecha={fecha}")

                    ' Ejecutar consulta
                    Dim registrosAfectados As Integer = cmd.ExecuteNonQuery()
                    Console.WriteLine($"Registros afectados: {registrosAfectados}")
                    Return registrosAfectados > 0
                End Using
            End Using
        Catch ex As Exception
            ' Depuración de errores
            Console.WriteLine("Error: " & ex.Message)
            MessageBox.Show("Error al registrar el egreso: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class