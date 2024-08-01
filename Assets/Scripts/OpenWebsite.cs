using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    public static void OpenTwitch() 
    {
        Application.OpenURL("https://twitch.tv/hachiski");
    }
    public static void OpenYoutube()
    {
        Application.OpenURL("https://youtube.com/@Hachiski");
    }
    public static void OpenKoFi()
    {
        Application.OpenURL("https://ko-fi.com/hachiski");
    }
    public static void OpenTwitter()
    {
        Application.OpenURL("https://x.com/HachiskiYT");
    }
    public static void OpenMySite() 
    {
        Application.OpenURL("https://hachiski.com");
    }


}
