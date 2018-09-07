namespace Example_02
{
    public class Singleton
    {
        private Singleton() { }

        public static readonly Singleton Instance = new Singleton();
    }
}