using System;
using System.Threading;
using LSL;

namespace LSLExamples
{
    static class SendData
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();

            // create stream info and outlet
            using StreamInfo info = new StreamInfo("TestCSharp", "EEG", 8, 100, channel_format_t.cf_float32, "sddsfsdf");
            using StreamOutlet outlet = new StreamOutlet(info);
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
