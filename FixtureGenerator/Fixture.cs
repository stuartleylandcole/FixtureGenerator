using GeneticAlgorithm;

namespace FixtureGenerator
{
    public class Fixture : IGene
    {
        private readonly Team _homeTeam;
        private readonly Team _awayTeam;

        public Fixture(Team homeTeam, Team awayTeam)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
        }

        public Team HomeTeam
        {
            get { return _homeTeam; }
        }

        public Team AwayTeam
        {
            get { return _awayTeam; }
        }

        public string GetDescription()
        {
            return _homeTeam.Name + " v " + _awayTeam.Name;
        }

        public bool IsSameAs(IGene other)
        {
            var otherFixture = other as Fixture;
            if (otherFixture == null)
            {
                return false;
            }

            var otherHomeTeam = otherFixture.HomeTeam;
            var otherAwayTeam = otherFixture.AwayTeam;
            return HomeTeam.Equals(otherHomeTeam) && AwayTeam.Equals(otherAwayTeam);
        }
    }
}
