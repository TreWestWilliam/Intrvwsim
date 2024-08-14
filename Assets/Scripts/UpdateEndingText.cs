using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(TMP_Text))]

public class UpdateEndingText : MonoBehaviour
{

    public TMP_Text EndText;
    // Start is called before the first frame update
    void Start()
    {
        EndText.text = $"You got the '{Dialogues.EndingName}'";
    }

}
