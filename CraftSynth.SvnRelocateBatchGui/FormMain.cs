using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CraftSynth.BuildingBlocks.Common;
using CraftSynth.BuildingBlocks.Logging;

namespace CraftSynth.SvnRelocateBatchGui
{
	
	public partial class FormMain : Form
	{
		private List<Item> _allItems = new List<Item>();
		private List<string> _allSvnRootUrls = new List<string>();

		public FormMain()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.btnBrowse.Text = this.folderBrowserDialog.SelectedPath;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.folderBrowserDialog.SelectedPath = "d:\\Projects";
			if (!Directory.Exists(this.folderBrowserDialog.SelectedPath))
			{
				MessageBox.Show("You must select existing folder root folder of all projects (local copies) in step 1.");
			}
			else
			{
				var allFolders = BuildingBlocks.IO.FileSystem.GetFolderPaths(this.folderBrowserDialog.SelectedPath, true);
				var allSvnFolders = allFolders.Where(f=>f.ToLower().EndsWith("\\.svn")).ToList();
				foreach (var svnFolder in allSvnFolders)
				{
					var item = new Item(this.tbSvnExePath.Text, svnFolder, this.tbNewSvnRootUrl.Text.ToNonNullString());
					this.tbAllProjects.AppendText(item.folder);
					this.tbAllProjects.AppendText(" | ");
					this.tbAllProjects.AppendText(item.svnUrl);
					this.tbAllProjects.AppendText(" ==> ");
					//this.tbAllProjects.AppendText(item.svnRootUrl);
					//this.tbAllProjects.AppendText(" | "); 
					this.tbAllProjects.AppendText(item.svnNewUrl);
					this.tbAllProjects.AppendText("\r\n");
					this._allItems.Add(item);

					if (!this._allSvnRootUrls.Contains(item.svnRootUrl))
					{
						this._allSvnRootUrls.Add(item.svnRootUrl);
						this.tbSvnRootUrlsFound.AppendText(item.svnRootUrl+"\r\n");
					}
				}
			}
		}

		private void btnReloacteAll_Click(object sender, EventArgs e)
		{
			this.tbOutput.Clear();
			if (!File.Exists(this.tbSvnExePath.Text))
			{
				MessageBox.Show("You must select existing svn.exe under step 0.");
			}
			else if (this.tbNewSvnRootUrl.Text.IsNullOrWhiteSpace())
			{
				MessageBox.Show("You must specify new svn root url under step 5.");
			}
			else
			{

				this._allItems.ForEach(item => item.svnExePath = this.tbSvnExePath.Text);
				this._allItems.ForEach(item => item.newSvnRootUrl = this.tbNewSvnRootUrl.Text);
			}


			var log = new CustomTraceLog("Relocating to " + this.tbNewSvnRootUrl + " ...", true, false, (traceLog, line, newLine, level, ending, forNewLine) => { this.tbOutput.AppendText(line + "\r\n"); this.tbOutput.ScrollToCaret(); });
			List<string> allAllowedProjects = this.tbAllProjects.Text.ToLower().ToLines(false, false, new List<string>());
			List<string> svnRootUrlsFound = this.tbSvnRootUrlsFound.Text.ToLower().ToLines(false, false, new List<string>());

			string batchContent = string.Empty;
			foreach (var item in this._allItems)
			{
				item.Relocate(log, allAllowedProjects, svnRootUrlsFound, ref batchContent, this.cbExecuteImmediately.Checked);
			}

			if (this.cbWriteToBatFile.Checked)
			{
				string batchFilePath = BuildingBlocks.Common.Misc.ApplicationPhysicalExeFilePathWithoutExtension + ".bat";
				using (log.LogScope("Writing to " + batchFilePath + "..."))
				{
					
					if (File.Exists(batchFilePath))
					{
						using (log.LogScope("Deleting old file ..."))
						{
							File.Delete(batchFilePath);
						}
					}
					File.WriteAllText(batchFilePath, batchContent);
				}
			}

			if (log.ToString().Contains("[Failed.]"))
			{
				log.AddLine("DONE WITH ERROR(S).");
			}
			else
			{
				log.AddLine("DONE WITH SUCCESS.");
			}
			
		}
	}

	public class Item
	{
		public string svnExePath;
		public string folder;
		public string svnUrl;

		public string svnRootUrl
		{
			get
			{
				return BuildingBlocks.UI.Web.UriHandler.GetAuthority(this.svnUrl);
			}
		}

		public string newSvnRootUrl;

		public Item(string svnExePath, string svnFolder, string newSvnRootUrl)
		{
			this.svnExePath = svnExePath;
			this.folder = Path.GetDirectoryName(svnFolder);
			this.newSvnRootUrl = newSvnRootUrl;
			var  log = new CustomTraceLog();
			int exitCode = BuildingBlocks.UI.Console.ExecuteCommand(svnExePath, "info --show-item url", 3000, this.folder,log);
			if (exitCode != 0)
			{
				MessageBox.Show(log.ToString());
			}
			else
			{
				// Files\TortoiseSVN\bin\svn.exe info --show-item url
				//2016.12.29 21:58:10(local)   Command executing...
				//2016.12.29 21:58:10(local) >> https://craftsynth.cloudapp.net:8443/svn/F4CIO
				//2016.12.29 21:58:10(local)   ExitCode: 0}
				this.svnUrl = log.ToString().Replace("\n", "|").GetSubstring(">> ", "\r");
			}

		}

		public string svnNewUrl
		{
			get
			{
				if (this.svnExePath.IsNOTNullOrWhiteSpace() && this.svnRootUrl.IsNOTNullOrWhiteSpace() && this.folder.IsNOTNullOrWhiteSpace())
				{
					return  this.svnUrl.Replace(this.svnRootUrl, this.newSvnRootUrl.ToNonNullString());
				}
				else
				{
					return "";
				}
			}
		}

		public void Relocate(CustomTraceLog log, List<string> allAlowedProjects, List<string> allowedSvnRootUrlsToRelocate, ref string batchContent, bool executeImmediately)
		{
			using (log.LogScope("Processing "+this.folder+"..."))
			{
				if (!allAlowedProjects.Exists(line => line.StartsWith(this.folder.ToLower() + " | ")))
				{
					log.AddLine("project skipped.", false);
				}
				else if (!allowedSvnRootUrlsToRelocate.Exists(url => url == this.svnRootUrl))
				{
					log.AddLine("svn root url "+this.svnRootUrl+" skipped.", false);
				}
				else
				{
					using (log.LogScope(executeImmediately? "Relocating ":"Adding script for " + this.svnUrl + " ==> "+this.svnNewUrl+" ..."))
					{
						if (executeImmediately)
						{
							int exitCode = BuildingBlocks.UI.Console.ExecuteCommand(svnExePath, "relocate " + this.svnNewUrl, 10000, this.folder, log);
							if (exitCode != 0)
							{
								log.AddLine("[Failed.]");
							}
						}

						batchContent += "\r\nCD \"" + this.folder + "\"";
						batchContent += "\r\n\"" + this.svnExePath + "\" relocate "+this.svnNewUrl;
						batchContent += "\r\n";
					}
				}
			}
		}
	}

}
