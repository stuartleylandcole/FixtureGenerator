namespace FixtureGenerator.CrossoverStrategy
{
    interface ICrossoverStrategy<T> where T : ICrossoverable
    {
        void CrossOver(T parent1, T parent2);
    }
}
