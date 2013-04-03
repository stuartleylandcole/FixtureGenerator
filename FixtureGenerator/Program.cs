﻿using System.Collections.Generic;
using System;
using FixtureGenerator.Criteria;

namespace FixtureGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = GetTeams();
            var generator = new FixtureGenerator(teams, 2);
            var season = generator.GenerateFixtures();
            DisplayFixtures(season);

            var calculator = new CriteriaCalculator(season);
            var result = calculator.Calculate();
            DisplayResults(result);

            Console.ReadLine();
        }

        private static List<Team> GetTeams()
        {
            var topFourGrouping = new TableGrouping("Top 4", 1);
            var europaLeagueGrouping = new TableGrouping("Europa League", 2);
            var upperMidTable = new TableGrouping("Upper-mid table", 3);
            var lowerMidTable = new TableGrouping("Lower-mid table", 4);
            var relegationCandidates = new TableGrouping("Relegation candidates", 5);

            var teams = new List<Team>();

            //1-4
            teams.Add(new Team("Manchester United", topFourGrouping));
            teams.Add(new Team("Manchester City", topFourGrouping));
            teams.Add(new Team("Chelsea", topFourGrouping));
            teams.Add(new Team("Arsenal", topFourGrouping));

            //5-7
            teams.Add(new Team("Tottenham", europaLeagueGrouping));
            teams.Add(new Team("Everton", europaLeagueGrouping));
            teams.Add(new Team("Liverpool", europaLeagueGrouping));

            //8-12
            teams.Add(new Team("West Brom", upperMidTable));
            teams.Add(new Team("Swansea", upperMidTable));
            teams.Add(new Team("Fulham", upperMidTable));
            teams.Add(new Team("Stoke", upperMidTable));
            teams.Add(new Team("Newcastle", upperMidTable));

            //13-16
            teams.Add(new Team("West Ham", lowerMidTable));
            teams.Add(new Team("Southampton", lowerMidTable));
            teams.Add(new Team("Norwich", lowerMidTable));
            teams.Add(new Team("Sunderland", lowerMidTable));

            //17-20
            teams.Add(new Team("Wigan", relegationCandidates));
            teams.Add(new Team("Aston Villa", relegationCandidates));
            teams.Add(new Team("QPR", relegationCandidates));
            teams.Add(new Team("Reading", relegationCandidates));

            return teams;
        }

        private static void DisplayFixtures(Season season)
        {
            string description = "";
            foreach (MatchDay matchDay in season.MatchDays)
            {
                description += matchDay.GetDescription() + Environment.NewLine;
            }

            Console.Write(description);
        }

        private static void DisplayResults(CriteriaCalculatorResult result)
        {
            Console.WriteLine("Results" + Environment.NewLine);

            if (result.MatchingCriteria.Count > 0)
            {
                Console.WriteLine("Matching criteria:");
                foreach (var criteria in result.MatchingCriteria)
                {
                    Console.WriteLine(criteria.Description);
                }
            }

            if (result.FailedCriteria.Count > 0)
            {
                Console.WriteLine("Failed criteria:");
                foreach (var criteria in result.FailedCriteria)
                {
                    Console.WriteLine(criteria.Description);
                }
            }
            Console.WriteLine("Score: {0}", result.Score);
            Console.Write("Valid: {0}", result.IsValid);
        }
    }
}
