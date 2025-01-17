using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Stuff")]
    public bool IsDebug = false;
    private int Iterator;
    public TMP_Text TextOut;
    public TMP_Text NameText;
    public AudioSource SoundPlayer;
    public AudioSource SFXPlayer;
    public AudioSource MusicPlayer;
    private List<Dialogue> Ledger;
    public Dialogue CurrentDialogue;
    public DialogueStates _State;
    public AudioClip[] SpeakingClips;
    public AudioClip[] SoundEffects;
    public AudioClip[] Music;
    public bool IsSpeaking = false;
    private bool StartedSounds = false;
    [Space]
    [Header("Character")]
    public SpriteRenderer SpeakerSpriteRenderer;
    public Animator CurrentAnimator;
    public float TextSpeed = .25f;
    public int points = 0;
    [Space]
    [Header("Setting")]
    public SpriteRenderer Foreground;
    public SpriteRenderer Background;
    [Space]
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
    [Space]
    [Header("Characters")]
    public Character Hachi;
    public Character Korvilliath;
    public Character HRSlimeStacy;
    public Character NavOffice;
    public Character Bob;
    public Character RickCat;
    public Character BanthanyJanny;
    public Character WafflesSecurity;
    public Character YauwnCatnip;
    public Character WeirdCreature;
    public Character None;


    [Header("Foregrounds/Backgrounds")]
    public GameObject GameArt;
    public GameObject TextOverlay;
    public FGBG IntroCutscene;
    public FGBG HRoffice;
    public FGBG ManagerOffice;
    public FGBG CoderOffice;
    public FGBG BroomCloset;
    public FGBG Interrogation;
    public FGBG Navigation;
    public FGBG Helpdesk;
    [Space]
    public FGBG WeirdEnding;
    public FGBG WeirdEnding2;
    public FGBG WeirdEnding3;
    public FGBG WeirdEnding4;
    public FGBG CatnipEnding;
    public FGBG ITEND1;
    public FGBG ITEND2;
    public FGBG ITEND3;
    public FGBG ITEND4;
    public FGBG ITEND5;
    public FGBG HighCommanderEnd;
    public FGBG JanitorEnd;
    public FGBG NavEnd;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Data path: {Application.dataPath}");
        Iterator = 0;
        Ledger = new();
        //_State = DialogueStates.paused;

        /* CurrentDialogue = new("This was a Triumph.",
             new("Making a note here: HUGE SUCCESS",
             new Dialogue("Even though you broke my heart and killed me.", 
             new("Aperture Science", new("We do what we must, because we can.",
             new("For the good of all of us, except the ones who are dead.", 
             new Dialogue(DialogueType.halt, "lol") ))))));*/

        CurrentDialogue = new(DialogueType.cutscene, "Deep in space...");
        CurrentDialogue.BackgroundMusic = Music[1];
        CurrentDialogue._FGBG = IntroCutscene;
        CurrentDialogue._Character = None;
        CurrentDialogue.Next = new Dialogue(DialogueType.cutscene, "Your shuttle is taking you towards the HART Pavillion.  The place where your interview will be taking place.");
        
        Dialogue Three = new(DialogueType.cutscene, "And before you know it, a AI assistant has guided you towards where your interview will take place.");
        CurrentDialogue.Next.Next = Three;
        Dialogue Four = new(DialogueType.blankLoad);
        Three.Next = Four;
        //CurrentDialogue = Dialogues.Programmer(this);
        //CurrentDialogue = new(DialogueType.blankLoad);
        LoadNextDialogue(CurrentDialogue);
        //LoadNextDialogue(Dialogues.SharedARInterview(this));
        if (IsDebug) 
        {
            _State = DialogueStates.paused;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDebug)
        {
            _State = DialogueStates.paused;
        }
        if (CurrentDialogue.Type == DialogueType.text || CurrentDialogue.Type == DialogueType.cutscene) 
        {
            if (_State == DialogueStates.talking)
            {
                if (Iterator == 0)
                {
                    AddNextCharacter();
                    SpeakSound();
                    StartedSounds = true;
                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Ledger.Add(CurrentDialogue);

                    if (Iterator < CurrentDialogue.Text.Length)
                    {
                        Iterator = CurrentDialogue.Text.Length;
                        TextOut.text = CurrentDialogue.Text;
                        SoundPlayer.Stop();
                    }
                    else
                    {
                        LoadNextDialogue(CurrentDialogue.Next);
                    }
                }
            }

        }   
    }



    private void LoadNextDialogue(Dialogue MyDialogue) 
    {
        Iterator = 0;
        TextOut.text = "";
        StartedSounds = false;
        SoundPlayer.Stop();


        if (CurrentDialogue.Type != MyDialogue.Type) 
        {
            ToggleOffAllTabs();
        }

        if (MyDialogue.BackgroundMusic != null) 
        {
            MusicPlayer.Stop();
            MusicPlayer.clip = MyDialogue.BackgroundMusic;
            MusicPlayer.Play();
        }

        if (MyDialogue._Character != null) 
        {
            NameText.text = MyDialogue._Character.CharacterName;
            SpeakingClips = MyDialogue._Character.SpeakingSounds;
            SpeakerSpriteRenderer.sprite = MyDialogue._Character.CharacterSprite;

        }

        if (MyDialogue._FGBG != null) 
        {
            if (MyDialogue._FGBG.FG != null)
            {
                Foreground.gameObject.SetActive(true);
                Foreground.sprite = MyDialogue._FGBG.FG;
            }
            else 
            {
                Foreground.gameObject.SetActive(false);
            }

            if (MyDialogue._FGBG.BG != null)
            {
                Background.gameObject.SetActive(true);
                Background.sprite = MyDialogue._FGBG.BG;
            }
            else
            {
                Background.gameObject.SetActive(false);
            }
        }

        CurrentDialogue = MyDialogue;

        switch (MyDialogue.Type) 
        {

            case DialogueType.text:ChangeToTextDialogue();break;
            case DialogueType.choiceTwo: ChangeToTwoChoices();break;
            case DialogueType.choiceFour: ChangeToFourChoices(); break;
            case DialogueType.ChoicesMinigame: ChoicesMinigame();break;
            case DialogueType.SpaceMinigame: MeteorMinigame(); break;
            case DialogueType.CodingMinigame: CodingMinigame(); break;
            case DialogueType.cutscene: CutsceneMode(); break;
            case DialogueType.final: FinalDialogue(); break;
            case DialogueType.calcEnding:CalculateEnding(); break;
            case DialogueType.blankLoad:LoadBlank(); break;
            case DialogueType.soundeffect:PlaySoundDialogue(); break;
        }
    }

    private void FinalDialogue() 
    {
        Dialogues.EndingName = CurrentDialogue.Text;
        SceneManager.LoadSceneAsync(5, LoadSceneMode.Single);
    }

    private void CalculateEnding() 
    {
        //Jobs that always lead to a certain result
        switch (Dialogues.PathName) 
        {
            case "High Commander": CalcHCEnd(); break;
            case "Intergalactic Systems Operator": LoadNextDialogue(Dialogues.ISOEnd(this));  break;
            case "Information Technology Helpdesk Punching Bag and Ticket Escalation Agent": LoadNextDialogue(Dialogues.ITEnding(this)); break;
            case "Alien Resources": CalcAREnd(); break;
            case "Press Relations": LoadNextDialogue(Dialogues.BadEnding(this));  break;
            case "Object Orientated Organizational Programming Systems Intergalactic Engineer": LoadNextDialogue(Dialogues.ProgrammerEnding(this)); break;
            case "Assistant Manager of Tentacle Cleaning internship": LoadNextDialogue(Dialogues.JanitorEnd(this));  break;
            case "Senior Catnip Production Manager": CalcCatnipEnd();  break;
        }


        //Jobs that need more
    }

    private void CalcHCEnd() 
    {
        if (points > 100)
        {
            LoadNextDialogue(Dialogues.HCEnd(this));
        }
        else 
        {
            LoadNextDialogue(Dialogues.BadEnding(this));
        }
    }

    private void CalcCatnipEnd() 
    {
        if (points < 3)
        {
            LoadNextDialogue(Dialogues.BadEnding(this));
        }
        else 
        {
            LoadNextDialogue(Dialogues.CatnipEnd(this));
        }
    }
    private void CalcAREnd() 
    {
        if (points >= 2)
        {
            LoadNextDialogue(Dialogues.AREnd(this));
        }
        else 
        {
            LoadNextDialogue(Dialogues.BadEnding(this));
        }
    }

    private void CutsceneMode() 
    {
        NameText.gameObject.SetActive(false);
        TextTab.gameObject.SetActive(true);

        if (CurrentDialogue._Character == null) 
        {
            SpeakerSpriteRenderer.sprite = null;
            SpeakingClips = None.SpeakingSounds;
        }

    }

    private void PlaySoundDialogue() 
    {
        SFXPlayer.Stop();
        switch (CurrentDialogue.Text) 
        {
            case "Drumroll": SFXPlayer.PlayOneShot(SoundEffects[0]); break;
            default:break;
        }
        LoadNextDialogue(CurrentDialogue.Next);
    }


    private void LoadBlank() 
    {
        switch (Dialogues.PathName) 
        {
            case "High Commander":LoadNextDialogue(Dialogues.HighCommanderStart(this)); break;
            case "Intergalactic Systems Operator": LoadNextDialogue(Dialogues.IntergalacticSystemsOperator(this)); break;
            case "Information Technology Helpdesk Punching Bag and Ticket Escalation Agent": LoadNextDialogue(Dialogues.IT(this)); break;
            case "Alien Resources": LoadNextDialogue(Dialogues.AlienResources(this)); break;
            case "Press Relations": LoadNextDialogue(Dialogues.PressRelations(this)); break;
            case "Object Orientated Organizational Programming Systems Intergalactic Engineer": LoadNextDialogue(Dialogues.Programmer(this)); break;
            case "Assistant Manager of Tentacle Cleaning internship": LoadNextDialogue(Dialogues.TentcleCleaner(this)); break;
            case "Senior Catnip Production Manager": LoadNextDialogue(Dialogues.CatnipProduction(this));  break;
            default: Debug.Log($"Default path reached"); break;


        }
    }

    private void HideArt() 
    {
        GameArt.SetActive(false);
        TextOverlay.SetActive(false);
    }
    private void UnhideArt() 
    {
        GameArt.SetActive(true);
        TextOverlay.SetActive(true);
    }

    private void ChoicesMinigame() 
    {

        SceneManager.LoadSceneAsync("ChoicesScene", LoadSceneMode.Additive);
    }

    private void MeteorMinigame()
    {
        HideArt();
        SceneManager.LoadSceneAsync("SpaceDefense", LoadSceneMode.Additive);
    }
    

    public void EndMeteorGame(int Choice) 
    {
        UnhideArt();
        LoadNextDialogue(CurrentDialogue.dialogueChoices[Choice].NextDialogue);
        SceneManager.UnloadSceneAsync("SpaceDefense");

    }
    private void CodingMinigame()
    {
        SceneManager.LoadSceneAsync("CodingGame", LoadSceneMode.Additive);
    }
    public void EndChoicesMinigame() 
    {
        SceneManager.UnloadSceneAsync("ChoicesScene");
        LoadNextDialogue(CurrentDialogue.Next);
    }

    public void EndCodingMinigame() 
    {
        SceneManager.UnloadSceneAsync("CodingGame");
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
    private void ChangeToFourChoices()
    {
        FourChoices.gameObject.SetActive(true);
        if (CurrentDialogue.dialogueChoices.Length == 4)
        {
            Choice1.text = CurrentDialogue.dialogueChoices[0]._Text;
            Choice2.text = CurrentDialogue.dialogueChoices[1]._Text;
            Choice3.text = CurrentDialogue.dialogueChoices[2]._Text;
            Choice4.text = CurrentDialogue.dialogueChoices[3]._Text;
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
        NameText.gameObject.SetActive(true);
        TwoChoices.SetActive(false);
        FourChoices.SetActive(false);
    }

    private void AddNextCharacter() 
    {
        if (_State == DialogueStates.talking)
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
        else 
        {
            Invoke(nameof(AddNextCharacter), TextSpeed);
        }
        
    }

    public void SpeakSound() 
    {
        if (!IsSpeaking) 
        {
            Debug.Log("Cant Speak");
            return; 
        } 

        if (SpeakingClips.Length > 0  && _State == DialogueStates.talking)
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

    public void ButtonClick(int button) 
    {
        ButtonClickDebugMessages();
        ProcessDialogueChoice(CurrentDialogue.dialogueChoices[button]);
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