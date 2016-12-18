using CUE.NET;
using CUE.NET.Devices.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CUE.NET.Devices.Generic.Enums;
using CUE.NET.Devices.Generic;

namespace KeyboardGlow
{
    class Program
    {
        private static float currentMultiplier = 1.0f;

        static void Main(string[] args)
        {
            CueSDK.Initialize();
            CueSDK.UpdateMode = CUE.NET.Devices.Generic.Enums.UpdateMode.Continuous;
            CueSDK.UpdateFrequency = 1f / 30f;

            CorsairKeyboard keyboard = CueSDK.KeyboardSDK;

            bool done = false;

            List<CorsairLedId> wasd = new List<CorsairLedId>();
            wasd = new List<CorsairLedId>();
            wasd.Add(CorsairLedId.W);
            wasd.Add(CorsairLedId.A);
            wasd.Add(CorsairLedId.S);
            wasd.Add(CorsairLedId.D);

            CorsairColor wasdColor = new CorsairColor(255, 0, 0);
            CorsairColor mainColor = new CorsairColor(0, 64, 255);
            CorsairColor otherColor = new CorsairColor(255, 255, 255);

            while (!done)
            {
                currentMultiplier -= 0.05f;
                if (currentMultiplier <= 0.0f)
                {
                    currentMultiplier = 0.0f;
                    done = true;
                }

                foreach(CorsairLedId led in wasd)
                {
                    keyboard[led].Color = new CorsairColor((byte)(currentMultiplier * wasdColor.R), (byte)(currentMultiplier * wasdColor.G), (byte)(currentMultiplier * wasdColor.B));
                }

            
                System.Threading.Thread.Sleep(64);
            }

            System.Threading.Thread.Sleep(5000);
        }
    }
}
