// <copyright file="program.cs" company="SofTest402">
// Copyright @ 2010 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>


namespace GoatDogGames
{
	using System;
	using System.Collections.Generic;
	using System.IO;

	public class HandleTestSetup
	{
        //public bool Ready
        //{
        //    get
        //    {
        //        return !((HasErrors) || (NoTestFiles));
        //    }
        //}
        //public bool DoubleCheckTestSetupHandled
        //{
        //    get { return DoubleCheckReady(); }
        //}
        //public bool HasErrors
        //{
        //    get { return errors.Count > 0; }
        //}
        //public bool NoTestFiles
        //{
        //    get { return TestFiles.Count < 1; }
        //}

        //private string[] setupFileContents;

        //private string resultsLogPath;
        //public string ResultsLogPath
        //{
        //    get { return resultsLogPath; }
        //}

        //private List<string> testDescription;
        //public List<string> TestDescription
        //{
        //    get { return testDescription; }
        //}

        //private List<TestFile> testFiles;
        //public List<TestFile> TestFiles
        //{
        //    get
        //    {
        //        return testFiles;
        //    }
        //}

        //private List<ErrorBase> errors;
        //public List<ErrorBase> Errors
        //{
        //    get { return errors; }
        //}

        //public HandleTestSetup(HandleArgs ArgsHandled)
        //{
        //    testDescription = new List<string>();
        //    setupFileContents = new string[0];
        //    testFiles = new List<TestFile>();
        //    errors = new List<ErrorBase>();

        //    resultsLogPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        //    CheckArgsHandledForNull(ArgsHandled);
        //}

        //private void CheckArgsHandledForNull(HandleArgs ArgsHandled)
        //{
        //    if (ArgsHandled == null)
        //    {
        //        ErrorBase NewError = new ErrorBase();
        //        NewError.Name = "NullArgsHandled";
        //        NewError.Message = "ArgsHandled passed to HandleTestSetup() was null.";
        //        errors.Add(NewError);
        //    }
        //    else
        //    {
        //        CheckReadyOfArgsHandled(ArgsHandled);
        //    }
        //}
        //private void CheckReadyOfArgsHandled(HandleArgs ArgsHandled)
        //{
        //    if (ArgsHandled.Ready)
        //    {
        //        GetSetupFileContents(ArgsHandled);
        //    }
        //    else
        //    {
        //        ErrorBase NewError = new ErrorBase();
        //        NewError.Name = "ArgsHandledNotReady";
        //        NewError.Message = "ArgsHandled.Ready was FALSE.";
        //        errors.Add(NewError);
        //    }
        //}
		
        //private void GetSetupFileContents(HandleArgs ArgsHandled)
        //{
        //    try
        //    {
        //        setupFileContents = File.ReadAllLines(ArgsHandled.SetupFilePath);
        //        CheckTestSetupFileForEmpty(ArgsHandled);
        //    }
        //    catch (Exception e)
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "TestSetupFileException";
        //        NewError.Message = e.Message;
        //        errors.Add(NewError);
        //    }
        //}
        //private void CheckTestSetupFileForEmpty(HandleArgs ArgsHandled)
        //{
        //    if (setupFileContents.Length < 1)
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "TestSetupFileEmpty";
        //        NewError.Message = "The test setup file was empty";
        //        errors.Add(NewError);
        //    }
        //    else
        //    {
        //        HandleTestSetupFileContents(ArgsHandled);
        //    }
        //}
        //private void HandleTestSetupFileContents(HandleArgs ArgsHandled)
        //{
        //    int LineCount = 1;
        //    foreach (string Line in setupFileContents)
        //    {
        //        if (Line.Equals(string.Empty))
        //        {
        //            Error NewError = new Error();
        //            NewError.Name = "TestSetupFileLineEmpty";
        //            NewError.Message = "TestSetupFile line # " + LineCount.ToString() + " was empty.";
        //            errors.Add(NewError);
        //        }
        //        else
        //        {
        //            string[] LineData = Line.Split(new string[1] { ArgsHandled.Delimiter }, StringSplitOptions.None);
        //            CompareLineNameAgainstValidNames(LineData, LineCount);
        //        }
        //        LineCount++;
        //    }

        //    GetTestFileData(ArgsHandled);
        //}
        //private void CompareLineNameAgainstValidNames(string[] LineData, int LineCount)
        //{
        //    switch (LineData[0])
        //    {
        //        case "RESULTSLOGPATH":
        //            CheckForResultsLogPathEmpty(LineData, LineCount);
        //            break;
        //        case "TESTDESCRIPTION":
        //            AddTestDescriptionLineToList(LineData,LineCount);
        //            break;
        //        case "TESTFILE":
        //            CheckLineDataLength(LineData,LineCount);
        //            break;
        //        default:
        //            Error NewError = new Error();
        //            NewError.Name = "TestLineNameNotValid";
        //            NewError.Message = "The Name of TestSetupFile line # " + LineCount.ToString() + " wasn't valid.";
        //            errors.Add(NewError);
        //            break;
        //    }
        //}
        //private void GetTestFileData(HandleArgs ArgsHandled)
        //{
        //    foreach (TestFile Item in TestFiles)
        //    {
        //        if (Item.ReadyToGetData)
        //        {
        //            string TestFilePath = string.Empty;

        //            if (Item.FilePath.Equals(string.Empty))
        //            {
        //                DirectoryInfo TestSetupFileDirectory = Directory.GetParent(ArgsHandled.SetupFilePath);
        //                TestFilePath = TestSetupFileDirectory.FullName + @"\" + Item.Name + ".txt";
        //            }
        //            else
        //            {
        //                TestFilePath = Item.FilePath;
        //            }

        //            GetTestFileContents(Item, TestFilePath);
        //        }
        //        else
        //        {
        //            Error NewError = new Error();
        //            NewError.Name = "TestFileNotReady";
        //            NewError.Message = "The TestFile wasn't ready.";
        //            errors.Add(NewError);
        //        }
        //    }
        //}

        //private void CheckForResultsLogPathEmpty(string[] LineData, int LineCount)
        //{
        //    if (LineData.Length != 2)
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "ResultsLogPathValueMissing";
        //        NewError.Message = "Parameter " + LineData[0] + " on line # " + LineCount.ToString() + " was missing Path value.";
        //        errors.Add(NewError);
        //    }
        //    else
        //    {
        //        CheckIfResultsLogPathValueExists(LineData, LineCount);
        //    }
        //}
        //private void CheckIfResultsLogPathValueExists(string[] LineData, int LineCount)
        //{
        //    if (File.Exists(LineData[1]))
        //    {
        //        resultsLogPath = LineData[1];
        //    }
        //    else
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "ResultsLogPathDoesntExist";
        //        NewError.Message = "ResultsLogPathValue provided on " + LineCount.ToString() + " doesn't exist.";
        //        errors.Add(NewError);
        //    }
        //}
		
        //private void AddTestDescriptionLineToList(string[] LineData, int LineCount)
        //{
        //    if (LineData.Length < 2)
        //    {
        //        testDescription.Add(string.Empty);
        //    }
        //    else
        //    {
        //        testDescription.Add(LineData[1]);
        //    }
        //}
		
        //private void CheckLineDataLength(string[] LineData, int LineCount)
        //{
        //    if ((LineData.Length > 3) && (LineData.Length < 6))
        //    {
        //        ValidateLineValues(LineData, LineCount);
        //    }
        //    else if (LineData.Length > 5)
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "TooManyTestBatteryParameters";
        //        NewError.Message = LineData[0] + " on line # " + LineCount.ToString() + " had too many values.";
        //        errors.Add(NewError);
        //    }
        //    else
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "ToFewTestBatteryParameters";
        //        NewError.Message = LineData[0] + LineData[0] + " on line # " + LineCount.ToString() + " had too few values.";
        //        errors.Add(NewError);
        //    }
        //}
        //private void ValidateLineValues(string[] LineData, int LineCount)
        //{
        //    bool Result = true;
        //    int CountOfValues = 0;

        //    if (CheckBatteryValuesForNullAndEmpty(LineData, LineCount))
        //    {
        //        Result = false;
        //    }

        //    if (Result)
        //    {
        //        CountOfValues = ConvertValueCountToInteger(LineData, LineCount);
        //        if (CountOfValues < 0)
        //        {
        //            Result = false;
        //        }
        //    }

        //    if ((Result) && (LineData.Length == 5))
        //    {
        //        if (CheckFilePathForExists(LineData, LineCount))
        //        {
        //            Result = false;
        //        }
        //    }

        //    if (Result)
        //    {
        //        TestFile NewTestFile = null;
        //        if (LineData.Length == 4)
        //        {
        //            NewTestFile = new TestFile(LineData[1], LineData[2], CountOfValues);
        //        }
        //        else
        //        {
        //            NewTestFile = new TestFile(LineData[1], LineData[2], CountOfValues, LineData[4]);
        //        }
        //        testFiles.Add(NewTestFile);
        //    }
        //}
        //private bool CheckBatteryValuesForNullAndEmpty(string[] LineData, int LineCount)
        //{
        //    bool Result = false;
        //    for (int i = 1; i < LineData.Length; i++)
        //    {
        //        if ((LineData[i] == null) || (LineData[i].Equals(string.Empty)))
        //        {
        //            Result = true;

        //            Error NewError = new Error();
        //            NewError.Name = "ValueWasNullOrEmpty";
        //            NewError.Message = "Value # " + i.ToString() + " of " + LineData[0] + " on line # " + LineCount.ToString() + " was null or empty.";
        //            errors.Add(NewError);
        //        }
        //    }
        //    return Result;
        //}
        //private int ConvertValueCountToInteger(string[] LineData, int LineCount)
        //{
        //    int Result = 0;
        //    if (!Int32.TryParse(LineData[3], out Result))
        //    {
        //        Result = -1;

        //        Error NewError = new Error();
        //        NewError.Name = "BatteryValueCountWasNotANumber";
        //        NewError.Message = "ValueCount " + LineData[3] + " of " + LineData[0] + " on line # " + LineCount.ToString() + " was not a number.";
        //        errors.Add(NewError);
        //    }
        //    return Result;
        //}
        //private bool CheckFilePathForExists(string[] LineData, int LineCount)
        //{
        //    bool Result = true;
        //    if (!File.Exists(LineData[4]))
        //    {
        //        Result = false;

        //        Error NewError = new Error();
        //        NewError.Name = "FilePathHasError";
        //        NewError.Message = "FilePath " + LineData[4] + " of " + LineData[0] + " on line # " + LineCount.ToString() + " had problems during existence check.";
        //        errors.Add(NewError);
        //    }
        //    return Result;
        //}

        //private void GetTestFileContents(TestFile TestDataFile, string FilePath)
        //{
        //    try
        //    {
        //        TestDataFile.TestData = File.ReadAllLines(FilePath);
        //    }
        //    catch (Exception e)
        //    {
        //        Error NewError = new Error();
        //        NewError.Name = "ExceptionWhileReadingTestDataFile";
        //        NewError.Message = e.Message;
        //        errors.Add(NewError);
        //    }
        //}

        //private bool DoubleCheckReady()
        //{
        //    return false;
        //}
	}
}
