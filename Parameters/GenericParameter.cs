// <copyright file="GenericParameter.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.IO;
using System.Collections.Generic;

namespace GoatDogGames
{
    public class GenericParameter<T> : ParameterBase
    {
        #region Fields

        private T parameterType;

        #endregion
        #region Properties

        public override Type Type
        {
            get
            {
                return typeof(T);
            }
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value == null)
                {
                }
                else if (value.Length == 0)
                {
                }
                else
                {

                }
            }
        }

        #endregion
        #region Constructors
        
        
        
        #endregion
        #region Methods

        private static void AddFailedParseToErrors(ParameterBase parent)
        {
            FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
            parent.Errors.Add(newError);
        }
        //public static object TryParse<T>(string text, out string textResult, ParameterBase parent)
        //{
        //    textResult = string.Empty;
        //    object newObject = null;

        //    if (text == null)
        //    {
        //        FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
        //        parent.Errors.Add(newError);
        //    }
        //    else if (text.Length == 0)
        //    {
        //        FormattingError newError = new FormattingError(FormattingErrorTypes.Empty);
        //        parent.Errors.Add(newError);
        //    }
        //    else
        //    {
        //        textResult = text;

        //        string typeName = typeof(T).ToString();
        //        switch (typeName)
        //        {
        //            // typeof(string)
        //            case "System.String":
        //                newObject = (object)text;
        //                break;

        //            // typeof(bool)
        //            case "System.Bool":
        //                newObject = (object)false;
        //                bool parseFailed = false;
        //                switch (text.ToUpper())
        //                {
        //                    case "0":
        //                        newObject = (object)false;
        //                        break;
        //                    case "FALSE":
        //                        newObject = (object)false;
        //                        break;
        //                    case "1":
        //                        newObject = (object)true;
        //                        break;
        //                    case "TRUE":
        //                        newObject = (object)true;
        //                        break;
        //                    default:
        //                        AddFailedParseToErrors(parent);
        //                        parseFailed = true;
        //                        break;
        //                }
        //                if (!parseFailed)
        //                {
        //                    parent.Errors.Clear();
        //                }
        //                break;

        //            // typeof(DateTime)
        //            case "System.DateTime":
        //                DateTime dateResult = DateTime.MinValue;
        //                if (DateTime.TryParse(text, out dateResult))
        //                {
        //                    parent.Errors.Clear();
        //                }
        //                else
        //                {
        //                    AddFailedParseToErrors(parent);
        //                }
        //                newObject = (object)dateResult;
        //                break;

        //            // typeof(Double)
        //            case "System.Double":
        //                Double doubleResult = Double.MinValue;
        //                if (Double.TryParse(text, out doubleResult))
        //                {
        //                    parent.Errors.Clear();
        //                }
        //                else
        //                {
        //                    AddFailedParseToErrors(parent);
        //                }
        //                newObject = (Double)doubleResult;
        //                break;

        //            // typeof(Int32)
        //            case "System.Int32":
        //                Int32 intResult = Int32.MinValue;
        //                if (Int32.TryParse(text, out intResult))
        //                {
        //                    parent.Errors.Clear();
        //                }
        //                else
        //                {
        //                    AddFailedParseToErrors(parent);
        //                }
        //                newObject = (object)intResult;
        //                break;

        //            // typeof(Int64)
        //            case "System.Int64":
        //                Int64 longResult = Int64.MinValue;
        //                if (Int64.TryParse(text, out longResult))
        //                {
        //                    parent.Errors.Clear();
        //                }
        //                else
        //                {
        //                    AddFailedParseToErrors(parent);
        //                }
        //                break;

        //            // typeof(FileInfo)
        //            case "System.IO.FileInfo":
        //                FileInfo fileResult = null;
        //                if (File.Exists(text))
        //                {
        //                    try
        //                    {
        //                        fileResult = new FileInfo(text);
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        ErrorBase newError = new ErrorBase();
        //                        newError.Exception = e;
        //                    }
        //                }
        //                else
        //                {
        //                    IOError newError = new IOError(IOErrorTypes.FileDoesNotExist);
        //                    parent.Errors.Add(newError);
        //                }
        //                newObject = (object)fileResult;
        //                break;

        //            // typeof(DirectoryInfo)
        //            case "System.IO.DirectoryInfo":
        //                DirectoryInfo directoryResult = null;
        //                if (Directory.Exists(text))
        //                {
        //                    try
        //                    {
        //                        directoryResult = new DirectoryInfo(text);
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        ErrorBase newError = new ErrorBase();
        //                        newError.Exception = e;
        //                    }
        //                }
        //                else
        //                {
        //                    IOError newError = new IOError(IOErrorTypes.DirectoryDoesNotExist);
        //                    parent.Errors.Add(newError);
        //                }
        //                newObject = (object)directoryResult;
        //                break;
        //        }
        //    }
        //    return newObject;
        //}
                
        #endregion
        #region UnitTests

        public void Test_AddFailedParseToErrors(ParameterBase parentPassed)
        {
            AddFailedParseToErrors(parentPassed);
        }

        #endregion
    }
}
