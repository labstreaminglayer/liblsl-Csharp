# Using LSL in Unity

The [LSL4Unity repository](https://github.com/labstreaminglayer/LSL4Unity) provides a more featureful integration of LSL into Unity. However, it is not as well-maintained as this repository. The recommended approach to integrating LSL into a Unity project is to use liblsl-Csharp's LSL.cs, and use LSL4Unity as a reference for more advanced use of LSL in Unity.

## Getting Started in Unity

LSL.cs includes a Unity interface to liblsl as a [Unity native plug-in](https://docs.unity3d.com/Manual/NativePlugins.html). The following instructions outline how to add a cube to a Unity scene that uses the LSL native plugin to pull in samples that modify its movement vector. These instructions were written while using Unity 2020.1.0f1.

1. Download the latest [liblsl release](https://github.com/sccn/liblsl/releases) for your platform(s) (e.g. liblsl-1.14.0-Win64.zip) and extract the library (e.g. lsl.dll) into the project's Assets/Plugins/lib folder (you may have to create this folder).
    * If you plan to build for more than one target platform then you may wish to further subdivide the folders.
    * If you will deploy to Android, the easiest way to get the lib files is to follow the instructions in the ["Building for Android" LSL docs](https://labstreaminglayer.readthedocs.io/dev/build_android.html).
    * On recent versions of MacOS, if the dylib fails to load for security reasons, you will have to allow it manually in "Security & Privacy Settings". [More info](https://support.apple.com/en-ca/HT202491).
1. Drag and drop LSL.cs into the project's Assets/Plugins folder.
1. In Unity, use the Project view and navigate to the Assets/Plugins/lib folder. For each library file:
    * Set the platforms for the plug-in. [See here](https://docs.unity3d.com/Manual/PluginsForDesktop.html).
1. In Unity, use the menu to place a cube in the scene: GameObject > 3D Object > Cube

### Control a game object from an inlet

1. When the cube is selected, in the Inspector click on "Add Component", and create a new script called LSLInput.
1. In the Project viewer, double click on LSLInput.cs. This should launch Visual Studio or another IDE.
1. Fill in the script. Use [LSL4Unity AInlet](https://github.com/labstreaminglayer/LSL4Unity/blob/master/Scripts/AInlet.cs) for inspiration.
    * There is [currently a bug](https://github.com/sccn/liblsl/issues/29) that prevents liblsl in Unity from resolving streams from _other_ computers while running in editor, and also the built product but only when using `ContinuousResolver`. For this reason we recommend using `LSL.resolve_stream` instead.

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLInput : MonoBehaviour
{
    public string StreamType = "EEG";
    public float scaleInput = 0.1f;

    StreamInfo[] streamInfos;
    StreamInlet streamInlet;

    float[] sample;
    private int channelCount = 0;

    void Update()
    {
        if (streamInlet == null)
        {

            streamInfos = LSL.resolve_stream("type", StreamType, 1, 0.0);
            if (streamInfos.Length > 0)
            {
                streamInlet = new StreamInlet(streamInfos[0]);
                channelCount = streamInlet.info().channel_count();
                streamInlet.open_stream();
            }
        }

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
1. Run the Unity game and watch that cube shake!

### Unity Outlet example

1. Attach a new component called LSLPosOutput to the cube.
1. Edit it as follows:
```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLOutput : MonoBehaviour
{
    private StreamOutlet outlet;
    private float[] currentSample;


    public string StreamName = "Unity.ExampleStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";

    // Start is called before the first frame update
    void Start()
    {
        StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 3, Time.fixedDeltaTime * 1000, LSL.channel_format_t.cf_float32);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "X");
        chans.append_child("channel").append_child_value("label", "Y");
        chans.append_child("channel").append_child_value("label", "Z");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new float[3];
    }


    // FixedUpdate is a good hook for objects that are governed mostly by physics (gravity, momentum).
    // Update might be better for objects that are governed by code (stimulus, event).
    void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        currentSample[0] = pos.x;
        currentSample[1] = pos.y;
        currentSample[2] = pos.z;
        outlet.push_sample(currentSample);
    }
}
```
