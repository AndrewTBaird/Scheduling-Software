'Class is completed

Public Class Employee

    Public Property ID As Integer
    Public Property EmployeeName As String
    Public Property AvailShiftList As New SortedList(Of Integer, Integer) '2nd Integer is the employee rating of the 1st Integer they are available
    Public Property AssignedShiftNum As Integer

    'Default Constructor
    Public Sub New()

    End Sub

    'Sets the ID and EmployeeName fields
    Public Sub New(ident As Integer, name As String)
        ID = ident
        EmployeeName = name
    End Sub


End Class
