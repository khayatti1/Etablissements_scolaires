Imports System.Data.OleDb
Module Module1
    Public con As OleDbConnection
    Sub connecter()
        Try
            con = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data source=|datadirectory|\academie.accdb;Persist Security Info = True")
            con.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Module
