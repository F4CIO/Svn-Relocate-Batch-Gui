namespace CraftSynth.SvnRelocateBatchGui
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnBrowse = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.tbAllProjects = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSvnRootUrlsFound = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbNewSvnRootUrl = new System.Windows.Forms.TextBox();
			this.btnReloacteAll = new System.Windows.Forms.Button();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbSvnExePath = new System.Windows.Forms.TextBox();
			this.cbExecuteImmediately = new System.Windows.Forms.CheckBox();
			this.cbWriteToBatFile = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(282, 46);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(490, 23);
			this.btnBrowse.TabIndex = 0;
			this.btnBrowse.Text = "d:\\Projects";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(263, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "1. Choose root folder for all SVN projects (local copies)";
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.SelectedPath = "D:\\Projects";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(16, 78);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(756, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "2. Find all SVN projects (local copies; searches for .svn folders)";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbAllProjects
			// 
			this.tbAllProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbAllProjects.Location = new System.Drawing.Point(16, 134);
			this.tbAllProjects.Multiline = true;
			this.tbAllProjects.Name = "tbAllProjects";
			this.tbAllProjects.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbAllProjects.Size = new System.Drawing.Size(756, 101);
			this.tbAllProjects.TabIndex = 4;
			this.tbAllProjects.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(347, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "3. Exclude lines for projects that should not be modified (just delete lines)";
			// 
			// tbSvnRootUrlsFound
			// 
			this.tbSvnRootUrlsFound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbSvnRootUrlsFound.Location = new System.Drawing.Point(16, 267);
			this.tbSvnRootUrlsFound.Multiline = true;
			this.tbSvnRootUrlsFound.Name = "tbSvnRootUrlsFound";
			this.tbSvnRootUrlsFound.Size = new System.Drawing.Size(386, 67);
			this.tbSvnRootUrlsFound.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 251);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(389, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "4. Exclude lines for SVN root URLs that should not be modified (just delete URLs)" +
    "";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(405, 251);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(169, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "5. Specify new SVN server root url";
			// 
			// tbNewSvnRootUrl
			// 
			this.tbNewSvnRootUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbNewSvnRootUrl.Location = new System.Drawing.Point(408, 267);
			this.tbNewSvnRootUrl.Name = "tbNewSvnRootUrl";
			this.tbNewSvnRootUrl.Size = new System.Drawing.Size(364, 20);
			this.tbNewSvnRootUrl.TabIndex = 9;
			this.tbNewSvnRootUrl.Text = "svn.MyCompany.com:443";
			// 
			// btnReloacteAll
			// 
			this.btnReloacteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReloacteAll.Location = new System.Drawing.Point(408, 311);
			this.btnReloacteAll.Name = "btnReloacteAll";
			this.btnReloacteAll.Size = new System.Drawing.Size(364, 23);
			this.btnReloacteAll.TabIndex = 10;
			this.btnReloacteAll.Text = "7. Relocate all";
			this.btnReloacteAll.UseVisualStyleBackColor = true;
			this.btnReloacteAll.Click += new System.EventHandler(this.btnReloacteAll_Click);
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(16, 359);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbOutput.Size = new System.Drawing.Size(756, 140);
			this.tbOutput.TabIndex = 11;
			this.tbOutput.WordWrap = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(146, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "0. Specify full path to svn.exe";
			// 
			// tbSvnExePath
			// 
			this.tbSvnExePath.Location = new System.Drawing.Point(282, 12);
			this.tbSvnExePath.Name = "tbSvnExePath";
			this.tbSvnExePath.Size = new System.Drawing.Size(490, 20);
			this.tbSvnExePath.TabIndex = 13;
			this.tbSvnExePath.Text = "C:\\Program Files\\TortoiseSVN\\bin\\svn.exe";
			// 
			// cbExecuteImmediately
			// 
			this.cbExecuteImmediately.AutoSize = true;
			this.cbExecuteImmediately.Location = new System.Drawing.Point(479, 293);
			this.cbExecuteImmediately.Name = "cbExecuteImmediately";
			this.cbExecuteImmediately.Size = new System.Drawing.Size(123, 17);
			this.cbExecuteImmediately.TabIndex = 14;
			this.cbExecuteImmediately.Text = "Execute Immediately";
			this.cbExecuteImmediately.UseVisualStyleBackColor = true;
			// 
			// cbWriteToBatFile
			// 
			this.cbWriteToBatFile.AutoSize = true;
			this.cbWriteToBatFile.Checked = true;
			this.cbWriteToBatFile.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbWriteToBatFile.Location = new System.Drawing.Point(649, 293);
			this.cbWriteToBatFile.Name = "cbWriteToBatFile";
			this.cbWriteToBatFile.Size = new System.Drawing.Size(100, 17);
			this.cbWriteToBatFile.TabIndex = 15;
			this.cbWriteToBatFile.Text = "Write to .bat file";
			this.cbWriteToBatFile.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(408, 293);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "6.";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 511);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cbWriteToBatFile);
			this.Controls.Add(this.cbExecuteImmediately);
			this.Controls.Add(this.tbSvnExePath);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbOutput);
			this.Controls.Add(this.btnReloacteAll);
			this.Controls.Add(this.tbNewSvnRootUrl);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbSvnRootUrlsFound);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbAllProjects);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnBrowse);
			this.MinimumSize = new System.Drawing.Size(800, 550);
			this.Name = "FormMain";
			this.Text = "SVNRelocateBatchGui";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbAllProjects;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSvnRootUrlsFound;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbNewSvnRootUrl;
		private System.Windows.Forms.Button btnReloacteAll;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbSvnExePath;
		private System.Windows.Forms.CheckBox cbExecuteImmediately;
		private System.Windows.Forms.CheckBox cbWriteToBatFile;
		private System.Windows.Forms.Label label6;
	}
}

