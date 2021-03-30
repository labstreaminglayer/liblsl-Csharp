using LSL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // wait until an EEG stream shows up
            liblsl.StreamInfo[] results = liblsl.resolve_stream("type", "EEG");

            // open an inlet and print some interesting info about the stream (meta-data, etc.)
            using liblsl.StreamInlet inlet = new liblsl.StreamInlet(results[0]);
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
