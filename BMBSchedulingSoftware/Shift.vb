Public Class Shift

    Public Property Salary As Decimal
    Public Property AvailEmployees As SortedList(Of String, Employee)
    Public Property numAssigned As Integer
    Public Property AssignedEmployees As SortedList(Of String, Employee)

    'Default Constructor
    Public Sub New()

    End Sub

    'Sets the Salary and numAssigned fields and initializes two lists
    Public Sub New(sal As Decimal, num As Integer)
        AvailEmployees = New SortedList(Of String, Employee)
        AssignedEmployees = New SortedList(Of String, Employee)
        Salary = sal
        numAssigned = num
    End Sub

End Class
