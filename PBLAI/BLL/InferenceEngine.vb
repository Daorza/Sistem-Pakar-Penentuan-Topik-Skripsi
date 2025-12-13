Imports System.Data

Public Class InferenceEngine
    ''' <summary>
    ''' Calculate CF for all topics (Level 1).
    ''' Results can now be NEGATIVE (indicating the user dislikes the topic).
    ''' </summary>
    Public Function CalculateTopicCF(userId As Integer) As Dictionary(Of Integer, Double)
        Dim result As New Dictionary(Of Integer, Double)

        Try
            ' Get all topics defined in the system [cite: 53]
            Dim topics = TopicRepository.GetAll()

            For Each topic In topics
                ' Fetch Expert Weight and User Confidence for this topic
                ' Note: user_answers table must store the converted CF (-1.0 to 1.0) 
                ' OR you must convert scale->CF inside this loop.
                Dim query As String = "SELECT qr.cf_pakar, ua.cf_user " &
                                      "FROM question_rules qr " &
                                      "INNER JOIN user_answers ua ON qr.question_id = ua.question_id " &
                                      "INNER JOIN questions q ON q.id = ua.question_id " &
                                      "WHERE ua.user_id = @userId " &
                                      "AND qr.topic_id = @topicId " &
                                      "AND q.level = 1 " &
                                      "AND qr.is_active = 1"

                Dim params As New Dictionary(Of String, Object) From {
                    {"@userId", userId},
                    {"@topicId", topic.Id}
                }

                Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

                If dt.Rows.Count > 0 Then
                    Dim cfValues As New List(Of Double)

                    For Each row As DataRow In dt.Rows
                        Dim cfPakar As Double = CDbl(row("cf_pakar")) ' Always Positive (0.4 to 1.0)
                        Dim cfUser As Double = CDbl(row("cf_user"))   ' Can be Negative (-1.0 to 1.0)

                        ' Calculate Rule Strength
                        ' If cfUser is negative (e.g. -0.6) and Expert is 0.8:
                        ' cfHasil = -0.6 * 0.8 = -0.48 (Negative Evidence)
                        Dim cfHasil As Double = cfPakar * cfUser

                        cfValues.Add(cfHasil)
                    Next

                    ' Use the new 3-Case Sequential Combination
                    Dim combinedCF As Double = CertaintyFactorHelper.CombineMultipleCF(cfValues)
                    result.Add(topic.Id, combinedCF)
                Else
                    result.Add(topic.Id, 0.0)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Error calculating topic CF: " & ex.Message, ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Calculate CF for Methods (Qualitative vs Quantitative).
    ''' </summary>
    Public Function CalculateMetodeCF(userId As Integer) As Dictionary(Of String, Double)
        Dim result As New Dictionary(Of String, Double)

        Try
            Dim metodeList As New List(Of String) From {"KUALITATIF", "KUANTITATIF"}

            For Each metode In metodeList
                Dim query As String = "SELECT qr.cf_pakar, ua.cf_user " &
                                      "FROM question_rules qr " &
                                      "INNER JOIN user_answers ua ON qr.question_id = ua.question_id " &
                                      "WHERE ua.user_id = @userId " &
                                      "AND qr.metode = @metode " &
                                      "AND qr.is_active = 1"

                Dim params As New Dictionary(Of String, Object) From {
                    {"@userId", userId},
                    {"@metode", metode}
                }

                Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

                If dt.Rows.Count > 0 Then
                    Dim cfValues As New List(Of Double)
                    For Each row As DataRow In dt.Rows
                        Dim cfPakar As Double = CDbl(row("cf_pakar"))
                        Dim cfUser As Double = CDbl(row("cf_user"))
                        cfValues.Add(cfPakar * cfUser)
                    Next
                    result.Add(metode, CertaintyFactorHelper.CombineMultipleCF(cfValues))
                Else
                    result.Add(metode, 0.0)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Error calculating metode CF: " & ex.Message, ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Calculate CF for Recommendation (Build vs Analysis).
    ''' </summary>
    Public Function CalculateRekomendasiCF(userId As Integer) As Dictionary(Of String, Double)
        Dim result As New Dictionary(Of String, Double)

        Try
            Dim rekomendasiList As New List(Of String) From {"MEMBUAT", "ANALISIS"}

            For Each rekomendasi In rekomendasiList
                Dim query As String = "SELECT qr.cf_pakar, ua.cf_user " &
                                      "FROM question_rules qr " &
                                      "INNER JOIN user_answers ua ON qr.question_id = ua.question_id " &
                                      "WHERE ua.user_id = @userId " &
                                      "AND qr.rekomendasi = @rekomendasi " &
                                      "AND qr.is_active = 1"

                Dim params As New Dictionary(Of String, Object) From {
                    {"@userId", userId},
                    {"@rekomendasi", rekomendasi}
                }

                Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

                If dt.Rows.Count > 0 Then
                    Dim cfValues As New List(Of Double)
                    For Each row As DataRow In dt.Rows
                        Dim cfPakar As Double = CDbl(row("cf_pakar"))
                        Dim cfUser As Double = CDbl(row("cf_user"))
                        cfValues.Add(cfPakar * cfUser)
                    Next
                    result.Add(rekomendasi, CertaintyFactorHelper.CombineMultipleCF(cfValues))
                Else
                    result.Add(rekomendasi, 0.0)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Error calculating rekomendasi CF: " & ex.Message, ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' Calculate CF for Subtopics (Level 2).
    ''' </summary>
    Public Function CalculateSubtopicCF(userId As Integer, selectedTopicId As Integer) As Dictionary(Of Integer, Double)
        Dim result As New Dictionary(Of Integer, Double)

        Try
            ' Get subtopics for the winning topic (Inferensi Bertingkat) [cite: 108]
            Dim subtopics = SubtopicRepository.GetByTopicId(selectedTopicId)

            For Each subtopic In subtopics
                Dim query As String = "SELECT qr.cf_pakar, ua.cf_user " &
                                      "FROM question_rules qr " &
                                      "INNER JOIN user_answers ua ON qr.question_id = ua.question_id " &
                                      "INNER JOIN questions q ON q.id = ua.question_id " &
                                      "WHERE ua.user_id = @userId " &
                                      "AND qr.subtopic_id = @subtopicId " &
                                      "AND q.level = 2 " &
                                      "AND qr.is_active = 1"

                Dim params As New Dictionary(Of String, Object) From {
                    {"@userId", userId},
                    {"@subtopicId", subtopic.Id}
                }

                Dim dt As DataTable = DatabaseHelper.ExecuteQuery(query, params)

                If dt.Rows.Count > 0 Then
                    Dim cfValues As New List(Of Double)
                    For Each row As DataRow In dt.Rows
                        Dim cfPakar As Double = CDbl(row("cf_pakar"))
                        Dim cfUser As Double = CDbl(row("cf_user"))
                        cfValues.Add(cfPakar * cfUser)
                    Next
                    result.Add(subtopic.Id, CertaintyFactorHelper.CombineMultipleCF(cfValues))
                Else
                    result.Add(subtopic.Id, 0.0)
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Error calculating subtopic CF: " & ex.Message, ex)
        End Try

        Return result
    End Function
End Class