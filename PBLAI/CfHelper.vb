Module CfHelper
    Public Function ConvertScaleToCF(scale As Integer) As Double
        Select Case scale
            Case 1 : Return 0.0
            Case 2 : Return 0.1
            Case 3 : Return 0.3
            Case 4 : Return 0.7
            Case 5 : Return 0.9
            Case 6 : Return 1.0
            Case Else
                Return 0.0
        End Select
    End Function
End Module