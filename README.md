# LSL.Net

LSL.Net is a cross-platform C# binding of [Lab Streaming Layer](https://github.com/sccn/labstreaminglayer).

## Usage

LSL.Net is available as a convenient NuGet package. You can install LSL.Net using any of the following methods:

.NET CLI:

```
dotnet add package LSL.Net --version <version>
```

NuGet package manager:

```
Install-Package LSL.Net -Version <version>
```

PackageReference:

```
<PackageReference Include="LSL.Net" Version="<version>" />
```

Replace `<version>` with the specific version number of LSL.Net you wish to use.

In addition to installing LSL.Net, you will need to install the appropriate liblsl runtime package(s) for your target platform(s). There are separate NuGet packages that contain liblsl native binaries for the most common platforms, named [```LSL.Net.runtime.[RID]```](https://www.nuget.org/packages?q=LSL.Net.runtime), where `[RID]` represents the runtime identifier for the specific platform. For details on runtime identifiers, refer to the [.NET RID catalog](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog). You can find the list of available native packages and their platform mappings in the [LSL.Net.runtime README](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/src/LSL.Net.runtime/README.md).

# C# Example Programs

The examples folder contains example C# code for sending and receiving data streams. The examples are described in details in the [online documentation](https://labstreaminglayer.readthedocs.io/dev/examples.html#id2).

These example applications can be debugged from within the IDE (i.e. Visual Studio). However, the built products are DLL files, not EXE files. The DLL files can be run at console with `dotnet my_application` (from within same folder as my_application.DLL). This will work anywhere the .NET Core Runtime works. To make a self-contained but platform-dependent product, use `dotnet publish -C Debug -r win10-x64` (or `Release` instead of `Debug`) and this will generate an EXE file.

# Unity

Please see the separate [README-Unity](https://github.com/labstreaminglayer/liblsl-Csharp/blob/master/README-Unity.md).
