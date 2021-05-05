using System;
using System.Threading;
using LSL;

namespace LSLExamples
{
    static class SendStringMarkers
    {
        public static void Main(string[] args)
        {
            // create stream info and outlet
            using StreamInfo inf = new StreamInfo("Test1", "Markers", 1, 0, channel_format_t.cf_string, "giu4569");
            using StreamOutlet outl = new StreamOutlet(inf);

            Random rnd = new Random();
            string[] strings = new string[] { "Test", "ABC", "123" };
            string[] sample = new string[1];
            for (int k = 0; !Console.KeyAvailable; k++)
            {
                // send a marker and wait for a random interval
                sample[0] = strings[k % 3];
                outl.push_sample(sample);
                Console.Out.WriteLine(sample[0]);
                Thread.Sleep(rnd.Next(1000));
            }
        }
    }
}
