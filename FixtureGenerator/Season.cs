using System.Collections.Generic;

namespace FixtureGenerator
{
    public class Season
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
    }
}
