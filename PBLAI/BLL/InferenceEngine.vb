Public Class InferenceEngine
    ''' <summary>
    ''' Calculate CF for all topics based on Level 1 answers
    ''' Uses SEQUENTIAL COMBINATION standard formula
    ''' Returns Dictionary(topicId, combinedCF)
    ''' </summary>
    Public Function CalculateTopicCF(userId As Integer) As Dictionary(Of Integer, Double)
        Dim result As New Dictionary(Of Integer, Double)

        Try
            ' Get all topics
            Dim topics = TopicRepository.GetAll()

            For Each topic In topics
                ' Get all rules for this topic from Level 1 questions
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
                        Dim cfPakar As Double = CDbl(row("cf_pakar"))
                        Dim cfUser As Double = CDbl(row("cf_user"))
                        Dim cfHasil As Double = cfPakar * cfUser
                        cfValues.Add(cfHasil)
                    Next

                    ' Use Standard Sequential Combination
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
    ''' Calculate CF for metode (KUALITATIF vs KUANTITATIF)
    ''' Uses SEQUENTIAL COMBINATION standard formula
    ''' Returns Dictionary(metode, combinedCF)
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
                        Dim cfHasil As Double = cfPakar * cfUser
                        cfValues.Add(cfHasil)
                    Next

                    ' Use Sequential Combination
                    Dim combinedCF As Double = CertaintyFactorHelper.CombineMultipleCF(cfValues)
                    result.Add(metode, combinedCF)
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
    ''' Calculate CF for rekomendasi (MEMBUAT vs ANALISIS)
    ''' Uses SEQUENTIAL COMBINATION standard formula
    ''' Returns Dictionary(rekomendasi, combinedCF)
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
                        Dim cfHasil As Double = cfPakar * cfUser
                        cfValues.Add(cfHasil)
                    Next

                    ' Use Sequential Combination
                    Dim combinedCF As Double = CertaintyFactorHelper.CombineMultipleCF(cfValues)
                    result.Add(rekomendasi, combinedCF)
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
    ''' Calculate CF for subtopics based on Level 2 answers
    ''' Uses SEQUENTIAL COMBINATION standard formula
    ''' Returns Dictionary(subtopicId, combinedCF)
    ''' </summary>
    Public Function CalculateSubtopicCF(userId As Integer, selectedTopicId As Integer) As Dictionary(Of Integer, Double)
        Dim result As New Dictionary(Of Integer, Double)

        Try
            ' Get all subtopics for selected topic
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
                        Dim cfHasil As Double = cfPakar * cfUser
                        cfValues.Add(cfHasil)
                    Next

                    ' Use Sequential Combination
                    Dim combinedCF As Double = CertaintyFactorHelper.CombineMultipleCF(cfValues)
                    result.Add(subtopic.Id, combinedCF)
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
