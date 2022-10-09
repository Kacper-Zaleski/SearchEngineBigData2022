namespace SearchEngine.Calculation.SearchEngine.Core.Algorithm
{
    public interface IIdGenerator<TId>
    {
        TId Next(string parameter);
    }
}