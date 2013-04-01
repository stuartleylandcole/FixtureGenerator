using System;
using System.Collections.Generic;
using System.Linq;

namespace FixtureGenerator.Criteria
{
    public class SuperSundayCriteria : CriteriaBase
    {
        public SuperSundayCriteria(List<Gameweek> gameweeks) : base(gameweeks)
        {
        }

        public override string Description
        {
            get { return "Super Sunday"; }
        }

        protected override Func<Gameweek, bool> Criteria
        {
            get { return gameweek =>
                gameweek.Fixtures.Count(
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
