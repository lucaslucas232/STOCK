Imports System.Data.OleDb

Module MODULO_STOCK
    'Public RutaDB_STOCK As String = "provider=microsoft.ace.oledb.12.0; data source=" & My.Application.Info.DirectoryPath & "\STOCK.accdb"
    Public RutaDB_STOCK As String = "provider=microsoft.ace.oledb.16.0; data source=" &
                                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\STOCK\STOCK.accdb"
    Public usuario As String = ""


    'Public usuario As String = ""
    Public Function Carga_formulario(ByVal form As Form) As Boolean
        For Each f In Application.OpenForms
            If f.Name = form.Name Then
                form.Select()
                Return False
            End If
        Next
        form.MdiParent = STOCK
        form.Show()
        Return True
    End Function



End Module
