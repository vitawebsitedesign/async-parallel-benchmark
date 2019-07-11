using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestAsync
{
    class Program
    {
        private static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                var sw = Stopwatch.StartNew();
                for (var i = 0; i < 10; i++)
                {
                    await TestAsyncParallel();
                    sw.Stop();
                    Console.WriteLine($"Took {sw.ElapsedMilliseconds}ms");
                    sw.Restart();
                }
                Console.ReadKey();
            }).GetAwaiter().GetResult();
        }

        private static async Task TestAsyncSequential()
        {
            await EmptyTask();
            await EmptyTask();
            await EmptyTask();
        }

        private static async Task TestAsyncParallel()
        {
            await Task.WhenAll(EmptyTask(), EmptyTask(), EmptyTask());
        }

        private static async Task EmptyTask()
        {
            await Task.Delay(1000);
        }
    }
}
