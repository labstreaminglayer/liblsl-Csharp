// Port of https://github.com/sccn/liblsl/blob/master/testing/lslver.c
using System;

namespace LSLExamples
{
    internal class LSLVer
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"LSL version: {LSL.LSL.library_version()}");
            Console.WriteLine(LSL.LSL.library_info());
            Console.WriteLine(LSL.LSL.local_clock());
        }
    }
}
