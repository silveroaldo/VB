Imports System.Data.OleDb
Public Class Form2
    Dim cn As New OleDb.OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=C:\Users\Silvero\Documents\alumnos.accdb")
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub mostrar()
        Dim da As New OleDb.OleDbDataAdapter("select * from alumno where cedula = '" & TextBox1.Text & "'", cn)
        Dim ds As New DataSet
        da.Fill(ds, "alumno")
        DataGridView1.DataSource = ds.Tables("alumno")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mostrar()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub
End Class