// <copyright file="ReportingTemplateBase.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public enum FileType
    {
        None,
        RawData,
        FixedWidth,
        Delimited,
        Markup
    }

    public class ReportingTemplateBase
    {

    }



    public class RawDataFileTemplate : FileTemplate
    {
        public override FileType Type
        {
            get { return FileType.RawData; }
        }

        public RawDataFileTemplate()
        {
            extension = "dat";
        }
    }

    public class DelimitedFileTemplate : FileTemplate
    {
        public override FileType Type
        {
            get { return FileType.Delimited; }
        }
    }

    public class FixedWithFileTemplate : FileTemplate
    {
        public override FileType Type
        {
            get { return FileType.FixedWidth; }
        }
    }

    public class MarkupFileTemplate : FileTemplate
    {
        public override FileType Type
        {
            get { return FileType.Markup; }
        }
    }
}
