using System.Collections.Generic;

namespace FixtureGenerator.SelectionStrategy
{
    interface ISelectionStrategy<T> where T : ICrossoverable
    {
        T SelectParent(IList<T> parents);
    }
}
