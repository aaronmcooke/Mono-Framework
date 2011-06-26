using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GoatDogGames;

namespace GoatDogGames
{
	[Serializable]
	public class DirTreeDisplay
	{
		private Tabbing displayTab;
		private StringBuilder dirTreeText;
        private int currentDepth = 0;
		private int maximumPathLength;
        private int maximumDepth;
		private string dateTimeFormat;

		public string DateTimeFormat // Add code to check that the formatting is correct.
		{
			get { return dateTimeFormat; }
			set
			{
				if (value == null)
				{
					dateTimeFormat = string.Empty;
				}
				else
				{
					dateTimeFormat = value;
				}
			}
		}
		public string DirTreeText
		{
			get { return dirTreeText.ToString();}
		}

		private DirTreeDisplay() { }
		public DirTreeDisplay(int multiplier)
		{
            maximumDepth = 0;
            maximumDepth = 0;

			dateTimeFormat = "MM/dd/yyyy hh:mm:ss";
			displayTab = new Tabbing(multiplier);
			dirTreeText = new StringBuilder();
		}

		public void AssembleDirTreeText(DirTreeNode dirTreeNode)
		{
			dirTreeText.Length = 0;
			CheckAgainstMaximumPathDisplayLength(dirTreeNode);
			AppendInfoIntoDirTreeText(dirTreeNode);
		}

		private void AppendInfoIntoDirTreeText(DirTreeNode currentNode)
		{
            displayTab.TabIn();

            dirTreeText.Append(string.Empty.PadLeft(displayTab.Value, ' '));
            dirTreeText.Append(currentNode.DirName.PadRight(displayTab.Multiplier + maximumPathLength - displayTab.Value, ' '));
            dirTreeText.Append(currentNode.CreatedOn.ToString(dateTimeFormat) + string.Empty.PadRight(displayTab.Multiplier, ' '));
			dirTreeText.Append(currentNode.LastAccessed.ToString(dateTimeFormat) + string.Empty.PadRight(displayTab.Multiplier, ' '));
			dirTreeText.Append(currentNode.LastWritten.ToString(dateTimeFormat) + string.Empty.PadRight(displayTab.Multiplier, ' '));
			dirTreeText.AppendLine(currentNode.FilePaths.Count.ToString());

			foreach (DirTreeNode Item in currentNode.Directories)
			{
				AppendInfoIntoDirTreeText(Item);
			}

			displayTab.TabOut();
		}

		private void CheckAgainstMaximumPathDisplayLength(DirTreeNode dirTreeNodePassed)
		{
            displayTab.TabIn();

			int pathLength = dirTreeNodePassed.DirName.PadLeft(dirTreeNodePassed.DirName.Length + displayTab.Value, ' ').Length;
			if (pathLength > maximumPathLength)
			{
				maximumPathLength = pathLength;
			}

			foreach (DirTreeNode node in dirTreeNodePassed.Directories)
			{
				CheckAgainstMaximumPathDisplayLength(node);
			}

			displayTab.TabOut();
		}

		public void AssembleDirTreeListStatsText(DirTreeList dirTreeListPassed)
		{
			dirTreeText.Length = 0;
			dirTreeText.AppendLine("HasPath : " + dirTreeListPassed.HasPath.ToString());
			dirTreeText.AppendLine("Count : " + dirTreeListPassed.Count.ToString());

			dirTreeText.AppendLine();
			dirTreeText.AppendLine("ImagedAsOf For Each DirTree In List");
			dirTreeText.AppendLine();

			int Counter = 1;
			foreach (DirTree tree in dirTreeListPassed.DirTrees)
			{
				dirTreeText.Append(Counter.ToString().PadLeft(3, ' ') + string.Empty.PadRight(displayTab.Multiplier, ' '));
				dirTreeText.AppendLine(tree.DirImagedAt.ToString(dateTimeFormat) + string.Empty.PadRight(displayTab.Multiplier, ' '));
				Counter++;
			}
		}
	}
}
