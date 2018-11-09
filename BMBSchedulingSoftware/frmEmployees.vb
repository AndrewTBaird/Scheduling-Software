Public Class Employees
    Private Sub frmEmployees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.EmployeesTableAdapter1.Fill(Me.BmB_DataDataSet1.Employees)
    End Sub

End Class