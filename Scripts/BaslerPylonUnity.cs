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

using System;
using System.Runtime.InteropServices;

public static class BaslerPylonUnity
{
    private const string DLL_NAME = "BaslerPylonWrapper";

    [DllImport(DLL_NAME)]
    // Must be called first, before any other call.
    public static extern void Init();

    [DllImport(DLL_NAME)]
    // Must be called for each camera, before any call to StartRecording()
    public static extern void PrepareRecording(string pDeviceSN, string pVideoFilePath, double pFramesPerSecond = 60.0, uint pQuality = 90);

    [DllImport(DLL_NAME)]
    // Recording of video happens in a thread and will never block the calling thread.
    public static extern void StartRecording();

    [DllImport(DLL_NAME)]
    public static extern bool IsRecording();

    [DllImport(DLL_NAME)]
    public static extern void StopRecording();

    [DllImport(DLL_NAME)]
    public static extern bool HasError();

    [DllImport(DLL_NAME)]
    private static extern IntPtr GetErrors();

    public static string GetErrorsMessage()
    {
        IntPtr ptr = GetErrors();
        return Marshal.PtrToStringAnsi(ptr);
    }

    [DllImport(DLL_NAME)]
    // Must be called at the end of the program.
    // Automatically Stop any recording in progress.
    public static extern void Terminate();
}
