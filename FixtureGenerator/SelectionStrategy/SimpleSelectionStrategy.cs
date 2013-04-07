using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator.SelectionStrategy
{
    public class SimpleSelectionStrategy<T> : ISelectionStrategy<T> where T : ICrossoverable
    {
        // ReSharper disable StaticFieldInGenericType
        private static readonly Random Random = new Random();
        // ReSharper restore StaticFieldInGenericType

        public T SelectParent(IList<T> parents)
        {
            return parents[Random.Next(0, parents.Count - 1)];
        }
    }
}
