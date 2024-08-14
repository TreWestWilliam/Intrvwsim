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
    public static Settings MySettings;
    public Settings Settings2;
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

    [Header("Audio Stuff")]
    public AudioSource[] SFXplayers;
    public AudioSource DialoguePlayer;
    public AudioSource MusicPlayer;

    [Header("Unpause")]
    public DialogueManager DM;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        //TODO: LOAD SETTINGS
        if (MySettings == null) 
        {
            MySettings = new();
        }

        if (!MySettings.IsInitialized)
        {
            string path =  $"{Application.persistentDataPath}/InterviewSimulatorSettings.xml";
            if (File.Exists(path))
            {
                LoadSettings();
                UpdateSliders();
                ApplySettingsNoUpdate();
                UpdateSettings();
            }
            else
            {
                MySettings = new Settings();
                ApplySettingsNoUpdate();
                UpdateSliders();
                UpdateSettings();
                SaveSettings();
            }
            MySettings.IsInitialized = true;
        }
        else 
        {
            ApplySettings();
        }
        
    }

    public void UpdateSliders() 
    {
        Mastervol.value = MySettings.MasterVolume;
        SFXvol.value = MySettings.Svolume;
        DialogueVol.value = MySettings.DialogueVolume;
        MusicVol.value = MySettings.MusicVolume;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSettings() 
    {
        string path = Application.persistentDataPath;
        path = $"{path}/InterviewSimulatorSettings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Debug.Log(json);
            MySettings =(Settings) JsonUtility.FromJson(json,typeof(Settings));
            //Note: I AM SO FUCKING DONE WITH THIS SERIALIZATION BULLSHIT IM WRITING IT MY SELF;
            //
            //MySettings.Svolume = float.Parse(json.Substring(json.IndexOf("\"Svolume\":"), json.IndexOf(",", json.IndexOf("\"Svolume\":") - json.IndexOf("\"Svolume\":"))));

            /*
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            using StreamReader sr = new StreamReader(path);
            {
                MySettings = (Settings)ser.Deserialize(sr);
            }

            sr.Close();
            */

            Settings2 = MySettings;
            //todo applysettings;
            //ApplySettings();
        }
    }

    public void ApplySettings() 
    {
        Application.targetFrameRate = MySettings.TargetFrameRate;
        Screen.SetResolution(MySettings.Resolution.x, MySettings.Resolution.y, MySettings.IsFullscreen);
        FPS_Choice.value = MySettings.TargetFrameRateChoice;
        Mastervol.value = MySettings.MasterVolume;
        SFXvol.value = MySettings.Svolume;
        DialogueVol.value = MySettings.DialogueVolume;
        MusicVol.value = MySettings.MusicVolume;

        CalculatedSFX = MySettings.MasterVolume * MySettings.Svolume;
        CalculatedDialogue = MySettings.MasterVolume * MySettings.DialogueVolume;
        CalculatedMusic = MySettings.MasterVolume * MySettings.MusicVolume;

        //TODO Apply settings to the audio stuff;

        foreach (AudioSource AS in SFXplayers) 
        {
            AS.volume = CalculatedSFX;
        }
        if (DialoguePlayer != null) 
        {
            DialoguePlayer.volume = CalculatedDialogue;
        }
        if (MusicPlayer!=null) 
        {
            MusicPlayer.volume = CalculatedMusic;
        }
    }

    public void ApplySettingsNoUpdate() 
    {
        CalculatedSFX = MySettings.MasterVolume * MySettings.Svolume;
        CalculatedDialogue = MySettings.MasterVolume * MySettings.DialogueVolume;
        CalculatedMusic = MySettings.MasterVolume * MySettings.MusicVolume;

        //TODO Apply settings to the audio stuff;

        foreach (AudioSource AS in SFXplayers)
        {
            AS.volume = CalculatedSFX;
        }
        if (DialoguePlayer != null)
        {
            DialoguePlayer.volume = CalculatedDialogue;
        }
        if (MusicPlayer != null)
        {
            MusicPlayer.volume = CalculatedMusic;
        }
    }

    public void SaveSettings() 
    {
        string path = Application.persistentDataPath;
        if (!Directory.Exists(path)) 
        {
            Directory.CreateDirectory(path);
        }
        path = $"{path}/InterviewSimulatorSettings.json";

        string json = JsonUtility.ToJson(MySettings);
        File.WriteAllText(path, json);
        
        /*
        XmlSerializer Serializer = new XmlSerializer(typeof(Settings));
        Directory.CreateDirectory(path);
        using var writer = new StreamWriter($"{path}/InterviewSimulatorSettings.xml");
        Serializer.Serialize(writer, MySettings);
        writer.Close();*/


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

    public void AudioSliderChange(int slider) 
    {
        switch (slider) 
        {
            case 0: MySettings.MasterVolume = Mastervol.value ;break;
            case 1: MySettings.Svolume= SFXvol.value; break;
            case 2:  MySettings.DialogueVolume= DialogueVol.value; break;
            case 3: MySettings.MusicVolume= MusicVol.value; break;
        }
        ApplySettingsNoUpdate();
    }

    public void SetFullScreen() 
    {
        MySettings.IsFullscreen = FullScreenToggle.isOn;
        Screen.fullScreen = FullScreenToggle.isOn;
    }

    public void UpdateSettings() 
    {
        MySettings.MasterVolume = Mastervol.value;
        MySettings.MusicVolume = MusicVol.value;
        MySettings.Svolume = SFXvol.value;
        MySettings.DialogueVolume = DialogueVol.value;
        MySettings.IsFullscreen = FullScreenToggle.isOn;

        switch (FPS_Choice.value) 
        {
            case 0: MySettings.TargetFrameRate = -1;break;
            case 1: MySettings.TargetFrameRate = 30;break;
            case 2: MySettings.TargetFrameRate = 60;break;
            case 3: MySettings.TargetFrameRate = 120;break;
            case 4: MySettings.TargetFrameRate = 144; break;
            case 5: MySettings.TargetFrameRate = 69; break;
        }
        MySettings.TargetFrameRateChoice = FPS_Choice.value;

    }

    public void Unpause() 
    {
        if (DM != null)
        {
            if (DM.CurrentDialogue.Type == DialogueType.choiceFour || DM.CurrentDialogue.Type == DialogueType.choiceTwo)
            {
                DM._State = DialogueStates.choice;
            }
            else 
            {
                DM._State = DialogueStates.talking;
            }
        }
    }

    public void SaveApplyButton() 
    {
        ApplySettings();
        SaveSettings();
    }

}

[System.Serializable]
[XmlRoot("Settings")]
public class Settings 
{
    [XmlElement("IsInitialized")]
    public bool IsInitialized = false;
    [XmlElement("TargetFrameRate")]
    public int TargetFrameRate=-1;
    [XmlElement("TargetFrameRateChoice")]
    public int TargetFrameRateChoice = 0;
    [XmlElement("IsFullscreen")]
    public bool IsFullscreen =false;
    [XmlElement("Resolution")]
    public CustomVector2Int Resolution = new(1920,1080);
    [XmlElement("MasterVolume")]
    public float MasterVolume=1;
    public float Svolume=1;
    [XmlElement("DialogueVolume")]
    public float DialogueVolume=1;
    [XmlElement("MusicVolume")]
    public float MusicVolume=1;
}

[System.Serializable]
public class CustomVector2Int 
{
    [XmlElement("x")]
    public int x;
    [XmlElement("y")]
    public int y;

    public CustomVector2Int(int _x,int _y) 
    {
        x = _x;
        y = _y;
    }
    public CustomVector2Int() 
    {
        x = 0;
        y = 0;
    }
}