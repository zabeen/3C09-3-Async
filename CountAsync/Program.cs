using System;
using System.Threading.Tasks;

namespace CountAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            var countTask = new WordCounter().CountNonExistentWordsAsync();
            int count = countTask.Result;

            Console.WriteLine($"{count} words in {(DateTime.Now-start).TotalMilliseconds}ms");
            Console.ReadLine();
        }
    }
}
