Imports MySql.Data.MySqlClient
Public Class Form1
    Dim intentos As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Existeusuario(txtUsuario.Text, txtClave.Text)) Then
            Me.Hide()
            principal.Show()
        End If
    End Sub
    Function Existeusuario(ByVal usuario As String, ByVal clave As String) As Boolean
        Dim Conexion As New MySqlConnection
        Dim DataAdapter As New MySqlDataAdapter
        Dim DataSet As New DataSet
        Dim Sql As String
        Dim sw As Boolean = False

        Try
            Conexion.ConnectionString = "server=localhost;database=vbmysl;user id=root;password=;"
            Sql = "SELECT * FROM usuarios WHERE nom_usr='" & usuario & "' and clave='" & clave & "'"
            Conexion.Open()
            DataAdapter = New MySqlDataAdapter(Sql, Conexion)
            DataSet.Clear()
            DataAdapter.Fill(DataSet, "usuarios")
            If (DataSet.Tables("usuarios").Rows.Count() = 0) Then
                If intentos = 2 Then
                    MessageBox.Show("Su cuenta se ha bloqueado por la cantidad de intentos fallidos.", "Sistema")
                    Me.Close()
                Else
                    MessageBox.Show("Datos incorrecto", "Sistema")
                    txtUsuario.Text = ""
                    txtClave.Text = ""
                    txtUsuario.Focus()
                    intentos = intentos + 1
                End If
                sw = False
            Else
                MessageBox.Show("Bienvenido al sistema", "Sistema")
                sw = True
            End If

        Catch ex As Exception

        End Try
        Return (sw)
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtClave.PasswordChar = ""
        ElseIf CheckBox1.Checked = False Then
            txtClave.PasswordChar = "*"
        End If
    End Sub
End Class
