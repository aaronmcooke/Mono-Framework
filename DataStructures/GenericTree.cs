// <copyright file="GenericTree.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;
using System.Text;

namespace GoatDogGames
{
    public class GenericTree<T,U>
        where T : class, IGenericNodeKeys<U>
        where U : struct
    {
        private enum TreeOperation
        {
            None,
            Add,
            Delete,
            Contains,
            Get,
            Filter,
            Parse
        }
        #region Generic Node

        private class GenericTreeNode
        {
            private GenericTreeNode parent;
            private List<GenericTreeNode> children;
            private T item;

            public T Item
            {
                get { return item; }
            }
            public GenericTreeNode Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            public List<GenericTreeNode> Children
            {
                get { return children; }
            }

            private GenericTreeNode()
            {
                parent = null;
                children = new List<GenericTree<T, U>.GenericTreeNode>();
                item = null;
            }
            public GenericTreeNode(T itemPassed)
                : this()
            {
                item = itemPassed;
            }

            public void AddChild(T childToAdd)
            {
                if (childToAdd != null)
                {
                    GenericTreeNode newChild = new GenericTree<T, U>.GenericTreeNode(childToAdd);
                    newChild.Parent = this;
                    children.Add(newChild);
                }
            }
        }

        #endregion
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);
        public delegate void HandleItems(T itemToHandle);
        private delegate void HandleNodes(GenericTree<T, U>.GenericTreeNode nodeToHandle);

        #endregion
        #region Fields

        private GenericTreeNode rootNode;

        private int nodeCount;

        private Stack<GenericTree<T, U>.GenericTreeNode> traverseStack;
        private Queue<GenericTree<T, U>.GenericTreeNode> traverseQueue;
        private GenericTreeNode currentNode;
        private TreeOperation currentTreeOperation;
        private T itemPassed;
        private U keyPassed;

        private bool haltTraverse;
        private bool itemFound;
        private GenericTree<T, U>.GenericTreeNode nodeIdentified;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;
        protected HandleItems itemHandler;
        protected bool itemHandlerOn;
        private HandleNodes nodeHandler;
        private bool nodeHandlerOn;

        #endregion
        #region Properties

        public bool IsEmpty
        {
            get { return rootNode == null; }
        }
        public bool IsNotEmpty
        {
            get { return rootNode != null; }
        }
        public int Count
        {
            get
            {
                int countResult = 0;

                if (IsNotEmpty)
                {
                    GenericTree<T, U>.HandleNodes countHandler = GetCount;
                    NodeHandler = countHandler;
                    Traverse(TraverseType.DepthFirst);

                    countResult = nodeCount;

                    NodeHandler = null;
                    nodeCount = 0;
                }

                return countResult;
            }
        }
        public HandleErrors ErrorHandler
        {
            get { return errorHandler; }
            set
            {
                if (value == null)
                {
                    errorHandler = null;
                    errorHandlerOn = false;
                }
                else
                {
                    errorHandler = value;
                    errorHandlerOn = true;
                }
            }
        }
        public bool ErrorHandlerOn
        {
            get { return errorHandlerOn; }
        }
        public HandleReports ReportHandler
        {
            get { return reportHandler; }
            set
            {
                if (value == null)
                {
                    reportHandler = null;
                    reportHandlerOn = false;
                }
                else
                {
                    reportHandler = value;
                    reportHandlerOn = true;
                }
            }
        }
        public bool ReportHandlerOn
        {
            get { return reportHandlerOn; }
        }
        public HandleItems ItemHandler
        {
            get { return itemHandler; }
            set
            {
                if (value == null)
                {
                    itemHandler = null;
                    itemHandlerOn = false;
                }
                else
                {
                    itemHandler = value;
                    itemHandlerOn = true;
                }
            }
        }
        public bool ItemHandlerOn
        {
            get { return itemHandlerOn; }
        }
        private HandleNodes NodeHandler
        {
            get { return nodeHandler; }
            set
            {
                if (value == null)
                {
                    nodeHandler = null;
                    nodeHandlerOn = false;
                }
                else
                {
                    nodeHandler = value;
                    nodeHandlerOn = true;
                }
            }
        }
        private bool NodeHandlerOn
        {
            get { return nodeHandlerOn; }
        }
       
        #endregion
        #region Constructors

        public GenericTree()
        {
            rootNode = null;

            nodeCount = 0;

            traverseStack = new Stack<GenericTree<T, U>.GenericTreeNode>();
            traverseQueue = new Queue<GenericTree<T, U>.GenericTreeNode>();
            currentNode = null; 
            currentTreeOperation = GenericTree<T, U>.TreeOperation.None;

            itemPassed = null;
            keyPassed = default(U);

            haltTraverse = false;
            itemFound = false;
            nodeIdentified = null;

            errorHandler = null;
            reportHandler = null;
            itemHandler = null;

            errorHandlerOn = false;
            reportHandlerOn = false;
            itemHandlerOn = false;
        }

        #endregion
        #region Methods

        public void Clear()
        {
            rootNode = null;
            nodeCount = 0;

            Reset();
        }
        private void Reset()
        {
            currentTreeOperation = GenericTree<T, U>.TreeOperation.None;
            currentNode = null;
            itemPassed = null;
            keyPassed = default(U);

            haltTraverse = false;
            itemFound = false;
        }

        private int GetDepth()
        {
            int depthCount = 0;
            if (IsNotEmpty)
            {

            }
            return depthCount;
        }
        private int[] GetBreadth()
        {
            int[] breadthResult = new int[0];
            if (IsNotEmpty)
            {

            }
            return breadthResult;
        }

        public bool SetRoot(T itemToSet)
        {
            bool setResult = true;

            if (IsEmpty)
            {
                rootNode = new GenericTree<T, U>.GenericTreeNode(itemToSet);
            }
            else
            {
                setResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "RootNodeAlreadySet";
                HandleError(newError);
            }

            return setResult;
        }
        public bool Add(T itemToAdd)
        {
            bool addResult = false;

            if (itemToAdd == null)
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "ItemPassedWasNull";
                HandleError(newError);
            }
            else if (rootNode == null)
            {
                addResult = false;
                ErrorBase newError = new ErrorBase();
                newError.Name = "RootNodeNotSet";
                HandleError(newError);
            }
            else
            {
                itemPassed = itemToAdd;
                itemFound = false;
                currentTreeOperation = GenericTree<T, U>.TreeOperation.Add;
                NodeHandler = CompareCurrentItemKeyToItemPassedParentKey;
                
                Traverse(TraverseType.BreadthFirst);

                if (itemFound)
                {
                    GenericTreeNode newNode = new GenericTree<T, U>.GenericTreeNode(itemToAdd);
                    newNode.Parent = currentNode;
                    currentNode.Children.Add(newNode);
                }
                else
                {
                    addResult = false;
                }
            }

            return addResult;
        }
        public bool Delete(T itemToDelete)
        {
            bool deleteResult = false;



            return deleteResult;
        }
        public bool Contains(T itemToFind)
        {
            bool containsResult = false;



            return containsResult;
        }
        public T Get(U keyOfItemToGet)
        {
            T itemFound = null;


            return itemFound;
        }
        public List<T> Filter()
        {
            List<T> filteredList = new List<T>();


            return filteredList;
        }
        public void Parse()
        {

        }

        public void Traverse(TraverseType traverseTypePassed)
        {
            if ((IsNotEmpty) && (ItemHandlerOn))
            {
                switch (traverseTypePassed)
                {
                    case TraverseType.BreadthFirst:

                        traverseQueue.Clear();
                        traverseQueue.Enqueue(rootNode);
                        BreadthFirstTraverse();
                        break;

                    case TraverseType.DepthFirst:
                        
                        traverseStack.Clear();
                        traverseStack.Push(rootNode);
                        DepthFirstTraverse();
                        break;

                    default:

                        ErrorBase newError = new ErrorBase();
                        newError.Name = "InvalidTraverseTypePassed";
                        newError.Value = traverseTypePassed.ToString();
                        HandleError(newError);                        
                        break;
                }
            }
        }
        private void BreadthFirstTraverse()
        {
            GenericTree<T, U>.GenericTreeNode currentNode = traverseQueue.Dequeue();

            if (currentNode.Children.Count > 0)
            {
                foreach (GenericTree<T, U>.GenericTreeNode node in currentNode.Children)
                {
                    traverseQueue.Enqueue(node);
                }
            }

            ItemHandler(currentNode.Item);

            if (traverseQueue.Count > 0)
            {
                BreadthFirstTraverse();
            }

        }
        private void DepthFirstTraverse()
        {
            GenericTree<T, U>.GenericTreeNode currentNode = traverseStack.Pop();

            if (currentNode.Children.Count > 0)
            {
                foreach (GenericTree<T, U>.GenericTreeNode node in currentNode.Children)
                {
                    traverseStack.Push(node);
                }

                DepthFirstTraverse();
            }

            ItemHandler(currentNode.Item);

            if (traverseStack.Count > 0)
            {
                DepthFirstTraverse();
            }
        }

        #endregion
        #region Internal Handler Methods

        private void GetCount(GenericTree<T, U>.GenericTreeNode currentNode)
        {
            nodeCount++;
        }
        private void CompareCurrentItemKeyToItemPassedParentKey(GenericTree<T,U>.GenericTreeNode currentNode)
        {
            if ((currentNode.Item != null) && (currentNode.Item.Key.Equals(itemPassed.ParentKey)))
            {
                itemFound = true;
                nodeIdentified = currentNode;
            }
        }
        private void CompareCurrentItemKeyToItemPassedCurrentKey(GenericTree<T, U>.GenericTreeNode currentNode)
        {
            if ((currentNode.Item != null) && (currentNode.Item.Key.Equals(itemPassed.Key)))
            {
                itemFound = true;
            }
        }
        private void CompareCurrentItemkeyToKeyPassed(GenericTree<T, U>.GenericTreeNode currentNode)
        {
            if ((currentNode.Item != null) && (currentNode.Item.Key.Equals(keyPassed)))
            {
                itemFound = true;
            }
        }

        #endregion
        #region Handling Methods

        private void HandleError(ErrorBase errorToHandle)
        {
            if (ErrorHandlerOn)
            {
                ErrorHandler(errorToHandle);
            }
        }
        private void HandleReport(ReportBase reportToHandle)
        {
            if (ReportHandlerOn)
            {
                ReportHandler(reportToHandle);
            }
        }
        private void HandleItem(T itemToHandle)
        {
            if (ItemHandlerOn)
            {
                HandleItem(itemToHandle);
            }
        }
        
        #endregion
    }
}
