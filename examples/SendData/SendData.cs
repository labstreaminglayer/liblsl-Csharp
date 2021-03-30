using System;
using System.Threading;
using LSL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            // create stream info and outlet
            liblsl.StreamInfo info = new liblsl.StreamInfo("TestCSharp", "EEG", 8, 100, liblsl.channel_format_t.cf_float32, "sddsfsdf");
            liblsl.StreamOutlet outlet = new liblsl.StreamOutlet(info);
            float[] data = new float[8];
            while (!Console.KeyAvailable)
            {
                // generate random data and send it
                for (int k = 0; k < data.Length; k++)
                    data[k] = rnd.Next(-100, 100);
                outlet.push_sample(data);
                Thread.Sleep(10);
            }
        }
    }
}
