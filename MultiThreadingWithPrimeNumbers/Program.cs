using MultiThreadingWithPrimeNumbers.Implementations;
using System.Diagnostics;

Console.WriteLine("Let's use multi-threadings to find prime numbers");

var sw = new Stopwatch();

sw.Start();
var result = SequencialImplementation.PrimesInRange(200, 800000);
sw.Stop();
Console.WriteLine("Sequencial implementation");
Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");

sw.Reset();
sw.Start();
result = WithThreads.PrimesInRange(200, 800000);
sw.Stop();
Console.WriteLine("With threads");
Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");

sw.Reset();
sw.Start();
result = WithThreadsNoLock.PrimesInRange2_1(200, 800000);
sw.Stop();
Console.WriteLine("With threads (no lock)");
Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");

sw.Reset();
sw.Start();
result = WithThreadsInterlocked.PrimesInRange(200, 800000);
sw.Stop();
Console.WriteLine("With threads (interlocked)");
Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");

sw.Reset();
sw.Start();
result = ParallelFor.PrimesInRange(200, 800000);
sw.Stop();
Console.WriteLine("ParallelFor)");
Console.WriteLine($"{result} prime numbers found in {sw.ElapsedMilliseconds / 1000} seconds ({Environment.ProcessorCount} processors).");


