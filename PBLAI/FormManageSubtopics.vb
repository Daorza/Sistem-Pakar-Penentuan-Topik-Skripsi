Imports System.Windows.Forms

Public Class FormManageSubtopics
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormManageSubtopics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim list = SubtopicRepository.GetAll()
            dgvSubtopics.DataSource = Nothing
            dgvSubtopics.DataSource = list

            ' Adjust Columns
            If dgvSubtopics.Columns.Count > 0 Then
                If dgvSubtopics.Columns.Contains("Id") Then dgvSubtopics.Columns("Id").Width = 50
                If dgvSubtopics.Columns.Contains("TopicId") Then dgvSubtopics.Columns("TopicId").Visible = False
                If dgvSubtopics.Columns.Contains("IsActive") Then dgvSubtopics.Columns("IsActive").Visible = False
                If dgvSubtopics.Columns.Contains("CreatedAt") Then dgvSubtopics.Columns("CreatedAt").Visible = False
                If dgvSubtopics.Columns.Contains("UpdatedAt") Then dgvSubtopics.Columns("UpdatedAt").Visible = False

                ' Make TopicName prominent
                If dgvSubtopics.Columns.Contains("TopicNama") Then
                    dgvSubtopics.Columns("TopicNama").HeaderText = "Topik Induk"
                    dgvSubtopics.Columns("TopicNama").DisplayIndex = 1
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frm As New FormAddEditSubtopic()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvSubtopics.SelectedRows.Count > 0 Then
            Dim selectedItem As Subtopic = CType(dgvSubtopics.SelectedRows(0).DataBoundItem, Subtopic)
            Dim frm As New FormAddEditSubtopic(selectedItem.Id)
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        Else
            MessageBox.Show("Pilih subtopik yang ingin diedit!")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvSubtopics.SelectedRows.Count > 0 Then
            If MessageBox.Show("Yakin ingin menghapus subtopik ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim selectedItem As Subtopic = CType(dgvSubtopics.SelectedRows(0).DataBoundItem, Subtopic)
                    SubtopicRepository.Delete(selectedItem.Id)
                    LoadData()
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Pilih subtopik yang ingin dihapus!")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class