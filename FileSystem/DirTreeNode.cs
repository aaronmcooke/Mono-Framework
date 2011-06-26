using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoatDogGames
{
	[Serializable]
	public class DirTreeNode // TODO : Implement the FileSystemObject abstract class as base.
    {
        #region Fields

        private List<DirTreeNode> directories;
		private List<string> filePaths;
		private string dirPath;

        #endregion

        public DateTime CreatedOn;
		public DateTime LastAccessed;
		public DateTime LastWritten;

        private DataReporter runLog;
        public DataReporter RunLog
        {
            get { return runLog; }
            set
            {
                if (value != null)
                {
                    runLog = value;
                }
                else
                {
                    runLog = new DataReporter();
                }
            }
        }

		public bool HasPath
		{
			get { return dirPath.Equals(string.Empty) ? false : true; }
		}
		public bool HasDirectories
		{
			get { return directories.Count > 0 ? true : false; }
		}
		public bool HasFile
		{
			get { return filePaths.Count > 0 ? true : false; }
		}

		public List<DirTreeNode> Directories
		{
			get { return directories; }
		}
		public List<string> FilePaths
		{
			get { return filePaths; }
		}
		public string DirName
		{
			get
			{
				DirectoryInfo currentDirectory = new DirectoryInfo(dirPath);
				return currentDirectory.Name;
			}
		}
		public string Path
		{
			get { return dirPath; }
		}

		private DirTreeNode() {}
		public DirTreeNode(string dirPathPassed)
		{
			dirPath = string.Empty;
			if (dirPathPassed != null)
			{
				dirPath = dirPathPassed;
			}

			filePaths = new List<string>();
			directories = new List<DirTreeNode>();
		}

		public void SetDirectories()
		{
			if (!dirPath.Equals(@"D:\System Volume Information"))
			{
				string[] directoryPaths = new string[0];
				try
				{
					directoryPaths = Directory.GetDirectories(dirPath);
				}
				catch (Exception e)
				{
					runLog.AppendLine(e.Message);
                    runLog.AppendLine(DirName);
				}

				for (int i = 0; i < directoryPaths.Length; i++)
				{
					try
					{
						DirTreeNode newDirTreeNode = new DirTreeNode(directoryPaths[i]);
						directories.Add(newDirTreeNode);
					}
					catch (Exception e)
					{
						runLog.AppendLine(e.Message);
                        runLog.AppendLine(DirName);
					}
				}
			}
		}
		public void SetFilePaths()
		{
			if (!dirPath.Equals(@"D:\System Volume Information"))
			{
				try
				{
					string[] dirFilePaths = Directory.GetFiles(dirPath);
					for (int i = 0; i < dirFilePaths.Length; i++)
					{
						filePaths.Add(dirFilePaths[i]);
					}
				}
				catch (Exception e)
				{
					runLog.AppendLine(e.Message);
                    runLog.AppendLine(DirName);
				}
			}
		}
		public void SetAttributes()
		{
			try
			{
				CreatedOn = Directory.GetCreationTime(dirPath);
				LastWritten = Directory.GetLastWriteTime(dirPath);
				LastAccessed = Directory.GetLastAccessTime(dirPath);
			}
			catch (Exception e)
			{
				runLog.AppendLine(e.Message);
                runLog.AppendLine(DirName);
			}
		}
	}

}
