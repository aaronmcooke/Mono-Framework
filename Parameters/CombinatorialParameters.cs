// <copyright file="CombinatorialParameters.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;

// TODO : Figure out how (and if) to add proper constraints

namespace GoatDogGames
{
    public class CombinatorialParameter<T> : ParameterBase
    {
        private Combinatorial<T> combinatorial;

        public override Type Type
        {
            get { return combinatorial.Type; }
        }
        public Combinatorial<T> Combinatorial
        {
            get { return combinatorial; }
        }

        private CombinatorialParameter()
        {
            name = "Combinatorial";
            combinatorial = null;
        }
        public CombinatorialParameter(Combinatorial<T> combinatorialPassed) : this()
        {
            if (combinatorialPassed != null)
            {
                combinatorial = combinatorialPassed;
            }
            else
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "CombinatorialPassedWasNull";
                errors.Add(newError);
            }
        }
    }

    public class CombinatorialTierParameter<T> : ParameterBase
    {
        private CombinatorialTier<T> tier;

        public override Type Type
        {
            get { return tier.Type; }
        }
        public CombinatorialTier<T> Tier
        {
            get { return tier; }
        }

        private CombinatorialTierParameter()
        {
            name = "CombinatorialTier";
            tier = null;
        }
        public CombinatorialTierParameter(CombinatorialTier<T> combinatorialTierPassed) : this()
        {
            if (combinatorialTierPassed != null)
            {
                tier = combinatorialTierPassed;
            }
            else
            {
                ErrorBase newError = new ErrorBase();
                newError.Name = "TierPassedWasNull";
                errors.Add(newError);
            }
        }
    }
}
