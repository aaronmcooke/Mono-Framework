// <copyright file="DataStructureEnumerations.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public enum TraverseType
    {
        None,
        InOrder,
        PreOrder,
        PostOrder,
        DepthFirst,
        BreadthFirst
    }
    [Flags()]
    public enum BinaryNodeState
    {
        None = 0,
        ItemIsNull = 1,
        LeftChildIsNull = 2,
        RightChildIsNull = 4
    }
}
