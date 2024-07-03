using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWebsite : MonoBehaviour
{
    public static void OpenTwitch() 
    {
        System.Diagnostics.Process.Start("https://twitch.tv/hachiski");
    }
    public static void OpenYoutube()
    {
        System.Diagnostics.Process.Start("https://youtube.com/@Hachiski");
    }
    public static void OpenKoFi()
    {
        System.Diagnostics.Process.Start("https://ko-fi.com/hachiski");
    }
    public static void OpenTwitter()
    {
        System.Diagnostics.Process.Start("https://x.com/HachiskiYT");
    }

}
