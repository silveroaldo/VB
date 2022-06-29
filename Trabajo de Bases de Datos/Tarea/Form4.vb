Imports System.Data.OleDb
Public Class Form4
    Dim cn As New OleDb.OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=C:\Users\Silvero\Documents\alumnos.accdb")

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub eliminar()
        Dim cmd As New OleDb.OleDbCommand("delete from alumno where cedula='" & TextBox1.Text & "'", cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        MsgBox("Registro eliminado exitosamente")
        cn.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        eliminar()
        mostrar()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Button1.PerformClick()
        End If
    End Sub
End Class