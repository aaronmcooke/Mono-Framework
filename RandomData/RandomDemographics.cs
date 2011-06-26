// <copyright file="RandomDemographics.cs" company="GoatDogGames">
// Copyright @ 2011 All Rights Reserved. </copyright>
// <author>Aaron M. Cooke</author>
// <email>aaron.m.cooke@gmail.com</email>using System;

using System;
using System.Collections.Generic;

namespace GoatDogGames.Demographics
{
    public class DemographicInformation
    {
        public string prefix;
        public string firstName;
        public string middleName;
        public string lastName;
        public string suffix;

        public DateTime birthDate;
        public DateTime deathDate;

        public Sex sex;
        public string socialSecurityNumber;
        
        public string addressFirstLine;
        public string addressSecondLine;
        public string city;
        public string state;
        public string zipcode;
        public string country;
    }

    public enum Sex
    {
        None = 0,
        Male = 1,
        Female = 2
    }
    public enum AgeBand
    {
        None = 0,
        Infant = 0,
        Toddler = 1,
        Child = 2,
        Preteen = 3,
        Teen = 4,
        YoungAdult = 5,
        Adult = 6,
        EarlyMiddleAge = 7,
        MiddleAge = 8,
        LateMiddleAge = 9,
        Elderly = 10,
        Geriatric = 11
    }

    public class AgeBandInfo
    {
        #region Fields

        protected List<ErrorBase> errors;
        protected int fromAge;
        protected int thruAge;
        protected AgeBand ageBand;

        #endregion
        #region Properties

        public bool HasErrors
        {
            get { return errors.Count > 0 ? true : false; }
        }
        public List<ErrorBase> Errors
        {
            get { return errors; }
        }
        public int FromAge
        {
            get { return fromAge; }
        }
        public int ThruAge
        {
            get { return thruAge; }
        }
        public AgeBand AgeBand
        {
            get { return ageBand; }
        }

        #endregion
        #region Constructors

        public AgeBandInfo()
        {
            SetDefaults();
        }
        public AgeBandInfo(AgeBand ageBandPassed, int fromAgePassed, int thruAgePassed)
        {
            SetDefaults();

            ageBand = ageBandPassed;

            ValidateFromAgeValue(ageBandPassed, fromAgePassed);
            ValidateThruAgeValue(ageBandPassed, thruAgePassed);
        }

        #endregion
        #region Constructor Methods

        private void SetDefaults()
        {
            fromAge = -1;
            thruAge = -1;
            ageBand = AgeBand.None;
            errors = new List<ErrorBase>();
        }
        private void ValidateFromAgeValue(AgeBand ageBandPassed, int fromAgePassed)
        {
            AgeBand containingAgeBand = AgeBandFactory.GetAgeBandContainingAge(fromAgePassed);
            if (ageBandPassed == containingAgeBand)
            {
                fromAge = fromAgePassed;
            }
            else
            {
                errors.Add(new ErrorBase());
            }
        }
        private void ValidateThruAgeValue(AgeBand ageBandPassed, int thruAgePassed)
        {
            AgeBand containingAgeBand = AgeBandFactory.GetAgeBandContainingAge(thruAgePassed);
            if (ageBandPassed == containingAgeBand)
            {
                thruAge = thruAgePassed;
            }
            else
            {
                errors.Add(new ErrorBase());
            }
        }

        #endregion
    }

    public static class AgeBandFactory
    {
        #region Public Methods

        public static AgeBandInfo GetAgeBandFromName(string ageBandNamePassed)
        {
            AgeBandInfo newAgeBandInfo = new AgeBandInfo();
            if (CheckIfAgeBandPassedValid(ageBandNamePassed))
            {
                AgeBand newAgeBand = (AgeBand)Enum.Parse(typeof(AgeBand), ageBandNamePassed);
                newAgeBandInfo = GetAgeBandFromEnum(newAgeBand);
            }
            else
            {
                newAgeBandInfo.Errors.Add(new ErrorBase());
            }

            return newAgeBandInfo;
        }
        public static AgeBandInfo GetAgeBandFromValue(int ageBandValuePassed)
        {
            AgeBandInfo newAgeBandInfo = new AgeBandInfo();
            if (CheckIfAgeBandPassedValid(ageBandValuePassed))
            {
                string ageBandName = Enum.GetName(typeof(AgeBand), ageBandValuePassed);
                AgeBand newAgeBand = (AgeBand)Enum.Parse(typeof(AgeBand), ageBandName);
                newAgeBandInfo = GetAgeBandFromEnum(newAgeBand);
            }
            else
            {
                newAgeBandInfo.Errors.Add(new ErrorBase());
            }

            return newAgeBandInfo;
        }
        public static AgeBandInfo GetAgeBandFromEnum(AgeBand ageBandPassed)
        {
            int fromAge = GetFromAgeOfBand(ageBandPassed);
            int thruAge = GetThruAgeOfBand(ageBandPassed);
            AgeBandInfo newAgeBandInfo = new AgeBandInfo(ageBandPassed, fromAge, thruAge);
            return newAgeBandInfo;
        }
        public static AgeBand GetAgeBandContainingAge(int agePassed)
        {
            AgeBand resultAgeBand = AgeBand.None;
            string[] ageBandNames = Enum.GetNames(typeof(AgeBand));
            Type ageBandType = typeof(AgeBand);

            int counter = 0;
            int fromAge = 0;
            int thruAge = 0;
            AgeBand currentAgeBand = AgeBand.None;

            while (resultAgeBand == AgeBand.None)
            {
                currentAgeBand = (AgeBand)Enum.Parse(ageBandType, ageBandNames[counter++]);
                
                fromAge = GetFromAgeOfBand(currentAgeBand);
                thruAge = GetThruAgeOfBand(currentAgeBand);

                if ((currentAgeBand != AgeBand.None) && (agePassed >= fromAge) && (agePassed <= thruAge))
                {
                    resultAgeBand = currentAgeBand;
                }
            }

            return resultAgeBand;
        }

        #endregion
        #region Private Methods

        private static int GetFromAgeOfBand(AgeBand ageBandPassed)
        {
            int fromAge = -1;

            switch (ageBandPassed)
            {
                case AgeBand.Infant:
                    fromAge = 0;
                    break;
                case AgeBand.Toddler:
                    fromAge = 1;
                    break;
                case AgeBand.Child:
                    fromAge = 3;
                    break;
                case AgeBand.Preteen:
                    fromAge = 9;
                    break;
                case AgeBand.Teen:
                    fromAge = 13;
                    break;
                case AgeBand.YoungAdult:
                    fromAge = 20;
                    break;
                case AgeBand.Adult:
                    fromAge = 25;
                    break;
                case AgeBand.EarlyMiddleAge:
                    fromAge = 45;
                    break;
                case AgeBand.MiddleAge:
                    fromAge = 55;
                    break;
                case AgeBand.LateMiddleAge:
                    fromAge = 65;
                    break;
                case AgeBand.Elderly:
                    fromAge = 75;
                    break;
                case AgeBand.Geriatric:
                    fromAge = 85;
                    break;
                default:
                    fromAge = -1;
                    break;
            }

            return fromAge;
        }
        private static int GetThruAgeOfBand(AgeBand ageBandPassed)
        {
            int thruAge = -1;

            switch (ageBandPassed)
            {
                case AgeBand.Infant:
                    thruAge = 0;
                    break;
                case AgeBand.Toddler:
                    thruAge = 2;
                    break;
                case AgeBand.Child:
                    thruAge = 8;
                    break;
                case AgeBand.Preteen:
                    thruAge = 12;
                    break;
                case AgeBand.Teen:
                    thruAge = 19;
                    break;
                case AgeBand.YoungAdult:
                    thruAge = 24;
                    break;
                case AgeBand.Adult:
                    thruAge = 44;
                    break;
                case AgeBand.EarlyMiddleAge:
                    thruAge = 54;
                    break;
                case AgeBand.MiddleAge:
                    thruAge = 64;
                    break;
                case AgeBand.LateMiddleAge:
                    thruAge = 74;
                    break;
                case AgeBand.Elderly:
                    thruAge = 84;
                    break;
                case AgeBand.Geriatric:
                    thruAge = 125;
                    break;
                default:
                    thruAge = -1;
                    break;
            }

            return thruAge;
        }        
        private static bool CheckIfAgeBandPassedValid(string ageBandName)
        {
            return Enum.IsDefined(typeof(AgeBand), ageBandName);
        }
        private static bool CheckIfAgeBandPassedValid(int ageBandValue)
        {
            return Enum.IsDefined(typeof(AgeBand), ageBandValue);
        }

        #endregion
    }    

    public class RandomDemographics : DataGenerator
    {
        public int[] sexDistribution;

        public RandomDemographics()
        {
            sexDistribution = new int[0];
        }
        public RandomDemographics(int newSeedValue) : this()
        {
            valueGen = new Random(newSeedValue);
        }

        public void SetDemographicDistributionLists()
        {
            sexDistribution = new int[] {
                2934300,
                2959821 };            
        }

        public static string[] GetRandomMaleFirstNameSet()
        {
            return new string[] {
                "Jacob", "Ethan", "Michael", "Alexander", "William", 
                "Joshua", "Daniel", "Jayden", "Noah", "Anthony", 
                "Christopher", "Aiden", "Matthew", "David", "Andrew",
                "Joseph", "Logan", "James", "Ryan", "Benjamin", "Elijah",
                "Gabriel", "Christian", "Nathan", "Jackson", "John",
                "Samuel", "Tyler", "Dylan", "Jonathan", "Caleb", "Nicholas",
                "Gavin", "Mason", "Evan", "Landon", "Angel", "Brandon",
                "Lucas", "Isaac", "Isaiah", "Jack", "Jose", "Kevin",
                "Jordan", "Justin", "Brayden", "Luke", "Liam", "Carter",
                "Owen", "Connor", "Zachary", "Aaron", "Robert", "Hunter",
                "Thomas", "Adrian", "Cameron", "Wyatt", "Chase",
                "Julian", "Austin", "Charles", "Jeremiah", "Jason",
                "Juan", "Xavier", "Luis", "Sebastian", "Henry", "Aidan",
                "Ian", "Adam", "Diego", "Nathaniel", "Brody", "Jesus",
                "Carlos", "Tristan", "Dominic", "Cole", "Alex", "Cooper",
                "Ayden", "Carson", "Josiah", "Levi", "Blake", "Eli",
                "Hayden", "Bryan", "Colton", "Brian", "Eric", "Parker", "Sean",
                "Oliver", "Miguel", "Kyle" };
        }
        public static string[] GetRandomFemaleFirstNameSet()
        {
            return new string[] {
                 "Isabella", "Emma", "Olivia", "Sophia", "Ava", "Emily", 
                 "Madison", "Abigail", "Chloe", "Mia", "Elizabeth", "Addison",
                 "Alexis", "Ella", "Samantha", "Natalie", "Grace", "Lily", 
                 "Alyssa", "Ashley", "Sarah", "Taylor", "Hannah", "Brianna",
                 "Hailey", "Kaylee", "Lillian", "Leah", "Anna", "Allison", 
                 "Victoria", "Avery", "Gabriella", "Nevaeh", "Kayla",
                 "Sofia", "Brooklyn", "Riley", "Evelyn", "Savannah", 
                 "Aubrey", "Alexa", "Peyton", "Makayla", "Layla", "Lauren", 
                 "Zoe", "Sydney", "Audrey", "Julia", "Jasmine", "Arianna",
                 "Claire", "Brooke", "Amelia", "Morgan", "Destiny",
                 "Bella", "Madelyn", "Katherine", "Kylie", "Maya", 
                 "Aaliyah", "Madeline", "Sophie", "Kimberly", "Kaitlyn", 
                 "Charlotte", "Alexandra", "Jocelyn", "Maria", "Valeria", 
                 "Andrea", "Trinity", "Zoey", "Gianna", "Mackenzie", "Jessica",
                 "Camila", "Faith", "Autumn", "Ariana", "Genesis", "Payton",
                 "Bailey", "Angelina", "Caroline", "Mariah", "Katelyn", 
                 "Rachel", "Vanessa", "Molly", "Melanie", "Serenity", "Khloe",
                 "Gabrielle", "Paige", "Mya", "Eva" };
        }
        public static string[] GetRandomWesternSurnameSet()
        {
            return new string[] {
                "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis",
                "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas",
                "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", 
                "Martinez", "Robinson", "Clark", "Rodriguez", "Lewis", "Lee", 
                "Walker", "Hall", "Allen", "Young", "Hernandez", "King", 
                "Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker",
                "Gonzalez", "Nelson", "Carter", "Mitchell", "Perez", 
                "Roberts", "Turner", "Phillips", "Campbell", "Parker",
                "Evans", "Edwards", "Collins", "Stewart", "Sanchez", "Morris",
                "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy",
                "Bailey", "Rivera", "Cooper", "Richardson", "Cox", "Howard",
                "Ward", "Torres", "Peterson", "Gray", "Ramirez", "James", 
                "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett",
                "Wood", "Barnes", "Ross", "Henderson", "Coleman", "Jenkins",
                "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores",
                "Washington", "Butler", "Simmons", "Foster", "Gonzales", 
                "Bryant", "Alexander", "Russell", "Griffin", "Diaz", "Hayes" };
        }
        public string GetRandomFirstName(Sex sexPassed)
        {
            string nameResult = string.Empty;
            switch (sexPassed)
            {
                case Sex.Female:
                    nameResult = GetRandomFemaleFirstNameSet()[ValueGen.Next(0, GetRandomFemaleFirstNameSet().Length)];
                    break;

                case Sex.Male:
                    nameResult = GetRandomMaleFirstNameSet()[ValueGen.Next(0, GetRandomMaleFirstNameSet().Length)];
                    break;

                case Sex.None:
                    if (ValueGen.Next(0, 2) == 0)
                    {
                        nameResult = GetRandomFemaleFirstNameSet()[ValueGen.Next(0, GetRandomFemaleFirstNameSet().Length)];
                    }
                    else
                    {
                        nameResult = GetRandomMaleFirstNameSet()[ValueGen.Next(0, GetRandomMaleFirstNameSet().Length)];
                    }
                    break;
            }
            return nameResult;
        }
        public string[] GetName(Sex nameSex)
        {
            string[] firstNameList = new string[0];
            string[] lastNameList = GetRandomWesternSurnameSet();
            
            switch (nameSex)
            {
                case Sex.Female:
                    firstNameList = GetRandomFemaleFirstNameSet();
                    break;
                case Sex.Male:
                    firstNameList = GetRandomMaleFirstNameSet();
                    break;
                case Sex.None:
                    firstNameList = CollectionManipulation.CombineArrays<string>(GetRandomMaleFirstNameSet(),
                        GetRandomFemaleFirstNameSet());
                    break;
                default:
                    firstNameList = CollectionManipulation.CombineArrays<string>(GetRandomMaleFirstNameSet(),
                        GetRandomFemaleFirstNameSet());
                    break;
            }

            int firstNameIndex = ValueGen.Next(0, firstNameList.Length);
            int middleNameIndex = ValueGen.Next(0, firstNameList.Length);
            int lastNameIndex = ValueGen.Next(0, lastNameList.Length);

            return new string[] { firstNameList[firstNameIndex], firstNameList[middleNameIndex],
                lastNameList[lastNameIndex] };
        }

        public List<string> GetRandomSocialSecurityNumbers(int countOfSSNsToGet)
        {
            List<string> randomSSNList = new List<string>();
            if (countOfSSNsToGet > 0)
            {
                long currentSSN = 10000000;
                int randomIncrementWidth = 1000000000 / countOfSSNsToGet;
                int randomIncrementValue = ValueGen.Next(0, (int)currentSSN);
                currentSSN += (long)randomIncrementValue;
                randomSSNList.Add(currentSSN.ToString().PadLeft(9, '0'));

                for (int i = 1; i < countOfSSNsToGet; i++)
                {
                    randomIncrementValue = ValueGen.Next(0, randomIncrementWidth);
                    currentSSN += (long)randomIncrementValue;
                    randomSSNList.Add(currentSSN.ToString().PadLeft(9, '0'));
                }
            }

            return randomSSNList;
        }

        public Sex GetRandomSex()
        {
            Sex sexResult = Sex.None;
            if (sexDistribution.Length > 0)
            {
                int maxValue = CollectionManipulation.SumArray(sexDistribution);
                int randomSex = ValueGen.Next(0, maxValue);

                if (randomSex < sexDistribution[0])
                {
                    sexResult = Sex.Male;
                }
                else
                {
                    sexResult = Sex.Female;
                }
            }
            else
            {
                sexResult = (Sex)ValueGen.Next(1, 3);
            }
            return sexResult;
        }
        public List<Sex> GetRandomSexes(int countOfSexesToGet)
        {
            List<Sex> randomSexes = new List<Sex>();

            if ((sexDistribution != null) && (sexDistribution.Length > 0))
            {
                int maxValue = CollectionManipulation.SumArray(sexDistribution);
                int randomSex = 0;
                Sex sexResult = Sex.None;
                for (int i = 0; i < countOfSexesToGet; i++)
                {
                    randomSex = ValueGen.Next(0, maxValue);
                    if (randomSex < sexDistribution[0])
                    {
                        sexResult = (Sex)1;
                    }
                    else
                    {
                        sexResult = (Sex)2;
                    }
                    randomSexes.Add(sexResult);
                }
            }

            return randomSexes;
        }
    }
}
