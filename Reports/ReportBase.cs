// <copyright file="ReportBase.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public class ReportBase
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ReportBase()
        {
            name = string.Empty;
        }
    }
}
