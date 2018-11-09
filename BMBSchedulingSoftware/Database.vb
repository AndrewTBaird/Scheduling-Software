Imports System.Data.OleDb

Public Class Database
    Public Property Capacity As Integer
    Public Property ShiftLength As Integer
    Public Property EmployeeList As New SortedList(Of Integer, Employee)
    Public Property DemandList As New SortedList(Of String, Integer)
    Public Property PeriodList As New SortedList(Of String, Period)
    Public Property ShiftList As New SortedList(Of String, Shift) 'Has results from opt 1 saved here, use to populate AvailShiftList in Employee
    Public Property AvailList As New SortedList(Of String, Integer)

    'For reading data from Access Database
    Private myDataAdapter As OleDbDataAdapter
    Private myConnectionStr As String
    Private myDataSet As New DataSet
    Private mySQL As String

    'Constructor that sets Capacity and ShiftLength based on user input
    Public Sub New(cap As Integer, shifLength As Integer)
        AddDemand()
        Capacity = cap
        ShiftLength = shifLength
        AddPeriods()
    End Sub

    'Default Constructor
    Public Sub New()
        AddPeriods()
        AddDemand()
    End Sub

    'Creates a Data Adapter from the BMB_Data Access Database
    Public Sub CreateDataAdapter(table As String)
        myConnectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
            Application.StartupPath & "\BMB_Data.accdb"
        mySQL = "SELECT * FROM " & table
        myDataAdapter = New OleDbDataAdapter(mySQL, myConnectionStr)
        myDataAdapter.Fill(myDataSet, table)
    End Sub

    'Gets a value from myDataSet
    Public Function GetValue(i As Integer, table As String, colName As String) As String
        Return myDataSet.Tables(table).Rows(i)(colName)
    End Function

    'Because employee capacity is entered by the user on the form, we do not want to retrieve this from the database
    Public Sub AddPeriods()
        For i As Integer = 1 To 7
            PeriodList.Add("" & i, New Period("" & i, Capacity))
        Next
    End Sub

    'Demand is retrieved from the Database
    Public Sub AddDemand()
        CreateDataAdapter("PeriodDemand")
        For i As Integer = 0 To 6
            DemandList.Add(i + 1, GetValue(i, "PeriodDemand", "TotalDemand"))
        Next
    End Sub

    'Adds Employees and their availabilities to the lists from the DB
    Public Sub AddEmployees()
        'Initializes employees and populates EmployeeList using a DB
        CreateDataAdapter("Employees")
        For i As Integer = 0 To 29
            EmployeeList.Add(i + 1, New Employee(i + 1, GetValue(i, "Employees", "EmployeeName")))
        Next

        'Populates Employees' available shifts
        CreateDataAdapter("EmployeeAvailability")
        Dim count = 0
        For x As Integer = 1 To 30
            For j As Integer = 1 To 3
                Dim strShift As String = GetValue(count, "EmployeeAvailability", "StartingPeriods")
                Dim strRate As String = GetValue(count, "EmployeeAvailability", "Rating")
                AvailList.Add(x & "-" & strShift, strRate)
                EmployeeList(x).AvailShiftList.Add(strShift, strRate)
                ShiftList(strShift).AvailEmployees.Add(count + 1, EmployeeList(x))

                count += 1
            Next
        Next

    End Sub

End Class
