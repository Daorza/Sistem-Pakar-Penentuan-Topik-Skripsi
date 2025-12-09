Imports System.Windows.Forms
Imports System.Drawing
Public Class FormAddEditTopic
    Inherits System.Windows.Forms.Form
    Private _topicId As Integer
    ' UI Controls
    Private txtKode As TextBox
    Private txtNama As TextBox
    Private btnSave As Button
    Private btnCancel As Button
    Public Sub New(Optional topicId As Integer = 0)
        _topicId = topicId
        SetupUI()

        If _topicId > 0 Then
            LoadTopicData()
            Me.Text = "Edit Topik"
        Else
            Me.Text = "Tambah Topik Baru"
        End If
    End Sub
    Private Sub SetupUI()
        Me.Size = New Size(450, 250)
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Dim y As Integer = 20
        ' Kode
        Dim lblKode As New Label() With {.Text = "Kode Topik:", .Location = New Point(20, y), .AutoSize = True}
        txtKode = New TextBox() With {.Location = New Point(130, y), .Size = New Size(280, 25)}
        Me.Controls.Add(lblKode)
        Me.Controls.Add(txtKode)
        y += 40
        ' Nama
        Dim lblNama As New Label() With {.Text = "Nama Topik:", .Location = New Point(20, y), .AutoSize = True}
        txtNama = New TextBox() With {.Location = New Point(130, y), .Size = New Size(280, 60), .Multiline = True}
        Me.Controls.Add(lblNama)
        Me.Controls.Add(txtNama)
        y += 80
        ' Buttons
        btnSave = New Button() With {.Text = "Simpan", .Location = New Point(130, y), .Size = New Size(100, 35), .BackColor = Color.ForestGreen, .ForeColor = Color.White}
        AddHandler btnSave.Click, AddressOf btnSave_Click

        btnCancel = New Button() With {.Text = "Batal", .Location = New Point(240, y), .Size = New Size(100, 35)}
        AddHandler btnCancel.Click, AddressOf btnCancel_Click
        Me.Controls.Add(btnSave)
        Me.Controls.Add(btnCancel)
    End Sub
    Private Sub LoadTopicData()
        Try
            Dim topic = TopicRepository.GetById(_topicId)
            If topic IsNot Nothing Then
                txtKode.Text = topic.Kode
                txtNama.Text = topic.Nama
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading topic data: " & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs)
        ' Validation
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode Topik harus diisi!")
            txtKode.Focus()
            Return
        End If
        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama Topik harus diisi!")
            txtNama.Focus()
            Return
        End If
        Try
            If _topicId > 0 Then
                ' Update
                TopicRepository.Update(_topicId, txtKode.Text.Trim(), txtNama.Text.Trim())
            Else
                ' Insert
                TopicRepository.Insert(txtKode.Text.Trim(), txtNama.Text.Trim())
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