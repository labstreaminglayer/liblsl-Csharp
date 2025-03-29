# LSL.Net runtime packages

The following NuGet packages include binary distributions for major platform runtimes targeted by [liblsl](https://github.com/sccn/liblsl).

| RID           |                        NuGet Package                         |
| :------------ | :----------------------------------------------------------: |
| android-arm   | [![LSL.Net.runtime.android-arm-badge]][LSL.Net.runtime.android-arm-nuget] |
| android-arm64 | [![LSL.Net.runtime.android-arm64-badge]][LSL.Net.runtime.android-arm64-nuget] |
| android-x64   | [![LSL.Net.runtime.android-x64-badge]][LSL.Net.runtime.android-x64-nuget] |
| android-x86   | [![LSL.Net.runtime.android-x86-badge]][LSL.Net.runtime.android-x86-nuget] |
| ios-arm64     | [![LSL.Net.runtime.ios-arm64-badge]][LSL.Net.runtime.ios-arm64-nuget] |
| linux-arm     | [![LSL.Net.runtime.linux-arm-badge]][LSL.Net.runtime.linux-arm-nuget] |
| linux-arm64   | [![LSL.Net.runtime.linux-arm64-badge]][LSL.Net.runtime.linux-arm64-nuget] |
| linux-x64     | [![LSL.Net.runtime.linux-x64-badge]][LSL.Net.runtime.linux-x64-nuget] |
| osx-arm64     | [![LSL.Net.runtime.osx-arm64-badge]][LSL.Net.runtime.osx-arm64-nuget] |
| osx-x64       | [![LSL.Net.runtime.osx-x64-badge]][LSL.Net.runtime.osx-x64-nuget] |
| win-arm64     | [![LSL.Net.runtime.win-arm64-badge]][LSL.Net.runtime.win-arm64-nuget] |
| win-x64       | [![LSL.Net.runtime.win-x64-badge]][LSL.Net.runtime.win-x64-nuget] |
| win-x86       | [![LSL.Net.runtime.win-x86-badge]][LSL.Net.runtime.win-x86-nuget] |

[LSL.Net.runtime.android-arm-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.android-arm.svg
[LSL.Net.runtime.android-arm-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.android-arm
[LSL.Net.runtime.android-arm64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.android-arm64.svg
[LSL.Net.runtime.android-arm64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.android-arm64
[LSL.Net.runtime.android-x64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.android-x64.svg
[LSL.Net.runtime.android-x64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.android-x64
[LSL.Net.runtime.android-x86-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.android-x86.svg
[LSL.Net.runtime.android-x86-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.android-x86
[LSL.Net.runtime.ios-arm64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.ios-arm64.svg
[LSL.Net.runtime.ios-arm64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.ios-arm64
[LSL.Net.runtime.linux-arm-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.linux-arm.svg
[LSL.Net.runtime.linux-arm-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.linux-arm
[LSL.Net.runtime.linux-arm64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.linux-arm64.svg
[LSL.Net.runtime.linux-arm64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.linux-arm64
[LSL.Net.runtime.linux-x64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.linux-x64.svg
[LSL.Net.runtime.linux-x64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.linux-x64
[LSL.Net.runtime.osx-arm64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.osx-arm64.svg
[LSL.Net.runtime.osx-arm64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.osx-arm64
[LSL.Net.runtime.osx-x64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.osx-x64.svg
[LSL.Net.runtime.osx-x64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.osx-x64
[LSL.Net.runtime.win-arm64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.win-arm64.svg
[LSL.Net.runtime.win-arm64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.win-arm64
[LSL.Net.runtime.win-x64-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.win-x64.svg
[LSL.Net.runtime.win-x64-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.win-x64
[LSL.Net.runtime.win-x86-badge]: https://img.shields.io/nuget/v/LSL.Net.runtime.win-x86.svg
[LSL.Net.runtime.win-x86-nuget]: https://www.nuget.org/packages/LSL.Net.runtime.win-x86

## Usage

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <!--<RuntimeIdentifier>linux-x64</RuntimeIdentifier>-->
    <!--<RuntimeIdentifiers>linux-x64;osx-arm64;win-x64;win-x86</RuntimeIdentifiers>-->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="LSL.Net" Version="<version>" />
    <PackageReference Include="LSL.Net.runtime.linux-x64" Version="<version>" />
    <PackageReference Include="LSL.Net.runtime.osx-arm64" Version="<version>" />
    <PackageReference Include="LSL.Net.runtime.win-x64" Version="<version>" />
    <PackageReference Include="LSL.Net.runtime.win-x86" Version="<version>" />
  </ItemGroup>

</Project>
```

Replace `<version>` with the specific version number of these packages you wish to use.

# License

These packages only bundle the dynamic libraries of [liblsl](https://github.com/sccn/liblsl), thus using the same licensing agreement as liblsl. Please refer to the [LICENSE](./LICENSE) file for more information.
