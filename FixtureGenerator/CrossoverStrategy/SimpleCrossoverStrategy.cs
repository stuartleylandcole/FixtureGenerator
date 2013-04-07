namespace FixtureGenerator.CrossoverStrategy
{
    public class SimpleCrossoverStrategy<T> : ICrossoverStrategy<T> where T: ICrossoverable
    {
        public T CrossOver(T parent1, T parent2)
        {
            return parent1;
        }
    }
}
