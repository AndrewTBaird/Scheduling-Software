Public Class frmMainNew


    Public Property ObjectiveValue As Integer
    Public Property ObjectiveRating As Integer
    Public Property ObjectiveList As New List(Of Integer)
    Public Property myData As Database
    Public Property optim As Optimization

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim frm As New frmWelcomeNew
        frm.ShowDialog()

        InitializeFields()
        For i As Integer = 1 To 7
            lstShift.Items.Add(i)
        Next

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOptimize.Click
        ObjectiveList.Clear()

        myData = New Database(Integer.Parse(txtEmpCap.Text), Integer.Parse(txtShift.Text))
        optim = New Optimization(myData, getSalaryList())
        optim.SolveOptOne(ObjectiveValue, ObjectiveList)
        myData.AddEmployees()
        optim.SolveOptTwo(ObjectiveRating)

        txtEmpMonday.Text = ObjectiveList(0)
        txtEmpTuesday.Text = ObjectiveList(1)
        txtEmpWednesday.Text = ObjectiveList(2)
        txtEmpThursday.Text = ObjectiveList(3)
        txtEmpFriday.Text = ObjectiveList(4)
        txtEmpSaturday.Text = ObjectiveList(5)
        txtEmpSunday.Text = ObjectiveList(6)

        txtRating.Text = ObjectiveRating
        txtCost.Text = ObjectiveValue

        ShowOptimization()

    End Sub

    Public Sub InitializeFields()
        txtMonday.Text = "75"
        txtTuesday.Text = "75"
        txtWednesday.Text = "75"
        txtThursday.Text = "75"
        txtFriday.Text = "75"
        txtSaturday.Text = "100"
        txtSunday.Text = "100"

        txtShift.Text = "2"
        txtEmpCap.Text = "5"
    End Sub

    Public Function getSalaryList() As SortedList(Of String, Integer)
        Dim tempDailyList As New SortedList(Of String, Integer)
        Dim tempSalaryList As New SortedList(Of String, Integer)
        tempDailyList.Add("1", Integer.Parse(txtMonday.Text))
        tempDailyList.Add("2", Integer.Parse(txtTuesday.Text))
        tempDailyList.Add("3", Integer.Parse(txtWednesday.Text))
        tempDailyList.Add("4", Integer.Parse(txtThursday.Text))
        tempDailyList.Add("5", Integer.Parse(txtFriday.Text))
        tempDailyList.Add("6", Integer.Parse(txtSaturday.Text))
        tempDailyList.Add("7", Integer.Parse(txtSunday.Text))

        For i As Integer = 1 To 7
            tempDailyList.Add((i + 7).ToString, tempDailyList(i))
        Next
        'we now have a list of salaries that has a count of 14, and repeats the the 7 salaries

        For i As Integer = 1 To 7
            Dim shiftSalary = 0
            For j As Integer = 0 To Integer.Parse(txtShift.Text) - 1
                shiftSalary += tempDailyList((i + j).ToString)
            Next
            tempSalaryList.Add(i.ToString, shiftSalary)
        Next
        Return tempSalaryList
    End Function

    Private Sub lstShift_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstShift.SelectedIndexChanged
        lstEmp.Items.Clear()
        Dim shiftSelected As String = lstShift.SelectedItem
        For Each emp In optim.assignedList
            If shiftSelected = emp.AssignedShiftNum Then
                lstEmp.Items.Add(emp.EmployeeName)
            End If
        Next
    End Sub

    Private Function GetForm(txt As String) As Form
        For Each frm In Application.OpenForms
            If frm.Text = txt Then
                Return frm
            End If
        Next
        Return Nothing
    End Function

    Private Sub OpenChildForm(frm As Form)
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub ShowTeam()
        Dim frm As Form = GetForm("Team")
        If frm Is Nothing Then
            OpenChildForm(New Team)
        Else
            frm.Refresh()
            frm.BringToFront()
        End If
    End Sub

    Private Sub ShowEmployees()
        Dim frm As Form = GetForm("frmEmployees")
        If frm Is Nothing Then
            OpenChildForm(New Employees)
        Else
            frm.Refresh()
            frm.BringToFront()
        End If
    End Sub

    Private Sub ShowRating()
        Dim frm As Form = GetForm("frmRating")
        If frm Is Nothing Then
            OpenChildForm(New Rating)
        Else
            frm.Refresh()
            frm.BringToFront()
        End If
    End Sub

    Private Sub ShowDemand()
        Dim frm As Form = GetForm("frmDemand")
        If frm Is Nothing Then
            OpenChildForm(New Demand)
        Else
            frm.Refresh()
            frm.BringToFront()
        End If
    End Sub

    Private Sub ShowHelp()
        Dim frm As Form = GetForm("frmHelp")
        If frm Is Nothing Then
            OpenChildForm(New Help)
        Else
            frm.Refresh()
            frm.BringToFront()
        End If
    End Sub

    Private Sub ShowOptimization()
        Dim frm As Form = GetForm("frmOptimization")

        If frm Is Nothing Then
            frm = New frmOptimization
            frm.MdiParent = Me
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Else
            frm.Refresh()
            frm.BringToFront()
        End If

        Dim frm2 As frmOptimization = frm

        frm2.frmMain = Me
        frm2.setChartVals()

        frm.Refresh()
        frm.BringToFront()
    End Sub



    Private Sub tsbteam_Click(sender As Object, e As EventArgs) Handles tsbTeam.Click
        ShowTeam()
    End Sub

    Private Sub btnEmployees_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        ShowEmployees()
    End Sub

    Private Sub btnRating_Click(sender As Object, e As EventArgs) Handles btnRating.Click
        ShowRating()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeesToolStripMenuItem.Click
        ShowEmployees()
    End Sub

    Private Sub RatingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RatingsToolStripMenuItem.Click
        ShowRating()
    End Sub

    Private Sub DemandToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DemandToolStripMenuItem1.Click
        ShowDemand()
    End Sub

    Private Sub btnDemand_Click(sender As Object, e As EventArgs) Handles btnDemand.Click
        ShowDemand()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        ShowHelp()
    End Sub

    Private Sub OptimizationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptimizationToolStripMenuItem.Click
        If ObjectiveList.Count = 0 Then
            MessageBox.Show("Please press the optimize button before displaying optimization results.", "Error")
        Else
            ShowOptimization()
        End If

    End Sub
End Class