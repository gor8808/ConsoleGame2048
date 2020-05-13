using Game2048;
using System;
namespace ConsoleGame2048
{
    public class Program
    {
        static void Main(string[] args)
        {
            //// null <= null calls <= operator overloaded method of 
            //// Nullable<int> struct (the same as int?), the C# compiler
            //// always returns false when we try to compare (<, >, <=, >=) Nullable<T> with null
            //// Compiler wants to call <= of type int, but detecs null and produces IL as 
            //if(null <= null)
            //{
            //    Console.WriteLine("will not print");
            //}
            //else
            //{
            //    Console.WriteLine("will print");
            //}











            //Program program = new Program();
            //program.Start();
            if (null<=null)
            {
                Console.WriteLine("aa");
            }
            else
            {
                Console.WriteLine("bb");
            }
            //string s = new string('*', 5);
            //int[,,] vs = new int[5, 5,5];
            //Console.WriteLine(vs.Rank);
        }


        void Start()
        {
            Model model = new Model(10);
            model.Start();
            while (true)
            {
                Show(model);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.LeftArrow:
                        model.Left();
                        break;
                    case ConsoleKey.RightArrow:
                        model.Right();
                        break;
                    case ConsoleKey.UpArrow:
                        model.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        model.Down();
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
        }

        public void Show(Model model)
        {
            for (int y = 0; y < model.MapSize; y++)
            {
                for (int x = 0; x < model.MapSize; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);
                    int number = model.GetMap(x, y);
                    Console.Write(number == 0 ? ".   " : number.ToString() + "  ");

                }
            }
            Console.WriteLine();
            if (model.IsGameOver())
            {
                Console.WriteLine("Game Over ");
            }
            else
            {
                Console.WriteLine("Still play");
            }
        }

    }
}
