namespace FixtureGenerator
{
    public class TableGrouping
    {
        private readonly string _description;
        private readonly int _ordering;

        public TableGrouping(string description, int ordering)
        {
            _description = description;
            _ordering = ordering;
        }

        public int Ordering
        {
            get { return _ordering; }
        }
    }
}
