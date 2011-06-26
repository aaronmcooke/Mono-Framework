using System;
using System.Text;

namespace GoatDogGames
{
	public enum TraverseType
	{
		None,
		InOrder,
		PreOrder,
		PostOrder
	}

	public class BinaryTree
	{
		#region fields
		private BinaryNode root;
		#endregion

		#region properties
		public int Count
		{
			get	{ return ( (root == null) ? 0 : root.GetCount() ); }
		}
		public int Height
		{
			get	{ return ( ( root == null ) ? 0 : root.GetHeight() ); }
		}
		public bool IsEmpty
		{
			get { return (root == null); }
		}
		#endregion

		#region constructors
		public BinaryTree()
		{
			root = null;
		}
		#endregion

		//TODO: reimplement as IEnumerator

		#region methods
		public StringBuilder Traverse(TraverseType TypeOfTraverse)
		{
			StringBuilder NodeValues = new StringBuilder();
			if (!IsEmpty)
			{
				switch (TypeOfTraverse)
				{
					case TraverseType.InOrder:
						InOrder(root, NodeValues);
						break;
					case TraverseType.PreOrder:
						PreOrder(root, NodeValues);
						break;
					case TraverseType.PostOrder:
						PostOrder(root, NodeValues);
						break;
					default:
						break;
				}
			}
			return NodeValues;
		}
		public int[] GetValues(TraverseType TypeOfTraverse)
		{
			int[] NodeValues = new int[Count];
			if (!IsEmpty)
			{
				switch (TypeOfTraverse)
				{
					case TraverseType.InOrder:
						InOrder(root, NodeValues, 0);
						break;
					case TraverseType.PreOrder:
						PreOrder(root, NodeValues, 0);
						break;
					case TraverseType.PostOrder:
						PostOrder(root, NodeValues, 0);
						break;
					default:
						break;
				}
			}
			return NodeValues;
		}

		private int InOrder(BinaryNode CurrentNode, int[] NodeValues, int count)
		{
			if (CurrentNode.LeftNode != null)
			{
				count = InOrder(CurrentNode.LeftNode, NodeValues, count);
			}
			Console.WriteLine(NodeValues.Length + "   " + count.ToString());
			NodeValues[count++] = CurrentNode.Value;
			if (CurrentNode.RightNode != null)
			{
				count = InOrder(CurrentNode.RightNode, NodeValues, count);
			}
			return count;
		}
		private void InOrder(BinaryNode CurrentNode, StringBuilder NodeValues)
		{
			if (CurrentNode.LeftNode != null)
			{
				InOrder(CurrentNode.LeftNode,NodeValues);
			}
			NodeValues.Append(CurrentNode.Value.ToString());
			NodeValues.AppendLine();
			if (CurrentNode.RightNode != null)
			{
				InOrder(CurrentNode.RightNode,NodeValues);
			}
		}

		private int PreOrder(BinaryNode CurrentNode, int[] NodeValues, int count)
		{
			NodeValues[count++] = CurrentNode.Value;
			if (CurrentNode.LeftNode != null)
			{
				count = PreOrder(CurrentNode.LeftNode, NodeValues, count);
			}
			if (CurrentNode.RightNode != null)
			{
				count = PreOrder(CurrentNode.RightNode, NodeValues, count);
			}
			return count;
		}
		private void PreOrder(BinaryNode CurrentNode, StringBuilder NodeValues)
		{
			NodeValues.Append(CurrentNode.Value.ToString());
			NodeValues.AppendLine();
			if (CurrentNode.LeftNode != null)
			{
				PreOrder(CurrentNode.LeftNode,NodeValues);
			}
			if (CurrentNode.RightNode != null)
			{
				PreOrder(CurrentNode.RightNode,NodeValues);
			}

		}

		private int PostOrder(BinaryNode CurrentNode, int[] NodeValues, int count)
		{
			if (CurrentNode.LeftNode != null)
			{
				count = PostOrder(CurrentNode.LeftNode, NodeValues, count);
			}
			if (CurrentNode.RightNode != null)
			{
				count = PostOrder(CurrentNode.RightNode, NodeValues, count);
			}
			NodeValues[count++] = CurrentNode.Value;
			return count;
		}
		private void PostOrder(BinaryNode CurrentNode, StringBuilder NodeValues)
		{
			if (CurrentNode.LeftNode != null)
			{
				PostOrder(CurrentNode.LeftNode,NodeValues);
			}
			if (CurrentNode.RightNode != null)
			{
				PostOrder(CurrentNode.RightNode,NodeValues);
			}
			NodeValues.Append(CurrentNode.Value.ToString());
			NodeValues.AppendLine();
		}

		public bool Add(int ValueToAdd)
		{
			return IsEmpty ? AddNode(null, ValueToAdd) : AddNode(root, ValueToAdd);
		}
		private	bool AddNode(BinaryNode CurrentNode, int ValueToAdd)
		{
			BinaryNode NewNode = null;
			if (IsEmpty)
			{
				if (CurrentNode == null)
				{
					NewNode = new BinaryNode(ValueToAdd);
					root = NewNode;
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				if ( ( CurrentNode == null ) || ( ValueToAdd == CurrentNode.Value ) )
				{
					return false;
				}
				else
				{
					if ( ValueToAdd < CurrentNode.Value)
					{
						if ( CurrentNode.LeftNode != null )
						{
							return AddNode(CurrentNode.LeftNode, ValueToAdd);
						}
						else
						{
							NewNode = new BinaryNode(ValueToAdd);
							CurrentNode.LeftNode = NewNode;
							return true;
						}
					}
					else
					{
						if ( CurrentNode.RightNode != null )
						{
							return AddNode(CurrentNode.RightNode, ValueToAdd);
						}
						else
						{
							NewNode = new BinaryNode(ValueToAdd);
							CurrentNode.RightNode = NewNode;
							return true;
						}
					}
				}
			}
		}

		public bool AddArray (int[] array)
		{
			bool result = true;
			for ( int i = 0 ; i < array.Length ; i++ )
			{
				if (!AddNode(root, array[i]))
				{
					result = false;
				}
			}
			return result;
		}

		public bool Delete(int ValueToDelete)
		{
			if (IsEmpty) // Can't delete a node from a tree that has none.
			{
				return false;
			}
			else
			{
				if (root.Value == ValueToDelete) // Node to delete is root
				{
					return DeleteNode(null, ValueToDelete);
				}
				else // Node to delete might be in tree but it's not the root
				{
					BinaryNode ParentNode = FindParentOf(root, ValueToDelete);
					if (ParentNode == null) // Value wasn't in tree so nothing to delete.
					{
						return false;
					}
					else // Value was in tree and wasn't the root.
					{
						return DeleteNode(ParentNode, ValueToDelete);
					}
				}
			}
		}
		private BinaryNode FindParentOf(BinaryNode CurrentNode, int ValueToFind)
		{
			if ( (IsEmpty) || (CurrentNode.Value == ValueToFind) || (CurrentNode == null) ) // These are error conditions
			{
				return null;
			}
			else
			{
				if ( ValueToFind < CurrentNode.Value )
				{
					if (CurrentNode.LeftNode == null) // Tree doesn't contain ValueToFind
					{
						return null;
					}
					else // Left branch of current may contain ValueToFind
					{
						if (CurrentNode.LeftNode.Value == ValueToFind) // CurrentNode is parent
						{
							return CurrentNode;
						}
						else // CurrentNode isn't parent but left branch might contain parent.
						{
							return FindParentOf(CurrentNode.LeftNode, ValueToFind);
						}
					}
				}
				else
				{
					if (CurrentNode.RightNode == null) // Tree doesn't contain ValueToFind
					{
						return null;
					}
					else // Right branch of current may contain ValueToFind
					{
						if (CurrentNode.RightNode.Value == ValueToFind) // CurrentNode is parent
						{
							return CurrentNode;
						}
						else // CurrentNode isn't parent but right branch might contain parent.
						{
							return FindParentOf(CurrentNode.RightNode, ValueToFind);
						}
					}
				}
			}
		}
		private bool DeleteNode(BinaryNode ParentNode, int ValueToDelete)
		{
			// Figure out which node of the parent is the child to be deleted
			// and determine if the child node has any grandchildren.
			BinaryNode ChildNode = null;
			BinaryNode LeftGrandchild = null;
			BinaryNode RightGrandchild = null;

			if ( ParentNode == null ) // Node to delete is the root.
			{
				ChildNode = root;
			}
			else
			{
				if ( ValueToDelete < ParentNode.Value ) // Child is LeftNode of parent
				{
					ChildNode = ParentNode.LeftNode;
				}
				else // Child is RightNode of parent
				{
					ChildNode = ParentNode.RightNode;
				}
			}

			// Figure out how whether the Child has any grandchildren
			if (ChildNode.LeftNode != null)
			{
				LeftGrandchild = ChildNode.LeftNode;
			}
			if (ChildNode.RightNode != null)
			{
				RightGrandchild = ChildNode.RightNode;
			}

			if ( (ChildNode.IsLeaf) )
			{
				if ( ParentNode == null)
				{
					Console.WriteLine("Delete Pattern A");
					root = null;
				}
				else
				{
					if (ChildNode.Value < ParentNode.Value)
					{
						Console.WriteLine("Delete Pattern B");
						ParentNode.LeftNode = null;
					}
					else
					{
						Console.WriteLine("Delete Pattern C");
						ParentNode.RightNode = null;
					}
				}
			}
			else
			{
				if ( (LeftGrandchild != null) && (RightGrandchild == null) )
				{
					if (ParentNode == null)
					{
						Console.WriteLine("Delete Pattern D");
						root = LeftGrandchild;
					}
					else
					{
						if ( ChildNode.Value < ParentNode.Value)
						{
							Console.WriteLine("Delete Pattern E");
							ParentNode.LeftNode = LeftGrandchild;
						}
						else
						{
							Console.WriteLine("Delete Pattern F");
							ParentNode.RightNode = LeftGrandchild;
						}
					}
				}
				else if ( (LeftGrandchild == null) && (RightGrandchild != null) )
				{
					if (ParentNode == null)
					{
						Console.WriteLine("Delete Pattern G");
						root = RightGrandchild;
					}
					else
					{
						if ( ChildNode.Value < ParentNode.Value)
						{
							Console.WriteLine("Delete Pattern H");
							ParentNode.LeftNode = RightGrandchild;
						}
						else
						{
							Console.WriteLine("Delete Pattern I");
							ParentNode.RightNode = RightGrandchild;
						}
					}
				}
				else
				{
					if (ParentNode == null)
					{
							BinaryNode TempNode = LeftGrandchild;
							while (TempNode.RightNode != null)
							{
								TempNode = TempNode.RightNode;
							}
							TempNode.RightNode = RightGrandchild;
							Console.WriteLine("Delete Pattern J");
							root = LeftGrandchild;
					}
					else
					{
						if ( ChildNode.Value < ParentNode.Value )
						{
							BinaryNode TempNode = RightGrandchild;
							while (TempNode.LeftNode != null)
							{
								TempNode = TempNode.LeftNode;
							}
							TempNode.LeftNode = LeftGrandchild;
							Console.WriteLine("Delete Pattern K");
							ParentNode.LeftNode = RightGrandchild;
						}
						else
						{
							BinaryNode TempNode = LeftGrandchild;
							while (TempNode.RightNode != null)
							{
								TempNode = TempNode.RightNode;
							}
							TempNode.RightNode = RightGrandchild;
							Console.WriteLine("Delete Pattern L");
							ParentNode.RightNode = LeftGrandchild;
						}
					}
				}
			}
			return true;
		}


		#endregion

		#region short methods

		public bool Contains (int value) { return IsEmpty ? false : root.ContainsNode(value); }
		public string PathToNode(int value)
		{
			return Contains(value) ? root.GetNodePath(value) : string.Empty;
		}
		public void Clear ()
		{
			root = null;
		}
		#endregion
	}

	public class BinaryNode
	{
		#region short properties

		public int Value { get; set; }
		public BinaryNode LeftNode { get; set; }
		public BinaryNode RightNode { get; set; }

		#endregion

		#region complex properties

		public bool IsLeaf
		{
			get
			{
				if ( ( RightNode == null ) && ( LeftNode == null ) )
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		#endregion

		#region constructors and destructors
		public BinaryNode(int nodeValue)
		{
			Value = nodeValue;
			LeftNode = null;
			RightNode = null;
		}

		~BinaryNode()
		{
			Value = 0;
			LeftNode = null;
			RightNode = null;
		}
		#endregion

		#region recursive methods
		internal int GetHeight()
		{
			int LeftHeight = 0;
			int RightHeight = 0;

			if ( LeftNode != null )
			{
				LeftHeight = LeftNode.GetHeight();
			}

			if ( RightNode != null )
			{
				RightHeight = RightNode.GetHeight();
			}

			if ( LeftHeight == RightHeight )
			{
				return 1 + LeftHeight;
			}
			else
			{
				if ( LeftHeight > RightHeight )
				{
					return 1 + LeftHeight;
				}
				else
				{
					return 1 + RightHeight;
				}
			}
		}

		internal string GetNodePath(int value)
		{
		   if ( value == Value )
		   {
			   return string.Empty;
		   }
		   else
		   {
			   if (value < Value )
			   {
				   return "L" + LeftNode.GetNodePath(value);
			   }
			   else
			   {
				   return "R" + RightNode.GetNodePath(value);
			   }
		   }
	   }

		internal int GetCount()
		{
			return 1 +
				((LeftNode == null) ? 0 : LeftNode.GetCount()) +
				((RightNode == null) ? 0 : RightNode.GetCount());
		}

		internal bool ContainsNode(int value)
		{
			if ( value == Value)
			{
				return true;
			}
			else
			{
				if (IsLeaf)
				{
					return false;
				}
				else
				{
					if ( value < Value )
					{
						if ( LeftNode != null )
						{
							return LeftNode.ContainsNode(value);
						}
						else
						{
							return false;
						}
					}
					else
					{
						if ( RightNode != null )
						{
							return RightNode.ContainsNode(value);
						}
						else
						{
							return false;
						}
					}

				}
			}
		}

		#endregion
	}
}