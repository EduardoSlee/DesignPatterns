using System;
using System.Linq;
using System.Collections.Generic;
using Singleton.Implementation;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        //The best implementation in terms of speed and allocation is the LazyOfT implementation.
        static void Main(string[] args)
        {
            #region Input
            //Choose the Singleton Implementation
            Console.WriteLine("Choose one of the following singleton implementations to try.");
            Console.WriteLine("1. Naive Singleton");
            Console.WriteLine("2. Lazy Singleton");
            Console.WriteLine("Select a option: ");
            var singletonOption = Convert.ToInt32(Console.ReadLine().Trim());

            //Choose the type of test
            Console.WriteLine("Now choose one of the following type of test.");
            Console.WriteLine("1. Queued Instance Calls");
            Console.WriteLine("2. Parallel Instance Calls");
            Console.WriteLine("Select a option: ");
            var testOption = Convert.ToInt32(Console.ReadLine().Trim());
            #endregion

            #region Output
            if(singletonOption == 1) //Naive
            {
                if(testOption == 1) //Queued
                    TestNaiveQueuedInstanceCalls();
                else if(testOption == 2) //Parallel
                    TestNaiveParallelInstanceCalls();
            }
            else if(singletonOption == 2) //Lazy
            {
                if(testOption == 1) //Queued
                    TestLazyQueuedInstanceCalls();
                else if(testOption == 2) //Parallel
                    TestLazyParallelInstanceCalls();
            }
            else
            {
                throw new Exception("Unsupported singleton implementation");
                return;     
            }
            #endregion

            //Print result
            Logger.Output().ForEach(o => Console.WriteLine(o));
            Logger.Clear();
        }

        static void TestNaiveQueuedInstanceCalls()
        {
            Console.WriteLine("Test: Naive Queued Instance Calls:");
            var instance = NaiveSingleton.Instance;
            var instance2 = NaiveSingleton.Instance;
            var instance3 = NaiveSingleton.Instance;
        }

        static void TestLazyQueuedInstanceCalls()
        {
            Console.WriteLine("Test: Lazy Queued Instance Calls:");
            var instance = LazySingleton.Instance;
            var instance2 = LazySingleton.Instance;
            var instance3 = LazySingleton.Instance;
        }

        static void TestNaiveParallelInstanceCalls()
        {
            Console.WriteLine("Test: Naive Parallel Instance Calls:");
            Logger.DelayMilliseconds = 50; // configure logger to slow down the creation long enough to cause problems
            
            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<NaiveSingleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 6 };
            
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(NaiveSingleton.Instance);
            });
        }

        static void TestLazyParallelInstanceCalls()
        {
            Console.WriteLine("Test: Lazy Parallel Instance Calls:");
            Logger.DelayMilliseconds = 50; // configure logger to slow down the creation long enough to cause problems
            
            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<LazySingleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            
            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(LazySingleton.Instance);
            });
        }
    }
}
