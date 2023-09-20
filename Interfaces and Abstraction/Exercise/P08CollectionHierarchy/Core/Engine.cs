using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models;
using CollectionHierarchy.Models.Interfaces;

namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            string[] inputWord = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(Console.ReadLine());
            foreach (string word in inputWord)
            {
                Console.Write($"{addCollection.Add(word)} ");
            }
            Console.WriteLine();
            foreach (string word in inputWord)
            {
                Console.Write($"{addRemoveCollection.Add(word)} ");
            }
            Console.WriteLine();
            foreach (string word in inputWord)
            {
                Console.Write($"{myList.Add(word)} ");
            }
            Console.WriteLine();



            for (int i = 0; i < n; i++)
            {
                Console.Write($"{addRemoveCollection.Remove()} ");
            }
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{myList.Remove()} ");
            }
        }
    }
}
