using System;
using System.Collections.Generic;

namespace MIProject
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {

            System.IO.StreamReader file = new System.IO.StreamReader("newdata2.txt");
            

            int n = Int32.Parse(file.ReadLine());
            int m = Int32.Parse(file.ReadLine());

            int mario_x = Int32.Parse(file.ReadLine());
            int mario_y = Int32.Parse(file.ReadLine());


            int diamonds_count = Int32.Parse(file.ReadLine());
            List<int> diamonds_list = new List<int>(diamonds_count * 2);
            for (int i = 0; i < diamonds_count * 2; i++)
            {
                diamonds_list.Add(Int32.Parse(file.ReadLine()));
            }

            int rocks_count = Int32.Parse(file.ReadLine());
            List<int> rocks_list = new List<int>(rocks_count * 2);
            for (int i = 0; i < rocks_count*2; i++ )
                rocks_list.Add(Int32.Parse(file.ReadLine()));

            int concrete_count = Int32.Parse(file.ReadLine());
            List<int> concrete_list = new List<int>(concrete_count * 2);
            for (int i = 0; i < concrete_count * 2; i++)
                concrete_list.Add(Int32.Parse(file.ReadLine()));

            file.Close();
            using (Game1 game = new Game1(n, m, mario_x, mario_y, diamonds_count, diamonds_list,
                                                                    rocks_count, rocks_list, concrete_count, concrete_list))
                {
                    game.Run();
                }
        }
    }
#endif
}

