using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    public static string FirstName;
    public static string PathName;
    public static string EndingName;
    public static Dialogue HighCommanderStart(DialogueManager DM) 
    {

        Dialogue CurrentDialogue = new Dialogue("Hello Commander Candidate and Welcome to HART!  I’m very glad to meet you as a potential candidate.  I am Korvilliath, Chief Operations Manager of Hart Intergalactic and welcome to the HART Pavillion.");
        CurrentDialogue.Next = new Dialogue("Our vacancy for a High Commander here on the Hart Pavillion seems to be born of… Ahem… undisclosed reasons.  However, I’m sure the fellow staff here will be very welcoming to a new High Commander coming in with the experience you have.  Speaking of which, can you describe the experience which you have listed on your CV?");
        CurrentDialogue.Next._Character = DM.Korvilliath;
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


        Dialogue PartFive = new("One more question, very easy.  Can you wake up to work at 9 am consistently, and stay awake for your eight hour shift?");
        PartFour.Next = PartFive;

        Dialogue PartSix = new("Alright I want you to now do this quick code exam.");
        Dialogue Test = new Dialogue(DialogueType.CodingMinigame);
        Dialogue ThirdChoice = new Dialogue(DialogueType.choiceTwo);
        ThirdChoice.dialogueChoices = new DialogueChoice[2];
        ThirdChoice.dialogueChoices[0] = new("Yes", ChoiceType.addPoint, PartSix);
        ThirdChoice.dialogueChoices[1] = new("No", ChoiceType.removePoint, PartSix);
      
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
        One.Next = new(DialogueType.cutscene, "The cat person keeps meowing.  I don’t know what they’re saying.  But eventually, the cat points towards the door and so I leave.  The next part of the interview is in Alien Relations, though I don’t know why.");
        One.Next.Next = SharedARInterview(DM);

        return One;
    }

    public static Dialogue TentcleCleaner(DialogueManager DM) 
    {
        Dialogue One = new("Do you mop, son?");
        One._Character = DM.BanthanyJanny;
        Dialogue Two = new("Got the grit to clean the oily messes of these wonderful higher ups?");
        One.Next = Two;
        Dialogue Four = new("Great you're hired, go to AR.");

        Dialogue Three = new(DialogueType.choiceTwo);
        Three.dialogueChoices = new DialogueChoice[2];
        Three.dialogueChoices[0] = new("Yes", (ChoiceType)2, Four);
        Three.dialogueChoices[1] = new DialogueChoice("*Kill him with your laser eyes*", ChoiceType.placebo, CrazyEnding());
        Four.Next = SharedARInterview(DM);
        return One;
    }

    public static Dialogue CatnipProduction(DialogueManager DM) 
    {
        Dialogue One = new(DialogueType.cutscene, "I am in a damp prison-esq room.  Walls are made of solid concrete, and look like they have liquid stains running through them.  Inside below bright an artificially white LED lamp is a rusted metal table");
        Dialogue Two = new(DialogueType.cutscene, "A man enters from the only door, big and built like a tank.");
        One.Next = Two;
        Dialogue Three = new Dialogue("You’re here for the Catnip Production Manager job, right?");
        Three._Character = DM.WafflesSecurity;
        Dialogue Four = new("Good.  Now I have an important question to ask you.  But first put on these sensors for the start of our polygraph session.");
        Three.Next = Four;
        Dialogue Five = new("Thank you, now.  First question.  Have you ever been to the planet Nya-nya Rak’shalla?");
        Four.Next = Five;
        Dialogue Six = new("Second question.  Have you ever had romantic feelings for a catperson? ");
        Five.Next = Six;
        Dialogue Seven = new("Third question.  Do you have familial ties to any cat person or other species for which Catnip acts as a stimulant and or psychoactive drug?");
        Six.Next = Seven;
        Dialogue Eight = new("Thank you for your honesty.  Your interviewer will be next to see you.");
        Seven.Next = Eight;

        return One;
    }

    public static Dialogue SharedARInterview(DialogueManager DM) 
    {
        Dialogue PartOne = new Dialogue("Hi, hi I’m Angela and it’s soo good to meet you sweetie.  How have your interviews been?  Are you thirsty I could get you some water, juice, or coffee if you’d like.");
        PartOne._Character = DM.HRSlimeStacy;
        Dialogue QuestionOne = new Dialogue(DialogueType.choiceFour);
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
        Two.dialogueChoices[0] = new("Yes", ChoiceType.placebo, Three);
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
        Eight.dialogueChoices[0] = new DialogueChoice("Yes.", ChoiceType.placebo, Nine);
        Eight.dialogueChoices[1] = new DialogueChoice("Slay.", ChoiceType.placebo, Nine);
        Dialogue Ten = new("Haahah, okay, okay nice.");
        
        Dialogue NineChoice = new Dialogue(DialogueType.choiceTwo);

        Nine.Next = NineChoice;
        NineChoice.dialogueChoices = new DialogueChoice[2];
        NineChoice.dialogueChoices[0] = new DialogueChoice("Slay", ChoiceType.placebo, Ten);
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

    public static Dialogue BadEnding() 
    {
        Dialogue End1 = new Dialogue("After the interview, I got on my shuttle and headed back to the space port.  Looking at my Spacephone X900I, I saw a strange message.");
        
        Dialogue End2 = new Dialogue($"“Dear {FirstName}, \nIt is with great sadness that we must inform you that we are unable to go forward with your employment at this time.");
        Dialogue End3 = new Dialogue(" There was a highly skilled pool of applicants this year, and unfortunately you simply should git good.  Or in the future; just be born into the family of a manager.");
        Dialogue End4 = new Dialogue("Sincerely, Hart Management.”");
        Dialogue End5 = new Dialogue("And so, the job search goes on.");
        End1.Next = End2;
        End2.Next = End3;
        End3.Next = End4;
        End4.Next = End5;

        End5.Next = new Dialogue(DialogueType.final, "Bad Ending");

        return End1;
    }

    public static Dialogue GhostedEnding() 
    {
        Dialogue End1 = new Dialogue(DialogueType.cutscene, "I applied to HART, but never got a response.  I don't know what happened but I guess I made a mistake.  Eventually, I kept applying, and applying.  That's all I could do.");
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
    public static Dialogue CrazyEnding() 
    {
        return new Dialogue("Insane ending to be added.");
    }

}
