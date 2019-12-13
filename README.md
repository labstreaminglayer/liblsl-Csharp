# C# bindings

The is the C# interface to the lab streaming layer. To use it, you need to include the file LSL.cs in 
your project, and make sure that the lsl library (e.g. liblsl32.dll) is found (e.g., in your application's 
root directory or in a system path).

If you are deploying for something other than Unity, and on a platform that requires a different binary
than liblsl32.dll (e.g., liblsl64.so on 64-bit Linux, or liblsl64.dylib on Mac OS)
then you need to replace the libname constant in LSL.cs by the corresponding file name.

These example applications can be debugged from within the IDE (i.e. Visual Studio). However, the built
products are DLL files, not EXE files. The DLL files can be run at console with `dotnet my_application`
(from within same folder as my_application.DLL). This will work anywhere the .NET Core Runtime works.
To make a more portable but platform-dependent product, use `dotnet publish -C Debug -r win10-x64`
(or Release instead of Debug) and this will generate an EXE file.


## C# Example Programs

These examples show how to transmit a numeric multi-channel time series through LSL:

- [Sending a multi-channel time series into LSL.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/SendData.cs)
- [Receiving a multi-channel time series from LSL.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/ReceiveData.cs)

The following examples show how to transmit data in form of chunks instead of samples, which can be
more convenient.

- [Sending a multi-channel time series in chunks.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/SendDataInChunks.cs)
- [Receiving a multi-channel time series in chunks.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/ReceiveDataInChunks.cs)

These examples show a special-purpose use case that is mostly relevant for stimulus-presentation
programs or other applications that want to emit 'event' markers or other application state.

The stream here is single-channel and has irregular sampling rate, but the value per channel is a string:
- [Sending string-formatted irregular streams.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/SendStringMarkers.cs)
- [Receiving string-formatted irregular streams.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/ReceiveStringMarkers.cs)

The last example shows how to attach properly formatted meta-data to a stream, and how to read it
out again at the receiving end.
While meta-data is strictly optional, it is very useful to make streams self-describing.
LSL has adopted the convention to name meta-data fields according to the XDF file format
specification whenever the content type matches (for example EEG, Gaze, MoCap, VideoRaw, etc);
the spec is [here](https://github.com/sccn/xdf/wiki/Meta-Data).

- [Handling stream meta-data.](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/examples/HandleMetaData.cs)
