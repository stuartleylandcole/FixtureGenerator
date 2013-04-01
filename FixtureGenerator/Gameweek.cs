using System;
using System.Collections.Generic;

namespace FixtureGenerator
{
    public class Gameweek
    {
        private readonly int _week;
        private readonly List<Fixture> _fixtures;

        public Gameweek(int week, List<Fixture> fixtures)
        {
            _week = week;
            _fixtures = fixtures;
        }

        public List<Fixture> Fixtures
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
