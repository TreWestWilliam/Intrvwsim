using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoToTitleScreen : MonoBehaviour
{
    public void LoadTitleScreen() 
    {
        SceneManager.LoadSceneAsync("SampleScene",LoadSceneMode.Single);
    }
}
