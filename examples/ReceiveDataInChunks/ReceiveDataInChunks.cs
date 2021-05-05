using System;
using LSL;

namespace LSLExamples
{
    static class ReceiveDataInChunks
    {
        public static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            StreamInfo[] results = LSL.LSL.resolve_stream("type", "EEG");

            // open an inlet, with post-processing enabled, and print meta-data
            // Note: The use of post-processing makes it impossible to recover
            // the original timestamps and is not recommended for applications
            // that store data to disk.
            using StreamInlet inlet = new StreamInlet(results[0],
                postproc_flags: processing_options_t.proc_ALL);
            results.DisposeArray();
            System.Console.Write(inlet.info().as_xml());

            // read samples
            float[,] buffer = new float[512, 8];
            double[] timestamps = new double[512];
            while (!Console.KeyAvailable)
            {
                int num = inlet.pull_chunk(buffer, timestamps);
                for (int s = 0; s < num; s++)
                {
                    for (int c = 0; c < 8; c++)
                        Console.Write("\t{0}", buffer[s, c]);
                    Console.WriteLine();
                }
            }
        }
    }
}
