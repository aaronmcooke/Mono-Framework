// <copyright file="ErrorEnumerations.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public enum TestStepType
    {
        None,
        ArgsInfoPassToBase,
        ArgsValidation,
        ArgValidation
    }
    public enum ArgsInfoPassToBaseErrors
    {
        None = 0,
        MaxLessThanZero = 1,
        MinLessThanZero = 2,
        MaxLessThanMin = 4,
        ValidParametersAreNull = 8,
        ParameterTypeNotRecongized = 16
    }
    public enum ArgErrors
    {
        None = 0,
        ArgIsNull = 1,
        ArgIsEmpty = 2,
        ArgMissingLeadingHyphen = 4,
        ArgMissingColon = 8,
        ArgHasMoreThanOneColon = 16,
        ParameterIsEmpty = 32,
        ValueIsEmpty = 64,
        ParameterNotValid = 128,
        ValueNotValid = 256,
        DuplicateArg = 512,
    }
    public enum SetupFileErrors
    {
        None = 0,
        SetupPathExistsReturnsFalse = 1,
        ReadOperationThrowsException = 2,
        SetupFileEmpty = 4,
        NoValidBatteriesFound = 8
    }
    public enum SetupDataErrors
    {
        None = 0,
        EmptyLine = 1,
        LineDataTypeNotFound = 2,
        LineParametersLessThanMin = 4,
        LineParametersGreaterThanMax = 8,
        ValidParametersLessThanMin = 16,
        RequiredParameterEmpty = 32,
        DuplicateBatteryName = 64,
        BatteryTypeNotValid = 128,
        ParameterNotInt32 = 256,
        ParameterNotLength1 = 512,
        FileExistsReturnsFalse = 1024
    }

    public enum ErrorType
    {
        None,
        Handler,
        Args,
        Arg,
        Formatting,
        Parameter,
        IOParameter,
        FrequencyParameter
    }

    [Flags()]
    public enum HandlerErrorTypes
    {
        None = 0,
        MinArgsLessThanZero = 1,
        MaxArgsLessThanZero = 2,
        MaxLessThanMin = 4,
        AllowedListNull = 8,
        AllowedListEmpty = 16,
        AllowedTypeNull = 32,
        DuplicateAllowedType = 64,
        RequiredNotAllowed = 128,
        RequiredMoreThanAllowed = 256,
        RequiredTypeNull = 512,
        DuplicateRequiredType = 1024,
        ParameterNotFound = 2048,
        ErrorsPassedWasNull = 4096
    }
    [Flags()]
    public enum ArgsErrorTypes
    {
        None = 0,
        ArgsNull = 1,
        ArgsLengthZero = 2,
        ArgsLengthLessThanMin = 4,
        ArgsLengthGreaterThanMax = 8,
    }
    [Flags()]
    public enum ArgErrorTypes
    {
        None = 0,
        Null = 1,
        Empty = 2,
        NoHyphen = 4,
        MultipleHyphens = 8,
        FirstCharNotHyphen = 16,
        NoColon = 32,
        MultipleColons = 64,
        EmptyType = 128,
        EmptyText = 256,
        ArgTypeNotAllowed = 512,
        ArgTypeIsDuplicate = 1024
    }
    [Flags()]
    public enum ParameterErrorTypes
    {
        None = 0,
        NameWasNull = 1,
        TextWasNull = 2,
        NameWasEmpty = 4,
        TextWasEmpty = 8
    }
    [Flags()]
    public enum FormattingErrorTypes
    {
        None = 0,
        Null = 1,
        Empty = 2,
        FailedParse = 4
    }
    [Flags()]
    public enum FrequencyErrorTypes
    {
        None = 0,
        ResultLessThanDateMin = 1,
        ResultGreaterThanDateMax = 2
    }
    [Flags()]
    public enum IOErrorTypes
    {
        None = 0,
        FileDoesNotExist = 1,
        DirectoryDoesNotExist = 2,
        FileInfoInstanceException = 4,
        DirInfoInstanceException = 8
    }
}
