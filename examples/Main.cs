using System;
using System.Linq;
using System.Reflection;

namespace LSLExamples
{
    static class EntryPoint
    {
        public static void Main(string[] args) {
        var examples = Assembly.GetExecutingAssembly().GetTypes()
              .Where(t => t.Namespace =="LSLExamples").ToDictionary(e=>e.Name, e=>e);

            var WrapperVersion = Assembly.GetAssembly(typeof(LSL.LSL)).GetName().Version.ToString();
            Console.Out.Write("Wrapper version: ");
            Console.Out.WriteLine(WrapperVersion);
            Console.Out.Write("liblsl version: ");
            Console.Out.WriteLine(LSL.LSL.library_version());
            if (args.Length < 1 || !examples.ContainsKey(args[0])) {
				Console.Out.WriteLine("\nNot enough arguments. Valid examples:");
				foreach(var name in examples.Keys) Console.Out.WriteLine(name);
				return;
			}
            var method = examples[args[0]].GetMethod("Main", BindingFlags.Public|BindingFlags.Static);
            Console.Out.WriteLine(method);
            method.Invoke(null, new object[]{ args});
		}
	}
}
				
