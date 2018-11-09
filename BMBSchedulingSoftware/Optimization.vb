Imports Microsoft.SolverFoundation.Common
Imports Microsoft.SolverFoundation.Services
Imports Microsoft.SolverFoundation.Solvers

'This class holds the methods and attributes required to solve the optimization 
'model for our project
Public Class Optimization
    Public Property myData As Database
    Public Property myModel As New SimplexSolver
    Public Property decisionList As New SortedList(Of String, Integer) 'these are the COLUMNS in the excel matrix
    Public Property functionList As New SortedList(Of String, Integer) 'these are the ROWS in the excel matrix(constraints)
    Public Property salaryList As New SortedList(Of String, Integer)
    Public Property assignedList As New List(Of Employee)

    'Constructor that sets the myData and salaryList fields
    Public Sub New(data As Database, shiftedSalaryList As SortedList(Of String, Integer))
        myData = data
        salaryList = shiftedSalaryList
    End Sub

    'This method solves the first optimization model for our project. It uses Solver to find how
    'many employees are required to work each shift, and minimizes this number based on daily salary input.
    Public Sub SolveOptOne(ByRef objVal As Integer, ByRef objList As List(Of Integer))
        For i = 1 To 7
            Dim dName As String = "x" & i
            decisionList.Add(dName, 0)
            myModel.AddVariable(dName, decisionList(dName))
            myModel.SetBounds(decisionList(dName), 0, Rational.PositiveInfinity)
            myModel.SetIntegrality(decisionList(dName), True)
        Next

        For i As Integer = 1 To 7
            Dim fName As String = "f" & i
            functionList.Add(fName, 0)
            myModel.AddRow(fName, functionList(fName))
            For j As Integer = 1 To 7
                Dim currCoef As Integer
                If (i - j + 7) Mod 7 < myData.ShiftLength Then
                    currCoef = 1
                Else
                    currCoef = 0
                End If
                Dim dName = "x" & j
                myModel.SetCoefficient(functionList(fName), decisionList(dName), currCoef)
            Next 'IF(MOD($B10-C$9+7,7)<$C$2,1,0)
            myModel.SetBounds(functionList(fName), myData.DemandList.Values(i - 1) / myData.Capacity, Rational.PositiveInfinity)
        Next

        Dim objKey As String = "Obj"
        functionList.Add(objKey, 0)
        myModel.AddRow(objKey, functionList(objKey))

        Dim count As Integer = 1
        For Each s In salaryList
            myModel.SetCoefficient(functionList(objKey), decisionList("x" & count), s.Value)
            count = count + 1
        Next

        myModel.AddGoal(functionList(objKey), 0, True)
        myModel.Solve(New SimplexSolverParams)

        If myModel.Result <> LinearResult.Optimal Then
            MessageBox.Show("Result is infeasible.")
        End If

        objVal = myModel.GetValue(functionList(objKey))

        For i As Integer = 1 To 7
            Dim numAssigned = myModel.GetValue(decisionList("x" & i))
            objList.Add(numAssigned)
            myData.ShiftList.Add("" & i, New Shift(salaryList.Values(i - 1), numAssigned))
        Next

        myModel.ClearGoals()
        decisionList.Clear()
        functionList.Clear()

    End Sub

    'This method uses the information obtained from the first optimization to solve the
    'second optimization. The second optimization assigns employees to work shifts based
    'on their availability and rating, and maximizes the total rating over all employees
    'over one week.
    Public Sub SolveOptTwo(ByRef finalRating As Integer)
        'Objective Function: Maximize sum of Employee Ratings over all shifts
        'Constraints: 1: Number of employees assigned to shift = Number of employees required for shift
        '             2: One Employee can be assigned to at most one shift
        '

        'we have 210 decision variables here. we set columns
        For Each e In myData.EmployeeList.Values 'iterates through 30 employees
            For Each s In myData.ShiftList 'iterates through 7 shifts per emloyee
                Dim dkey As String = e.ID & "-" & s.Key
                decisionList.Add(dkey, 0)
                myModel.AddVariable(dkey, decisionList(dkey))
                myModel.SetBounds(decisionList(dkey), 0, 1)
                myModel.SetIntegrality(decisionList(dkey), True)
            Next
        Next


        '210 decision variables again, this time we set rows
        For Each e In myData.EmployeeList.Values
            Dim fkey As String = "e" & e.ID
            functionList.Add(fkey, 0)
            myModel.AddRow(fkey, functionList(fkey))
            For Each s In myData.ShiftList
                Dim dkey As String = e.ID & "-" & s.Key
                myModel.SetCoefficient(functionList(fkey), decisionList(dkey), 1) 'sets coeffcient for decision variables
            Next
            myModel.SetBounds(functionList(fkey), 0, 1) 'this constraint allows employees to work AT MOST 1 shift
        Next

        For Each s In myData.ShiftList '7 shifts
            Dim fkey As String = "s" & s.Key
            functionList.Add(fkey, 0)
            myModel.AddRow(fkey, functionList(fkey))
            'now look at each available employee in each shift
            For Each e In s.Value.AvailEmployees.Values
                Dim dkey As String = e.ID & "-" & s.Key
                myModel.SetCoefficient(functionList(fkey), decisionList(dkey), 1)
            Next
            myModel.SetBounds(functionList(fkey), s.Value.numAssigned, s.Value.numAssigned)
        Next

        Dim okey As String = "obj"
        functionList.Add(okey, 0)
        myModel.AddRow(okey, functionList(okey))

        For Each e In myData.EmployeeList.Values '30 employees
            For Each s In e.AvailShiftList '3 shifts each
                Dim dkey As String = e.ID & "-" & s.Key
                myModel.SetCoefficient(functionList(okey), decisionList(dkey), myData.AvailList(dkey))
            Next
        Next

        myModel.AddGoal(functionList(okey), 0, False)
        myModel.Solve(New SimplexSolverParams)

        If myModel.Result <> LinearResult.Optimal Then
            MessageBox.Show("Result is infeasible.")
        End If


        finalRating = myModel.GetValue(functionList(okey))

        For Each e In myData.EmployeeList.Values
            For Each s In e.AvailShiftList
                Dim dkey As String = e.ID & "-" & s.Key
                If (myModel.GetValue(decisionList(dkey)) >= 0.0000001) Then
                    e.AssignedShiftNum = s.Key
                    assignedList.Add(e)
                End If
            Next
        Next

        myModel.ClearGoals()
        decisionList.Clear()
        functionList.Clear()

    End Sub


End Class
