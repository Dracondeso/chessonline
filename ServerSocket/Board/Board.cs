using System;
using System.Collections.Generic;
using System.Text;

namespace ServerSocket
{
    class Boards
    {
        public string[] Line = new string[8];

        Dictionary<int, string> pippo = new Dictionary<int, string>();

        

        public Board()
        {
            this.Line[0] = "11111111";
            this.Line[1] = "11111111";
            this.Line[2] = "00000000";
            this.Line[3] = "00000000";
            this.Line[4] = "00000000";
            this.Line[5] = "00000000";
            this.Line[6] = "11111111";
            this.Line[7] = "11111111";
                                      
        }
    }
}
