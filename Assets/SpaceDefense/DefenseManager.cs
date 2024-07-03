using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenseManager : MonoBehaviour
{
    public int Score;
    public float TimeEnd;
    public float TotalTime;
    public int Health;

    public TMP_Text DisplayText;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Health = 10;
        TimeEnd = Time.time + 30;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = $"TIME:{(int)(TimeEnd - Time.time)} SCORE:{Score} HEALTH: {Health}";
    }

    public void Damage() 
    { 
        Health--;
        if (Health <= 0) 
        { 
        //End Game
        }
    }

    public void AddScore() 
    {
        Score += 10;
    }
    public void AddScore(float multiplier)
    {
        Score += Mathf.RoundToInt(10*Mathf.Abs(multiplier));
    }
}
