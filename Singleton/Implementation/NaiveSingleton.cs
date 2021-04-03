namespace Singleton.Implementation
{
    //First version - not thread-safe
    public sealed class NaiveSingleton
    {
        private static NaiveSingleton? _instance;
        public static NaiveSingleton Instance
        {
            get
            {
                Logger.Log("Naive Instance called.");
                return _instance ??= new NaiveSingleton();
            }
        }

        private NaiveSingleton()
        {
            //Cannot be created except within this class
            Logger.Log("Naive Constructor invoked.");
        }
    }
}