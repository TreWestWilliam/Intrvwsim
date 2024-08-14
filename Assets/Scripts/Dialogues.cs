using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    public static string FirstName;
    public static string PathName;
    public static string EndingName;
    public static DialogueType CT() 
    {
        return DialogueType.cutscene;
    }
    public static Dialogue HighCommanderStart(DialogueManager DM) 
    {

        Dialogue CurrentDialogue = new Dialogue("Hello Commander Candidate and Welcome to HART!  I’m very glad to meet you as a potential candidate.  I am Korvilliath, Chief Operations Manager of Hart Intergalactic and welcome to the HART Pavillion.");
        CurrentDialogue.Next = new Dialogue("Our vacancy for a High Commander here on the Hart Pavillion seems to be born of… Ahem… undisclosed reasons.  However, I’m sure the fellow staff here will be very welcoming to a new High Commander coming in with the experience you have.  Speaking of which, can you describe the experience which you have listed on your CV?");
        CurrentDialogue.Next._Character = DM.Korvilliath;
        CurrentDialogue._FGBG = DM.Navigation;
        CurrentDialogue._Character = DM.Korvilliath;
        Dialogue Choices1 = new Dialogue(DialogueType.choiceFour);
        CurrentDialogue.Next.Next = Choices1;
        Dialogue Choices1_divergence1 = new Dialogue("Professional Janitor, such a noble endeavor for a man of your stature.  My father was a Janitor till the day he died, and boy, those hallways were never cleaner!");
        Dialogue Choices1_divergence2 = new Dialogue("Such stoicism is rarely shown!  I like you already.");
        Dialogue Choices1_convergence = new Dialogue("Anyhow, enough for pleasantries.  For this position you must prove yourself ready to deal with any number of situations.  For this we have prepared a proper simulation of a hazardous event.  You will be assessed based on how well you do.");
        Choices1_divergence1.Next = Choices1_convergence;
        Choices1_divergence2.Next = Choices1_convergence;
        Choices1.dialogueChoices = new DialogueChoice[4];
        Choices1.dialogueChoices[0] = new DialogueChoice("I am a professional Janitor from the L.E.V. Expressite, looking for my proper place.", ChoiceType.placebo, Choices1_divergence1);
        Choices1.dialogueChoices[1] = new DialogueChoice("I was a Gunner in the Intergalactic Super Democratic Army.", ChoiceType.placebo, Choices1_convergence);
        Choices1.dialogueChoices[2] = new DialogueChoice("I was High Commander of the D.V.D. Fairlight, but she’s since been decommissioned.", ChoiceType.placebo, Choices1_convergence);
        Choices1.dialogueChoices[3] = new DialogueChoice("I don’t care.", ChoiceType.placebo, Choices1_divergence2);
        Dialogue MeteorGame = new Dialogue(DialogueType.SpaceMinigame);
        Dialogue CommanderEnd = new Dialogue("Excellent resolve, I admire your skills at operating that turret.  Now I must send you over to AR for their background check.");
        MeteorGame.Next = CommanderEnd;
        MeteorGame.dialogueChoices = new DialogueChoice[3];
        Dialogue HRStart = SharedARInterview(DM);
        MeteorGame.dialogueChoices[0] = new DialogueChoice("Positive", ChoiceType.addPoint, new Dialogue("Excellent resolve, I admire your skills at operating that turret.  Now I must send you over to AR for their background check.", HRStart));
        MeteorGame.dialogueChoices[1] = new DialogueChoice("Timeout", ChoiceType.removePoint, new Dialogue("Valiant Attempt! You kept the ship safe, but could've done better.  Regardless, I'll give you a reccomendation.  Now march to AR!", HRStart));
        MeteorGame.dialogueChoices[2] = new DialogueChoice("Death", ChoiceType.removePoint, new Dialogue("Honorable Service!  The ship may have gone down but you went out like a fighter!  Now go on over to AR for their evaluation.", HRStart));

        Choices1_convergence.Next = MeteorGame;

        return CurrentDialogue;
    }

    public static Dialogue IntergalacticSystemsOperator(DialogueManager DM) 
    {
        Dialogue PartOne = new("Hey uh- I am kinda busy here…  Interview?  Oh right yeah let me get this real quick…");
        PartOne._Character = DM.NavOffice;
        PartOne._FGBG = DM.Navigation;
        Dialogue PartTwo = new("This is the Pavillion requesting clearance to use jump gate Alpha-Zeta-Epsilon Three to jump to the Butterfly Galaxy in minus one and a half days.");
        Dialogue PartThree = new("Okay… Now I don’t know why I was assigned to this interview; pretty sure I told HR to not send me people for a few days.  But let’s get through this real quick. ");
        Dialogue PartFour = new Dialogue("First thing: Experience do you know how to operate SCAN, LAWGIC, SHISHKABOB, OFF-ITCH, and the Hydro Intergalactic New Tension System?");

        Dialogue PartSix = new("Okay Great, that’s exactly what I need.  You ever lay out plotted courses on a star chart?");

        Dialogue PartEight = new("Fantastic, you might be overqualified compared to some of the peanuts around here. \nAlright you ever perform a barrel roll ?");

        Dialogue PartNine = new("Great, you ever navigate your way through an asteroid field?");

        Dialogue DivergenceOne = new Dialogue("Damn right it is.");
        Dialogue PartTen = new Dialogue("Fantastic that’s enough for a quick interview, I’ll give you a glowing review.  Now head on over to the front, and then they’ll let you through to the AR part of the ship.");
        DivergenceOne.Next = PartTen;
        Dialogue ChoicesOne = new Dialogue(DialogueType.choiceTwo);
        ChoicesOne.dialogueChoices = new DialogueChoice[2];
        ChoicesOne.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.addPoint, PartSix);
        ChoicesOne.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.placebo, PartSix);

        Dialogue ChoicesTwo = new Dialogue(DialogueType.choiceTwo);
        ChoicesTwo.dialogueChoices = new DialogueChoice[2];
        ChoicesTwo.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.addPoint, PartEight);
        ChoicesTwo.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.placebo, PartEight);

        Dialogue ChoicesThree = new Dialogue(DialogueType.choiceTwo);
        ChoicesThree.dialogueChoices = new DialogueChoice[2];
        ChoicesThree.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.addPoint, PartNine);
        ChoicesThree.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.placebo, PartNine);

        Dialogue ChoicesFour = new Dialogue(DialogueType.choiceTwo);
        ChoicesFour.dialogueChoices = new DialogueChoice[2];
        ChoicesFour.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.addPoint, PartTen);
        ChoicesFour.dialogueChoices[1] = new DialogueChoice("That's suicide", ChoiceType.placebo, DivergenceOne);
        PartTen.Next = SharedARInterview(DM);

        PartOne.Next = PartTwo;
        PartTwo.Next = PartThree;
        PartThree.Next = PartFour;
        PartFour.Next = ChoicesOne;
        PartSix.Next = ChoicesTwo;
        PartEight.Next = ChoicesThree;
        PartNine.Next = ChoicesFour;

        return PartOne;
    }

    public static Dialogue IT(DialogueManager DM) 
    {
        Dialogue PartOne = new("Alright you’re the new help?");
        PartOne._Character = DM.Bob;
        PartOne._FGBG = DM.Helpdesk;
        Dialogue PartTwo = new Dialogue("Start?  You haven't already started?");
        Dialogue PartThree = new("Oh, just an interviewee.  Alright I'll make this simple.  Can you read?");
        PartTwo.Next = PartThree;

        Dialogue FirstChoice = new Dialogue(DialogueType.choiceTwo);
        FirstChoice.dialogueChoices = new DialogueChoice[2];
        FirstChoice.dialogueChoices[0] = new("I'm here for an interview.", ChoiceType.addPoint, PartThree);
        FirstChoice.dialogueChoices[1] = new("Yes, when can I start?", ChoiceType.addPoint, PartTwo);
        PartOne.Next = FirstChoice;

        Dialogue DivergenceSecond = new("Okay you can understand what I'm saying, that's good enough.");
        Dialogue PartFour = new("One more question, very easy.  Can you wake up to work at 9AM consistently, and stay awake for your eight hour shift?");
        DivergenceSecond.Next = PartFour;
        
        Dialogue SecondChoice = new(DialogueType.choiceTwo);
        SecondChoice.dialogueChoices = new DialogueChoice[2];
        SecondChoice.dialogueChoices[0] = new("Yes.", ChoiceType.addPoint, PartFour);
        SecondChoice.dialogueChoices[1] = new("Excuse me?", ChoiceType.addPoint, DivergenceSecond);

        PartThree.Next = SecondChoice;
        Dialogue PartFive = new("One more question, very easy.  Can you wake up to work at 9 am consistently, and stay awake for your eight hour shift?");
        

        Dialogue PartSix = new("Alright I want you to now do this quick code exam.");
        //PartFive.Next = PartSix;
        
        Dialogue Test = new Dialogue(DialogueType.CodingMinigame);
        Dialogue ThirdChoice = new Dialogue(DialogueType.choiceTwo);
        ThirdChoice.dialogueChoices = new DialogueChoice[2];
        ThirdChoice.dialogueChoices[0] = new("Yes", ChoiceType.addPoint, PartSix);
        ThirdChoice.dialogueChoices[1] = new("No", ChoiceType.removePoint, PartSix);

        PartFive.Next = ThirdChoice;
        PartFour.Next = ThirdChoice;
        PartSix.Next = Test;
        Dialogue PartSeven = new("Fantastic, you're hired.  Go to AR and they'll make it official.");
        Test.Next = PartSeven;
        PartSeven.Next = SharedARInterview(DM);

        return PartOne;
    }

    public static Dialogue Programmer(DialogueManager DM) 
    {
        Dialogue One = new("I uh.. forgot to write this part of the game");
        One._Character = DM.Hachi;
        One._FGBG = DM.CoderOffice;
        Dialogue Two = new("Yeah I mean this is the part I'm most experienced in.  Hour long interviews about my technical skill...");
        One.Next = Two;
        Dialogue Three = new("People asking me about my technical skill.");
        Two.Next = Three;
        Dialogue Four = new("I get some questions right, I get some questions wrong...");
        Three.Next = Four;
        Dialogue Five = new("Trying to be personable and talk about how much effort I've put into projects outside of school.");
        Four.Next = Five;
        Dialogue Six = new Dialogue("This game exists as it is because of an interview I had.");
        Five.Next = Six;
        Dialogue Seven = new("Before I even had the interview, the recruiter got aggresive towards me on a call, asked me `Do you even want this job?` and at the point someone treats you like that, what do you say? ");
        Six.Next = Seven;
        Dialogue Eight = new("And before that I had the weirdest screening stuff, a bunch of games that looked like a poor man's IQ test, and then a personality test that felt like aliens were trying to figure out human emotion");
        Seven.Next = Eight;
        Dialogue Nine = new("That personality test is what inspired the AR interview game, and in turn this entire game around it.  I was that weirded out and upset by it.");
        Eight.Next = Nine;
        Dialogue Ten = new("Anyhow, after the recruiter told me off for not sounding enthusiastic enough I did my best to assure her I was interested and that I was just tired, or whatever.  But at that point I knew I wouldnt get the job.");
        Nine.Next = Ten;
        Dialogue Eleven = new("A week later I had a technical interview, the interviewer wasn't even from the programming department, and I dont think understood the questions he was asking me.");
        Ten.Next = Eleven;
        Dialogue Twelve = new("Then he had a `critical thinking` question for me.  His genius critical thinking question was...");
        Eleven.Next = Twelve;
        Dialogue Thirteen = new(DialogueType.soundeffect,"Drumroll");
        Twelve.Next = Thirteen;
        Dialogue Fourteen = new("Drumroll please!");
        Thirteen.Next = Fourteen;
        Dialogue Fifteen = new("You probably wont believe me, but I added a function for sound effects just for this moment.  I might have to code it in elsewhere now as well, but I deserve my drumroll!");
        Fourteen.Next = Fifteen;
        Dialogue Sixteen = new("Alright lets try this again. \nThis genius `C R I T I C A L  T H I N K I N G` question was...");
        Fifteen.Next = Sixteen;
        Dialogue Seventeen = new Dialogue(DialogueType.soundeffect, "Drumroll");
        Sixteen.Next = Seventeen;
        Dialogue Eighteen = new("`How would you estimate how many gas stations there are in the world, without outside information`");
        Seventeen.Next = Eighteen;
        Dialogue Nineteen = new("Anyhow I didn't get hired.  I didn't really want to after my recruiter went at me like I wasnt super enthusiastic to get bumfuzzled going across the country to do whatever random job they give me and get laid off three months into a two year contract");
        Eighteen.Next = Nineteen;
        Dialogue Twenty = new("Yeah it wasn't a great deal, and it was made worse by people like you, Hannah, who believes in toxic positivity being the only way to act.");
        Nineteen.Next = Twenty;
        Dialogue TwentyOne = new("She didn't even remember if she had called me before.  And every time she called me she sent me three or four preformatted emails.  Like you have no enthusiasm either, and tell me to act that way.");
        Twenty.Next = TwentyOne;
        Dialogue TwentyTwo = new("Anyhow that's my rant.  I can write it because honestly, I don't expect people to see this.  Let alone having it attached to my name.  I might be a bit unhinged but I'm not crazy.");
        TwentyOne.Next = TwentyTwo;
        Dialogue TwentyThree = new("I actually coded a `Programming test` for this interview so you get to play that now.");
        TwentyTwo.Next = TwentyThree;
        Dialogue TwentyFour = new Dialogue(DialogueType.CodingMinigame);
        TwentyThree.Next = TwentyFour;
        Dialogue TwentyFive = new("I hope you enjoyed that.  It was a parody of how simplistic the code the interviewers want is but how nonsensically they explain it.");
        TwentyFour.Next = TwentyFive;
        Dialogue TwentySix = new Dialogue("Thanks for hearing my rant.  I'm not going to bother writing a failing score for this path, so go click through AR and see your ending.");
        TwentyFive.Next = TwentySix;
        Dialogue TwentySeven = new("But seriously, thanks for playing my game.  I appreciate it a lot.");
        TwentySix.Next = TwentySeven;
        TwentySeven.Next = SharedARInterview(DM);
        return One;
    }

    public static Dialogue PressRelations(DialogueManager DM)
    {
        Dialogue One = new("Meow.  Meow.");
        One._Character = DM.RickCat;
        One._FGBG = DM.Navigation;
        One.Next = new(DialogueType.cutscene, "The cat person keeps meowing.  I don’t know what they’re saying.  But eventually, the cat points towards the door and so I leave.  The next part of the interview is in Alien Relations, though I don’t know why.");
        One.Next.Next = SharedARInterview(DM);

        return One;
    }

    public static Dialogue TentcleCleaner(DialogueManager DM) 
    {
        Dialogue One = new("Do you mop, son?");
        One._Character = DM.BanthanyJanny;
        One._FGBG = DM.BroomCloset;
        Dialogue Two = new("Got the grit to clean the oily messes of these wonderful higher ups?");
        One.Next = Two;
        Dialogue Four = new("Great you're hired, go to AR.");

        Dialogue Three = new(DialogueType.choiceTwo);
        Three.dialogueChoices = new DialogueChoice[2];
        Three.dialogueChoices[0] = new("Yes", (ChoiceType)2, Four);
        Three.dialogueChoices[1] = new DialogueChoice("*Kill him with your laser eyes*", ChoiceType.placebo, CrazyEnd(DM));
        Two.Next = Three;
        Four.Next = SharedARInterview(DM);
        return One;
    }

    public static Dialogue CatnipProduction(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "I am in a damp prison-esq room.  Walls are made of solid concrete, and look like they have liquid stains running through them.  Inside below bright an artificially white LED lamp is a rusted metal table");
        One._FGBG = DM.Interrogation;
        Dialogue Two = new(DialogueType.cutscene, "A man enters from the only door, big and built like a tank.");
        One.Next = Two;
        Dialogue Three = new Dialogue("You’re here for the Catnip Production Manager job, right?");
        Three._Character = DM.WafflesSecurity;
        Two.Next = Three;
        Dialogue Four = new("Good.  Now I have an important question to ask you.  But first put on these sensors for the start of our polygraph session.");
        Three.Next = Four;
        Dialogue Five = new("Thank you, now.  First question.  Have you ever been to the planet Nya-nya Rak’shalla?");
        Four.Next = Five;
        Dialogue FiveQuestion = new(DialogueType.choiceTwo);
        FiveQuestion.dialogueChoices = new DialogueChoice[2];
        
        Dialogue Six = new("Second question.  Have you ever had romantic feelings for a catperson? ");
        FiveQuestion.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.addPoint, Six);
        FiveQuestion.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.addPoint, Six);
        Five.Next = FiveQuestion;
        Dialogue Seven = new("Third question.  Do you have familial ties to any cat person or other species for which Catnip acts as a stimulant and or psychoactive drug?");

        Dialogue SixQuestion = new(DialogueType.choiceTwo);
        SixQuestion.dialogueChoices = new DialogueChoice[2];
        SixQuestion.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.placebo, Seven);
        SixQuestion.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.addPoint, Seven);
        Six.Next = SixQuestion;

        Dialogue Eight = new("Thank you for your honesty.  Your interviewer will be next to see you.");

        

        Dialogue Nine = new("Thank you for meeting me, I understand you’ve passed the rigid security check.  Now, let’s talk business");
        Nine._Character = DM.YauwnCatnip;
        Eight.Next = Nine;
        Dialogue SevenQuestion = new(DialogueType.choiceTwo);
        SevenQuestion.dialogueChoices = new DialogueChoice[2];
        SevenQuestion.dialogueChoices[0] = new DialogueChoice("Yes", ChoiceType.placebo, Eight);
        SevenQuestion.dialogueChoices[1] = new DialogueChoice("No", ChoiceType.addPoint, Eight);
        Seven.Next = SevenQuestion;

        Dialogue Ten = new("Have you ever grown catnip before?");
        Nine.Next = Ten;
        Dialogue Eleven = new("Well regardless all you need to know is that 90% of the catnip we produce is for sale and or use within the company.  The other 10% is called the Angels share, you distribute it to the cats that would otherwise be dangerous towards you if you didn’t give them a little.");
        Ten.Next = Eleven;
        Dialogue Twelve = new("This is standard industry practice to keep you safe.  You never mention it to anyone higher than me though, they don’t really understand.");
        Eleven.Next = Twelve;
        Dialogue Thirteen = new("Anyhow, this was a good talk, I like ya kid so just head over to those sweethearts in AR and if any of them are meowing for some of the good stuff tell em you’ll give em a lil to catch a break, okay?");
        Twelve.Next = Thirteen;
        Thirteen.Next = SharedARInterview(DM);
        return One;
    }

    public static Dialogue SharedARInterview(DialogueManager DM) 
    {
        Dialogue PartOne = new Dialogue("Hi, hi I’m Angela and it’s soo good to meet you sweetie.  How have your interviews been?  Are you thirsty I could get you some water, juice, or coffee if you’d like.");
        PartOne._Character = DM.HRSlimeStacy;
        PartOne._FGBG = DM.HRoffice;
        Dialogue QuestionOne = new Dialogue(DialogueType.choiceFour);
        QuestionOne._Character = DM.HRSlimeStacy;
        PartOne.Next = QuestionOne;
        Dialogue ConvergenceOne = new("Please pick one of these pictures.  Some have associated words or phrases.  Choose the one that you like best.");
        Dialogue Q1Pos = new Dialogue("Fantastic, I’ll send Christina our intern to go get that for you.");
        Dialogue Q1Pos_p2 = new("Anyways, while we wait for that we have a simple personality evaluation for you to fill out.  Just answer however you feel.", ConvergenceOne);
        Q1Pos.Next = Q1Pos_p2;
        Dialogue Q1Neg = new Dialogue("Ah in that case we can get straight to business.", ConvergenceOne);
        QuestionOne.dialogueChoices = new DialogueChoice[4];
        QuestionOne.dialogueChoices[0] = new DialogueChoice("No, thank you.",ChoiceType.placebo,Q1Neg);
        QuestionOne.dialogueChoices[1] = new("I’d like some water.",ChoiceType.placebo,Q1Pos);
        QuestionOne.dialogueChoices[2] = new("Coffee would be nice; I'm still jet lagged.", ChoiceType.placebo, Q1Pos);
        QuestionOne.dialogueChoices[3] = new("I need my go-go juice.", ChoiceType.placebo, Q1Pos);
        
        Dialogue PlayReview = new Dialogue(DialogueType.ChoicesMinigame, "Nothing here");
        ConvergenceOne.Next = PlayReview;
        Dialogue Ending = new Dialogue("Thank you for your time.  I think your interviews are done.  You'll be hearing back from us soon.");
        PlayReview.Next = Ending;
        Dialogue CalcEnd = new Dialogue(DialogueType.calcEnding);
        Ending.Next = CalcEnd;


        return PartOne;
    }

    public static Dialogue AlienResources(DialogueManager DM) 
    {
        Dialogue One = new("OMG welcome to HART!  I’m Angela and you’re here for a position here in AR correct?");
        One._Character = DM.HRSlimeStacy;
        Dialogue Two = new(DialogueType.choiceTwo);
        Dialogue Three = new("Fantastic!  I’m so happy to meet you.  Here we’re like family it’s so close.  Like my neighbor in the next office over is my bestie Kuruluth’kragfe.  She’s like… so adorbs I love her to death!");
        Two.dialogueChoices = new DialogueChoice[2];
        Two.dialogueChoices[0] = new("Yes", ChoiceType.addPoint, Three);
        Two.dialogueChoices[1] = new DialogueChoice("Yeah?", ChoiceType.placebo, Three);
        One.Next = Two;
        Dialogue Four = new("And then her husband works over in Navigation like how nice is that?!  Ahhh if only Jeremy wasn’t such a cheating bee y’know.  Oh you don’t know Jeremy.");
        Three.Next = Four;
        Dialogue Five = new("Jeremy was my like boyfriend for two months when he got me this job but when I started working here and thought I’d see him more but like since he was the captain he never spent time with me.");
        Four.Next = Five;
        Dialogue Six = new("Then he was like really close with this catty.  I thought he was cheating on me with her.  So, I got him fired for it cause that’s how I role.  A few bruises and a broken nose was all it took, boss girl style.");
        Five.Next = Six;
        Dialogue Seven = new("Alright, he totally deserved it, ya?");
        Six.Next = Seven;
        Dialogue Eight = new(DialogueType.choiceTwo);
        Seven.Next = Eight;
        Dialogue Nine = new("Mhm mhm alright alright I like you.  Hmm…  Think I should like get you ready to be part of the family.  You single?  I can like hook you up with Bob in tech support, he’s such a sweetheart he’ll be like your little puppy of a boy.  Sound good?");
        Eight.dialogueChoices = new DialogueChoice[2];
        Eight.dialogueChoices[0] = new DialogueChoice("Yes.", ChoiceType.addPoint, Nine);
        Eight.dialogueChoices[1] = new DialogueChoice("Slay.", ChoiceType.placebo, Nine);
        Dialogue Ten = new("Haahah, okay, okay nice.");
        
        Dialogue NineChoice = new Dialogue(DialogueType.choiceTwo);

        Nine.Next = NineChoice;
        NineChoice.dialogueChoices = new DialogueChoice[2];
        NineChoice.dialogueChoices[0] = new DialogueChoice("Slay", ChoiceType.addPoint, Ten);
        NineChoice.dialogueChoices[1] = new DialogueChoice("Neigh", ChoiceType.placebo, Ten);
        Dialogue Eleven = new Dialogue("Let’s get you on the personality evaluation, tho I already give you a gold star.");
        Ten.Next = Eleven;
        Dialogue Twelve = new Dialogue(DialogueType.ChoicesMinigame);
        Eleven.Next = Twelve;
        Dialogue Thirteen = new("Fantastic!  You've done everything we need from you!  So fabulous!");
        Twelve.Next = Thirteen;
        Dialogue Fourteen = new("So thank you for your time, if you head out from here the shuttle back should be ready soon!  I hope you have a fantabulous rest of your day!");
        Thirteen.Next = Fourteen;
        Dialogue Fifteen = new(DialogueType.calcEnding);
        Fourteen.Next = Fifteen;

        return One;
    }

    public static Dialogue BadEnding(DialogueManager DM) 
    {
        Dialogue End1 = new Dialogue(CT(),"After the interview, I got on my shuttle and headed back to the space port.  Looking at my Spacephone X900I, I saw a strange message.");
        End1._FGBG = DM.IntroCutscene;
        End1.BackgroundMusic = DM.Music[4];
        Dialogue End2 = new Dialogue(CT(), $"“Dear {FirstName}, \nIt is with great sadness that we must inform you that we are unable to go forward with your employment at this time.");
        Dialogue End3 = new Dialogue(CT(), "There was a highly skilled pool of applicants this year, and unfortunately you simply should git good.  Or in the future; just be born into the family of a manager.");
        Dialogue End4 = new Dialogue(CT(), "Sincerely, Hart Management.”");
        Dialogue End5 = new Dialogue(CT(), "And so, the job search goes on.");
        End1.Next = End2;
        End2.Next = End3;
        End3.Next = End4;
        End4.Next = End5;

        End5.Next = new Dialogue(DialogueType.final, "Bad Ending");

        return End1;
    }

    public static Dialogue CrazyEnd(DialogueManager DM) 
    {
        Dialogue One = new Dialogue(DialogueType.cutscene, "You obliterate the Janitor in front of you.  Laser eyes burning it to a crisp.");
        One._Character = DM.None;
        Dialogue Two = new Dialogue(DialogueType.cutscene, "Suddenly, the lights went dark.");
        Two._FGBG = DM.WeirdEnding;
        One.Next = Two;
        Dialogue Three = new(DialogueType.cutscene, "Then spotlights.  Three sharks each in their own chairs, holding laser guns in their hand-fins.");
        Two.Next = Three;
        Dialogue Four = new(DialogueType.cutscene, "I don’t know why but suddenly I started pitching my product: The Finshawash.  The perfect thing to wash all your fins without effort.");
        Three.Next = Four;
        Dialogue Five = new(DialogueType.cutscene, "“With the deluxe scrubbing robotics- you can u- live in perfect luxury, scrubbers that feel better than-“ ");
        Four.Next = Five;
        Dialogue Six = new(DialogueType.cutscene,"I begin stuttering like crazy, unable to think anything at all.");
        Six._FGBG = DM.WeirdEnding2;
        Five.Next = Six;
        Dialogue Seven = new(DialogueType.cutscene, "Then I noticed it, from between my legs.");
        Six.Next = Seven;
        Dialogue Eight = new(DialogueType.cutscene, "A warm liquid sensation spreading onto my pants.");
        Seven.Next = Eight;
        Dialogue Nine = new(DialogueType.cutscene, "I was peeing myself.");
        Eight.Next = Nine;
        Dialogue Ten = new(DialogueType.cutscene, "Suddenly words stopped coming out.  Colors filled my vision.  And suddenly a burning pain from my left leg.  Then another in my right.  My body collapsed on the floor.");
        Nine.Next = Ten;
        Ten._FGBG = DM.WeirdEnding3;
        Dialogue Eleven = new(DialogueType.cutscene, "Life had become nothingness.  There was nothing in this world.  I was gone.");
        Ten.Next = Eleven;
        Dialogue Twelve = new(DialogueType.cutscene, "Then a weird creature started speaking to me.");
        Eleven.Next = Twelve;
        Dialogue Thirteen = new(DialogueType.text, "Wow, a ~normal~ ~human~ ~being~!  HuBbY mUcH pRoUd!");
        Thirteen._Character = DM.WeirdCreature;
        Thirteen._FGBG = DM.WeirdEnding4;
        Twelve.Next = Thirteen;
        Dialogue Fourteen = new(DialogueType.cutscene, "And then all went black.");
        Fourteen._Character = DM.None;
        Thirteen.Next = Fourteen;
        Dialogue Fifteen = new(DialogueType.final, "Crazy Ending");
        Fourteen.Next = Fifteen;
        return One;
    }

    public static Dialogue ITEnding(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "Being the helpdesk in an organization as large as HART is a form of torture.");
        One._FGBG = DM.ITEND1;
        One._Character = DM.None;
        One.BackgroundMusic = DM.Music[2];
        Dialogue Two = new Dialogue(DialogueType.cutscene, "Understaffed, Underpaid, and shifts too long for me to give a crap.");
        One.Next = Two;
        Dialogue Three = new(DialogueType.cutscene, "No, you have to reset your password every thirty days, company policy.");
        Two.Next = Three;
        Three._FGBG = DM.ITEND2;
        Dialogue Four = new(DialogueType.cutscene, "No, I cannot change it just for you.");
        Three.Next = Four;
        Dialogue Five = new(DialogueType.cutscene, "No.");
        Five._FGBG = DM.ITEND3;
        Four.Next = Five;
        Dialogue Six = new Dialogue(DialogueType.cutscene, "Have you tried turning it off and on again?");
        Five.Next = Six;
        Dialogue Seven = new(CT(), "The screens power button is not the computers power button.");
        Seven._FGBG = DM.ITEND4;
        Six.Next = Seven;
        Dialogue Eight = new(CT(), "Just because it worked that way before, doesn’t mean it will work that way now.");
        Seven.Next = Eight;
        Dialogue Nine = new(CT(), "No, I cannot roll back the update.");
        Eight.Next = Nine;
        Dialogue Ten = new Dialogue(CT(), "Soon enough though I got fired.");
        Nine.Next = Ten;
        Dialogue Eleven = new(CT(), "For sleeping on the job.");
        Eleven._FGBG = DM.ITEND5;
        Ten.Next = Eleven;
        Dialogue Twelve = new(CT(), "I had fallen asleep at my desk after I closed my 18 hour shift.  Apparently, my next shift was just six hours later.");
        Eleven.Next = Twelve;
        Dialogue Thirteen = new(CT(), "And I was caught sleeping in my cubicle.  I had been asleep for ten hours.  At least my severance package was decent. ");
        Twelve.Next = Thirteen;
        Thirteen.Next = new(DialogueType.final, "Long Live Tech Support");
        return One;
    }

    public static Dialogue JanitorEnd(DialogueManager DM) 
    {
        Dialogue One = new(CT(), "Mopping became my life, under my sensei’s guidance.");
        One._FGBG = DM.JanitorEnd;
        One.BackgroundMusic = DM.Music[5];
        Dialogue Two = new(CT(), "It’s a respectable ancient art, and I mastered three of many forms.");
        One.Next = Two;
        Dialogue Three = new(CT(), "My training was put to a stop due to the passing of my dear sensei.  The man who taught me everything.");
        Two.Next = Three;
        Dialogue Four = new(CT(), "He went on to mop the halls of some government buildings on Mars.  He sent me photos, I’m rather jealous that he was able to have such an opportunity.");
        Three.Next = Four;
        Dialogue Five = new(CT(), "Now I have my own student.  And their learning is my top priority.");
        Four.Next = Five;
        Dialogue Six = new(CT(), "But I cannot sit forever, one day I must learn more, perhaps under another master.");
        Five.Next = Six;
        Dialogue Seven = new(CT(), "Though another art tempts me, that of the vacuum…");
        Six.Next = Seven;
        Seven.Next = new(DialogueType.final, "The Way of the Mop");
        return One;
    }

    public static Dialogue CatnipEnd(DialogueManager DM) 
    {
        Dialogue One = new(CT(), "My job in Catnip production soon started.");
        One._FGBG = DM.IntroCutscene;
        One.BackgroundMusic = DM.Music[1];
        Dialogue Two = new(CT(), "Bribing the cat people and the cat girls became a regular part of my daily life.  I became popular with them, but soon even in my sleep I would hear meowing.  Slowly driving me insane.");
        Two._FGBG = DM.CatnipEnding;
        One.Next = Two;
        Dialogue Three = new(CT(), "But at least I had met my wife through my work.   She’s very pretty though she does take a lot of my budget and says that she’s gone the moment I move from my position.");
        Two.Next = Three;
        Three.Next = new(DialogueType.final, "Catnip Master");
        return One;
    }

    public static Dialogue ProgrammerEnding(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "So I forgot to write this ending as well..");
        One.BackgroundMusic = DM.Music[0];
        One._FGBG = DM.IntroCutscene;
        Dialogue Two = new(DialogueType.cutscene, "I guess I'll just write what's going on in my life now.  As I am writing this.");
        Dialogue Three = new(DialogueType.cutscene, "I kinda gave up on applying for programming jobs in the traditional sense.  Now I'm applying to local jobs just to get some money together.");
        Dialogue Four = new(DialogueType.cutscene, "I need the money.  The student loans I have aren't magically disappearing anytime soon, I have things I need money for, especially visiting my loved ones");
        Dialogue Five = new(DialogueType.cutscene, "My family thinks the solution for my education not getting me a job is more education.  I'm not going to go get my master's, I don't even know how I'd get one for various reasons, that would be the definition of insanity.");
        Dialogue Six = new Dialogue(DialogueType.cutscene, "Instead I'm joining some game dev groups, getting some certifications, trying to get some references and become an insider in software dev.");
        Dialogue Seven = new(DialogueType.cutscene, "It kinda sucks, but going to online college I didn't really build any connections of worth.");
        Dialogue Eight = new(DialogueType.cutscene, "Sorry this pathway is so weird.  I guess it's a venting thing now.");
        Dialogue Nine = new(DialogueType.cutscene, "This is the final thing I'm writing for this game.  I wish I was a faster developer to make the game more interesting, more mini games, more fun things in it, vareity, etc.");
        Dialogue Ten = new(DialogueType.cutscene, "But after this I'm moving towards new things, wherever they take me.");
        One.Next = Two;
        Two.Next = Three;
        Three.Next = Four;
        Four.Next = Five;
        Five.Next = Six;
        Six.Next = Seven;
        Seven.Next = Eight;
        Eight.Next = Nine;
        Nine.Next = Ten;
        Ten.Next = new Dialogue(DialogueType.final, "Learn to Code");
        return One;
    }

    public static Dialogue HCEnd(DialogueManager DM) 
    {
        Dialogue One = new Dialogue(DialogueType.cutscene, "Soon after the interviews concluded, I was contacted by Korvilliath that I was now the official High Commander of the Pavilion.");
        One._FGBG = DM.IntroCutscene;
        One.BackgroundMusic = DM.Music[0];
        Dialogue Two = new(DialogueType.cutscene, "High commander was a position that suited me greatly.  Especially when I realized that I am basically just a manager with a fancy title.");
        One.Next = Two;
        Dialogue Three = new(DialogueType.cutscene, "And boy, did I manage.");
        Two.Next = Three;
        Dialogue Four = new Dialogue(DialogueType.final, "High Commander!");
        Three.Next = Four;
        return One;
    }

    public static Dialogue AREnd(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "Like, hell yeah, girl I got the job.");
        One.BackgroundMusic = DM.Music[0];
        One._FGBG = DM.IntroCutscene;
        Dialogue Two = new(DialogueType.cutscene, "Then we like, boss'd it up.  Mhm.  Yass.");
        One.Next = Two;
        Dialogue Three = new(DialogueType.cutscene, "It's a great place with us in charge.  Mhm.");
        Two.Next = Three;
        Three.Next = new(DialogueType.final, "Alien Resources Bossing It Ending");
        return One;
    }

    public static Dialogue ISOEnd(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "Intergalactic Systems Operator sounds neat and all, but really, I ended up just phoning locations to tell them we needed to use them and navigating the logistics of flying.");
        One._FGBG = DM.NavEnd;
        One.BackgroundMusic = DM.Music[0];
        Dialogue Two = new(DialogueType.cutscene, "But hey, on the bright side half the day I sit around doing nothing, so there’s worse jobs.");
        One.Next = Two;
        Two.Next = new(DialogueType.final, "Intergalactic System Operator Ending!");
        return One;
    }

    public static Dialogue GhostedEnding(DialogueManager DM) 
    {
        Dialogue End1 = new Dialogue(DialogueType.cutscene, "I applied to HART, but never got a response.  I don't know what happened but I guess I made a mistake.  Eventually, I kept applying, and applying.  That's all I could do.");
        End1._FGBG = DM.IntroCutscene;
        End1.BackgroundMusic = DM.Music[2];
        Dialogue End2 = new Dialogue(DialogueType.cutscene, "The job market sucked.  I rarely got even a response to reject me.  And sometimes when I did I had to login to a website just to see that `unfortunately` written in red.");
        Dialogue End3 = new(DialogueType.cutscene, "I had skills and training.  I had dedication to my craft.  But in the end, no one wanted to take a chance on me when people with more work experience were flooding the market.");
        Dialogue End4 = new(DialogueType.cutscene, "So I took a job no one else wanted, not even me.  And tried my best to like it.  But in the back of my mind there was that maybe, always lingering.  Nagging at me.  If only things had been different.");
        Dialogue End5 = new Dialogue(DialogueType.final, "Ghosted Ending");
        End1.Next = End2;
        End2.Next = End3;
        End3.Next = End4;
        End4.Next = End5;
        return End1;
    }

}
