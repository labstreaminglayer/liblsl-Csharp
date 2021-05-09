using System;
using LSL;

namespace LSLExamples
{
    static class ReceiveStringMarkers
    {
        public static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            StreamInfo[] results = LSL.LSL.resolve_stream("type", "Markers");

            // open an inlet and print meta-data
            using StreamInlet inlet = new StreamInlet(results[0]);
            results.DisposeArray();
            Console.Write(inlet.info().as_xml());

            // read samples
            string[] sample = new string[1];
            while (!Console.KeyAvailable)
            {
                inlet.pull_sample(sample);
                Console.WriteLine(sample[0]);
            }
        }
    }
}
