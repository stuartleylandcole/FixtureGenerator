using System.Collections.Generic;

namespace FixtureGenerator.Criteria
{
    public class CriteriaCalculator<T> where T : ICrossoverable
    {
        private readonly T _entity;
        private readonly IEnumerable<CriteriaBase<T>> _criteria;

        public CriteriaCalculator(T entity, IEnumerable<CriteriaBase<T>> criteria)
        {
            _entity = entity;
            _criteria = criteria;
        }

        public CriteriaCalculatorResult<T> Calculate()
        {
            var matchedCriteria = new List<CriteriaBase<T>>();
            var failedCriteria = new List<CriteriaBase<T>>();
            int score = 0;

            foreach (var criteria in _criteria)
            {
                score += criteria.GetScore(_entity);

                if (criteria.PassesCriteria(_entity))
                {
                    matchedCriteria.Add(criteria);
                }
                else
                {
                    failedCriteria.Add(criteria);
                }
            }

            return new CriteriaCalculatorResult<T>(matchedCriteria, failedCriteria, score);
        }
    }
}
