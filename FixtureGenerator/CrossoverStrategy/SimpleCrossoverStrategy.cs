using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator.CrossoverStrategy
{
    public class SimpleCrossoverStrategy<T> : ICrossoverStrategy<T> where T: ICrossoverable
    {
        public void CrossOver(T parent1, T parent2)
        {
            throw new NotImplementedException();
        }
    }
}
