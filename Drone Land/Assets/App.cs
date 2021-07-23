using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class App : MonoBehaviour
{
    // [SerializeField] TextMeshProUGUI pythonRcvdText = null;
    // [SerializeField] TextMeshProUGUI sendToPythonText = null;

    private Camera debugCamera;

    string tempStr = "Sent from Python xxxx";
    string receivedText = "";
    string sendText = "";
    int numToSendToPython = 0;

    public int resHeight = 1080;
    public int resWidth = 1920;

    UdpSocket udpSocket;

    private void Awake()
    {
        // debugCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        debugCamera = Camera.main;
    }

    public void QuitApp()
    {
        print("Quitting");
        Application.Quit();
    }

    public void UpdatePythonRcvdText(string str)
    {
        tempStr = str;
    }

    public void SendToPython()
    {
        udpSocket.SendData("Sent From Unity: " + numToSendToPython.ToString());
        numToSendToPython++;
        // sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
        sendText = "Send Number: " + numToSendToPython.ToString();
    }

    private void Start()
    {
        udpSocket = FindObjectOfType<UdpSocket>();
        // sendToPythonText.text = "Send Number: " + numToSendToPython.ToString();
        sendText = "Send Number: " + numToSendToPython.ToString();
    }

    public void Resize(Texture2D texture2D, int targetX, int targetY, bool mipmap = true, FilterMode filter = FilterMode.Bilinear)
    {
        RenderTexture rt = RenderTexture.GetTemporary(targetX, targetY, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
        RenderTexture.active = rt;
        
        // This uses the GPU to do the resize
        Graphics.Blit(texture2D, rt);
        texture2D.Resize(targetX, targetY, texture2D.format, mipmap);
        texture2D.filterMode = filter;

        try
        {
            texture2D.ReadPixels(new Rect(0.0f, 0.0f, targetX, targetY), 0, 0);
            texture2D.Apply(); // Not sure if we need this since we are not drawing the texture to the screen
        }
        catch
        {
            Debug.LogError("Read/Write is not enabled on texture "+ texture2D.name);
        }

        RenderTexture.ReleaseTemporary(rt);
    }

    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();

        string filename = Application.dataPath + "/screenshots/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss").Replace(" ", "_") + ".png";

        ScreenCapture.CaptureScreenshot(filename);
        udpSocket.SendData(filename);
        UnityEditor.AssetDatabase.Refresh(); // Only needed if you want to view the screenshot in Unity immediately

        /*
        NOTE: When I was trying to send the image via UDP, too many bytes
        
        var screenshot = ScreenCapture.CaptureScreenshotAsTexture();
        Resize(screenshot, 640, 480);
        byte[] bytes = screenshot.EncodeToPNG();
        string bytesAsBase64 = System.Convert.ToBase64String(bytes);

        udpSocket.SendData("Image: " + bytesAsBase64);

        Object.Destroy(screenshot);*/
    }

    void Update()
    {
        receivedText = tempStr;
    }

    public void LateUpdate()
    {
        StartCoroutine(RecordFrame());
    }
}
