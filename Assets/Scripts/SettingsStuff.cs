using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using TMPro;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class SettingsStuff : MonoBehaviour
{
    public Settings MySettings;
    public TMP_Dropdown FPS_Choice;
    public Toggle FullScreenToggle;
    public Slider Mastervol;
    public Slider SFXvol;
    public Slider DialogueVol;
    public Slider MusicVol;

    [Header("Volumes")]
    public float CalculatedSFX;
    public float CalculatedMusic;
    public float CalculatedDialogue;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //TODO: LOAD SETTINGS
        string path = Application.persistentDataPath + "/InterviewSimulatorSettings.xml";
        if (File.Exists(path))
        {
            LoadSettings();
        }
        else 
        {
            MySettings = new Settings();
            ApplySettings();
            SaveSettings();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSettings() 
    {
        string path = Application.persistentDataPath + "/InterviewSimulatorSettings.xml";
        if (File.Exists(path))
        {
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            using StreamReader sr = new StreamReader(path);
            MySettings = (Settings)ser.Deserialize(sr);
            //todo applysettings;
            ApplySettings();
        }
    }

    public void ApplySettings() 
    {
        Application.targetFrameRate = MySettings.TargetFrameRate;
        Screen.SetResolution(MySettings.Resolution.x, MySettings.Resolution.y, MySettings.IsFullscreen);
        FPS_Choice.value = MySettings.TargetFrameRateChoice;
        Mastervol.value = MySettings.MasterVolume;
        SFXvol.value = MySettings.SFXVolume;
        DialogueVol.value = MySettings.DialogueVolume;
        MusicVol.value = MySettings.MusicVolume;

        CalculatedSFX = MySettings.MasterVolume * MySettings.SFXVolume;
        CalculatedDialogue = MySettings.MasterVolume * MySettings.DialogueVolume;
        CalculatedMusic = MySettings.MasterVolume * MySettings.MusicVolume;

        //TODO Apply settings to the audio stuff;
    }

    public void SaveSettings() 
    {
        string path = Application.persistentDataPath;
        XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
        Directory.CreateDirectory(path);
        using var writer = new StreamWriter($"{path}/InterviewSimulatorSettings.xml");
        Serializer.Serialize(writer, MySettings);
    }

    public void SetFPS() 
    {
        int choice = FPS_Choice.value;
        MySettings.TargetFrameRateChoice = choice;
        switch (choice) 
        {
            case 0: MySettings.TargetFrameRate = -1; break;
            case 1: MySettings.TargetFrameRate = 30; break;
            case 2: MySettings.TargetFrameRate = 60; break;
            case 3: MySettings.TargetFrameRate = 120; break;
            case 4: MySettings.TargetFrameRate = 144; break;
            case 5: MySettings.TargetFrameRate = 69; break;
        }
        Application.targetFrameRate = MySettings.TargetFrameRate;
        //SaveSettings();
    }

    public void SetFullScreen() 
    {
        MySettings.IsFullscreen = FullScreenToggle.isOn;
        Screen.fullScreen = FullScreenToggle.isOn;
    }
}

[System.Serializable]
public class Settings 
{
    public int TargetFrameRate=-1;
    public int TargetFrameRateChoice = 0;
    public bool IsFullscreen =false;
    public Vector2Int Resolution = new(1920,1080);
    public float MasterVolume=1;
    public float SFXVolume=1;
    public float DialogueVolume=1;
    public float MusicVolume=1;
}
