using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Stuff")]
    private int Iterator;
    public TMP_Text TextOut;
    public AudioSource SoundPlayer;
    private List<Dialogue> Ledger;
    public Dialogue CurrentDialogue;
    public DialogueStates _State;
    public AudioClip[] SpeakingClips;
    public bool IsSpeaking = false;
    private bool StartedSounds = false;

    public Animator CurrentAnimator;

    public float TextSpeed = .25f;

    public int points = 0;

    [Header("UI Tabs")]
    public GameObject TextTab;
    public GameObject TwoChoices;
    public GameObject FourChoices;
    public TMP_Text TwosChoice1;
    public TMP_Text TwosChoice2;
    public TMP_Text Choice1;
    public TMP_Text Choice2;
    public TMP_Text Choice3;
    public TMP_Text Choice4;

    // Start is called before the first frame update
    void Start()
    {
        Iterator = 0;
        Ledger = new();
        //_State = DialogueStates.paused;

        /* CurrentDialogue = new("This was a Triumph.",
             new("Making a note here: HUGE SUCCESS",
             new Dialogue("Even though you broke my heart and killed me.", 
             new("Aperture Science", new("We do what we must, because we can.",
             new("For the good of all of us, except the ones who are dead.", 
             new Dialogue(DialogueType.halt, "lol") ))))));*/

        /*
        CurrentDialogue = new Dialogue("This is a test of choices");
        Dialogue FirstChoice = new Dialogue("You chose the first option");
        Dialogue SecondChoice = new Dialogue("You chose the second option");
        CurrentDialogue.Next = new Dialogue(DialogueType.choiceTwo, "First",ChoiceType.placebo,FirstChoice,"Second is Best!",ChoiceType.placebo,SecondChoice);
        */

        CurrentDialogue = new Dialogue("The next Dialogue will cause the minigame to load");
        CurrentDialogue.Next = new Dialogue(DialogueType.ChoicesMinigame, "Nothing here");
        CurrentDialogue.Next.Next = new Dialogue("Wasn't that fun?!");
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentDialogue.Type == DialogueType.text && _State == DialogueStates.talking) 
        {
            if (Iterator == 0)
            {
                AddNextCharacter();
                SpeakSound();
                StartedSounds = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ledger.Add(CurrentDialogue);

                if (Iterator < CurrentDialogue.Text.Length)
                {
                    Iterator = CurrentDialogue.Text.Length;
                    TextOut.text = CurrentDialogue.Text;
                }
                else
                {
                    LoadNextDialogue(CurrentDialogue.Next);
                }
            }
        }

        
    }

    private void LoadNextDialogue(Dialogue MyDialogue) 
    {
        Iterator = 0;
        TextOut.text = "";
        StartedSounds = false;

        if (CurrentDialogue.Type != MyDialogue.Type) 
        {
            ToggleOffAllTabs();
        }

        CurrentDialogue = MyDialogue;

        switch (MyDialogue.Type) 
        {

            case DialogueType.text:ChangeToTextDialogue();break;
            case DialogueType.choiceTwo: ChangeToTwoChoices();break;
            case DialogueType.ChoicesMinigame: ChoicesMinigame();break;
        }
    }

    private void ChoicesMinigame() 
    {

        SceneManager.LoadSceneAsync("ChoicesScene", LoadSceneMode.Additive);
    }

    public void EndChoicesMinigame() 
    {
        SceneManager.UnloadSceneAsync("ChoicesScene");
        LoadNextDialogue(CurrentDialogue.Next);
    }

    private void ChangeToTwoChoices() 
    {
        TwoChoices.gameObject.SetActive(true);
        if (CurrentDialogue.dialogueChoices.Length == 2) 
        {
            TwosChoice1.text = CurrentDialogue.dialogueChoices[0]._Text;
            TwosChoice2.text = CurrentDialogue.dialogueChoices[1]._Text;
        }
        else 
        {
            Debug.LogError("Dialogue Manager's Current Dialogue has the wrong length of choices for Two Choices to be made", gameObject);
        }
    
    }

    private void ChangeToTextDialogue() 
    {
        if (TextTab.activeInHierarchy)
        {

        }
        else 
        {
            ToggleOffAllTabs();
            TextTab.SetActive(true);
        }
    }


    private void ToggleOffAllTabs() 
    {
        TextTab.SetActive(false);
        TwoChoices.SetActive(false);
        FourChoices.SetActive(false);
    }

    private void AddNextCharacter() 
    {
        if (Iterator < CurrentDialogue.Text.Length)
        {
            TextOut.text += CurrentDialogue.Text.ToCharArray()[Iterator];
            Iterator++;
            CurrentAnimator.SetBool("IsTalking", true);
            IsSpeaking = true;
            Invoke(nameof(AddNextCharacter), TextSpeed);
        }
        else
        {
            CurrentAnimator.SetBool("IsTalking", false);
            IsSpeaking = false;
        }
    }

    public void SpeakSound() 
    {
        if (!IsSpeaking) 
        {
            Debug.Log("Cant Speak");
            return; 
        } 

        if (SpeakingClips.Length > 0)
        {
            int SoundChoice = Random.Range(0, SpeakingClips.Length);
            SoundPlayer.PlayOneShot(SpeakingClips[SoundChoice]);
            Invoke(nameof(SpeakSound), SpeakingClips[SoundChoice].length);

        }
        else
        {
            Debug.Log("We have no sounds to play", gameObject);
        }
    }

    public void FirstButtonClick() 
    {
        ButtonClickDebugMessages();

        ProcessDialogueChoice(CurrentDialogue.dialogueChoices[0]);
    }
    public void SecondButtonClick()
    {
        ButtonClickDebugMessages();
        ProcessDialogueChoice(CurrentDialogue.dialogueChoices[1]);
    }
    public void ButtonClickDebugMessages() 
    {
        if (!(CurrentDialogue.Type == DialogueType.choiceTwo || CurrentDialogue.Type == DialogueType.choiceFour))
        {
            Debug.Log("Dialogue Type isnt a choice but still buttons are being pressed.");
        }

        if (CurrentDialogue.dialogueChoices == null)
        {
            Debug.Log("A choice was made but choices werent instantiated");
        }

    }

    public void ProcessDialogueChoice(DialogueChoice MyChoice) 
    {
        switch (MyChoice.type) 
        {
            case ChoiceType.addPoint:points++;break;
            case ChoiceType.removePoint: points--; break;
            case ChoiceType.placebo: Debug.Log("Placebo implemented"); break;
        }

        LoadNextDialogue(MyChoice.NextDialogue);
    }


}

public enum DialogueStates 
{
    paused,
    talking,
    choice
}