using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Character 
{
    public string CharacterName;
    public AudioClip[] SpeakingSounds;
    public Sprite CharacterSprite;


    public Character(string s) 
    {
        CharacterName = s;   
    }
}
