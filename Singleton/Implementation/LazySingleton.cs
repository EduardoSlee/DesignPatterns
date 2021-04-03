using System;

namespace Singleton.Implementation
{
    //Final version - using .NET 4's Lazy<T> type. It implicitly uses LazyThreadSafetyMode.ExecutionAndPublication as the thread safety mode for the Lazy<Singleton>.
    //Source: https://csharpindepth.com/articles/singleton
    public sealed class LazySingleton
    {
        //reading this will initialize the instance
        private static readonly Lazy<LazySingleton> _lazy = new Lazy<LazySingleton>(() => new LazySingleton());
        public static LazySingleton Instance
        {
            get
            {
                Logger.Log("Lazy Instance called.");
                return _lazy.Value;
            }
        }

        private LazySingleton()
        {
            //Cannot be created except within this class
            Logger.Log("Lazy Constructor invoked.");
        }
    }
}