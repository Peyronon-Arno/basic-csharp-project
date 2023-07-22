using Bibliotheque.DAL;

namespace Bibliotheque
{
    public class Singleton
    {
        private static ContextDA instance;
        private static readonly object lockObject = new object();

        private Singleton()
        {
        }

        public static ContextDA GetInstance()
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ContextDA();
                    }
                }
            }
            return instance;
        }
    }
}
