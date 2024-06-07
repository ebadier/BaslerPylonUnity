/******************************************************************************************************************************************************
* MIT License																																		  *
*																																					  *
* Copyright (c) 2024																																  *
* Emmanuel Badier <emmanuel.badier@gmail.com>																										  *
* 																																					  *
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"),  *
* to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,  *
* and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:		  *
* 																																					  *
* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.					  *
* 																																					  *
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, *
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 																							  *
* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 		  *
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.							  *
******************************************************************************************************************************************************/

using System.IO;
using UnityEngine;

public class BaslerPylonRecorderTest : MonoBehaviour
{
    private const string VIDEO_FILENAME = "Video.mp4";

    [Range(30f, 100f)]
    public float recordingFrameRate = 60f;
    [Range(1, 100)]
    public uint recordingQuality = 90u;
    public string[] camerasSN = { "24551463", "24794830" };

    private void Awake()
    {
        BaslerPylonUnity.Init();
        Debug.Log("[BaslerPylonRecorderTest] Press Space to start/stop cameras recording multiple times.");
    }

    private void Update()
    {
        if(BaslerPylonUnity.HasError())
        {
            Debug.LogErrorFormat("[BaslerPylonRecorderTest] {0}", BaslerPylonUnity.GetErrorsMessage());
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(BaslerPylonUnity.IsRecording())
            {
                BaslerPylonUnity.StopRecording();
                Debug.Log("[BaslerPylonRecorderTest] Recording Stopped.");
            }
            else
            {
                // The same video files are overwritten each time
                foreach (string camSN in camerasSN)
                {
                    string filename = string.Format("../{0}_{1}", camSN, VIDEO_FILENAME);
                    string videoFilePath = Path.Combine(Application.dataPath, filename);
                    BaslerPylonUnity.PrepareRecording(camSN, videoFilePath, recordingFrameRate, recordingQuality);
                }
                BaslerPylonUnity.StartRecording();
                Debug.Log("[BaslerPylonRecorderTest] Recording Started.");
            }
        }
    }

    private void OnDestroy()
    {
        BaslerPylonUnity.Terminate();
    }
}
