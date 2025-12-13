Public Class CertaintyFactorHelper
    ''' <summary>
    ''' Convert Likert Scale (1-6) to Certainty Factor (-1.0 to +1.0).
    ''' This mapping is symmetric to allow "Disagree" to punish the score.
    ''' </summary>
    Public Shared Function ConvertSkalaToCF(skala As Integer) As Double
        Select Case skala
            Case 1 ' Sangat Tidak Setuju (Strongly Disagree) -> Strong Negative
                Return -1.0
            Case 2 ' Tidak Setuju (Disagree) -> Moderate Negative
                Return -0.6
            Case 3 ' Kurang Setuju (Slightly Disagree) -> Weak Negative
                Return -0.2
            Case 4 ' Cukup Setuju (Slightly Agree) -> Weak Positive
                Return 0.2
            Case 5 ' Setuju (Agree) -> Moderate Positive
                Return 0.6
            Case 6 ' Sangat Setuju (Strongly Agree) -> Strong Positive
                Return 1.0
            Case Else
                Return 0.0
        End Select
    End Function

    ''' <summary>
    ''' Combine two CF values using the Standard 3-Case Formula.
    ''' Handles negative values correctly to prevent mathematical errors.
    ''' </summary>
    ''' <param name="cfOld">The accumulated CF so far</param>
    ''' <param name="cfNew">The new CF to combine</param>
    Public Shared Function CombineCF(cfOld As Double, cfNew As Double) As Double
        ' Case 1: Both Positive (Accumulate Belief)
        ' Logic: Increase confidence towards +1.0
        If cfOld > 0 AndAlso cfNew > 0 Then
            Return cfOld + cfNew * (1 - cfOld)
        End If

        ' Case 2: Both Negative (Accumulate Disbelief)
        ' Logic: Increase confidence towards -1.0
        If cfOld < 0 AndAlso cfNew < 0 Then
            Return cfOld + cfNew * (1 + cfOld)
        End If

        ' Case 3: Mixed (One Positive, One Negative)
        ' Logic: They cancel each other out based on their strength
        Return (cfOld + cfNew) / (1 - Math.Min(Math.Abs(cfOld), Math.Abs(cfNew)))
    End Function

    ''' <summary>
    ''' Iteratively combine a list of CF values.
    ''' </summary>
    Public Shared Function CombineMultipleCF(cfList As List(Of Double)) As Double
        If cfList Is Nothing OrElse cfList.Count = 0 Then
            Return 0.0
        End If

        ' Start with the first value
        Dim result As Double = cfList(0)

        ' Loop through the rest and combine sequentially
        For i As Integer = 1 To cfList.Count - 1
            result = CombineCF(result, cfList(i))
        Next

        Return result
    End Function

    ''' <summary>
    ''' Convert CF to a displayable percentage string (e.g., -80%).
    ''' </summary>
    Public Shared Function CFToPercentage(cfValue As Double) As Integer
        Return CInt(Math.Round(cfValue * 100))
    End Function
End Class