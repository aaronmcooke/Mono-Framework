using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoatDogGames
{
	[Serializable]
	public class DirTree
	{
		private string rootDirPath;
		private DirTreeNode root;
		private DateTime dirImagedAt;
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
        public bool Ready
        {
            get { return root.HasPath; }
        }
		public DirTreeNode Root
		{
			get { return root; }
		}
		public DateTime DirImagedAt
		{
			get { return dirImagedAt; }
		}

		public DirTree(string rootDirPathPassed)
		{
			rootDirPath = rootDirPathPassed;
			root = new DirTreeNode(rootDirPath);
		}

		public bool GrowDirTree()
		{
            bool growResult = false;
			if (Root.HasPath)
			{
				dirImagedAt = DateTime.Now;
				try
				{
					SetUpNodeOnTree(root);
                    growResult = true;
				}
				catch (Exception e)
				{
					runLog.AppendLine(e.Message);
                    runLog.AppendLine(e.StackTrace);
				}
			}
			else
			{
				runLog.AppendLine("rootDirPath was null or empty.");
			}
            return growResult;
		}

		private void SetUpNodeOnTree(DirTreeNode currentDirTreeNode)
		{
			currentDirTreeNode.SetDirectories();
			currentDirTreeNode.SetFilePaths();
			currentDirTreeNode.SetAttributes();

			foreach (DirTreeNode node in currentDirTreeNode.Directories)
			{
				SetUpNodeOnTree(node);
			}			
		}
	}
}
