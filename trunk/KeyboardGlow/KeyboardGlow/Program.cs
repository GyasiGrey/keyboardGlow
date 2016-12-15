using CUE.NET;
using CUE.NET.Devices.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardGlow
{
    class Program
    {
        static void Main(string[] args)
        {
            CueSDK.Initialize();
            CueSDK.UpdateMode = CUE.NET.Devices.Generic.Enums.UpdateMode.Continuous;
            CueSDK.UpdateFrequency = 1f / 30f;

            CorsairKeyboard keyboard = CueSDK.KeyboardSDK;

            bool goingUp = true;
            byte green = 0;

            while(true)
            {
                if(goingUp)
                {
                    green++;
                    if(green >= 255)
                    {
                        goingUp = false;
                    }
                }
                else
                {
                    green--;
                    if(green <= 0)
                    {
                        goingUp = true;
                    }
                }

                keyboard['Q'].Color = new CUE.NET.Devices.Generic.CorsairColor(0, green, 0);
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
