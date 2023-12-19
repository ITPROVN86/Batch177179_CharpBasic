using DemoConsole.Lab4;
using DemoConsole.Session11;
using DemoConsole.Session13;
using ABC = Automotive;
namespace DemoConsole
{
    public class Program
    {
        static (int Max, int Min) FindMaxMin(int[] numbers)
        {
            return (numbers.Max(), numbers.Min());
        }

        public static void Main(string[] args)
        {
            //new CalculateRectangle().Run();
            int[] numbers = { 1, 2, 3, 4, 5 };
            var result = FindMaxMin(numbers);
            Console.WriteLine($"Max: {result.Max}, Min: {result.Min}");

            Console.ReadLine();
        }
    }

}

namespace Automotive
{
    public class SpareParts { 
        string _spareName; 
        public SpareParts() { _spareName = "Gear Box"; } 
        public void Display() { 
            Console.WriteLine("Spare Part name: " + _spareName); 
        } 
    }
}

