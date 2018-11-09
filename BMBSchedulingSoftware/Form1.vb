Public Class frmEmployeeScheduling
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim schedule As New Schedule(5, 2)
        Dim opt1 As New Optimization(schedule)
        opt1.SolveOptOne()

    End Sub
End Class
