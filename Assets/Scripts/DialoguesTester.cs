using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMP_Text))]
public class DialoguesTester : MonoBehaviour
{
    public DialogueManager DM;
    public string[] DialoguesToTest;
    public int Iterator = 0;
    public TMP_Text TextElement;
    public string Out;

    // Start is called before the first frame update
    void Start()
    {

        foreach (string s in DialoguesToTest) 
        {
            Out += $"{s}: {TestDialogue(LoadBlank(s), s)} \n";
            Iterator = 0;
        }

        TextElement.text = Out;

        
    }


    bool TestDialogue(Dialogue MyDialogue, string pathname) 
    {
        Iterator++;
        if (MyDialogue == null) 
        {
            Debug.Log($"Dialogue failed on Iterator {Iterator}");
            return false; 
        }

        if (MyDialogue.Type == DialogueType.cutscene || MyDialogue.Type == DialogueType.text || MyDialogue.Type == DialogueType.soundeffect ||
            MyDialogue.Type == DialogueType.ChoicesMinigame || MyDialogue.Type == DialogueType.CodingMinigame) 
        {
            if (MyDialogue.Next != null)
            {
                return TestDialogue(MyDialogue.Next, pathname);
            }
            else
            {
                Debug.Log($"FAILED: '{MyDialogue.Text}'  {Iterator}");
                return false;
            }
        }


        switch (MyDialogue.Type)
        {
            case DialogueType.choiceTwo:
                if (MyDialogue.dialogueChoices.Length == 2)
                {
                    return (TestDialogue(MyDialogue.dialogueChoices[0].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[1].NextDialogue, pathname));
                }
                else 
                {
                    return false;
                }
            case DialogueType.choiceFour:
                if (MyDialogue.dialogueChoices.Length == 4)
                {
                    return TestDialogue(MyDialogue.dialogueChoices[0].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[1].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[2].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[3].NextDialogue, pathname);
                }
                else
                {
                    return false;
                }
            case DialogueType.SpaceMinigame:
                if (MyDialogue.dialogueChoices.Length == 3)
                {
                    return TestDialogue(MyDialogue.dialogueChoices[0].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[1].NextDialogue, pathname) && TestDialogue(MyDialogue.dialogueChoices[2].NextDialogue, pathname);
                }
                else
                {
                    return false;
                }
            case DialogueType.final: return true;
            case DialogueType.calcEnding: return CalculateEnding(pathname); 
            case DialogueType.blankLoad: return TestDialogue(LoadBlank(pathname),pathname);
        }

        Debug.Log($"Dialogue {MyDialogue.Text} slipped through the if and switch statements");
        return false;
    }

    private Dialogue LoadBlank(string PathName)
    {
        switch (PathName)
        {
            case "High Commander": return Dialogues.HighCommanderStart(DM);
            case "Intergalactic Systems Operator": return Dialogues.IntergalacticSystemsOperator(DM);
            case "Information Technology Helpdesk Punching Bag and Ticket Escalation Agent": return Dialogues.IT(DM);
            case "Alien Resources": return Dialogues.AlienResources(DM); 
            case "Press Relations": return Dialogues.PressRelations(DM); 
            case "Object Orientated Organizational Programming Systems Intergalactic Engineer": return Dialogues.Programmer(DM); 
            case "Assistant Manager of Tentacle Cleaning internship": return Dialogues.TentcleCleaner(DM);
            case "Senior Catnip Production Manager": return Dialogues.CatnipProduction(DM);
            default: return null;


        }
    }

    private bool CalculateEnding(string PathName)
    {
        //Jobs that always lead to a certain result
        switch (PathName)
        {
            case "High Commander": return TestDialogue(Dialogues.HCEnd(DM), PathName);
            case "Intergalactic Systems Operator": return TestDialogue(Dialogues.ISOEnd(DM),PathName); 
            case "Information Technology Helpdesk Punching Bag and Ticket Escalation Agent": return TestDialogue(Dialogues.ITEnding(DM), PathName);
            case "Alien Resources": return TestDialogue(Dialogues.AREnd(DM), PathName);
            case "Press Relations": return TestDialogue(Dialogues.BadEnding(DM), PathName);
            case "Object Orientated Organizational Programming Systems Intergalactic Engineer": return TestDialogue(Dialogues.ProgrammerEnding(DM), PathName);
            case "Assistant Manager of Tentacle Cleaning internship": return TestDialogue(Dialogues.JanitorEnd(DM), PathName);
            case "Senior Catnip Production Manager": return TestDialogue(Dialogues.CatnipEnd(DM), PathName);
        }
        return false;


        //Jobs that need more
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
