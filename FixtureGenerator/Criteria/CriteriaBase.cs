using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator.Criteria
{
    public abstract class CriteriaBase
    {
        private readonly List<Gameweek> _gameweeks;

        protected CriteriaBase(List<Gameweek> gameweeks)
        {
            _gameweeks = gameweeks;
        }

        public abstract string Description { get; }
        protected abstract Func<Gameweek, bool> Criteria { get; }
        protected abstract int Multiplier { get; }
        protected abstract bool Mandatory { get; }

        public bool PassesCriteria
        {
            get
            {
                if (Mandatory && MatchesFound)
                {
                    return false;
                }

                return true;
            }
        }

        public int Score
        {
            get { return NumberOfMatches * Multiplier; }
        }

        private bool MatchesFound
        {
            get { return NumberOfMatches > 0; }
        }

        private int NumberOfMatches
        {
            get { return _gameweeks.Count(Criteria); }
        }
    }
}
