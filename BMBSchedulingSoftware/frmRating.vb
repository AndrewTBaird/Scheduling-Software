Public Class Rating
    Private Sub frmRating_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.EmployeeAvailabilityTableAdapter1.Fill(Me.BmB_DataDataSet1.EmployeeAvailability)
    End Sub
End Class