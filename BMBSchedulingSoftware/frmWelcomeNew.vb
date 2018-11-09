Imports System.Data.OleDb
Public Class frmWelcomeNew

    Dim myDataSet As New DataSet


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim btn As DialogResult = MessageBox.Show("Do you want to close the program?", "Close program",
                                                  MessageBoxButtons.YesNo)
        If btn = DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub frmWelcome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim myConnectionStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
            Application.StartupPath & "\User_Data.accdb"
        Dim mySQL As String = "SELECT * FROM Users"
        Dim myDataAdapter As OleDbDataAdapter = New OleDbDataAdapter(mySQL, myConnectionStr)
        myDataAdapter.Fill(myDataSet, "Users")
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim found As Boolean = False
        For i As Integer = 0 To myDataSet.Tables("Users").Rows.Count - 1
            If myDataSet.Tables("Users").Rows(i)("Username").ToString = txtUsername.Text And
               myDataSet.Tables("Users").Rows(i)("Password").ToString = txtPassword.Text Then
                found = True
                Exit For
            End If
        Next
        If found Then
            Me.Close()
        Else
            MessageBox.Show("Incorrect username/password.", "Access denied.")
        End If
    End Sub

End Class