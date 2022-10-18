using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UniRx;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

public class TestScreenshot : MonoBehaviour
{
    
    (RenderTexture grab, RenderTexture flip) _rt;
    NativeArray<byte> _buffer;

    IEnumerator Start()
    {
        Debug.Log(Application.dataPath + "/CaptureScreenshot" + "/CaptureScreenshot" + Time.time.ToString() + ".png");
        StartCoroutine(kek());
        yield break;
    }

    IEnumerator kek()
    {
        var (w, h) = (Screen.width, Screen.height);
    
        _rt.grab = new RenderTexture(w, h, 0);
        _rt.flip = new RenderTexture(w, h, 0);

        _buffer = new NativeArray<byte>(w * h * 4, Allocator.Persistent,
            NativeArrayOptions.UninitializedMemory);
    
        var (scale, offs) = (new Vector2(1, -1), new Vector2(0, 1));
    
        while (true)
        {
            yield return new WaitForSeconds(1);
    
            ScreenCapture.CaptureScreenshotIntoRenderTexture(_rt.grab);
            Graphics.Blit(_rt.grab, _rt.flip, scale, offs);
    
            AsyncGPUReadback.RequestIntoNativeArray(ref _buffer, _rt.flip, 0, OnCompleteReadback);
        }
    }

    void OnDestroy()
    {
        AsyncGPUReadback.WaitAllRequests();

        Destroy(_rt.flip);
        Destroy(_rt.grab);

        _buffer.Dispose();
    }

    void OnCompleteReadback(AsyncGPUReadbackRequest request)
    {
        if (request.hasError)
        {
            Debug.Log("GPU readback error detected.");
            return;
        }
        MainThreadDispatcher.StartUpdateMicroCoroutine(save());

    }

    IEnumerator save()
    {
        using var encoded = ImageConversion.EncodeNativeArrayToPNG
        (_buffer, _rt.flip.graphicsFormat, (uint)_rt.flip.width, (uint)_rt.flip.height);
     
        File.WriteAllBytesAsync(
                    Application.dataPath + "/CaptureScreenshot" + "/CaptureScreenshot" + Time.time.ToString() + ".png",
                    encoded.ToArray());
        yield return null;
    }

    
}



