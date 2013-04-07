using System.Collections.Generic;

namespace FixtureGenerator
{
    public class Season : ICrossoverable
    {
        private readonly IEnumerable<MatchDay> _matchDays;

        public Season(IEnumerable<MatchDay> matchDays)
        {
            _matchDays = matchDays;
        }

        public IEnumerable<MatchDay> MatchDays
        {
            get { return _matchDays; }
        }

        public IEnumerable<MatchDay> Chromosomes
        {
            get { return _matchDays; }
        }
    }
}
