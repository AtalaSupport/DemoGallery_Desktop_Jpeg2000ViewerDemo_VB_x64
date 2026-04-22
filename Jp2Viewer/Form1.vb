Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Net
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Codec.Jpeg2000
Imports Atalasoft.Imaging.WinControls

Namespace Jp2Viewer
	''' <summary>
	''' Summary description for Form1.
	''' </summary>
	Public Class Form1
		Inherits System.Windows.Forms.Form
		Private mainMenu1 As System.Windows.Forms.MainMenu
		Private menuItem1 As System.Windows.Forms.MenuItem
		Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
		Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
		Private WithEvents menuItemFileOpen As System.Windows.Forms.MenuItem
		Private WithEvents workspaceViewer1 As Atalasoft.Imaging.WinControls.WorkspaceViewer
		Private WithEvents menuItemFileExit As System.Windows.Forms.MenuItem
		Private progressBar1 As System.Windows.Forms.ProgressBar
		Private WithEvents menuFileOpenUrl As System.Windows.Forms.MenuItem

		Private _jp2 As Jp2Decoder
		Private _numProgress As Integer = 0
		Private _cancel As Boolean = False
		Private WithEvents chkEnableProgressive As System.Windows.Forms.CheckBox
		Private WithEvents textBox1 As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents button1 As System.Windows.Forms.Button
		Private menuItem2 As System.Windows.Forms.MenuItem
		Private WithEvents menuItem3 As System.Windows.Forms.MenuItem

		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			_jp2 = New Jp2Decoder()
			InitializeComponent()

			_jp2.EnableProgressiveDecompression = True
			AddHandler _jp2.ProgressiveImage, AddressOf jp2_ProgressiveImage

			'register JP2 Decoder
			Atalasoft.Imaging.Codec.RegisteredDecoders.Decoders.Insert(0, _jp2)

			'initialize OpenFileDialog
			openFileDialog1.CheckFileExists = True
			openFileDialog1.CheckPathExists = True
			openFileDialog1.Filter = "Jpeg2000 (*.j2k; *.jpc; *.jp2; *.jpf;)|*.j2k;*.jpc;*.jp2;*.jpf;|All files (*.*)|*.*"
			openFileDialog1.FilterIndex = 1
			openFileDialog1.RestoreDirectory = True
			openFileDialog1.ShowHelp = False
			openFileDialog1.ShowReadOnly = True
			openFileDialog1.Title = "Open Image File"

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
			Me.mainMenu1 = New System.Windows.Forms.MainMenu()
			Me.menuItem1 = New System.Windows.Forms.MenuItem()
			Me.menuItemFileOpen = New System.Windows.Forms.MenuItem()
			Me.menuFileOpenUrl = New System.Windows.Forms.MenuItem()
			Me.menuItemFileExit = New System.Windows.Forms.MenuItem()
			Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
			Me.workspaceViewer1 = New Atalasoft.Imaging.WinControls.WorkspaceViewer()
			Me.progressBar1 = New System.Windows.Forms.ProgressBar()
			Me.chkEnableProgressive = New System.Windows.Forms.CheckBox()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.button1 = New System.Windows.Forms.Button()
			Me.menuItem2 = New System.Windows.Forms.MenuItem()
			Me.menuItem3 = New System.Windows.Forms.MenuItem()
			Me.SuspendLayout()
			' 
			' mainMenu1
			' 
			Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuItem1, Me.menuItem2})
			' 
			' menuItem1
			' 
			Me.menuItem1.Index = 0
			Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuItemFileOpen, Me.menuFileOpenUrl, Me.menuItemFileExit})
			Me.menuItem1.Text = "&File"
			' 
			' menuItemFileOpen
			' 
			Me.menuItemFileOpen.Index = 0
			Me.menuItemFileOpen.Text = "Open File"
'			Me.menuItemFileOpen.Click += New System.EventHandler(Me.menuItemFileOpen_Click);
			' 
			' menuFileOpenUrl
			' 
			Me.menuFileOpenUrl.Index = 1
			Me.menuFileOpenUrl.Text = "Open URL"
'			Me.menuFileOpenUrl.Click += New System.EventHandler(Me.menuFileOpenUrl_Click);
			' 
			' menuItemFileExit
			' 
			Me.menuItemFileExit.Index = 2
			Me.menuItemFileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlE
			Me.menuItemFileExit.Text = "&Exit"
'			Me.menuItemFileExit.Click += New System.EventHandler(Me.menuItemFileExit_Click);
			' 
			' workspaceViewer1
			' 
			Me.workspaceViewer1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.workspaceViewer1.Asynchronous = True
			Me.workspaceViewer1.Centered = True
			Me.workspaceViewer1.DisplayProfile = Nothing
			Me.workspaceViewer1.ForeColor = System.Drawing.Color.Transparent
			Me.workspaceViewer1.Location = New System.Drawing.Point(0, 0)
			Me.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White
			Me.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
			Me.workspaceViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
			Me.workspaceViewer1.Name = "workspaceViewer1"
			Me.workspaceViewer1.OutputProfile = Nothing
			Me.workspaceViewer1.Selection = Nothing
			Me.workspaceViewer1.Size = New System.Drawing.Size(528, 360)
			Me.workspaceViewer1.TabIndex = 0
			Me.workspaceViewer1.Text = "workspaceViewer1"
			Me.workspaceViewer1.ZoomRectangle = Nothing
'			Me.workspaceViewer1.Progress += New Atalasoft.Imaging.ProgressEventHandler(Me.workspaceViewer1_Progress);
'			Me.workspaceViewer1.ProcessError += New Atalasoft.Imaging.ExceptionEventHandler(Me.workspaceViewer1_ProcessError);
			' 
			' progressBar1
			' 
			Me.progressBar1.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.progressBar1.Location = New System.Drawing.Point(8, 360)
			Me.progressBar1.Name = "progressBar1"
			Me.progressBar1.Size = New System.Drawing.Size(512, 16)
			Me.progressBar1.TabIndex = 1
			' 
			' chkEnableProgressive
			' 
			Me.chkEnableProgressive.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.chkEnableProgressive.Checked = True
			Me.chkEnableProgressive.CheckState = System.Windows.Forms.CheckState.Checked
			Me.chkEnableProgressive.Location = New System.Drawing.Point(8, 384)
			Me.chkEnableProgressive.Name = "chkEnableProgressive"
			Me.chkEnableProgressive.Size = New System.Drawing.Size(168, 24)
			Me.chkEnableProgressive.TabIndex = 2
			Me.chkEnableProgressive.Text = "Enable Progressive Decode"
'			Me.chkEnableProgressive.CheckedChanged += New System.EventHandler(Me.chkEnableProgressive_CheckedChanged);
			' 
			' textBox1
			' 
			Me.textBox1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.textBox1.Location = New System.Drawing.Point(320, 384)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(32, 20)
			Me.textBox1.TabIndex = 3
			Me.textBox1.Text = "16"
'			Me.textBox1.TextChanged += New System.EventHandler(Me.textBox1_TextChanged);
			' 
			' label1
			' 
			Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(216, 384)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(99, 16)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Progressive Steps:"
			' 
			' button1
			' 
			Me.button1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.button1.Location = New System.Drawing.Point(448, 376)
			Me.button1.Name = "button1"
			Me.button1.TabIndex = 5
			Me.button1.Text = "Cancel"
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' menuItem2
			' 
			Me.menuItem2.Index = 1
			Me.menuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() { Me.menuItem3})
			Me.menuItem2.Text = "&Help"
			' 
			' menuItem3
			' 
			Me.menuItem3.Index = 0
			Me.menuItem3.Text = "About ..."
'			Me.menuItem3.Click += New System.EventHandler(Me.menuItem3_Click);
			' 
			' Form1
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(528, 417)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.chkEnableProgressive)
			Me.Controls.Add(Me.progressBar1)
			Me.Controls.Add(Me.workspaceViewer1)
			Me.Menu = Me.mainMenu1
			Me.Name = "Form1"
			Me.Text = "JP2 Viewer"
			Me.ResumeLayout(False)

		End Sub
		#End Region

		<STAThread> _
		Shared Sub Main(ByVal args As String())
			Application.Run(New Form1())
		End Sub

		Private Sub workspaceViewer1_ProcessError(ByVal sender As Object, ByVal e As ExceptionEventArgs) Handles workspaceViewer1.ProcessError
			MessageBox.Show(Me, e.ToString())
		End Sub

		Private Sub workspaceViewer1_Progress(ByVal sender As Object, ByVal e As Atalasoft.Imaging.ProgressEventArgs) Handles workspaceViewer1.Progress
			If e.Total = 0 Then
				e.Total = 1
			End If
			Dim progV As Integer = e.Current * 100 / e.Total
			If progV > 100 Then
				progV = 100
			End If
			progressBar1.Value = progV
			progressBar1.Refresh()
			If _cancel Then
				e.Cancel = True
			End If
		End Sub

        Private Sub RefreshViewer()
            workspaceViewer1.Refresh()
        End Sub

        Public Delegate Sub InvokeDelegate()

        Private Sub jp2_ProgressiveImage(ByVal sender As Object, ByVal e As ProgressiveImageEventArgs)
            workspaceViewer1.Image = e.Image
            workspaceViewer1.BeginInvoke(New InvokeDelegate(AddressOf RefreshViewer))
            _numProgress += 1
            If _cancel Then
                e.Cancel = True
            End If
        End Sub

		Private Sub menuFileOpenUrl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFileOpenUrl.Click
			Dim openUrl As OpenUrlDialog = New OpenUrlDialog()
			If openUrl.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
				_numProgress = 0
				_cancel = False
				' network stream
				Dim request As HttpWebRequest = CType(HttpWebRequest.Create(openUrl.Url), HttpWebRequest)
				Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
				Dim stream As Stream = response.GetResponseStream()

				Dim progress As ProgressEventHandler = New ProgressEventHandler(AddressOf workspaceViewer1_Progress)
				workspaceViewer1.Image = _jp2.Read(stream, progress)

			End If
		End Sub

		Private Sub chkEnableProgressive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEnableProgressive.CheckedChanged
			_jp2.EnableProgressiveDecompression = chkEnableProgressive.Checked
		End Sub

		Private Sub menuItemFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFileOpen.Click
			If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				_numProgress = 0
				_cancel = False
				workspaceViewer1.Open(openFileDialog1.FileName)
			End If
		End Sub

		Private Sub menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemFileExit.Click
			Application.Exit()
		End Sub

		Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles textBox1.TextChanged
			Try
				_jp2.ProgressiveDecodeSteps = Integer.Parse(textBox1.Text)
			Catch e1 As Exception
			End Try
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
			_cancel = True
		End Sub

		Private Sub menuItem3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItem3.Click
			Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft DotImage Jp2 Viewer Demo", "DotImage Jp2 Viewer Demo")
			aboutBox.Description = "This simple demo shows how to open and view JPEG2000 image files, and demonstrates some of the functionality in the professional version of JPEG2000 such as progressive loading and display."
			aboutBox.ShowDialog()

		End Sub
	End Class
End Namespace
