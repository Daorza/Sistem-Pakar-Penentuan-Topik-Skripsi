Imports System.Windows.Forms
Imports System.Drawing
Public Class FormAddEditQuestion
    Inherits System.Windows.Forms.Form
    Private _questionId As Integer
    Private _currentRule As QuestionRule
    ' UI Controls
    Private txtPertanyaan As TextBox
    Private cboLevel As ComboBox
    Private cboKategori As ComboBox
    Private txtCFPakar As TextBox
    Private lblTarget As Label
    Private cboTargetTopic As ComboBox
    Private cboTargetSubtopic As ComboBox
    Private cboTargetMetode As ComboBox
    Private cboTargetRekomendasi As ComboBox

    Private btnSave As Button
    Private btnCancel As Button

    ' Data Lists
    Private listTopics As List(Of Topic)
    Private listSubtopics As List(Of Subtopic)
    Public Sub New(Optional questionId As Integer = 0)
        _questionId = questionId
        SetupUI()
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
    Private Sub SetupUI()
        Me.Size = New Size(600, 500)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Dim y As Integer = 20
        Dim labelWidth As Integer = 120
        Dim controlWidth As Integer = 400
        ' Pertanyaan
        Dim lblP As New Label() With {.Text = "Pertanyaan:", .Location = New Point(20, y), .AutoSize = True}
        txtPertanyaan = New TextBox() With {.Location = New Point(140, y), .Size = New Size(controlWidth, 60), .Multiline = True}
        Me.Controls.Add(lblP)
        Me.Controls.Add(txtPertanyaan)
        y += 70
        ' Level
        Dim lblL As New Label() With {.Text = "Level:", .Location = New Point(20, y), .AutoSize = True}
        cboLevel = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(100, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cboLevel.Items.AddRange(New Object() {"1", "2"})
        AddHandler cboLevel.SelectedIndexChanged, AddressOf cboLevel_SelectedIndexChanged
        Me.Controls.Add(lblL)
        Me.Controls.Add(cboLevel)
        y += 40
        ' Kategori
        Dim lblK As New Label() With {.Text = "Kategori:", .Location = New Point(20, y), .AutoSize = True}
        cboKategori = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(200, 25), .DropDownStyle = ComboBoxStyle.DropDownList}
        cboKategori.Items.AddRange(New Object() {"TOPIK", "SUBTOPIK", "METODE", "REKOMENDASI"})
        AddHandler cboKategori.SelectedIndexChanged, AddressOf cboKategori_SelectedIndexChanged
        Me.Controls.Add(lblK)
        Me.Controls.Add(cboKategori)
        y += 40
        ' Separator
        Dim separator As New Label() With {.Text = "Konfigurasi Aturan (Rule)", .Font = New Font(Me.Font, FontStyle.Bold), .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(separator)
        y += 30
        ' Target Rule (Dynamic)
        lblTarget = New Label() With {.Text = "Target Rule:", .Location = New Point(20, y), .AutoSize = True}
        Me.Controls.Add(lblTarget)
        ' Target Controls (Overlapping, only one visible)
        cboTargetTopic = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(controlWidth, 25), .DropDownStyle = ComboBoxStyle.DropDownList, .Visible = False}
        cboTargetSubtopic = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(controlWidth, 25), .DropDownStyle = ComboBoxStyle.DropDownList, .Visible = False}
        cboTargetMetode = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(controlWidth, 25), .DropDownStyle = ComboBoxStyle.DropDownList, .Visible = False}
        cboTargetRekomendasi = New ComboBox() With {.Location = New Point(140, y), .Size = New Size(controlWidth, 25), .DropDownStyle = ComboBoxStyle.DropDownList, .Visible = False}

        cboTargetMetode.Items.AddRange(New Object() {"KUALITATIF", "KUANTITATIF"})
        cboTargetRekomendasi.Items.AddRange(New Object() {"MEMBUAT", "ANALISIS"})
        Me.Controls.Add(cboTargetTopic)
        Me.Controls.Add(cboTargetSubtopic)
        Me.Controls.Add(cboTargetMetode)
        Me.Controls.Add(cboTargetRekomendasi)
        y += 40
        ' CF Pakar
        Dim lblCF As New Label() With {.Text = "CF Pakar (0.1-1.0):", .Location = New Point(20, y), .AutoSize = True}
        txtCFPakar = New TextBox() With {.Location = New Point(140, y), .Size = New Size(100, 25)}
        Me.Controls.Add(lblCF)
        Me.Controls.Add(txtCFPakar)
        y += 60
        ' Buttons
        btnSave = New Button() With {.Text = "Simpan", .Location = New Point(140, y), .Size = New Size(100, 35), .BackColor = Color.ForestGreen, .ForeColor = Color.White}
        AddHandler btnSave.Click, AddressOf btnSave_Click

        btnCancel = New Button() With {.Text = "Batal", .Location = New Point(250, y), .Size = New Size(100, 35)}
        AddHandler btnCancel.Click, AddressOf btnCancel_Click
        Me.Controls.Add(btnSave)
        Me.Controls.Add(btnCancel)
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
            Case "SUBTOPIK"
                cboTargetSubtopic.Visible = True
                lblTarget.Text = "Target Subtopik:"
            Case "METODE"
                cboTargetMetode.Visible = True
                lblTarget.Text = "Target Metode:"
            Case "REKOMENDASI"
                cboTargetRekomendasi.Visible = True
                lblTarget.Text = "Target Rekomendasi:"
        End Select
    End Sub
    Private Sub cboKategori_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateUIState()
    End Sub
    Private Sub cboLevel_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Auto-set category based on level (suggestion)
        If cboLevel.SelectedItem.ToString() = "2" Then
            cboKategori.SelectedItem = "SUBTOPIK"
        ElseIf cboKategori.SelectedItem = "SUBTOPIK" Then
            cboKategori.SelectedIndex = 0 ' Back to Topik
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        ' Validation
        If String.IsNullOrWhiteSpace(txtPertanyaan.Text) Then
            MessageBox.Show("Pertanyaan harus diisi!")
            Return
        End If
        Dim cf As Double
        If Not Double.TryParse(txtCFPakar.Text, cf) OrElse cf < 0 OrElse cf > 1 Then
            MessageBox.Show("CF Pakar harus angka antara 0.0 - 1.0 (gunakan titik/koma sesuai setting komputer)")
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class