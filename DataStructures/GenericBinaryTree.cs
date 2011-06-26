// <copyright file="GenericBinaryTree.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    // TODO : Implement Flag To Allow Items With Same Key Value
    // TODO : Implement Code To Cause ReportHandler To Send Tree And CurrentNode State
    public class GenericBinaryTree<T> where T : class, IComparable
    {
        #region Private BinaryNode Class

        private class BinaryNode
        {
            #region Fields

            private T item;
            private BinaryNode leftChild;
            private BinaryNode rightChild;

            #endregion
            #region Properties

            public T Item
            {
                get { return item; }
                set { item = value; }
            }
            public BinaryNode LeftChild
            {
                get { return leftChild; }
                set { leftChild = value; }
            }
            public BinaryNode RightChild
            {
                get { return rightChild; }
                set { rightChild = value; }
            }

            public bool LeftIsNull
            {
                get { return leftChild == null; }
            }
            public bool RightIsNull
            {
                get { return rightChild == null; }
            }            
            public BinaryNodeState State
            {
                get
                {
                    BinaryNodeState currentState = BinaryNodeState.None;
                    if (Item == null)
                    {
                        currentState |= BinaryNodeState.ItemIsNull;
                    }
                    if (LeftChild == null)
                    {
                        currentState |= BinaryNodeState.LeftChildIsNull;
                    }
                    if (RightChild == null)
                    {
                        currentState |= BinaryNodeState.RightChildIsNull;
                    }
                    return currentState;
                }
            }
            
            #endregion
            #region Constructors And Destructors

            public BinaryNode(T itemPassed)
            {
                item = itemPassed;
                leftChild = null;
                rightChild = null;
            }
            ~BinaryNode()
            {
                item = default(T);
                leftChild = null;
                rightChild = null;
            }

            #endregion
        }

        #endregion
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);
        public delegate void HandleItems(T itemToHandle);
        private delegate bool HandleNode(T itemTohandle, BinaryNode nodeToHandle);

        #endregion
        #region Fields

        private BinaryNode rootNode;
        private HandleNode nodeHandler;

        private int nodeCount;

        private HandleErrors errorHandler;
        private bool errorHandlerOn;
        private HandleReports reportHandler;
        private bool reportHandlerOn;
        private HandleItems itemHandler;
        private bool itemHandlerOn;

        #endregion
        #region Properties

        public int Count
        {
            get { return nodeCount; }
        }
        public bool IsEmpty
        {
            get { return rootNode == null; }
        }
        public Type Type
        {
            get { return typeof(T); }
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

        #endregion
        #region Constructors

        public GenericBinaryTree()
        {
            rootNode = null;
            nodeHandler = null;

            nodeCount = 0;

            errorHandler = null;
            errorHandlerOn = false;
            reportHandler = null;
            reportHandlerOn = false;
            itemHandler = null;
            itemHandlerOn = false;
        }

        #endregion
        #region Methods

        public void Clear()
        {
            rootNode = null;
            nodeCount = 0;
        }

        public bool AddItem(T itemToAdd)
        {
            nodeHandler = AddTransactionHandler;
            return TransactionHandler(itemToAdd);
        }
        private bool AddTransactionHandler(T itemToHandle, BinaryNode nodeToHandle)
        {
            bool addResult = false;
            if (nodeToHandle == null)
            {
                if (IsEmpty)
                {
                    rootNode = new GenericBinaryTree<T>.BinaryNode(itemToHandle);
                    addResult = true;
                    nodeCount++;
                }
            }
            else if (itemToHandle.CompareTo(nodeToHandle.Item) == 0)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "Item Passed Was Equal To NodeReturned.Item";
                HandleError(newError);
            }
            else if ((itemToHandle.CompareTo(nodeToHandle.Item) < 0) && (nodeToHandle.LeftIsNull))
            {
                nodeToHandle.LeftChild = new GenericBinaryTree<T>.BinaryNode(itemToHandle);
                addResult = true;
                nodeCount++;
            }
            else if ((itemToHandle.CompareTo(nodeToHandle.Item) > 0) && (nodeToHandle.RightIsNull))
            {
                nodeToHandle.RightChild = new GenericBinaryTree<T>.BinaryNode(itemToHandle);
                addResult = true;
                nodeCount++;
            }
            return addResult;
        }
        
        public bool ContainsItem(T itemToFind)
        {
            nodeHandler = ContainsTransactionHandler;
            return TransactionHandler(itemToFind);
        }
        private bool ContainsTransactionHandler(T itemToHandle, BinaryNode nodeToHandle)
        {
            bool containsResult = false;
            if (nodeToHandle == null)
            {
                if (!IsEmpty)
                {
                    containsResult = true;
                }
            }
            else
            {
                if (itemToHandle.CompareTo(nodeToHandle.Item) == 0)
                {
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "Item Passed Was Equal To NodeReturned.Item";
                    HandleError(newError);
                }
                else if ((itemToHandle.CompareTo(nodeToHandle.Item) < 0) && (!nodeToHandle.LeftIsNull))
                {
                    containsResult = true;
                }
                else if ((itemToHandle.CompareTo(nodeToHandle.Item) > 0) && (!nodeToHandle.RightIsNull))
                {
                    containsResult = true;
                }
            }
            return containsResult;
        }
        
        public bool DeleteItem(T itemToDelete)
        {
            nodeHandler = DeleteTransactionHandler;
            return TransactionHandler(itemToDelete);
        }
        private bool DeleteTransactionHandler(T itemToDelete, BinaryNode nodeToHandle)
        {
            bool deleteResult = false;
            if (nodeToHandle == null)
            {
                if (!IsEmpty) // Node To Delete Is Root
                {
                    if ((rootNode.LeftIsNull) && (rootNode.RightIsNull))
                    {
                        rootNode = null;
                    }
                    else if ((!rootNode.LeftIsNull) && (rootNode.RightIsNull))
                    {
                        rootNode = rootNode.LeftChild;                        
                    }
                    else if ((rootNode.LeftIsNull) && (!rootNode.RightIsNull))
                    {
                        rootNode = rootNode.RightChild;
                    }
                    else if ((!rootNode.LeftIsNull) && (!rootNode.RightIsNull))
                    {
                        BinaryNode nodeToDelete = rootNode;
                        BinaryNode tempNode = nodeToDelete.LeftChild;
                        rootNode = nodeToDelete.RightChild;
                        while (!tempNode.LeftIsNull)
                        {
                            tempNode = tempNode.LeftChild;
                        }
                        tempNode.LeftChild = nodeToDelete.LeftChild;
                    }
                    deleteResult = true;
                    nodeCount--;
                }
            }
            else // Node To Delete Is Not Root
            {
                if (itemToDelete.CompareTo(nodeToHandle.Item) == 0)
                {
                    ErrorBase newError = new ErrorBase();
                    newError.Name = "Item Passed Was Equal To NodeReturned.Item";
                    HandleError(newError);
                }
                else if ((itemToDelete.CompareTo(nodeToHandle.Item) < 0) && (!nodeToHandle.LeftIsNull))
                {
                    // Node To Delete Is Left Child Of NodeToHandle
                    if ((nodeToHandle.LeftChild.LeftIsNull) && (nodeToHandle.LeftChild.RightIsNull))
                    {
                        // Both Children Of Left Node Are Null
                        nodeToHandle.LeftChild = null;
                    }                     
                    else if ((!nodeToHandle.LeftChild.LeftIsNull) && (nodeToHandle.LeftChild.RightIsNull))
                    {
                        // Right Child Of Left Node Is Null
                        nodeToHandle.LeftChild = nodeToHandle.LeftChild.LeftChild;
                    }
                    else if ((nodeToHandle.LeftChild.LeftIsNull) && (!nodeToHandle.LeftChild.RightIsNull))
                    {
                        // Left Child Of Left Node Is Null
                        nodeToHandle.LeftChild = nodeToHandle.LeftChild.RightChild;
                    }
                    else if ((!nodeToHandle.LeftChild.LeftIsNull) && (!nodeToHandle.LeftChild.RightIsNull))
                    {
                        // Neither Child Of Left Node Is Null
                        BinaryNode nodeToDelete = nodeToHandle.LeftChild;
                        BinaryNode tempNode = nodeToDelete.RightChild;
                        nodeToHandle.LeftChild = nodeToDelete.RightChild;
                        while (!tempNode.LeftIsNull)
                        {
                            tempNode = tempNode.LeftChild;
                        }
                        tempNode.LeftChild = nodeToDelete.LeftChild;
                    }
                    deleteResult = true;
                    nodeCount--;
                }
                else if (((itemToDelete.CompareTo(nodeToHandle.Item) > 0) && (!nodeToHandle.RightIsNull)))
                {
                    // Node To Delete Is Right Child Of NodeToHandle
                    if ((nodeToHandle.RightChild.LeftIsNull) && (nodeToHandle.RightChild.RightIsNull))
                    {
                        // Both Children Of Right Node Are Null
                        nodeToHandle.RightChild = null;
                    }
                    else if ((!nodeToHandle.RightChild.LeftIsNull) && (nodeToHandle.RightChild.RightIsNull))
                    {
                        // Right Child Of Right Node Is Null
                        nodeToHandle.RightChild = nodeToHandle.RightChild.LeftChild;
                    }
                    else if ((nodeToHandle.RightChild.LeftIsNull) && (!nodeToHandle.RightChild.RightIsNull))
                    {
                        // Left Child Of Right Node Is Null
                        nodeToHandle.RightChild = nodeToHandle.RightChild.RightChild;
                    }
                    else if ((!nodeToHandle.RightChild.LeftIsNull) && (!nodeToHandle.RightChild.RightIsNull))
                    {
                        // Neither Child Of Right Node Is Null
                        BinaryNode nodeToDelete = nodeToHandle.RightChild;
                        BinaryNode tempNode = nodeToDelete.LeftChild;
                        nodeToHandle.RightChild = nodeToDelete.LeftChild;
                        while (!tempNode.RightIsNull)
                        {
                            tempNode = tempNode.RightChild;
                        }
                        tempNode.RightChild = nodeToDelete.RightChild;
                    }
                    deleteResult = true;
                    nodeCount--;
                }
            }
            return deleteResult;
        }
        
        private bool TransactionHandler(T itemToFind)
        {
            bool transactionResult = false;
            if (itemToFind == null)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "Item Passed Was NULL";
                HandleError(newError);
            }
            else
            {
                BinaryNode resultNode = InternalTraverse_AtRoot(itemToFind);
                transactionResult = nodeHandler(itemToFind, resultNode); 
            }
            return transactionResult;
        }
        private BinaryNode InternalTraverse_AtRoot(T itemToFind)
        {
            BinaryNode result = null;
            if ((!IsEmpty) && (itemToFind.CompareTo(rootNode.Item) != 0))
            {
                result = InternalTraverse_PostRoot(itemToFind, rootNode);
            }
            return result;
        }
        private BinaryNode InternalTraverse_PostRoot(T itemToFind, BinaryNode currentNode)
        {
            BinaryNode result = currentNode;
            if (itemToFind.CompareTo(currentNode.Item) < 0)
            {
                if ((!currentNode.LeftIsNull) && (itemToFind.CompareTo(currentNode.LeftChild.Item) != 0))
                {
                    result = InternalTraverse_PostRoot(itemToFind, currentNode.LeftChild);
                }
            }
            else
            {
                if ((!currentNode.RightIsNull) && (itemToFind.CompareTo(currentNode.RightChild.Item) != 0))
                {
                    result = InternalTraverse_PostRoot(itemToFind, currentNode.RightChild);
                }
            }
            return result;
        }

        #endregion
        #region Traverse Methods

        public void Traverse(TraverseType typeOfTraverse)
        {
            if (!ItemHandlerOn)
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "ItemHandle Handler Not Set";
                HandleError(newError);
            }
            else if (!IsEmpty)
            {
                switch (typeOfTraverse)
                {
                    case TraverseType.InOrder:
                        InOrderTraverse(rootNode);
                        break;

                    case TraverseType.PostOrder:
                        PostOrderTraverse(rootNode);
                        break;

                    case TraverseType.PreOrder:
                        PreOrderTraverse(rootNode);
                        break;

                    default:

                        ErrorBase newError = new ErrorBase();
                        newError.Name = "Traverse Type Passed Was None";
                        HandleError(newError);
                        break;
                }
            }
        }
        private void InOrderTraverse(BinaryNode currentNodePassed)
        {
            // Left, Item, Right
            if (!currentNodePassed.LeftIsNull)
            {                
               InOrderTraverse(currentNodePassed.LeftChild);
            }
            ItemHandler(currentNodePassed.Item);
            if (!currentNodePassed.RightIsNull)
            {
                InOrderTraverse(currentNodePassed.RightChild);
            }
        }
        private void PostOrderTraverse(BinaryNode currentNodePassed)
        {
            // Left, Right, Item
            if (!currentNodePassed.LeftIsNull)
            {
                PostOrderTraverse(currentNodePassed.LeftChild);
            }
            if (!currentNodePassed.RightIsNull)
            {
                PostOrderTraverse(currentNodePassed.RightChild);
            }
            ItemHandler(currentNodePassed.Item);
        }
        private void PreOrderTraverse(BinaryNode currentNodePassed)
        {
            // Item, Left, Right
            ItemHandler(currentNodePassed.Item);
            if (!currentNodePassed.LeftIsNull)
            {
                PreOrderTraverse(currentNodePassed.LeftChild);
            }
            if (!currentNodePassed.RightIsNull)
            {
                PreOrderTraverse(currentNodePassed.RightChild);
            }
        }

        #endregion
        #region Handler Methods

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
                ItemHandler(itemToHandle);
            }
        }

        #endregion
    }
}
