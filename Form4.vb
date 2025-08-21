Imports System.Data.OleDb
Imports System.IO
Public Class Form4
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Materiel.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connecter()
        charger_fournisseurs()
    End Sub

    Private Sub charger_fournisseurs()
        Dim sql As String = "Select * from Fournisseur"
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        Dim t As New DataTable
        t.Load(rd)
        rd.Close()
        DataGridView1.DataSource = t
        For i As Integer = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).Width = DataGridView1.Width \ DataGridView1.Columns.Count
        Next
    End Sub

    Function FormValid() As Boolean
        If TextBox1.Text.Trim.Equals("") Or TextBox2.Text.Trim.Equals("") Or TextBox3.Text.Trim.Equals("") Or TextBox4.Text.Trim.Equals("") Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If FormValid() = False Then
            MessageBox.Show("FORMULAIRE INVALIDE")
            Exit Sub
        End If
        Dim sql As String = "insert into Fournisseur (NomComplet,Telephone,Ville,NombreMateriel) values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
        Dim cmd As New OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        charger_fournisseurs()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim ligne As Integer = DataGridView1.CurrentRow.Index
            Dim indexholder As String = DataGridView1.Rows(ligne).Cells(0).Value.ToString
            Dim sql As String = "Delete from Fournisseur where Code = " & indexholder
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            charger_fournisseurs()
        Catch ex As Exception
            MessageBox.Show("Auncun Eleve à Supprimer")
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim indexholder As Integer = DataGridView1.CurrentRow.Cells(0).Value
        If FormValid() = False Then
            MessageBox.Show("FORMULAIRE INVALIDE", "ERREUR")
            Exit Sub
        End If
        Dim sql As String = "Update Fournisseur Set NomComplet = '" & TextBox1.Text & "', Telephone = '" & TextBox2.Text & "', Ville = '" & TextBox3.Text & "', NombreMateriel = '" & TextBox4.Text & "' where Code = " & indexholder
        Dim cmd As New OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        charger_fournisseurs()
    End Sub

    Public Function max(ByVal x As Integer) As Integer
        Dim sql As String = "Select count(Code) from Fournisseur"
        Dim cmd As New OleDbCommand(sql, con)
        x = cmd.ExecuteScalar
        Return x
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sql As String = "Select Code,NomComplet,Telephone,Ville,NombreMateriel as Filiére from Fournisseur"
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader
        Try
            Dim f As New StreamWriter("fournisseur.html")
            Dim code As String =
            "<html> 
        <head> 
        </head> 
        <body> 
        <H2 style='text-align:center'> BASE DE DONNEES DU FOURNISSEUR <H2>
        <table border='1px' align='center'>
        <tr>
        <th>CODE</th>
        <th>NOM COMPLET</th>
        <th>TELEPHONE</th>
        <th>VILLE</th>
        <th>NOMBRE DE MATERIEL</th>
        </tr>"
            f.WriteLine(code)
            Dim num As Integer
            For i As Integer = 0 To max(num) - 1
                rd.Read()
                Dim code1 As String =
            "<tr> 
        <td style='text-align:center;background-color:beige;'> " & rd(0).ToString & "</td>
        <td style='text-align:center'> " & rd(1).ToString & "</td>
        <td style='text-align:center;background-color:beige;'> " & rd(2).ToString & "</td>
        <td style='text-align:center'> " & rd(3).ToString & "</td>
        <td style='text-align:center;background-color:beige;'> " & rd(4) & "</td>
        </tr>"
                f.WriteLine(code1)
            Next
            rd.Close()
            Dim code2 As String =
            "</table> 
        </body> 
        </html>"
            f.WriteLine(code2)
            f.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim ligne As Integer = DataGridView1.CurrentRow.Index
        Dim c As String = DataGridView1.Rows(ligne).Cells(0).Value.ToString
        Dim sql As String = "select * from fournisseur where Code = " & c
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader
        rd.Read()
        TextBox1.Text = rd(1).ToString
        TextBox2.Text = rd(2).ToString
        TextBox3.Text = rd(3).ToString
        TextBox4.Text = rd(4).ToString
        rd.Close()
    End Sub

End Class