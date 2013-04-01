using System.Collections.Generic;
using System.Linq;

namespace FixtureGenerator.Criteria
{
    public class CriteriaCalculatorResult
    {
        private readonly List<CriteriaBase> _matchingCriteria;
        private readonly List<CriteriaBase> _failedCriteria;

        public CriteriaCalculatorResult(List<CriteriaBase> matchingCriteria, List<CriteriaBase> failedCriteria)
        {
            _matchingCriteria = matchingCriteria;
            _failedCriteria = failedCriteria;
        }

        public bool IsValid
        {
            get { return _failedCriteria.Count == 0; }
        }

        public int Score
        {
            get { return _matchingCriteria.Sum(c => c.Score); }
        }

        public List<CriteriaBase> MatchingCriteria
        {
            get { return _matchingCriteria; }
        }

        public List<CriteriaBase> FailedCriteria
        {
            get { return _failedCriteria; }
        }
    }
}
