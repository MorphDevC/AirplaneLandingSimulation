using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class TestScreenshot : MonoBehaviour
{
    
    public Camera captureCamera;
    void Start()
    {
        //StartCoroutine(MakeScrenshot());
        //Debug.Log(Application.dataPath);
        
    }

    private void Update()
    {
        StartCoroutine(MakeScrenshot());
    }

    public IEnumerator MakeScrenshot() {
        //
        
        int width = this.captureCamera.pixelWidth;
        int height = this.captureCamera.pixelHeight;
        
        Texture2D texture = new Texture2D(width, height);
        yield return new WaitForEndOfFrame();
        texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        texture.Apply();
        
        // byte[] bytes = texture.EncodeToPNG();
        // // Write to file and specify the path
        // File.WriteAllBytes(Application.dataPath+"/CaptureScreenshot" + "/CaptureScreenshot"+Time.time.ToString()+".png", bytes);
    }
    
    
}


