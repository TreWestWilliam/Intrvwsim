using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CodeTestManager : MonoBehaviour
{
    public TMP_Dropdown DropOne;
    public TMP_Dropdown DropTwo;
    public TMP_Dropdown DropThree;

    public DialogueManager DM;
    // Start is called before the first frame update
    void Start()
    {
        DM = FindFirstObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Finish() 
    {
        DM.points += CalcScore();
        DM.EndCodingMinigame();
    }
    
    public int CalcScore()
    {
        int correct = 0;
        if (DropOne.value == 1) { correct++; }
        if (DropTwo.value ==0) { correct++; }
        if (DropThree.value == 3) { correct++; }
        return 6491 * correct;
    }
}
