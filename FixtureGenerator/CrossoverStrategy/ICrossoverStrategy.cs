namespace FixtureGenerator.CrossoverStrategy
{
    interface ICrossoverStrategy<T> where T : ICrossoverable
    {
        T CrossOver(T parent1, T parent2);
    }
}
