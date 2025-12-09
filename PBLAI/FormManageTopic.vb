Imports System.Windows.Forms
Imports System.Drawing
Public Class FormManageTopics
    Inherits System.Windows.Forms.Form
    Private dgvTopics As DataGridView
    Private btnAdd As Button
    Private btnEdit As Button
    Private btnDelete As Button
    Private btnClose As Button
    Private lblTitle As Label
    Public Sub New()
        SetupUI()
    End Sub
    Private Sub FormManageTopics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub
    Private Sub SetupUI()
        Me.Text = "Manage Topics"
        Me.Size = New Size(800, 500)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Title
        lblTitle = New Label()
        lblTitle.Text = "Daftar Topik"
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 20)
        ' Buttons
        btnAdd = New Button()
        btnAdd.Text = "Tambah Topik"
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
        btnClose.Location = New Point(650, 60)
        btnClose.Size = New Size(100, 35)
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddHandler btnClose.Click, AddressOf btnClose_Click
        ' DataGridView
        dgvTopics = New DataGridView()
        dgvTopics.Location = New Point(20, 110)
        dgvTopics.Size = New Size(740, 330)
        dgvTopics.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvTopics.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTopics.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvTopics.MultiSelect = False
        dgvTopics.AllowUserToAddRows = False
        dgvTopics.ReadOnly = True

        Me.Controls.Add(lblTitle)
        Me.Controls.Add(btnAdd)
        Me.Controls.Add(btnEdit)
        Me.Controls.Add(btnDelete)
        Me.Controls.Add(btnClose)
        Me.Controls.Add(dgvTopics)
    End Sub
    Private Sub LoadData()
        Try
            Dim topics = TopicRepository.GetAll()

            dgvTopics.DataSource = Nothing
            dgvTopics.DataSource = topics

            ' Hide unnecessary columns
            If dgvTopics.Columns.Count > 0 Then
                If dgvTopics.Columns.Contains("IsActive") Then dgvTopics.Columns("IsActive").Visible = False
                If dgvTopics.Columns.Contains("CreatedAt") Then dgvTopics.Columns("CreatedAt").Visible = False
                If dgvTopics.Columns.Contains("UpdatedAt") Then dgvTopics.Columns("UpdatedAt").Visible = False
                If dgvTopics.Columns.Contains("Id") Then dgvTopics.Columns("Id").Width = 50
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message)
        End Try
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Dim frm As New FormAddEditTopic()
        If frm.ShowDialog() = DialogResult.OK Then
            LoadData()
        End If
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        If dgvTopics.SelectedRows.Count > 0 Then
            Dim selectedTopic As Topic = CType(dgvTopics.SelectedRows(0).DataBoundItem, Topic)

            Dim frm As New FormAddEditTopic(selectedTopic.Id)
            If frm.ShowDialog() = DialogResult.OK Then
                LoadData()
            End If
        Else
            MessageBox.Show("Pilih topik yang ingin diedit!")
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        If dgvTopics.SelectedRows.Count > 0 Then
            If MessageBox.Show("Yakin ingin menghapus topik ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                Try
                    Dim selectedTopic As Topic = CType(dgvTopics.SelectedRows(0).DataBoundItem, Topic)
                    TopicRepository.Delete(selectedTopic.Id)
                    LoadData()
                    MessageBox.Show("Berhasil dihapus!")
                Catch ex As Exception
                    MessageBox.Show("Gagal menghapus: " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Pilih topik yang ingin dihapus!")
        End If
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class