using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator
{
    public interface ICrossoverable
    {
        IEnumerable<MatchDay> Chromosomes { get; }
    }
}
