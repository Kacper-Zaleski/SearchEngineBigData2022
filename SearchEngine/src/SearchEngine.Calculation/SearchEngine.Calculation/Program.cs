using MySearchEngine.Core.Analyzer;
using SearchEngine.Calculation.Calculation;
using System.Diagnostics;

class Program
{
    private static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        IndexerProcessor index = new IndexerProcessor();
        stopwatch.Stop();
        Console.WriteLine($"Elapsed Time of indexing: {stopwatch.ElapsedMilliseconds} ms. Number of documents {index.CountDocumentsCount()}");
        stopwatch.Start();
    }
}