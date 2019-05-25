using System;

namespace _11.Threeuple
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
                    var city = input[3];
                    PrintTuple(new MyTuple<string, string, string>(name, address, city));
                }
                else if (i == 1)
                {
                    var name = input[0];
                    var countofBeers = int.Parse(input[1]);
                    bool drunk = input[2] == "drunk" ? true : false;
                    PrintTuple(new MyTuple<string, int, bool>(name, countofBeers, drunk));
                }
                else if (i == 2)
                {
                    var name = input[0];
                    var floatingPoint = double.Parse(input[1]);
                    var bank = input[2];
                    PrintTuple(new MyTuple<string, double, string>(name, floatingPoint, bank));
                }
            }
        }

        private static void PrintTuple<T, U, V>(MyTuple<T, U, V> tuple)
        {
            Console.WriteLine(tuple.FirstItem + " -> " + tuple.SecondItem + " -> " + tuple.ThirdItem);
        }
    }
}
