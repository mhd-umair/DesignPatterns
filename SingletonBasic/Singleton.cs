using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonBasic
{
    class Singleton
    {
        // The single instance of the class is stored in this static field.
        private static Singleton _instance = null;

        // Private constructor prevents instantiation from other classes.
        private Singleton()
        {
            Console.WriteLine("Singleton instance created");
        }

        // Public method to provide access to the instance.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
