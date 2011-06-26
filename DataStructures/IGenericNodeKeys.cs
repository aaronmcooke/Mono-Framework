// <copyright file="IGenericNodeKeys.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

namespace GoatDogGames
{
    public interface IGenericNodeKeys<T> where T : struct
    {
        T ParentKey { get; }
        T Key { get; }
    }
}
