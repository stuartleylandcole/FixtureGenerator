namespace FixtureGenerator
{
    public class Team
    {
        private readonly string _name;
        private readonly TableGrouping _tableGrouping;

        public Team(string name, TableGrouping tableGrouping)
        {
            _name = name;
            _tableGrouping = tableGrouping;
        }

        public string Name
        {
            get { return _name; }
        }

        public TableGrouping TableGrouping
        {
            get { return _tableGrouping; }
        }

        public override bool Equals(object obj)
        {
            var otherTeam = obj as Team;
            if (otherTeam == null)
            {
                return false;
            }
            return _name == otherTeam.Name;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }
    }
}
