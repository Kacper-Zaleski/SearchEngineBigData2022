using Indexer.Models;
using MySearchEngine.Core.Analyzer;
using SearchEngine.Calculation.Calculation;
using System.Diagnostics;

class Program
{
    private static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        IInvertedIndex index = new IndexerProcessor().CreateIndex();
        stopwatch.Stop();
        Console.WriteLine($"Elapsed Time of indexing: {stopwatch.ElapsedMilliseconds} ms. Number of indexes {index.CountAllIndexes()}");
        stopwatch.Start();

        Console.WriteLine("Searching: ");
        var result = index.Search("szlachecki");

        foreach (Page p in result)
            Console.WriteLine($"Znaleziono {p.Title}");
        stopwatch.Stop();
        Console.WriteLine($"Searching: {stopwatch.ElapsedMilliseconds} ms");

    }
}