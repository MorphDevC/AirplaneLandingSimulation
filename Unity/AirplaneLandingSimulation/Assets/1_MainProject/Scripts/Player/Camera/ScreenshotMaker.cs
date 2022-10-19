using System;
using System.Collections;
using System.IO;
using UniRx;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class ScreenshotMaker: MonoBehaviour
{
    //TODO:Refactor
    [SerializeField] private AirplaneManager AirplaneManagerRef;
    [SerializeField] private AirplaneFlying AirplaneFlyingRef;

    private (RenderTexture grab, RenderTexture flip) _rt;
    private NativeArray<byte> _buffer;

    private DirectoryInfo _pathCreatedDirictory;
    private int _screenshotCounter = 0;

    private bool _isButtonPressedTwicly = false;

    private void Awake()
    {
        AirplaneManagerRef.OnButtonPressed += MakeScreenshot;
    }
    
    private void MakeScreenshot(object sender)
    {
        if(_isButtonPressedTwicly)
        {
            //TODO: _isButtonPressedTwicly = !_isButtonPressedTwicly; repeats twice. Take out for other logic 
            _isButtonPressedTwicly = !_isButtonPressedTwicly;
            return;
        }

        Debug.Log("its ok");
        _pathCreatedDirictory =Directory.CreateDirectory(Application.dataPath+$"/Screenshots/Session_{DateTime.Today.ToString("dd-MM-yyyy")+"-Time-"+DateTime.Now.ToString("hh-mm-ss")}");
        _screenshotCounter = 0;
        var (w, h) = (Screen.width, Screen.height);
    
        _rt.grab = new RenderTexture(w, h, 0);
        _rt.flip = new RenderTexture(w, h, 0);

        _buffer = new NativeArray<byte>(w * h * 4, Allocator.Persistent,
            NativeArrayOptions.UninitializedMemory);
    
        var (scale, offs) = (new Vector2(1, -1), new Vector2(0, 1));
        StartCoroutine(TakeScreenshotLoop(scale, offs));
        _isButtonPressedTwicly = !_isButtonPressedTwicly;
    }

    private IEnumerator TakeScreenshotLoop(Vector2 scale, Vector2 offs, int interval = 1)
    {
        //TODO: Lel crutch fix later
        yield return new WaitUntil(()=>(AirplaneFlyingRef.Tween?.active) == true);
        while ((AirplaneFlyingRef.Tween?.active)==true)
        {
            yield return new WaitForSeconds(interval);
            
            ScreenCapture.CaptureScreenshotIntoRenderTexture(_rt.grab);
            Graphics.Blit(_rt.grab, _rt.flip, scale, offs);
    
            AsyncGPUReadback.RequestIntoNativeArray(ref _buffer, _rt.flip, 0, OnCompleteReadback);
        }
    }

    private void OnCompleteReadback(AsyncGPUReadbackRequest request)
    {
        if (request.hasError)
        {
            Debug.Log("GPU readback error detected.");
            return;
        }
        MainThreadDispatcher.StartUpdateMicroCoroutine(SaveScreenshot());
        
    }

    private IEnumerator SaveScreenshot()
    {
        using var encoded = ImageConversion.EncodeNativeArrayToPNG
            (_buffer, _rt.flip.graphicsFormat, (uint)_rt.flip.width, (uint)_rt.flip.height);
     
        File.WriteAllBytesAsync(
            _pathCreatedDirictory + "/Screenshot_" + _screenshotCounter + ".png",
            encoded.ToArray());
        _screenshotCounter++;
        yield return null;
    }

    void OnDestroy()
    {
        AsyncGPUReadback.WaitAllRequests();

        Destroy(_rt.flip);
        Destroy(_rt.grab);

        //TODO: Remove try catch 
        try
        {
            _buffer.Dispose();
        }
        catch
        {
            //ignore
        }
        
    }
}