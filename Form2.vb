Imports System.Data.OleDb
Imports System.IO
Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Materiel.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form4.Show()
        Me.Hide()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connecter()
        charger_academie()
        charger_etablissements()
    End Sub

    Private Sub charger_academie()
        Dim sql As String = "select * from Academie"
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        Dim t As New DataTable
        t.Load(rd)
        rd.Close()
        ComboBox1.DisplayMember = "NomAcademie"
        ComboBox1.ValueMember = "ID"
        ComboBox1.DataSource = t
    End Sub
    Private Sub charger_etablissements()
        Dim sql As String = "Select etablissement.ID,NAME,VILLE,TEL,RESPONSABLE,DATERECEPTION,NomAcademie from Academie inner join etablissement on Academie.ID = etablissement.NomAcademi"
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader()
        Dim t As New DataTable
        t.Load(rd)
        rd.Close()
        DataGridView2.DataSource = t
        For i As Integer = 0 To DataGridView2.Columns.Count - 1
            DataGridView2.Columns(i).Width = DataGridView2.Width \ DataGridView2.Columns.Count
        Next
    End Sub

    Function FormValid() As Boolean
        If TextBox2.Text.Trim.Equals("") Or TextBox3.Text.Trim.Equals("") Or TextBox4.Text.Trim.Equals("") Or TextBox5.Text.Trim.Equals("") Then
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
        Dim sql As String = "insert into etablissement(NAME,VILLE,TEL,RESPONSABLE,DATERECEPTION,NomAcademi) values ('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & DateTimePicker1.Value & "','" & ComboBox1.SelectedValue & "')"
        Dim cmd As New OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        charger_etablissements()
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim ligne As Integer = DataGridView2.CurrentRow.Index
            Dim indexholder As String = DataGridView2.Rows(ligne).Cells(0).Value.ToString
            Dim sql As String = "Delete from etablissement where ID = " & indexholder
            Dim cmd As New OleDbCommand(sql, con)
            cmd.ExecuteNonQuery()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            charger_etablissements()
        Catch ex As Exception
            MessageBox.Show("Auncun Eleve à Supprimer")
        End Try
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim indexholder As Integer = DataGridView2.CurrentRow.Cells(0).Value
        If FormValid() = False Then
            MessageBox.Show("FORMULAIRE INVALIDE", "ERREUR")
            Exit Sub
        End If
        Dim sql As String = "Update etablissement Set NAME = '" & TextBox2.Text & "', VILLE = '" & TextBox3.Text & "',TEL = '" & TextBox4.Text & "', RESPONSABLE = '" & TextBox5.Text & "', DATERECEPTION = '" & DateTimePicker1.Value & "', NomAcademi = '" & ComboBox1.SelectedValue & "' where ID = " & indexholder
        Dim cmd As New OleDbCommand(sql, con)
        cmd.ExecuteNonQuery()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        charger_etablissements()
    End Sub
    Public Function max(ByVal x As Integer) As Integer
        Dim sql As String = "Select count(ID) from etablissement"
        Dim cmd As New OleDbCommand(sql, con)
        x = cmd.ExecuteScalar
        Return x
    End Function
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sql As String = "Select etablissement.ID,NAME,VILLE,TEL,RESPONSABLE,DATERECEPTION,NomAcademie from Academie inner join etablissement on Academie.ID = etablissement.NomAcademi"
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader
        Try
            Dim f As New StreamWriter("etablissement.html")
            Dim code As String =
            "<html> 
        <head> 
        </head> 
        <body> 
        <H2 style='text-align:center'> BASE DE DONNEES DU ETABLISSEMENT <H2>
        <table border='1px' align='center'>
        <tr>
        <th>ID</th>
        <th>NOM ETABLISSEMENT</th>
        <th>VILLE</th>
        <th>TELEPHONE</th>
        <th>RESPONSABLE</th>
        <th>DATE DE RECEPTION</th>
        <th>NOM DU ACADEMIE</th>
        </tr>"
            f.WriteLine(code)
            Dim num As Integer
            For x As Integer = 0 To max(num) - 1
                rd.Read()
                Dim code1 As String =
            "<tr> 
        <td style='text-align:center;background-color:beige;'> " & rd(0).ToString & "</td>
        <td style='text-align:center'> " & rd(1).ToString & "</td>
        <td style='text-align:center;background-color:beige;'> " & rd(2).ToString & "</td>
        <td style='text-align:center'> " & rd(3).ToString & "</td>
        <td style='text-align:center;background-color:beige;'> " & rd(4).ToString & "</td>
        <td style='text-align:center'> " & CDate(rd(5)) & "</td>
        <td style='text-align:center;background-color:beige;'> " & rd(6).ToString & "</td>
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

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim ligne As Integer = DataGridView2.CurrentRow.Index
        Dim c As String = DataGridView2.Rows(ligne).Cells(0).Value.ToString
        Dim sql As String = "select * from etablissement where ID = " & c
        Dim cmd As New OleDbCommand(sql, con)
        Dim rd As OleDbDataReader = cmd.ExecuteReader
        rd.Read()
        TextBox2.Text = rd(1).ToString
        TextBox3.Text = rd(2).ToString
        TextBox4.Text = rd(3).ToString
        TextBox5.Text = rd(4).ToString
        ComboBox1.SelectedValue = rd(6).ToString
        DateTimePicker1.Value = CDate(rd(5))
        rd.Close()
    End Sub
End Class
