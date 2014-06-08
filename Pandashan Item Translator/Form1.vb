Imports System.Data
Imports System.Data.SQLite
Imports System.Threading.Thread
Public Class Form1
    Dim cons As New SQLite.SQLiteConnection
    Dim cmd As New SQLite.SQLiteCommand
    Dim sql As String
    Dim strSQL As String
    Dim dss As New DataSet
    Dim das As New SQLite.SQLiteDataAdapter

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cons.ConnectionString = "Data Source=database.db; Version=3"
        cons.Open()
    End Sub
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RecuperareIITextBox2.Select()
    End Sub
    Private Sub RecuperareIITextBox2_TextChanged(sender As Object, e As EventArgs) Handles RecuperareIITextBox2.TextChanged
        If RecuperareIITextBox2.Text.Length > 3 Then
            cmd = cons.CreateCommand
            cmd.CommandText = "SELECT * FROM items WHERE string_en like ""%" & RecuperareIITextBox2.Text & "%"""
            Dim SQLreader As SQLiteDataReader = cmd.ExecuteReader()
            ListBox1.Items.Clear()
            While SQLreader.Read()
                Sleep(3000)
                ListBox1.Items.Add(String.Format("{1}", SQLreader(0), SQLreader(1), SQLreader(2)))
            End While
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim SelectedItem = ListBox1.SelectedItem.ToString
        cmd = cons.CreateCommand
        cmd.CommandText = "SELECT * FROM items WHERE string_en = """ & SelectedItem & """"
        Dim SQLreader As SQLiteDataReader = cmd.ExecuteReader()
        While SQLreader.Read()

            RecuperareIITextBox1.Text = (String.Format("{2}", SQLreader(0), SQLreader(1), SQLreader(2)))
        End While
    End Sub

    Private Sub RecuperareIIButton1_Click(sender As Object, e As EventArgs) Handles RecuperareIIButton1.Click
        Clipboard.SetText(RecuperareIITextBox1.Text)
    End Sub
End Class
