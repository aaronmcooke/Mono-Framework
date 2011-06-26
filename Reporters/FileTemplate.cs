// <copyright file="FileTemplate.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public class FileTemplate : ReportingTemplateBase
    {
        protected string extension;

        public string Extension
        {
            get { return extension; }
        }
        public virtual FileType Type
        {
            get { return FileType.None; }
        }

        public FileTemplate()
        {
            extension = string.Empty;
        }

        public virtual bool Set(FileReporter currentReporter)
        {
            bool setResult = true;



            return setResult;
        }
    }
}
