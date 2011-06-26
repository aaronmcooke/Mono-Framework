// <copyright file="DebuggingLogTemplate.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Text;

namespace GoatDogGames
{
    public class DebuggingLogTemplate : FileTemplate
    {
        #region Fields

        private string headerText;
        private int lineWidth;
        private bool appendOnWrite;
        private bool appendOnStart;

        #endregion
        #region Properties

        public string HeaderText
        {
            get { return headerText; }
            set
            {
                if (value != null)
                {
                    headerText = value;
                }
                else
                {
                    headerText = "DebuggingLog";
                }
            }
        }
        public int LineWidth
        {
            get { return lineWidth; }
            set
            {
                if (value < 37)
                {
                    lineWidth = 39;
                }
                else
                {
                    lineWidth = value;
                }
            }
        }
        public bool AppendOnStart
        {
            get { return appendOnStart; }
        }
        public bool AppendOnWrite
        {
            get { return appendOnWrite; }
        }

        #endregion
        #region Constructors

        public DebuggingLogTemplate()
        {
            headerText = "DebuggingLog";
            lineWidth = 150;
            appendOnWrite = true;
            appendOnStart = true;
        }

        #endregion
        #region Methods

        public override bool Set(FileReporter currentReporter)
        {
            bool setResult = true;

            FileReporter.GenerateHeader headerGenerator = GenerateHeader;
            FileReporter.GenerateFooter footerGenerator = GenerateFooter;

            currentReporter.HeaderGenerator = headerGenerator;
            currentReporter.FooterGenerator = footerGenerator;

            return setResult;
        }
        public string GenerateHeader()
        {            
            string header = " " + headerText + " Started At " + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + " ";
            int leftPadLength = (lineWidth - header.ToString().Length) / 2;
            return "[" + header.PadLeft(header.Length + leftPadLength, '-').PadRight(lineWidth, '-') + "]";
        }
        public string GenerateFooter()
        {
            return string.Empty;
        }

        #endregion
    }
}
