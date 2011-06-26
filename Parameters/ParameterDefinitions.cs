// <copyright file="ParameterDefinitions.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>

using System;
using System.Collections.Generic;

namespace GoatDogGames
{
    public static class ParameterDefinitions
    {
        public delegate ParameterBase NameDispatcher(string namePassed, string textPassed);

        public static List<NameDispatcher> GetNameDispatchList()
        {
            List<NameDispatcher> dispatchList = new List<NameDispatcher>();

            dispatchList.Add(StringParameterDefs);
            dispatchList.Add(BooleanParameterDefs);
            dispatchList.Add(DateTimeParameterDefs);
            dispatchList.Add(DoubleParameterDefs);
            dispatchList.Add(Int32ParameterDefs);
            dispatchList.Add(Int64ParameterDefs);
            dispatchList.Add(FileInfoParameterDefs);
            dispatchList.Add(DirectoryInfoParameterDefs);
            dispatchList.Add(FrequencyParameterDefs);

            return dispatchList;
        }
        public static ParameterBase GetParameter(string namePassed, string textPassed)
        {
            List<NameDispatcher> dispatchList = GetNameDispatchList();

            ParameterBase newParameter = null;
            foreach (NameDispatcher item in dispatchList)
            {
                newParameter = item(namePassed, textPassed);
                if (newParameter != null)
                {
                    continue;
                }
            }

            return newParameter;
        }

        private static ParameterBase StringParameterDefs(string namePassed, string textPassed)
        {
            bool nameFound = false;
            switch (namePassed.ToUpper())
            {
                case "PROGRAMNAME":
                    nameFound = true;
                    break;
                case "PROCESSKEY":
                    nameFound = true;
                    break;
                case "TESTSUITE":
                    nameFound = true; 
                    break;
                case "TESTBATTERY":
                    nameFound = true; 
                    break;
                case "TESTCASE":
                    nameFound = true; 
                    break;
            }

            StringParameter newParameter = null;
            if (nameFound)
            {
                newParameter = new StringParameter();
                newParameter.Name = namePassed;
                newParameter.Text = textPassed;
            }

            return (ParameterBase)newParameter;
        }
        private static ParameterBase BooleanParameterDefs(string namePassed, string textPassed)
        {
            bool nameFound = false;
            switch (namePassed.ToUpper())
            {
                case "TEST":
                    nameFound = true;
                    break;
                case "UPDATE":
                    nameFound = true;
                    break;
            }
            
            BoolParameter newParameter = null;
            if (nameFound)
            {
                newParameter = new BoolParameter();
                newParameter.Name = namePassed;
                newParameter.Text = textPassed;
            }

            return (ParameterBase)newParameter;
        }
        private static ParameterBase DateTimeParameterDefs(string namePassed, string textPassed)
        {
            return null;
        }     // Not In Use
        private static ParameterBase DoubleParameterDefs(string namePassed, string textPassed)
        {
            return null;
        }       // Not In Use
        private static ParameterBase Int32ParameterDefs(string namePassed, string textPassed)
        {
            return null;
        }        // Not In Use
        private static ParameterBase Int64ParameterDefs(string namePassed, string textPassed)
        {
            return null;
        }        // Not In Use
        private static ParameterBase DirectoryInfoParameterDefs(string namePassed, string textPassed)
        {
            bool nameFound = false;
            switch (namePassed.ToUpper())
            {
                case "OUTPUTFILES":
                    nameFound = true;
                    break;
                case "INPUTFILES":
                    nameFound = true;
                    break;
            }

            DirInfoParamter newParameter = null;
            if (nameFound)
            {
                newParameter = new DirInfoParamter();
                newParameter.Name = namePassed;
                newParameter.Text = textPassed;
            }

            return (ParameterBase)newParameter;
        }
        private static ParameterBase FileInfoParameterDefs(string namePassed, string textPassed)
        {
            bool nameFound = false;
            switch (namePassed.ToUpper())
            {
                case "PROGRAMPATH":
                    break;
                case "SETUPFILE":
                    break;
                case "LOGFILE":
                    break;
            }
            
            FileInfoParameter newParameter = null;
            if (nameFound)
            {
                newParameter = new FileInfoParameter();
                newParameter.Name = namePassed;
                newParameter.Text = textPassed;
            }

            return (ParameterBase)newParameter;
        }
        private static ParameterBase FrequencyParameterDefs(string namePassed, string textPassed)
        {
            FrequencyParameter newParameter = null;
            if (namePassed.ToUpper().Equals("FREQ"))
            {
                newParameter = new FrequencyParameter();
                newParameter.Name = namePassed;
                newParameter.Text = textPassed;
            }
            return (ParameterBase)newParameter;
        }
    }
}
