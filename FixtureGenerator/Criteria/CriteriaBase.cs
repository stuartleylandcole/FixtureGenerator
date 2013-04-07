using System;
using System.Linq;

namespace FixtureGenerator.Criteria
{
    public abstract class CriteriaBase<T> where T : ICrossoverable
    {
        public abstract string Description { get; }
        protected abstract Func<MatchDay, bool> Criteria { get; }
        protected abstract int Multiplier { get; }
        protected abstract bool Mandatory { get; }

        public bool PassesCriteria(T season)
        {
            var matchesFound = GetNumberOfCriteriaMatches(season) > 0;
            return !Mandatory || matchesFound;
        }

        public int CalculateScore(T season)
        {
            return GetNumberOfCriteriaMatches(season) * Multiplier;
        }

        private int GetNumberOfCriteriaMatches(T season)
        {
            return season.Chromosomes.Count(Criteria);
        }
    }
}
