Public Class Period

    Public Property Name As String
    Public Property MinRequired As Integer
    Public Property WorkingEmployees As SortedList(Of String, Employee)

    'Default Constructor
    Public Sub New()

    End Sub

    'Sets the Name and MinRequired Field
    Public Sub New(pname As String, min As Integer)
        Name = pname
        MinRequired = min
    End Sub

End Class
