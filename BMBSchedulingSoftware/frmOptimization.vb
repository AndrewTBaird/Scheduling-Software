Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmOptimization
    Public Property frmMain As frmMainNew

    Private Sub frmOptimization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart1.Series.Add("Employees")
        With Chart1.Series("Employees")
            .ChartType = SeriesChartType.Column
            .ChartArea = "ChartArea1"
        End With
        With Chart1.ChartAreas("ChartArea1")
            .AxisX.Title = "Shift Number"
            .AxisY.Title = "# Employees Assigned"
        End With
    End Sub

    Public Sub setChartVals()
        Dim mon = Integer.Parse(frmMain.txtEmpMonday.Text)
        Dim tues = Integer.Parse(frmMain.txtEmpTuesday.Text)
        Dim wed = Integer.Parse(frmMain.txtEmpWednesday.Text)
        Dim thurs = Integer.Parse(frmMain.txtEmpThursday.Text)
        Dim fri = Integer.Parse(frmMain.txtEmpFriday.Text)
        Dim sat = Integer.Parse(frmMain.txtEmpSaturday.Text)
        Dim sun = Integer.Parse(frmMain.txtEmpSunday.Text)

        Dim dp1 As New DataPoint
        Dim dp2 As New DataPoint
        Dim dp3 As New DataPoint
        Dim dp4 As New DataPoint
        Dim dp5 As New DataPoint
        Dim dp6 As New DataPoint
        Dim dp7 As New DataPoint

        dp1.SetValueXY(1, mon)
        dp2.SetValueXY(2, tues)
        dp3.SetValueXY(3, wed)
        dp4.SetValueXY(4, thurs)
        dp5.SetValueXY(5, fri)
        dp6.SetValueXY(6, sat)
        dp7.SetValueXY(7, sun)

        With Chart1.Series("Employees").Points
            .Clear()
            .Add(dp1)
            .Add(dp2)
            .Add(dp3)
            .Add(dp4)
            .Add(dp5)
            .Add(dp6)
            .Add(dp7)
        End With



    End Sub

End Class