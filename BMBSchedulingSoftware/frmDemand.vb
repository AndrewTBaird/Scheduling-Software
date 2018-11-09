Public Class Demand
    Private Sub frmDemand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.PeriodDemandTableAdapter1.Fill(Me.BmB_DataDataSet1.PeriodDemand)
    End Sub
End Class