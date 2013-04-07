using System;
using System.Linq;

namespace FixtureGenerator.Criteria
{
    public class SuperSundayCriteria : CriteriaBase<Season>
    {
        public override string Description
        {
            get { return "Super Sunday"; }
        }

        protected override Func<MatchDay, bool> Criteria
        {
            get { return matchDay =>
                matchDay.Fixtures.Count(
                    fixture =>
                    fixture.HomeTeam.TableGrouping.Ordering == 1 && fixture.AwayTeam.TableGrouping.Ordering == 1) > 1; }
        }

        protected override int Multiplier
        {
            get { return 10; }
        }

        protected override bool Mandatory
        {
            get { return false; }
        }
    }
}
