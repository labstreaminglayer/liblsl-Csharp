# Runtime Identifier Dependencies

The NuGet package for the C# bindings includes binary distributions for major platform runtimes targeted by [liblsl](https://github.com/sccn/liblsl). To successfully build the package, these binaries need to be downloaded from [liblsl releases](https://github.com/sccn/liblsl/releases) and included in this folder following the RID naming conventions outlined in the [RID Catalog](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog).

The following [architecture-specific folders](https://docs.microsoft.com/en-us/nuget/create-packages/supporting-multiple-target-frameworks#architecture-specific-folders) are recommended:

```
\runtimes
    \linux-x64
        \native
            liblsl.so
            liblsl.so.1.14.0
    \osx-x64
        \native
            liblsl.dylib
            liblsl.1.14.0.dylib
    \win-x64
        \native
            lsl.dll
    \win-x86
        \native
            lsl.dll
```

## Project files for dependent projects

From Visual Studio 2019, both .NET Core (`dotnet`) and .NET Framework compilers will use the `RuntimeIdentifier` element of the new SDK csproj format to control which native dependencies to deploy to the final output folder.

### .NET Core
In .NET Core, the default is to generate cross-platform deployments, which means that all the runtimes will be deployed to the final output folder. By inserting a specific `RuntimeIdentifier` a build targeting only the specified architecture is generated.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net5.0</TargetFramework>
    <!--<RuntimeIdentifier>linux-x64</RuntimeIdentifier>-->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="lsl_csharp" Version="2.0.0" />
  </ItemGroup>

</Project>
```

### .NET Framework
In legacy .NET framework projects, `RuntimeIdentifier` defaults to `win7-x86` which has the generic fallback to `win-x86`. Therefore, the above folder structure will automatically copy `lsl.dll` into the output folder of .NET Framework projects.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net472</TargetFramework>
    <!--<RuntimeIdentifier>win-x64</RuntimeIdentifier>-->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="lsl_csharp" Version="2.0.0" />
  </ItemGroup>

</Project>
```