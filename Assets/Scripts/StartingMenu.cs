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


    private string[] Qualifications = {"Key Responsibilities:\n* Command and oversee all aspects of starship operations during missions.\n* Lead and manage a diverse crew, fostering a collaborative and efficient work environment.\n* Develop and implement mission plans, including scientific research, exploration, and first contact protocols.\n* Ensure the safety and well-being of all crew members through effective risk management and emergency response strategies.\n* Maintain communication with mission control and other interstellar entities.\n* Navigate complex interstellar environments, utilizing advanced astrogation systems.\n* Oversee maintenance and upgrades of starship systems, including propulsion, life support, and defense mechanisms.\n* Represent the starship and its crew in diplomatic engagements with extraterrestrial civilizations.\nQualifications:\n* Advanced degree in Astrophysics, Engineering, or a related field.\n* Minimum of 10 years of experience in space missions or aerospace operations.\n* Certification from a recognized space command training program.\n* Proficiency in interstellar navigation and astrogation software.\n* Demonstrated leadership and management experience in high-stakes environments.\n* Strong problem-solving skills and ability to make critical decisions under pressure.\n* Excellent communication skills, with the ability to interact effectively with diverse cultures and species.\n* Thorough understanding of space law and interstellar treaties.\nPreferred Skills:\n* Experience with extraterrestrial geology, biology, or xenolinguistics.\n* Familiarity with quantum communication systems.\n* Background in cyber defense and advanced AI systems.\n* Proficiency in multiple languages, including alien dialects.\n* Training in zero-gravity combat and defense techniques.\nPersonal Attributes:\n* Visionary thinker with a passion for exploration and discovery.\n* Resilient and adaptable, able to thrive in unknown and challenging environments.\n* High ethical standards and a commitment to the principles of peaceful exploration.\n* Strong interpersonal skills, with the ability to inspire and motivate a diverse team.\n* Keen attention to detail and a proactive approach to problem-solving.\n",
        "Key Responsibilities:\n* Operate and maintain a vareity of Space Ship systems including Navigational Aids, Energy Cannons, and Catnip Vending Machines\n* Be part of a fantastic team of fellow System Operators\n* Be Responsible for your own products and assistance in ship operation\n* Ensure the safety of fellow operators, especially against feisty catgirls who may attack loaders of vending machines\n* Maintain a clear chain of command and divide operational tasks amongst fellow team members\nQualifications:\n* Knowledge of common Space Ship Procedures and chain of command.\n* Minimum Three Years in Space Ship Operations\n* Certifications in Ship Navigation\n* Minimum Bachelors of Science in the fields of : Space Ship Engineering, Space Operations, Low Orbit Satelite Usage, or other related fields\n* Strong Problem Solving skills\n* Ability to maintain focus while under duress\n* Professionalism\n* Knowledge of at least three different common languages\nPreferred Skills:\n* Repair and Maintanence of common Space Ship Devices and Accessories\n* Ability to make sales\n* Ability to tame mischevious Cat Girls\n* Resistance to the Octavian People's Mind Tricks\nPersonal Attributes\n* Willing to work for minimal pay\n* Willing to relocate\n* Ability to work on space ships, and in zero gravity environments\n* Love of Space\n* Ability to act like you love the company.\n"
        ,"Key Responsibilities:\n* Be an effective way of relieving stress for low level managerial staff\n* Be capable of thought\n* Reading a script from a knowledge base of common troubleshoot tips\nQualifications:\n* Capable of thought, and speech\n* Ability to read and speak in three common languages\n* Ability to live in prison like quarters\nPreferred Skills: \n* Ability to multitask\n* Parallel thought\n* Ability to not fight back\n* Professional speaking\nPersonal Attributes:\n* Squishy\n* Unwillingness to complain\n* Social Anxiety\n* Willingness to help Jim out of the hold."
        ,"Primary Responsibilities:\n* Direct and command all positivity and team building operations during the mission. \n* Lead your team to create a positive atmosphere on the platform. Plan and implement emergency communications. \n* Ensure the safety of all personnel in day-to-day situations. \n * 10 years of experience in space. \n* Adequate knowledge in space computer programs. \n* A computer program used to control and manage space.\n Leadership and management behavior.\n Good communication skills are maintained even in difficult situations. \n*Astrology and Advanced Astrology\nBasic Skills:\n*Geography, Biology, Linguistics\n*Knowledge of mass communication technologies\n*Advanced knowledge of Internet security and safety. \nThis is a unique system. \n * Many languages, including foreign languages. \nThey have to work in harsh and difficult conditions"
        ,"Primary Responsibilities:\n* Lying and presenting the company in a positive light\n* Fixing issues with public perceptions\n* Writing professional articles published as if they're not advertisements for the company.\n* Sucking up the Board of Directors in order to raise the budget of the PR team.\nQualifications:\n* Knowledge of at least five different common languages\n* Not an AI\n* An advanced degree in lying from an accredited university\n* Not part of a hivemind that would knowingly spread the truth\nPreferred Skills\n* Creative Writing\n* Fast typing speed\n* Knowledge of basic Psychology for Press Writing\n* Ability to manipulate the public\n* Competency at overselling our products.\nPersonal Attributes\n* Lying as easy as breathing\n* Ability and willingness to travel\n* Keep a low profile in case of disaster\n* Love of making money\n* Ability to perform extortion"
        ,"//TODO: Write job responsibilities for plebs, then yell at Karen in HR for making me do this."
        ,"Assistant Manager of Tentacle cleaning Internship\nKey Responsibilities:\n* Assist Managing the Manager of the Manager of Tentacle Cleaning as an Intern\n* Clean Tentacles of various species\n* Help the old boss with computer problems because he doesn't want to call IT\nPlease come quick I need help."
        ,"Senior Catnip Production Manager\nResponsibilities:\n* Oversee the growth of Catnip\n* Prevent losses due to Catgirls and Catpeople invading the Hydroponics section of the ship\nQualifications\n* Ability to read and write two different languages\n* Understanding of basic math\n* Knowledge of how to use office software\n* Not a Catgirl or Catperson\nPreferred skills\n* Repair and Maintanence of Hydroponic devices\n* Ability to overpower and spray water at Catgirls and Catpeople\n* Ability to not be seduced easily\nPersonal Attributes:\n* Dedicated to a loving partner\n* Hatred of cats\n* Hardworker\n* Love working with plants\n* Not a cat.\n* Never a cat.\n* No sympathy for cat like species\n* No attraction to cats or cat like species\n* If theres a cat person hired for this so help us god."
    };

    public void SelectJobTitle() 
    {
        JobTitle = JobTitleDropdown.options[JobTitleDropdown.value].text;

        switch (JobTitle) 
        {
            case ("High Commander"):break;
            case ("Intergalactic Systems Operator"): QualficationsText.text = Qualifications[1]; break;
            case ("Information Technology Helpdesk Punching Bag and Ticket Escalation Agent"): QualficationsText.text = Qualifications[2]; break;
            case ("Alien Resources "):QualficationsText.text = Qualifications[3]; break;
            case ("Press Relations"):QualficationsText.text = Qualifications[4]; break;
            case ("Object Orientated Organizational Programming Systems Intergalactic Engineer"): QualficationsText.text = Qualifications[5]; break;
            case ("Assistant Manager of Tentacle Cleaning internship"): QualficationsText.text = Qualifications[6]; break;
            case ("Senior Catnip Production Manager"): QualficationsText.text = Qualifications[7]; break;
        }
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
