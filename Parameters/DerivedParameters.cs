// <copyright file="DerivedParameters.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.IO;
using System.Collections.Generic;

namespace GoatDogGames
{
    // TODO : Implement Method To Clear Errors On Successful Parse

    public class StringParameter : ParameterBase
    {
        // TODO : Implement This
        #region Fields

        private string parameterValue;
        
        #endregion
        #region Properties
        
        public override Type Type
        {
            get
            {
                return typeof(string);
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
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                    errors.Add(newError);
                }
                else
                {
                    text = value;
                }
            }
        }
        public string Value
        {
            get { return parameterValue; }
        }
        
        #endregion
        #region Constructor
        
        public StringParameter()
        {
            parameterValue = string.Empty;
        }
        
        #endregion
    }

    public class BoolParameter : ParameterBase
    {
        #region Fields

        

        #endregion
        #region Properties
        
        public override Type Type
        {
            get
            {
                return typeof(bool);
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
                text = "FALSE";
                if (value == null)
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                    errors.Add(newError);
                }
                else if (value.Equals(string.Empty))
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Empty);
                    errors.Add(newError);
                }
                else
                {
                    text = value;
                }
            }
        }
        public bool Value
        {
            get { return ConvertTextToBoolean(); }
        }
        
        #endregion
        #region Constructors
        
        public BoolParameter()
        {
            SetDefaults();
            SetBooleanParameterDefaults();
        }
        
        #endregion
        #region Constructor Methods

        private void SetBooleanParameterDefaults()
        {
            text = "FAlSE";
        }

        #endregion
        #region

        private bool ConvertTextToBoolean()
        {
            bool result = false;
            switch (Text.ToUpper())
            {
                case "0":
                    result = false;
                    break;
                case "FALSE":
                    result = false;
                    break;
                case "1":
                    result = true;
                    break;
                case "TRUE":
                    result = true;
                    break;
                default:
                    FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
                    newError.Name = Name;
                    errors.Add(newError);
                    break;
            }
            return result;
        }

        #endregion
    }

    public class DateTimeParameter : ParameterBase
    {
        // TODO : Implement This
        #region Fields

        private DateTime parameterValue;

        #endregion
        #region Properties

        public DateTime Value
        {
            get { return parameterValue; }
        }
        public override Type Type
        {
            get
            {
                return typeof(DateTime);
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
                text = string.Empty;

                if (value == null)
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                    errors.Add(newError);
                }
                else if (value.Length == 0)
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Empty);
                    errors.Add(newError);
                }
                else
                {
                    if (DateTime.TryParse(value, out parameterValue))
                    {
                        errors.Clear();
                    }
                    else
                    {
                        FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
                        errors.Add(newError);
                    }
                    text = value;
                }
            }
        }

        #endregion
        #region Constructors

        public DateTimeParameter()
        {
            parameterValue = DateTime.MinValue;
        }

        #endregion
    }

    public class DoubleParameter : ParameterBase
    {
        // TODO : Implement This
        #region Fields

        private Double parameterValue;

        #endregion
        #region Properties

        public override Type Type
        {
            get
            {
                return typeof(Double);
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
                text = string.Empty;

                if (value == null)
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Null);
                    errors.Add(newError);
                }
                else if (value.Length == 0)
                {
                    FormattingError newError = new FormattingError(FormattingErrorTypes.Empty);
                    errors.Add(newError);
                }
                else
                {
                    if (Double.TryParse(value, out parameterValue))
                    {
                        errors.Clear();
                    }
                    else
                    {
                        FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
                        errors.Add(newError);
                    }
                    text = value;
                }
            }
        }

        #endregion
        #region Constructors

        public DoubleParameter()
        {
            parameterValue = 0;
        }

        #endregion
    }

    public class IntegerParameter : ParameterBase
    {
        #region Fields



        #endregion
        #region Properties

        public override Type Type
        {
            get
            {
                return typeof(int);
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
                text = "0";
                if (value == null)
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasNull);
                    newError.Name = Name;
                    errors.Add(newError);
                }
                else if (value.Equals(string.Empty))
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasEmpty);
                    newError.Name = Name;
                    errors.Add(newError);
                }
                else
                {
                    text = value;
                }
            }
        }
        public int Value
        {
            get { return ConvertTextToInteger(); }
        }

        #endregion
        #region Constructors

        public IntegerParameter()
        {
            SetDefaults();
            SetIntegerParameterDefaults();
        }       

        #endregion  
        #region Constructor Methods
        
        private void SetIntegerParameterDefaults()
        {
            Text = "0";
        }

        #endregion
        #region Methods

        private int ConvertTextToInteger()
        {
            int result = 0;
            if (!Int32.TryParse(Text, out result))
            {
                FormattingError newError = new FormattingError(FormattingErrorTypes.FailedParse);
                newError.Name = Name;
                errors.Add(newError);
            }

            return result;
        }

        #endregion
    }


    public class DirInfoParamter : ParameterBase
    {
        #region Fields



        #endregion
        #region Properties

        public override Type Type
        {
            get
            {
                return typeof(DirectoryInfo);
            }
        }
        public override string Text
        {
            get
            {
                return base.text;
            }
            set
            {
                if (value == null)
                {

                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasNull);
                    newError.Name = Name;
                    errors.Add(newError);
                
                }
                else if (value == string.Empty)
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasEmpty);
                    newError.Name = Name;
                    errors.Add(newError);
                }
                else
                {
                    text = value;
                }
            }
        }
        public DirectoryInfo DirectoryIndicated
        {
            get { return ConvertTextToDirectoryInfo(); }
        }
        
        #endregion
        #region Constructors
        
        public DirInfoParamter()
        {
            SetDefaults();
            SetDirInfoDefaults();
        }
        
        #endregion
        #region Constructor Methods

        private void SetDirInfoDefaults()
        {
            text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        #endregion
        #region Methods

        private DirectoryInfo ConvertTextToDirectoryInfo()
        {
            DirectoryInfo newDirInfo = null;


            if (Directory.Exists(text))
            {
                try
                {
                    newDirInfo = new DirectoryInfo(text);
                }
                catch (Exception e)
                {
                    IOError newError = new IOError(IOErrorTypes.DirInfoInstanceException);
                    newError.Name = Name;
                    newError.Exception = e;
                    errors.Add(newError);
                }
            }
            else
            {
                IOError newError = new IOError(IOErrorTypes.DirectoryDoesNotExist);
                newError.Name = Name;
                errors.Add(newError);
            }

            if (newDirInfo == null)
            {
                newDirInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            }

            return newDirInfo;
        }

        #endregion
    }

    public class FileInfoParameter : ParameterBase
    {
        #region Fields



        #endregion
        #region Properties

        public override Type Type
        {
            get
            {
                return typeof(FileInfo);
            }
        }
        public override string Text
        {
            get
            {
                return base.text;
            }
            set
            {
                if (value == null)
                {

                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasNull);
                    newError.Name = Name;
                    errors.Add(newError);
                }
                else if (value == string.Empty)
                {
                    ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasEmpty);
                    newError.Name = Name;
                    errors.Add(newError);
                }
                else
                {
                    text = value;
                }
            }
        }
        public FileInfo FileIndicated
        {
            get { return ConvertTextToFileInfo(); }
        }

        #endregion
        #region Constructors

        public FileInfoParameter()
        {
            SetDefaults();
            SetFileInfoDefaults();
        }

        #endregion
        #region Constructor Methods

        private void SetFileInfoDefaults()
        {
            text = string.Empty;
        }

        #endregion
        #region Methods

        private FileInfo ConvertTextToFileInfo()
        {
            FileInfo newFileInfo = null;

            if (Text.Equals(string.Empty))
            {
                ParameterError newError = new ParameterError(ParameterErrorTypes.TextWasEmpty);
                newError.Name = Name;
                errors.Add(newError);
            }
            else if (File.Exists(text))
            {
                try
                {
                    newFileInfo = new FileInfo(text);
                }
                catch (Exception e)
                {
                    IOError newError = new IOError(IOErrorTypes.FileInfoInstanceException);
                    newError.Name = Name;
                    newError.Exception = e;
                    errors.Add(newError);
                }
            }
            else
            {
                IOError newError = new IOError(IOErrorTypes.FileDoesNotExist);
                newError.Name = Name;
                errors.Add(newError);
            }

            return newFileInfo;
        }

        #endregion
    }

    public class TimeSpanParameter : ParameterBase
    {
        // TODO : Implement This
    }

    
}
