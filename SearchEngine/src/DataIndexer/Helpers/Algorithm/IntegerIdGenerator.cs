namespace DataIndexer.Helpers.Algorithm
{
    public interface IIdGenerator<TId>
    {
        TId Next(string parameter);
    }
}