# C# bindings

The is the C# interface to the lab streaming layer. To use it, you need to include the file LSL.cs in your project, and make sure that the appropriate lsl library (e.g. lsl.dll) is findable (e.g., in your application's root directory or in a system path).

If using Visual Studio 2019, make sure you have the .NET desktop development pack installed. Then open the liblsl.sln file. If you are asked to upgrade then go ahead. In the solution explorer, right click on the `liblsl` target and choose `Add > Existing Item ...`. In the explorer window, change the `Add` dropdown button to `Add as Link` and change the file types/extensions to "all files (*.*)". Browse to where you have lsl.dll ([download from here](https://github.com/sccn/liblsl/releases)) and select it. Click on the lsl.dll entry now in the solution explorer to view its properties. Set "Build Action" to "Content" and "Copy to output directory" to "Copy if newer". Whenever a target in the solution is built, the dll will be copied into the build directory.
![Visual Studio lsl.dll properties](img/vs2019_lsl_props.PNG)

If LSL.cs fails to find the lsl shared library for your target platform, edit LSL.cs and update the following line with the library filename for your system: `const string libname = "lsl";`

# C# Example Programs

The examples folder contains example C# code for sending and receiving data streams. The examples are described in details in the [online documentation](https://labstreaminglayer.readthedocs.io/dev/examples.html#id2).

These example applications can be debugged from within the IDE (i.e. Visual Studio). However, the built products are DLL files, not EXE files. The DLL files can be run at console with `dotnet my_application` (from within same folder as my_application.DLL). This will work anywhere the .NET Core Runtime works. To make a self-contained but platform-dependent product, use `dotnet publish -C Debug -r win10-x64` (or `Release` instead of `Debug`) and this will generate an EXE file.

# Unity

Please see the separate [README-Unity](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/README-Unity.md).
