Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace Jp2Viewer
	''' <summary>
	''' Summary description for OpenUrlDialog.
	''' </summary>
	Public Class OpenUrlDialog
		Inherits System.Windows.Forms.Form
		Private label1 As System.Windows.Forms.Label
		Private txtUrl As System.Windows.Forms.TextBox
		Private WithEvents btnOK As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public ReadOnly Property Url() As String
			Get
				Return Me.txtUrl.Text
			End Get
		End Property

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not components Is Nothing Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"
		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txtUrl = New System.Windows.Forms.TextBox()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(8, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(30, 16)
			Me.label1.TabIndex = 0
			Me.label1.Text = "URL:"
			' 
			' txtUrl
			' 
			Me.txtUrl.Location = New System.Drawing.Point(40, 24)
			Me.txtUrl.Name = "txtUrl"
			Me.txtUrl.Size = New System.Drawing.Size(344, 20)
			Me.txtUrl.TabIndex = 1
            Me.txtUrl.Text = "http://www.atalasoft.com/products/Images/jp2/file9.jp2"
			' 
			' btnOK
			' 
			Me.btnOK.Location = New System.Drawing.Point(232, 56)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.TabIndex = 2
			Me.btnOK.Text = "OK"
'			Me.btnOK.Click += New System.EventHandler(Me.btnOK_Click);
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(312, 56)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "Cancel"
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
			' 
			' OpenUrlDialog
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(394, 96)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.txtUrl)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "OpenUrlDialog"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Open From URL"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
			DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Hide()
		End Sub

		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
			DialogResult = DialogResult.Cancel
			Me.Hide()
		End Sub
	End Class
End Namespace
