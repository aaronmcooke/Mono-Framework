// <copyright file="TestStep.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Text;

namespace GoatDogGames
{
    public class TestStep
    {
        #region Fields

        private TestCase parent;
        private int id;
        private string description;

        #endregion
        #region Properties

        public int ID
        {
            get { return id; }
        }
        public string Description
        {
            get { return description; }
        }

        #endregion
        #region Constructor

        private TestStep()
        {
            description = string.Empty;
        }
        public TestStep(TestCase parentPassed, int idPassed) : this()
        {
            parent = parentPassed;
            id = idPassed;
        }

        #endregion
        #region Methods

        public void AddDataToTestStep(TestSuiteData dataToAdd)
        {
            if (!dataToAdd.TestStepDescription.Equals(string.Empty))
            {
                description = dataToAdd.TestStepDescription;
            }
        }
        public override string ToString()
        {
            StringBuilder stepText = new StringBuilder();

            stepText.AppendLine(parent.ID.ToString());
            stepText.AppendLine(ID.ToString());
            stepText.AppendLine(Description.ToString());

            return stepText.ToString();
        }

        #endregion
    }
}
