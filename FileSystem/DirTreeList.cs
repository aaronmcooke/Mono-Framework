using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
	[Serializable]
	public class DirTreeList
	{
		private string dirPath;
		private List<DirTree> dirTreeList;

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
		public DirTree MostRecent
		{
			get
			{
				DateTime mostRecentAsOf = DateTime.MinValue;
				DirTree mostRecentDirTree = null;
				foreach (DirTree tree in dirTreeList)
				{
					if (DateTime.Compare(tree.DirImagedAt,mostRecentAsOf) >= 0)
					{
						mostRecentDirTree = tree;
						mostRecentAsOf = tree.DirImagedAt;
					}
				}
				return mostRecentDirTree;
			}
		}

		public DirTree TwoMostRecent
		{
            get
            {
                return null;
            }
		}
		public int Count
		{
			get { return dirTreeList.Count; }
		}
		public List<DirTree> DirTrees
		{
			get { return dirTreeList; }
		}

		private DirTreeList() { }
		public DirTreeList(string dirPathPassed)
		{
			dirPath = string.Empty;
			{
				if (dirPathPassed != null)
				{
					dirPath = dirPathPassed;
				}
			}

			dirTreeList = new List<DirTree>();
		}

		public void GenerateNewDirImage()
		{
			if (HasPath)
			{
				DirTree newDirTree = new DirTree(dirPath);
				newDirTree.GrowDirTree();
				dirTreeList.Add(newDirTree);
			}
			else
			{
				runLog.AppendLine("dirPath passed to DirTreeList was null or empty.");
			}
		}
	}
}
