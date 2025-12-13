Imports System.Windows.Forms

Public Class FormAddEditSubtopic
    Inherits Form

    Private _subtopicId As Integer

    Public Sub New(Optional subtopicId As Integer = 0)
        InitializeComponent()
        _subtopicId = subtopicId
    End Sub

    Private Sub FormAddEditSubtopic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTopics()

        If _subtopicId > 0 Then
            LoadData()
            Me.Text = "Edit Subtopik"
        Else
            Me.Text = "Tambah Subtopik Baru"
        End If
    End Sub

    Private Sub LoadTopics()
        Try
            Dim topics = TopicRepository.GetAll()
            cboTopic.DataSource = topics
            cboTopic.DisplayMember = "Nama"
            cboTopic.ValueMember = "Id"
        Catch ex As Exception
            MessageBox.Show("Gagal memuat topik: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Dim subtopic = SubtopicRepository.GetById(_subtopicId)
            If subtopic IsNot Nothing Then
                txtKode.Text = subtopic.Kode
                txtNama.Text = subtopic.Nama
                cboTopic.SelectedValue = subtopic.TopicId
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal memuat data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboTopic.SelectedValue Is Nothing Then
            MessageBox.Show("Pilih Topik Induk!")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode harus diisi!")
            Return
        End If
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama harus diisi!")
            Return
        End If

        Try
            Dim topicId As Integer = CInt(cboTopic.SelectedValue)

            If _subtopicId > 0 Then
                SubtopicRepository.Update(_subtopicId, topicId, txtKode.Text.Trim(), txtNama.Text.Trim())
            Else
                SubtopicRepository.Insert(topicId, txtKode.Text.Trim(), txtNama.Text.Trim())
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