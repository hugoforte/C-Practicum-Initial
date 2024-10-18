using Application;

namespace Practicum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new Server(new DishManager());
            while (true)
            {
                var order = Console.ReadLine();
                string output = server.TakeOrder(order);
                Console.WriteLine(output);
            }
        }
    }
}