using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Boards

    {
        public string[] Line = new string[8];

        Dictionary<int, string> pippo = new Dictionary<int, string>();



        public Boards()
        {
            string[,] box = new string[8, 8] { { "R", "N", "B", "K", "Q", "B", "N", "R" }, { "P", "P", "P", "P", "P", "P", "P", "P" }, { "0", "0", "0", "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "0", "0", "0", "0" }, { "0", "0", "0", "0", "0", "0", "0", "0" }, { "p", "p", "p", "p", "p", "p", "p", "p" }, { "r", "n", "b", "k", "q", "b", "n", "r" } };
            Console.WriteLine(box[1, 1], "|", box[1, 2], "|", box[1, 3], "|", box[1, 4], "|", box[1, 5], "|", box[1, 6], "|", box[1, 7], "|", box[1, 8]);
            Console.WriteLine(box[2, 1], "|", box[2, 2], "|", box[2, 3], "|", box[2, 4], "|", box[2, 5], "|", box[2, 6], "|", box[2, 7], "|", box[2, 8]);
            Console.WriteLine(box[3, 1], "|", box[3, 2], "|", box[3, 3], "|", box[3, 4], "|", box[3, 5], "|", box[3, 6], "|", box[3, 7], "|", box[3, 8]);
            Console.WriteLine(box[4, 1], "|", box[4, 2], "|", box[4, 3], "|", box[4, 4], "|", box[4, 5], "|", box[4, 6], "|", box[4, 7], "|", box[4, 8]);
            Console.WriteLine(box[5, 1], "|", box[5, 2], "|", box[5, 3], "|", box[5, 4], "|", box[5, 5], "|", box[5, 6], "|", box[5, 7], "|", box[5, 8]);
            Console.WriteLine(box[6, 1], "|", box[6, 2], "|", box[6, 3], "|", box[6, 4], "|", box[6, 5], "|", box[6, 6], "|", box[6, 7], "|", box[6, 8]);
            Console.WriteLine(box[7, 1], "|", box[7, 2], "|", box[7, 3], "|", box[7, 4], "|", box[7, 5], "|", box[7, 6], "|", box[7, 7], "|", box[7, 8]);
            Console.WriteLine(box[8, 1], "|", box[8, 2], "|", box[8, 3], "|", box[8, 4], "|", box[8, 5], "|", box[8, 6], "|", box[8, 7], "|", box[8, 8]);

        }
    }
}
