namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,,] matrix = new int[5, 5, 5];
            Find find = new Find(matrix);
            find.PutRandomNumberOne(100);

            Console.WriteLine(find.FindQueue(2,3,2));
        }
    }
}
