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

    public DialogueManager Dial;

    public List<GameObject> Meteors;

    public TMP_Text DisplayText;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Health = 10;
        TimeEnd = Time.time + 30;
        Dial = FindAnyObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText.text = $"TIME:{(int)(TimeEnd - Time.time)} SCORE:{Score} HEALTH: {Health}";
        if ((TimeEnd - Time.time) <= 0) 
        {
            if (Score > 100) 
            {
                EndGame(0);
            }
            else 
            {
                EndGame(1);
            }
        }
    }

    public void Damage() 
    { 
        Health--;
        if (Health <= 0) 
        {
            //End Game
            EndGame(2);
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

    private void EndGame(int Path) 
    {
        RemoveMeteors();
        Dial.points += Score;
        Dial.EndMeteorGame(Path);
    }

    private void RemoveMeteors() 
    {
        while (Meteors.Count > 0) 
        {
            Destroy(Meteors[0]);
            Meteors.RemoveAt(0);
        }
    }
}
