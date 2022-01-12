using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace keylogger1
{
    internal class WindowName
    {
        public string GetActiveWindowName()
        {
            string name = "none";

            //
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);



            try
            {
                int chars = 256;
                StringBuilder buff = new StringBuilder(chars);
                IntPtr handle = GetForegroundWindow();
                if (GetWindowText(handle, buff, chars) > 0)
                {
                    name = buff.ToString();
                }
            } catch (Exception ex)
            {
                name = "desktop";
            }




            //

            return name;
        }

        public string NN()
        {
            string n = this.GetActiveWindowName();
            if (n.Contains("/"))
            {
                var x = n.Split('/');
                n = x[x.Length];
            }
            return n;
        }
    }
}
