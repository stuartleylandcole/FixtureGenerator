using System.Collections.Generic;

namespace FixtureGenerator
{
    public interface ICrossoverable
    {
        IEnumerable<MatchDay> Chromosomes { get; }
    }
}
