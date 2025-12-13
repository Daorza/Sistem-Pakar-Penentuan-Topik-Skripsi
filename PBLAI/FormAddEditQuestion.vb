Imports System.Drawing
Imports System.Linq.Expressions
Imports System.Windows.Forms

Public Class FormAddEditQuestion
    Private _questionId As Integer
    Private _currentRule As QuestionRule

    ' Data Lists
    Private listTopics As List(Of Topic)
    Private listSubtopics As List(Of Subtopic)

    Public Sub New(Optional questionId As Integer = 0)
        ' Required by Windows Form Designer
        InitializeComponent()

        _questionId = questionId
        LoadMasterData()

        If _questionId > 0 Then
            LoadQuestionData()
            Me.Text = "Edit Pertanyaan"
        Else
            Me.Text = "Tambah Pertanyaan Baru"
            ' Default settings
            cboLevel.SelectedIndex = 0 ' Level 1
            cboKategori.SelectedIndex = 0 ' TOPIK
            txtCFPakar.Text = "0.8"
        End If
    End Sub

    Private Sub LoadMasterData()
        Try
            listTopics = TopicRepository.GetAll()
            cboTargetTopic.DisplayMember = "Nama"
            cboTargetTopic.ValueMember = "Id"
            cboTargetTopic.DataSource = listTopics

            listSubtopics = SubtopicRepository.GetAll()
            ' Add topic name to subtopic display for clarity
            Dim displayList = listSubtopics.Select(Function(s) New With {.Id = s.Id, .DisplayName = s.TopicNama & " - " & s.Nama}).ToList()
            cboTargetSubtopic.DisplayMember = "DisplayName"
            cboTargetSubtopic.ValueMember = "Id"
            cboTargetSubtopic.DataSource = displayList

        Catch ex As Exception
            MessageBox.Show("Error loading master data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadQuestionData()
        Try
            Dim q = QuestionRepository.GetById(_questionId)
            If q Is Nothing Then Return

            txtPertanyaan.Text = q.Pertanyaan
            cboLevel.SelectedItem = q.Level.ToString()
            cboKategori.SelectedItem = q.Kategori

            ' Load Rule
            Dim rule = QuestionRepository.GetRuleByQuestionId(_questionId)
            If rule IsNot Nothing Then
                txtCFPakar.Text = rule.CfPakar.ToString("F2")
                _currentRule = rule
                UpdateUIState()

                ' Set selected target
                If q.Kategori = "TOPIK" AndAlso rule.TopicId.HasValue Then
                    cboTargetTopic.SelectedValue = rule.TopicId.Value
                ElseIf q.Kategori = "SUBTOPIK" AndAlso rule.SubtopicId.HasValue Then
                    cboTargetSubtopic.SelectedValue = rule.SubtopicId.Value
                ElseIf q.Kategori = "METODE" Then
                    cboTargetMetode.SelectedItem = rule.Metode
                ElseIf q.Kategori = "REKOMENDASI" Then
                    cboTargetRekomendasi.SelectedItem = rule.Rekomendasi
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading question data: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateUIState()
        cboTargetTopic.Visible = False
        cboTargetSubtopic.Visible = False
        cboTargetMetode.Visible = False
        cboTargetRekomendasi.Visible = False
        lblTarget.Text = "Target Rule:"

        Dim kat = If(cboKategori.SelectedItem, "").ToString()
        Select Case kat
            Case "TOPIK"
                cboTargetTopic.Visible = True
                lblTarget.Text = "Target Topik:"
                ' Position all combos at same location (optional if done in designer)
                cboTargetTopic.BringToFront()
            Case "SUBTOPIK"
                cboTargetSubtopic.Visible = True
                lblTarget.Text = "Target Subtopik:"
                cboTargetSubtopic.BringToFront()
            Case "METODE"
                cboTargetMetode.Visible = True
                lblTarget.Text = "Target Metode:"
                cboTargetMetode.BringToFront()
            Case "REKOMENDASI"
                cboTargetRekomendasi.Visible = True
                lblTarget.Text = "Target Rekomendasi:"
                cboTargetRekomendasi.BringToFront()
        End Select
    End Sub

    Private Sub cboKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboKategori.SelectedIndexChanged
        UpdateUIState()
    End Sub

    Private Sub cboLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLevel.SelectedIndexChanged
        ' Auto-set category based on level (suggestion)
        If cboLevel.SelectedItem IsNot Nothing Then
            If cboLevel.SelectedItem.ToString() = "2" Then
                cboKategori.SelectedItem = "SUBTOPIK"
            ElseIf cboKategori.SelectedItem = "SUBTOPIK" Then
                cboKategori.SelectedIndex = 0 ' Back to Topik
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Validation
        If String.IsNullOrWhiteSpace(txtPertanyaan.Text) Then
            MessageBox.Show("Pertanyaan harus diisi!")
            Return
        End If

        Dim cf As Double
        If Not Double.TryParse(txtCFPakar.Text, cf) OrElse cf < 0 OrElse cf > 1 Then
            MessageBox.Show("CF Pakar harus angka antara 0.0 - 1.0")
            Return
        End If

        Try
            Dim q As New Question With {
                .Id = _questionId,
                .Pertanyaan = txtPertanyaan.Text.Trim(),
                .Level = CInt(cboLevel.SelectedItem),
                .Kategori = cboKategori.SelectedItem.ToString()
            }

            Dim r As New QuestionRule With {
                .CfPakar = cf
            }

            ' Set Rule Target
            If q.Kategori = "TOPIK" Then
                If cboTargetTopic.SelectedValue Is Nothing Then Throw New Exception("Pilih Topik!")
                r.TopicId = CInt(cboTargetTopic.SelectedValue)
            ElseIf q.Kategori = "SUBTOPIK" Then
                If cboTargetSubtopic.SelectedValue Is Nothing Then Throw New Exception("Pilih Subtopik!")
                r.SubtopicId = CInt(cboTargetSubtopic.SelectedValue)
            ElseIf q.Kategori = "METODE" Then
                If cboTargetMetode.SelectedItem Is Nothing Then Throw New Exception("Pilih Metode!")
                r.Metode = cboTargetMetode.SelectedItem.ToString()
            ElseIf q.Kategori = "REKOMENDASI" Then
                If cboTargetRekomendasi.SelectedItem Is Nothing Then Throw New Exception("Pilih Rekomendasi!")
                r.Rekomendasi = cboTargetRekomendasi.SelectedItem.ToString()
            End If

            ' Save
            If _questionId > 0 Then
                QuestionRepository.UpdateWithRule(q, r)
            Else
                QuestionRepository.InsertWithRule(q, r)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class