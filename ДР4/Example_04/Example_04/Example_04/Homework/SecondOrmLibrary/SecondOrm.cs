namespace Example_04.Homework.SecondOrmLibrary
{
    public class SecondOrm : ISecondOrm
    {
        public ISecondOrmContext Context { get; }

        public SecondOrm()
        {
            Context = new Context();
        }
    }
}
