## Use Basler Cameras in Unity
- The .NET SDK from Basler is not compatible with Unity, so a [Wrapper of the C++ SDK](https://github.com/ebadier/BaslerPylonWrapper) has been made to be compatible with Unity
- You can directly record videos from multiple Basler cameras simultaneously
- All video recording is done in a dedicated thread per camera, so the Unity main thread is never blocked
- Developped and Tested with Unity ***2019.4.36f1*** on Windows 10, with 2x [Basler acA1920-155uc](https://www.baslerweb.com/en/shop/aca1920-155uc/)

## Getting Started
#### 1. Plug your Basler cameras on your computer, and configure them using the [PylonViewer software](https://www.baslerweb.com/en/software/pylon/pylon-viewer/)
#### 2. Close the [PylonViewer software](https://www.baslerweb.com/en/software/pylon/pylon-viewer/), or at least close the camera devices inside it, because only one program can access the cameras at a time
#### 3. Open the BaslerPylonRecorderTest scene in Unity, and in BaslerPylonRecorderTest's inspector:  
- set your cameras serial numbers
- you can also set the video encoding quality
#### 4. Press Play

## Requirements
#### 1. Install [Pylon Software Suite for Windows](https://www2.baslerweb.com/en/downloads/software-downloads/software-pylon-7-5-0-windows/)
#### 2. Install [pylon Supplementary Package for MPEG-4 Windows](https://www2.baslerweb.com/en/downloads/software-downloads/pylon-supplementary-package-for-mpeg4-1-0-2-windows/)

## Optional
- If you want to build the [BaslerPylonWrapper](https://github.com/ebadier/BaslerPylonWrapper) project yourself, you should copy the generated **BaslerPylonWrapper.dll** to [Plugins/x86_64](Plugins/x86_64)
- You can also copy the latest dlls located in "C:\Program Files\Basler\pylon 7\Runtime\x64" to [Plugins/x86_64](Plugins/x86_64)
