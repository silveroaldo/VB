Imports System.Data.OleDb
Public Class Form5
    Dim cn As New OleDb.OleDbConnection("provider=microsoft.ace.oledb.12.0;data source=C:\Users\Silvero\Documents\alumnos.accdb")
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Sub buscar_codigo()
        Dim cmd As New OleDb.OleDbCommand("select * from alumno where cedula = '" & TextBox1.Text & "'", cn)
        Dim campo As OleDb.OleDbDataReader
        cn.Open()
        campo = cmd.ExecuteReader
        If campo.Read Then
            TextBox2.Text = campo(1)
            TextBox3.Text = campo(2)
            TextBox4.Text = campo(3)
        Else
            MsgBox("El registro no existe en la base de datos")
        End If
        cn.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        buscar_codigo()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        modificar()
    End Sub
    Sub modificar()
        Dim cmd As New OleDb.OleDbCommand("Update alumno set nombre='" & TextBox2.Text & "',profesor='" & TextBox3.Text & "',asignatura='" & TextBox4.Text & "'", cn)
        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
        'mostrar()
        MsgBox("Registro modificado satisfactoriamente")
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