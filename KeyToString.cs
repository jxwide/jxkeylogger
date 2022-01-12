using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keylogger1
{
    internal class KeyToString
    {
        public string process(int i)
        {
            string kkey = "";

            if (32 < i && i < 127)
            {
                kkey += (char)i;
            }
            else
            {
                if (i == 127) kkey = "(backspace)";
                if (i == 13) kkey = "(enter)";
                if (i == 9) kkey = "(tab)";
                if (i == 16 || i == 160) kkey = "(shift)";
                if (i == 17 || i == 162) kkey = "(ctrl)";
                if (i == 1) kkey = "(click)";
                if (i == 2) kkey = "(rclick)"; // test
                if (i == 190) kkey = "(dot)"; // test
                if (i == 191) kkey = "(slash)"; // test
                if (i == 186) kkey = "(semicolon)"; // test
                if (i == 189) kkey = "(dash)"; // test
                if (i == 8) kkey = "(back)"; // test
            }


            return kkey;
        }
    }
}
