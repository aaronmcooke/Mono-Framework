// <copyright file="Index.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public class Index<T,U> where T : struct where U : class, IComparable
    {
        #region Delegates

        public delegate void HandleErrors(ErrorBase errorToHandle);
        public delegate void HandleReports(ReportBase reportToHandle);

        #endregion
        #region Fields

        private Dictionary<T,List<U>> items;
        private string name;

        protected HandleErrors errorHandler;
        protected bool errorHandlerOn;
        protected HandleReports reportHandler;
        protected bool reportHandlerOn;

        #endregion
        #region Properties

        public Type TypeOfT
        {
            get { return typeof(T); }
        }
        public Type TypeOfU
        {
            get { return typeof(U); }
        }
        public string Name
        {
            get { return name; }
        }
        public int KeyCount
        {
            get {return 0;}
        }
        public int ValueCount
        {
            get
            {
                int count = 0;
                List<U> currentValue = null;
                foreach (T item in Keys)
                {
                    if (items.TryGetValue(item, out currentValue))
                    {
                        count += currentValue.Count;
                    }
                }
                return count;
            }
        }
        public List<T> Keys
        {
            get
            {
                List<T> list = new List<T>();
                Dictionary<T, List<U>>.KeyCollection.Enumerator enumerator = items.Keys.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
                return list;
            }
        }
        public GenericBinaryTree<U> DistinctValues
        {
            get
            {
                GenericBinaryTree<U> result = new GenericBinaryTree<U>();
                List<U> currentList = null;
                Dictionary<T, List<U>>.ValueCollection.Enumerator enumerator = items.Values.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    currentList = enumerator.Current;
                    foreach (U item in currentList)
                    {
                        result.AddItem(item);
                    }
                }
                return result;
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

        #endregion
        #region Constructors

        private Index()
        {
            name = string.Empty;
            items = new Dictionary<T, U>();
            errorHandler = null;
            reportHandler = null;
            errorHandlerOn = false;
            reportHandlerOn = false;
        }
        public Index(string namePassed) : this()
        {
            if (namePassed != null)
            {
                name = namePassed;
            }
        }

        #endregion
        #region Methods

        public void Clear()
        {
            items.Clear();
        }


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

        #endregion
    }
}
