using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FixtureGenerator.Criteria;
using FixtureGenerator.CrossoverStrategy;

namespace FixtureGenerator
{
    class PopulationGenerator<T> where T : ICrossoverable
    {
// ReSharper disable StaticFieldInGenericType
        private static readonly Random Random = new Random();
// ReSharper restore StaticFieldInGenericType

        private readonly List<T> _seasons;
        private readonly int _numberOfChildrenToCreate;
        private readonly ICrossoverStrategy<T> _crossoverStrategy;

        public PopulationGenerator(List<T> seasons, int numberOfChildrenToCreate, ICrossoverStrategy<T> crossoverStrategy)
        {
            _seasons = seasons;
            _numberOfChildrenToCreate = numberOfChildrenToCreate;
            _crossoverStrategy = crossoverStrategy;
        }

        public List<T> Generate()
        {
            var newPopulation = new List<T>();
            for (int i = 0; i < _numberOfChildrenToCreate; i++)
            {
                var parent1 = SelectParent();
                var parent2 = SelectParent();
            }

            //return newPopulation;
            return _seasons;
        }

        private T SelectParent()
        {
            return _seasons[Random.Next(0, _seasons.Count - 1)];
        }

        private T Crossover(T parent1, T parent2)
        {
            return parent1;
        }

        public string GetStatistics(IEnumerable<CriteriaBase<T>> criteria)
        {
            var average = _seasons.Average(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);
            var min = _seasons.Min(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);
            var max = _seasons.Max(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);

            return "Min: " + min + ". Max: " + max + ". Average: " + average;
        }
    }
}
