using LSL;

namespace LSLExamples
{
    static class ReceiveData
    {
        public static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            StreamInfo[] results = LSL.LSL.resolve_stream("type", "EEG");

            // open an inlet and print some interesting info about the stream (meta-data, etc.)
            using StreamInlet inlet = new StreamInlet(results[0]);
            results.DisposeArray();
            System.Console.Write(inlet.info().as_xml());

            // read samples
            float[] sample = new float[8];
            while (!System.Console.KeyAvailable)
            {
                inlet.pull_sample(sample);
                foreach (float f in sample)
                    System.Console.Write("\t{0}", f);
                System.Console.WriteLine();
            }
        }
    }
}
