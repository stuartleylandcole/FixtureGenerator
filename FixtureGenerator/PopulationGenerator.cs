using System;
using System.Collections.Generic;
using System.Linq;
using FixtureGenerator.Criteria;
using FixtureGenerator.CrossoverStrategy;
using FixtureGenerator.SelectionStrategy;

namespace FixtureGenerator
{
    class PopulationGenerator<T> where T : ICrossoverable
    {
        private readonly List<T> _parents;
        private readonly int _numberOfChildrenToCreate;
        private readonly ICrossoverStrategy<T> _crossoverStrategy;
        private readonly ISelectionStrategy<T> _selectionStrategy;

        public PopulationGenerator(List<T> parents, int numberOfChildrenToCreate, ICrossoverStrategy<T> crossoverStrategy, ISelectionStrategy<T> selectionStrategy)
        {
            _parents = parents;
            _numberOfChildrenToCreate = numberOfChildrenToCreate;
            _crossoverStrategy = crossoverStrategy;
            _selectionStrategy = selectionStrategy;
        }

        public List<T> Generate()
        {
            var newPopulation = new List<T>();
            for (int i = 0; i < _numberOfChildrenToCreate; i++)
            {
                var parent1 = _selectionStrategy.SelectParent(_parents);
                var parent2 = _selectionStrategy.SelectParent(_parents);

                var child = _crossoverStrategy.CrossOver(parent1, parent2);
                newPopulation.Add(child);
            }

            return newPopulation;
        }

        public string GetStatistics(IEnumerable<CriteriaBase<T>> criteria)
        {
            var average = _parents.Average(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);
            var min = _parents.Min(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);
            var max = _parents.Max(season => new CriteriaCalculator<T>(season, criteria).Calculate().Score);

            return "Min: " + min + ". Max: " + max + ". Average: " + average;
        }
    }
}
