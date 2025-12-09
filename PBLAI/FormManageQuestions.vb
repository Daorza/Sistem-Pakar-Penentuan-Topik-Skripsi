Imports System.Windows.Forms
Imports System.Drawing
Public Class FormManageQuestions
    Inherits System.Windows.Forms.Form
    Private dgvQuestions As DataGridView
    Private btnAdd As Button
    Private btnEdit As Button
    Private btnDelete As Button
    Private btnClose As Button
    Private lblTitle As Label
    Public Sub New()
        SetupUI()
    End Sub
    Private Sub FormManageQuestions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub SetupUI()
        Me.Text = "Manage Questions"
        Me.Size = New Size(900, 600)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Title
        lblTitle = New Label()
        lblTitle.Text = "Daftar Pertanyaan & Aturan Pakar"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 20)
        ' Buttons Panel
        btnAdd = New Button()
        btnAdd.Text = "Tambah Baru"
        btnAdd.Location = New Point(20, 60)
        btnAdd.Size = New Size(120, 35)
        btnAdd.BackColor = Color.ForestGreen
        btnAdd.ForeColor = Color.White
        AddHandler btnAdd.Click, AddressOf btnAdd_Click
        btnEdit = New Button()
        btnEdit.Text = "Edit Selected"
        btnEdit.Location = New Point(150, 60)
        btnEdit.Size = New Size(120, 35)
        btnEdit.BackColor = Color.Orange
        btnEdit.ForeColor = Color.White
        AddHandler btnEdit.Click, AddressOf btnEdit_Click
        btnDelete = New Button()
        btnDelete.Text = "Hapus Selected"
        btnDelete.Location = New Point(280, 60)
        btnDelete.Size = New Size(120, 35)
        btnDelete.BackColor = Color.Crimson
        btnDelete.ForeColor = Color.White
        AddHandler btnDelete.Click, AddressOf btnDelete_Click
        btnClose = New Button()
        btnClose.Text = "Tutup"
        btnClose.Location = New Point(750, 60)
        btnClose.Size = New Size(100, 35)
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler btnClose.Click, AddressOf btnClose_Click
        ' DataGridView
        dgvQuestions = New DataGridView()
        dgvQuestions.Location = New Point(20, 110)
        dgvQuestions.Size = New Size(840, 430)
        dgvQuestions.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvQuestions.MultiSelect = False
        dgvQuestions.AllowUserToAddRows = False
        dgvQuestions.ReadOnly = True

        Me.Controls.Add(lblTitle)
        Me.Controls.Add(btnAdd)
        Me.Controls.Add(btnEdit)
        Me.Controls.Add(btnDelete)
        Me.Controls.Add(btnClose)
        Me.Controls.Add(dgvQuestions)
    End Sub
    Private Sub LoadData()
        Try
            ' Get all questions
            Dim questions = QuestionRepository.GetAll()

            ' Setup Grid manually or bind list
            dgvQuestions.DataSource = Nothing
            dgvQuestions.DataSource = questions

            ' Rename headers safely
            If dgvQuestions.Columns.Count > 0 Then
                If dgvQuestions.Columns.Contains("IsActive") Then dgvQuestions.Columns("IsActive").Visible = False
                If dgvQuestions.Columns.Contains("CreatedAt") Then dgvQuestions.Columns("CreatedAt").Visible = False
                If dgvQuestions.Columns.Contains("UpdatedAt") Then dgvQuestions.Columns("UpdatedAt").Visible = False
                If dgvQuestions.Columns.Contains("Id") Then dgvQuestions.Columns("Id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        ' Open Add Form
        Dim frm As New FormAddEditQuestion()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If dgvQuestions.SelectedRows.Count > 0 Then
            Dim selectedQ As Question = CType(dgvQuestions.SelectedRows(0).DataBoundItem, Question)

            Dim frm As New FormAddEditQuestion(selectedQ.Id)
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        Else
            MessageBox.Show("Pilih pertanyaan yang ingin diedit!")
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvQuestions.SelectedRows.Count > 0 Then
            If MessageBox.Show("Yakin ingin menghapus pertanyaan ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim selectedQ As Question = CType(dgvQuestions.SelectedRows(0).DataBoundItem, Question)
                    QuestionRepository.Delete(selectedQ.Id)
                    LoadData()
                    MessageBox.Show("Berhasil dihapus!")
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Pilih pertanyaan yang ingin dihapus!")
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class