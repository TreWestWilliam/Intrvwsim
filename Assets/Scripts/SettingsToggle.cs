using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    public GameObject Target;
    public SettingsStuff Set;
    public DialogueManager DM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Target.activeInHierarchy) 
        {
            if (Input.GetKey(KeyCode.Escape) || Input.GetMouseButtonDown(1)) 
            {
                Target.SetActive(true);

                Set.ApplySettings();

                if (DM._State != DialogueStates.paused) 
                {
                    DM._State = DialogueStates.paused;
                }

            }
        }
        
    }
}
