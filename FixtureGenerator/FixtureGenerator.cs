using System.Collections.Generic;
using System;

namespace FixtureGenerator
{
    public class FixtureGenerator
    {
        private readonly static Random Random = new Random();

        private readonly List<Team> _teams;
        private readonly int _numberOfTimesToPlayEachTeam;

        public FixtureGenerator(List<Team> teams, int numberOfTimesToPlayEachTeam)
        {
            _teams = teams;
            _numberOfTimesToPlayEachTeam = numberOfTimesToPlayEachTeam;
        }

        public Season GenerateFixtures()
        {
            var matchDays = new List<MatchDay>();
            int numberOfGamesWeeks = (_teams.Count * _numberOfTimesToPlayEachTeam ) - _numberOfTimesToPlayEachTeam;

            for (int i = 0; i <= numberOfGamesWeeks; i++)
            {
                matchDays.Add(GenerateFixturesForMatchDay(i));
            }

            return new Season(matchDays);
        }

        private MatchDay GenerateFixturesForMatchDay(int week)
        {
            var fixtures = new List<Fixture>();

            var teams = new List<Team>(_teams);
            while (teams.Count > 0)
            {
                Team homeTeam = SelectTeam(teams);
                Team awayTeam = SelectTeam(teams);
                fixtures.Add(new Fixture(homeTeam, awayTeam));
            }

            return new MatchDay(week, fixtures);
        }

        private Team SelectTeam(List<Team> teams)
        {
            int teamIndex = Random.Next(0, teams.Count);
            Team team = teams[teamIndex];
            teams.RemoveAt(teamIndex);
            return team;
        }
    }
}
