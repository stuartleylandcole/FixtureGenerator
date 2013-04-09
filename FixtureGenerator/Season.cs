using System.Collections.Generic;
using GeneticAlgorithm;

namespace FixtureGenerator
{
    public class Season : IOrganism<MatchDay>
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
