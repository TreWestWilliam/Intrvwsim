using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingMenu : MonoBehaviour
{
    public string JobTitle;
    public string PlayersName;
    public string Species;
    public string Planet;

    [Header("Job Title")]
    public TMP_Dropdown JobTitleDropdown;
    [Header("Name")]
    public GameObject NamesScreen;
    public TMP_InputField FullName;
    public TMP_InputField PrefferedName;
    public TMP_Text NameError;
    [Header("Qualifications")]
    public GameObject QualificationsScreen;
    public TMP_Text QualficationsText;
    public bool IsQualified = false;
    [Header("Identificaiton")]
    public GameObject IdentifyGroup;
    private int Disclose = 0;
    public GameObject SpeciesGroup;
    public GameObject HomeGroup;
    public GameObject UniverseGroup;
    public TMP_Dropdown SpeciesDropdown;
    public TMP_Dropdown HomeplanetDropdown;
    [Header("Ending")]
    public GameObject Uploading;
    public GameObject Finished;
    



    public void SelectJobTitle() 
    {
        JobTitle = JobTitleDropdown.options[JobTitleDropdown.value].text;
    }

    public void ChooseName() 
    {
        if (FullName.text == "") 
        {
            NameError.gameObject.SetActive(true);
            NameError.text = "Please write your full legal name";
            return;
        }
        if (PrefferedName.text == "")
        {
            NameError.gameObject.SetActive(true);
            NameError.text = "Please write your Preffered Name";
            return;
        }

        PlayersName = PrefferedName.text;
        NamesScreen.SetActive(false);
        QualificationsScreen.SetActive(true);

    }

    public void Disclosures() 
    {
        if (Disclose < 2)
        {
            
            if (Disclose == 0) 
            {
                SpeciesGroup.SetActive(false);
                HomeGroup.SetActive(true);
            }
            if (Disclose == 1) 
            {
                HomeGroup.SetActive(false);
                UniverseGroup.SetActive(true);
            }
            Disclose++;

        }
        else 
        {
            Species = SpeciesDropdown.options[SpeciesDropdown.value].text;
            Planet = HomeplanetDropdown.options[HomeplanetDropdown.value].text;
            IdentifyGroup.SetActive(false);
            Uploading.SetActive(true);
        }
    }

    public void SubmitAnimationFinished() 
    {
        Uploading.SetActive(false);
        Finished.SetActive(true);
    }

    public void IAmQualified() { IsQualified = true; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
