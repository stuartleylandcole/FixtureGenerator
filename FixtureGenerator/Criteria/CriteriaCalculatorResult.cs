using System.Collections.Generic;

namespace FixtureGenerator.Criteria
{
    public class CriteriaCalculatorResult<T> where T : ICrossoverable
    {
        private readonly List<CriteriaBase<T>> _matchingCriteria;
        private readonly List<CriteriaBase<T>> _failedCriteria;
        private readonly int _score;

        public CriteriaCalculatorResult(List<CriteriaBase<T>> matchingCriteria, List<CriteriaBase<T>> failedCriteria, int score)
        {
            _matchingCriteria = matchingCriteria;
            _failedCriteria = failedCriteria;
            _score = score;
        }

        public bool IsValid
        {
            get { return _failedCriteria.Count == 0; }
        }

        public int Score
        {
            get { return _score; }
        }

        public List<CriteriaBase<T>> MatchingCriteria
        {
            get { return _matchingCriteria; }
        }

        public List<CriteriaBase<T>> FailedCriteria
        {
            get { return _failedCriteria; }
        }
    }
}
