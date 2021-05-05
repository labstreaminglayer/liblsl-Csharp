using System;
using LSL;

namespace LSLExamples
{
    static class HandleMetaData
    {
        public static void Main(string[] args)
        {
            {
                using StreamInfo inf_ = new StreamInfo("Test", "EEG", 8, 100, channel_format_t.cf_double64, "test1234");
                Console.Out.WriteLine("Test");
            }
            // create a new StreamInfo and declare some meta-data (in accordance with XDF format)
            using StreamInfo info = new StreamInfo("MetaTester", "EEG", 8, 100, channel_format_t.cf_float32, "myuid323457");
            XMLElement chns = info.desc().append_child("channels");
            String[] labels = { "C3", "C4", "Cz", "FPz", "POz", "CPz", "O1", "O2" };
            for (int k = 0; k < labels.Length; k++)
                chns.append_child("channel")
                    .append_child_value("label", labels[k])
                    .append_child_value("unit", "microvolts")
                    .append_child_value("type", "EEG");
            info.desc().append_child_value("manufacturer", "SCCN");
            info.desc().append_child("cap")
                .append_child_value("name", "EasyCap")
                .append_child_value("size", "54")
                .append_child_value("labelscheme", "10-20");

            // create outlet for the stream
            StreamOutlet outlet = new StreamOutlet(info);

            // === the following could run on another computer ===

            // resolve the stream and open an inlet
            StreamInfo[] results = LSL.LSL.resolve_stream("name", "MetaTester");
            using StreamInlet inlet = new StreamInlet(results[0]);
            results.DisposeArray();

            // get the full stream info (including custom meta-data) and dissect it
            using StreamInfo inf = inlet.info();
            Console.WriteLine("The stream's XML meta-data is: ");
            Console.WriteLine(inf.as_xml());
            Console.WriteLine("The manufacturer is: " + inf.desc().child_value("manufacturer"));
            Console.WriteLine("The cap circumference is: " + inf.desc().child("cap").child_value("size"));
            Console.WriteLine("The channel labels are as follows:");
            XMLElement ch = inf.desc().child("channels").child("channel");
            for (int k = 0; k < info.channel_count(); k++)
            {
                Console.WriteLine("  " + ch.child_value("label"));
                ch = ch.next_sibling();
            }
            Console.ReadKey();
        }
    }
}
