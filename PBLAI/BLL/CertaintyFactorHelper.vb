Public Class CertaintyFactorHelper
    ''' <summary>
    ''' Convert skala (1-6) to Certainty Factor value
    ''' </summary>
    ''' <summary>
    ''' Convert skala (1-6) to Certainty Factor value
    ''' Uses standard linear mapping for CF
    ''' </summary>
    Public Shared Function ConvertSkalaToCF(skala As Integer) As Double
        Select Case skala
            Case 1 ' Tidak / Sangat Tidak Yakin
                Return 0.0
            Case 2 ' Tidak Tahu / Tidak Yakin
                Return 0.2
            Case 3 ' Sedikit Yakin
                Return 0.4
            Case 4 ' Cukup Yakin
                Return 0.6
            Case 5 ' Yakin
                Return 0.8
            Case 6 ' Sangat Yakin / Sangat Setuju
                Return 1.0
            Case Else
                Return 0.0
        End Select
    End Function

    ''' <summary>
    ''' Combine two CF values using sequential formula
    ''' CF_combine = CF1 + CF2 * (1 - CF1)
    ''' </summary>
    Public Shared Function CombineCF(cf1 As Double, cf2 As Double) As Double
        Return cf1 + cf2 * (1 - cf1)
    End Function

    ''' <summary>
    ''' Combine multiple CF values sequentially
    ''' </summary>
    Public Shared Function CombineMultipleCF(cfList As List(Of Double)) As Double
        If cfList Is Nothing OrElse cfList.Count = 0 Then
            Return 0.0
        End If

        Dim result As Double = cfList(0)

        For i As Integer = 1 To cfList.Count - 1
            result = CombineCF(result, cfList(i))
        Next

        Return result
    End Function

    ''' <summary>
    ''' Calculate percentage from CF value
    ''' </summary>
    Public Shared Function CFToPercentage(cfValue As Double) As Integer
        Return CInt(Math.Round(cfValue * 100))
    End Function
End Class
