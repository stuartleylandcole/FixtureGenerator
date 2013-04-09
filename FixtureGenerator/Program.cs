using System.Collections.Generic;
using System;
using System.Linq;
using FixtureGenerator.Criteria;
using GeneticAlgorithm.Criteria;
using GeneticAlgorithm.CrossoverStrategy;
using GeneticAlgorithm.SelectionStrategy;
using GeneticAlgorithm;

namespace FixtureGenerator
{
    class Program
    {
        private const int NumberOfSeasons = 1000;
        private const int NumberOfGenerations = 100;
        private const int NumberOfChildrenPerGeneration = 200;

        static void Main(string[] args)
        {
            var teams = GetTeams();
            var generator = new FixtureGenerator(teams, 2);

            var seasons = new List<Season>();
            for (int i = 0; i < NumberOfSeasons; i++)
            {
                seasons.Add(generator.GenerateFixtures());
            }

            var criteria = GetCriteria();
            var seasonsCrossedOver = new List<Season>(seasons);
            for (int i = 0; i < NumberOfGenerations; i++)
            {
                var simpleCrossover = new SimpleCrossoverStrategy<Season, MatchDay>();
                var simpleSelection = new SimpleSelectionStrategy<Season, MatchDay>();
                var populationGenerator = new PopulationGenerator<Season, MatchDay>(seasonsCrossedOver, NumberOfChildrenPerGeneration, simpleCrossover, simpleSelection);
                seasonsCrossedOver = populationGenerator.Generate();
                string statistics = populationGenerator.GetStatistics(criteria);
                Console.WriteLine("Statistics for generation " + (i + 1));
                Console.WriteLine(statistics);
            }

            var bestSeason = seasonsCrossedOver.OrderByDescending(season => new CriteriaCalculator<Season, MatchDay>(season, criteria).Calculate().Score).FirstOrDefault();

            DisplayFixtures(bestSeason);

            var calculator = new CriteriaCalculator<Season, MatchDay>(bestSeason, criteria);
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

            return new List<Team>
                {
                    //1-4
                    new Team("Manchester United", topFourGrouping),
                    new Team("Manchester City", topFourGrouping),
                    new Team("Chelsea", topFourGrouping),
                    new Team("Arsenal", topFourGrouping),

                    //5-7
                    new Team("Tottenham", europaLeagueGrouping),
                    new Team("Everton", europaLeagueGrouping),
                    new Team("Liverpool", europaLeagueGrouping),

                    //8-12
                    new Team("West Brom", upperMidTable),
                    new Team("Swansea", upperMidTable),
                    new Team("Fulham", upperMidTable),
                    new Team("Stoke", upperMidTable),
                    new Team("Newcastle", upperMidTable),

                    //13-16
                    new Team("West Ham", lowerMidTable),
                    new Team("Southampton", lowerMidTable),
                    new Team("Norwich", lowerMidTable),
                    new Team("Sunderland", lowerMidTable),

                    //17-20
                    new Team("Wigan", relegationCandidates),
                    new Team("Aston Villa", relegationCandidates),
                    new Team("QPR", relegationCandidates),
                    new Team("Reading", relegationCandidates)
                };
        }

        private static IList<CriteriaBase<Season, MatchDay>> GetCriteria()
        {
            return new List<CriteriaBase<Season, MatchDay>>
                {
                    new SuperSundayCriteria()
                };
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

        private static void DisplayResults(CriteriaCalculatorResult<Season, MatchDay> result)
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
