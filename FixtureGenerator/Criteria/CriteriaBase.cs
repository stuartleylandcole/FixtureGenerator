using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator.Criteria
{
    public abstract class CriteriaBase<T> where T : ICrossoverable
    {
        protected CriteriaBase()
        {}

        public abstract string Description { get; }
        protected abstract Func<MatchDay, bool> Criteria { get; }
        protected abstract int Multiplier { get; }
        protected abstract bool Mandatory { get; }

        public bool PassesCriteria(T season)
        {
            bool matchesFound = NumberOfMatches(season) > 0;
            if (Mandatory && !matchesFound)
            {
                return false;
            }

            return true;
        }

        public int GetScore(T season)
        {
            return NumberOfMatches(season) * Multiplier;
        }

        private int NumberOfMatches(T season)
        {
            return season.Chromosomes.Count(Criteria);
        }
    }
}
