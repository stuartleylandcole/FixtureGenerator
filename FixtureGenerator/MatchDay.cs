using System;
using System.Collections.Generic;

namespace FixtureGenerator
{
    public class MatchDay
    {
        private readonly int _week;
        private readonly List<Fixture> _fixtures;

        public MatchDay(int week, List<Fixture> fixtures)
        {
            _week = week;
            _fixtures = fixtures;
        }

        public IEnumerable<Fixture> Fixtures
        {
            get { return _fixtures; }
        }

        public string GetDescription()
        {
            string desc = "Gameweek " + _week + Environment.NewLine;

            foreach (Fixture fixture in _fixtures)
            {
                desc += fixture.GetDescription() + Environment.NewLine;
            }

            return desc;
        }
    }
}
