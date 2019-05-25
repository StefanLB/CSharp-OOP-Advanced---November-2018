using System;

namespace _10.Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split();

                if (i == 0)
                {
                    var name = input[0] + " " + input[1];
                    var address = input[2];
                    PrintTuple(new MyTuple<string, string>(name, address));
                }
                else if (i == 1)
                {
                    var name = input[0];
                    var countofBeers = int.Parse(input[1]);
                    PrintTuple(new MyTuple<string, int>(name, countofBeers));
                }
                else if (i == 2)
                {
                    var integer = int.Parse(input[0]);
                    var floatingPoint = double.Parse(input[1]);
                    PrintTuple(new MyTuple<int, double>(integer, floatingPoint));
                }
            }
        }

        private static void PrintTuple<T,U>(MyTuple<T, U> myTuple)
        {
            Console.WriteLine(myTuple.FirstItem + " -> " + myTuple.SecondItem);
        }
    }
}
