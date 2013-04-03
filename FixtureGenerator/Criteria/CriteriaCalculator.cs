using System.Collections.Generic;

namespace FixtureGenerator.Criteria
{
    public class CriteriaCalculator
    {
        private readonly Season _season;

        public CriteriaCalculator(Season season)
        {
            _season = season;
        }

        public CriteriaCalculatorResult Calculate()
        {
            var matchedCriteria = new List<CriteriaBase>();
            var failedCriteria = new List<CriteriaBase>();
            var allCriteria = GetAllCriteria();
            foreach (var criteria in allCriteria)
            {
                if (criteria.PassesCriteria)
                {
                    matchedCriteria.Add(criteria);
                }
                else
                {
                    failedCriteria.Add(criteria);
                }
            }

            return new CriteriaCalculatorResult(matchedCriteria, failedCriteria);
        }

        private IEnumerable<CriteriaBase> GetAllCriteria()
        {
            var criteria = new List<CriteriaBase>();
            criteria.Add(new SuperSundayCriteria(_season));

            return criteria;
        }
    }
}
