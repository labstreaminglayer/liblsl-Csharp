# C# bindings

The is the C# interface to the lab streaming layer. To use it, you need to include the file LSL.cs in 
your project, and make sure that the appropriate lsl library (e.g. lsl.dll) is findable (e.g., in your application's 
root directory or in a system path).

If LSL.cs fails to find the lsl shared library for your target platform, edit LSL.cs and update the following line with the name for your system: `const string libname = "lsl";`

# C# Example Programs

The examples folder contains example C# code for sending and receiving data streams. The examples are described in the [online documentation](https://labstreaminglayer.readthedocs.io/dev/examples.html#id2).

These example applications can be debugged from within the IDE (i.e. Visual Studio). However, the built products are DLL files, not EXE files. The DLL files can be run at console with `dotnet my_application` (from within same folder as my_application.DLL). This will work anywhere the .NET Core Runtime works. To make a more portable but platform-dependent product, use `dotnet publish -C Debug -r win10-x64` (or Release instead of Debug) and this will generate an EXE file.

# Unity

The [LSL4Unity repository](https://github.com/labstreaminglayer/LSL4Unity) provides a more featureful integration of LSL into Unity. However, it is not as well-maintained as this repository. The recommended approach to integrating LSL into a Unity project is to use this repository's LSL.cs, and use LSL4Unity as a reference for more advanced use of LSL in Unity.

## Getting Started in Unity

These instructions were written while using Unity 2020.1.0f1.

1. Drag and drop LSL.cs into the project Assets folder.
1. Download the latest [liblsl release](https://github.com/sccn/liblsl/releases) for your platform and extract the library (e.g. liblsl64.dll) into the project root folder.
1. In Unity, use the menu to place a cube in the scene: GameObject > 3D Object > Cube
1. When the cube is selected, in the Inspector click on "Add Component", and create a new script called LSLInput.
1. In the Project viewer, double click on LSLInput.cs. This should launch Visual Studio or another IDE.
1. Fill in the script. Use [LSL4Unity AInlet](https://github.com/labstreaminglayer/LSL4Unity/blob/master/Scripts/AInlet.cs) for inspiration.
    ```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLInput : MonoBehaviour
{
    public string StreamType = "EEG";
    public float scaleInput = 0.1f;
    liblsl.StreamInfo[] streamInfos;
    liblsl.StreamInlet streamInlet;
    liblsl.ContinuousResolver resolver;
    float[] sample;
    private int channelCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        resolver = new liblsl.ContinuousResolver("type", StreamType);
        StartCoroutine(ResolveExpectedStream());
    }

    IEnumerator ResolveExpectedStream()
    {
        var streamInfos = resolver.results();
        yield return new WaitUntil(() => streamInfos.Length > 0);
        streamInlet = new liblsl.StreamInlet(streamInfos[0]);
        channelCount = streamInlet.info().channel_count();
        streamInlet.open_stream();
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (streamInlet != null)
        {
            sample = new float[channelCount];
            double lastTimeStamp = streamInlet.pull_sample(sample, 0.0f);
            if (lastTimeStamp != 0.0)
            {
                Process(sample, lastTimeStamp);
                while ((lastTimeStamp = streamInlet.pull_sample(sample, 0.0f)) != 0)
                {
                    Process(sample, lastTimeStamp);
                }
            }
        }
    }
    void Process(float[] newSample, double timeStamp)
    {
        var inputVelocity = new Vector3(scaleInput * (newSample[0] - 0.5f), scaleInput * (newSample[1] - 0.5f), scaleInput * (newSample[2] -0.5f));
        gameObject.transform.position = gameObject.transform.position + inputVelocity;
    }
}
    ```
1. Elsewhere, run one of the LSL outlet examples. For example, from a conda environment with pylsl installed: `python -m pylsl.examples.SendData`
1. Run the Unity game.
