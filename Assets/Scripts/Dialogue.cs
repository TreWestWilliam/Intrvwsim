using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue 
{
    public DialogueType Type;
    public string Text;
    public Character _Character;
    public Dialogue Next;
   

    //For Choices
    public DialogueChoice[] dialogueChoices;

    public Dialogue(string s) 
    {
        Text = s;
    }
    public Dialogue(string s,  Dialogue d, DialogueType t = DialogueType.text)
    {
        Text = s;
        Type = t;
        Next = d;
    }

    public Dialogue(string s, Dialogue d)
    {
        Text = s;
        Next = d;
    }
    public Dialogue(DialogueType t, string s)
    {
        Text = s;
        Type = t;
    }
    public Dialogue(DialogueType t)
    {
        Type = t;
    }

    public Dialogue(DialogueType t, string choice1text, ChoiceType firstType,Dialogue FirstChoiceNextDialogue,string choice2text,ChoiceType SecondType,Dialogue SecondChoiceNextDialogue)
    {
        Type = t;
        dialogueChoices = new DialogueChoice[2];
        dialogueChoices[0]._Text = choice1text;
        dialogueChoices[1]._Text = choice2text;

        dialogueChoices[0].type = firstType;
        dialogueChoices[1].type = SecondType;

        dialogueChoices[0].NextDialogue = FirstChoiceNextDialogue;
        dialogueChoices[1].NextDialogue = SecondChoiceNextDialogue;
    }
}

[System.Serializable]
public enum DialogueType 
{ 
    text,
    choiceTwo,
    choiceFour,
    halt,
    SpaceMinigame,
    CodingMinigame,
    ChoicesMinigame,
    minigame_one
}

public struct DialogueChoice 
{
    public string _Text;
    public ChoiceType type;
    public Dialogue NextDialogue;
    
}

public enum ChoiceType 
{ 
    placebo,
    pseudo,
    addPoint,
    removePoint
}