namespace SingletonBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            instance1.ShowMessage("Hello from Singleton!");

            // Check if instance1 and instance2 are the same
            if (instance1 == instance2)
            {
                Console.WriteLine("Both instances are the same.");
            }
        }
    }
}
