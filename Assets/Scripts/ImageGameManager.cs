using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageGameManager : MonoBehaviour
{
    public Texture2D[] Images;
    public string[] IdeaStrings;
    public Image Button1Image;
    public Image Button2Image;
    public TMP_Text Button1Text;
    public TMP_Text Button2Text;
    public int score;
    public int ToEnd = 10;
    public int ChoicesMade = 0;

    [Header("Stuff and stuff yknow")]
    public DialogueManager DM;


    // Start is called before the first frame update
    void Start()
    {
        if (Images.Length < 2) 
        {
            Debug.Log("We need more images");
        }

        if (DM == null) 
        {
            DM = GameObject.Find("DialogueSystem").GetComponent<DialogueManager>();
        }

        OnClickedButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedButton() 
    {
        if (Random.value > .6) 
        {
            score++;
        }
        ChoicesMade++;
        if (ChoicesMade >= ToEnd) 
        {
            DM.EndChoicesMinigame();
        }

        Texture2D Image1 = Images[(int)Random.Range(0, Images.Length)];
        Button1Image.sprite = Sprite.Create( Image1,Button1Image.sprite.rect,Button1Image.sprite.pivot );
        Texture2D Image2 = Images[(int)Random.Range(0, Images.Length)];
        Button2Image.sprite = Sprite.Create(Image2, Button1Image.sprite.rect, Button1Image.sprite.pivot);

        bool ShowText = (Random.value > .5);
       
        Button1Text.gameObject.SetActive(ShowText);
        Button2Text.gameObject.SetActive(ShowText);
        Button1Text.text = IdeaStrings[(int)Random.Range(0, IdeaStrings.Length)];
        Button2Text.text = IdeaStrings[(int)Random.Range(0, IdeaStrings.Length)];
        

    }

}
