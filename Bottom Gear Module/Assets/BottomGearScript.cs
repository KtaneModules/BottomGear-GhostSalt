using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class BottomGearScript : MonoBehaviour
{

    static int _moduleIdCounter = 1;
    int _moduleID = 0;

    public KMBombModule Module;
    public KMAudio Audio;
    public KMSelectable ThisIsTheLeftButtonOnTheModule;
    public KMSelectable ThisIsTheSubmitButtonOnTheModule;
    public KMSelectable ThisIsTheRightButtonOnTheModule;
    public TextMesh ThisIsTheTextThatIsDisplayedOnTheModule;
    public MeshRenderer ThisIsTheMaterialThatTheSurfaceOfTheModuleHas;
    public Material ThisIsTheMaterialThatShouldBeAssignedWheneverTheModuleIsSolved;

    private string[] TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule = { "Today on bottom gear\nI drive a silent electric car\nHammond uses a toilet\nAnd james commits arson", "*show budget does not\nexceed 23¥", "good evening ladies and gents\ntoday, our todayz sponsor is\nMSI colgate b450 check tem\nout, promo code: revving my\nwife tonigt", "today we will be reviewing\none of a kin vehicle that has\nabout 2.3 ghz revving engine\nsound, goes up to idk 88 mm\nper every time i find a proper\njob in today's economy", "helo mate we are going to\nasda do  uwant sanythijng", "hello i am stug i go quikk noom", "oy luv you posh dickead oy\n'ave cum bak gimme a siggy\ninnit cheesed off bloke daft\nfrucker bollocks fish and chips\nbloody bloody arse", "hammon you tiny man\nwhere is the lambo chevy?", "gon ei crashed\nit into James car", "hammond you sodding tic tac\nthis was my laborghini\naventador", "call 999 my fokin cah is\nbeaning on Fire mate", "ham ond i have crack\nadditcion i am die", "Jeremy I have to write divorce\npapers today I don't know\nwhat to do next please\nhelp me I can't go o-", "we do not hav\npetroleum hmalet", "Tody on medium gear, wat\nhappens when taste\nexhoost fume?", "K, I'll have a wiff.", "Ery nice.", "No Jeremia,\ncar gas bad for helf.", "Shut mouth hammock.", "cock", "Shut up jams", "th Esped is a lot !", "weed", "car", "feet" };
    private string[] TheseAreTheCorrespondingTextsThatAreTheSolutionsToEachTweet = { "*show budget does not\nexceed 23¥", "good evening ladies and gents\ntoday, our todayz sponsor is\nMSI colgate b450 check tem\nout, promo code: revving my\nwife tonigt", "today we will be reviewing\none of a kin vehicle that has\nabout 2.3 ghz revving engine\nsound, goes up to idk 88 mm\nper every time i find a proper\njob in today's economy", "helo mate we are going to\nasda do  uwant sanythijng", "hello i am stug i go quikk noom", "oy luv you posh dickead oy\n'ave cum bak gimme a siggy\ninnit cheesed off bloke daft\nfrucker bollocks fish and chips\nbloody bloody arse", "hammon you tiny man\nwhere is the lambo chevy?", "gon ei crashed\nit into James car", "hammond you sodding tic tac\nthis was my laborghini\naventador", "call 999 my fokin cah is\nbeaning on Fire mate", "ham ond i have crack\nadditcion i am die", "Jeremy I have to write divorce\npapers today I don't know\nwhat to do next please\nhelp me I can't go o-", "we do not hav\npetroleum hmalet", "Tody on medium gear, wat\nhappens when taste\nexhoost fume?", "K, I'll have a wiff.", "Ery nice.", "No Jeremia,\ncar gas bad for helf.", "Shut mouth hammock.", "cock", "Shut up jams", "th Esped is a lot !", "weed", "car", "feet", "Today on bottom gear\nI drive a silent electric car\nHammond uses a toilet\nAnd james commits arson" };
    private string[] ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray = { "Today on bottom gear\nI drive a silent electric car\nHammond uses a toilet\nAnd james commits arson", "*show budget does not\nexceed 23¥", "good evening ladies and gents\ntoday, our todayz sponsor is\nMSI colgate b450 check tem\nout, promo code: revving my\nwife tonigt", "today we will be reviewing\none of a kin vehicle that has\nabout 2.3 ghz revving engine\nsound, goes up to idk 88 mm\nper every time i find a proper\njob in today's economy", "helo mate we are going to\nasda do  uwant sanythijng", "hello i am stug i go quikk noom", "oy luv you posh dickead oy\n'ave cum bak gimme a siggy\ninnit cheesed off bloke daft\nfrucker bollocks fish and chips\nbloody bloody arse", "hammon you tiny man\nwhere is the lambo chevy?", "gon ei crashed\nit into James car", "hammond you sodding tic tac\nthis was my laborghini\naventador", "call 999 my fokin cah is\nbeaning on Fire mate", "ham ond i have crack\nadditcion i am die", "Jeremy I have to write divorce\npapers today I don't know\nwhat to do next please\nhelp me I can't go o-", "we do not hav\npetroleum hmalet", "Tody on medium gear, wat\nhappens when taste\nexhoost fume?", "K, I'll have a wiff.", "Ery nice.", "No Jeremia,\ncar gas bad for helf.", "Shut mouth hammock.", "cock", "Shut up jams", "th Esped is a lot !", "weed", "car", "feet" };
    private int ThisIsARandomNumberUsedToSelectText;
    private int ThisIsTheCurrentTweetThatTheModuleIsOn;
    private bool IfTheModuleIsSolvedThisBooleanIsTrue;

    void Awake()
    {
        _moduleID = _moduleIdCounter++;
        ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray.Shuffle();
        ThisIsARandomNumberUsedToSelectText = Rnd.Range(0, TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule.Length);
        ThisIsTheTextThatIsDisplayedOnTheModule.text = TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule[ThisIsARandomNumberUsedToSelectText];
        Debug.LogFormat("[Bottom Gear #{0}] tweett is \"{1}\".", _moduleID, TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule[ThisIsARandomNumberUsedToSelectText]);
        Debug.LogFormat("[Bottom Gear #{0}] corect twet to selec tis \"{1}\".", _moduleID, TheseAreTheCorrespondingTextsThatAreTheSolutionsToEachTweet[ThisIsARandomNumberUsedToSelectText]);
    }

    // Use this for initialization
    void Start()
    {
        ThisIsTheLeftButtonOnTheModule.OnInteract += delegate { if (!IfTheModuleIsSolvedThisBooleanIsTrue) { StartCoroutine(ThisIsTheFunctionAppliedWheneverTheLeftButtonIsPressedOnTheModule()); } return false; };
        ThisIsTheRightButtonOnTheModule.OnInteract += delegate { if (!IfTheModuleIsSolvedThisBooleanIsTrue) { StartCoroutine(ThisIsTheFunctionAppliedWheneverTheRightButtonIsPressedOnTheModule()); } return false; };
        ThisIsTheSubmitButtonOnTheModule.OnInteract += delegate { if (!IfTheModuleIsSolvedThisBooleanIsTrue) { StartCoroutine(ThisIsTheFunctionAppliedWheneverTheSubmitButtonIsPressedOnTheModule()); } return false; };
        Module.OnActivate += delegate { Audio.PlaySoundAtTransform("welcome to bottom gear", transform); };
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ThisIsTheFunctionAppliedWheneverTheLeftButtonIsPressedOnTheModule()
    {
        ThisIsTheCurrentTweetThatTheModuleIsOn = (ThisIsTheCurrentTweetThatTheModuleIsOn + ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray.Length - 1) % ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray.Length;
        ThisIsTheTextThatIsDisplayedOnTheModule.text = ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray[ThisIsTheCurrentTweetThatTheModuleIsOn];
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, ThisIsTheLeftButtonOnTheModule.transform);
        ThisIsTheLeftButtonOnTheModule.AddInteractionPunch(0.5f);
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheLeftButtonOnTheModule.transform.localPosition -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheLeftButtonOnTheModule.transform.localPosition += new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator ThisIsTheFunctionAppliedWheneverTheRightButtonIsPressedOnTheModule()
    {
        ThisIsTheCurrentTweetThatTheModuleIsOn = (ThisIsTheCurrentTweetThatTheModuleIsOn + 1) % ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray.Length;
        ThisIsTheTextThatIsDisplayedOnTheModule.text = ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray[ThisIsTheCurrentTweetThatTheModuleIsOn];
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, ThisIsTheRightButtonOnTheModule.transform);
        ThisIsTheRightButtonOnTheModule.AddInteractionPunch(0.5f);
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheRightButtonOnTheModule.transform.localPosition -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheRightButtonOnTheModule.transform.localPosition += new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator ThisIsTheFunctionAppliedWheneverTheSubmitButtonIsPressedOnTheModule()
    {
        if (ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray[ThisIsTheCurrentTweetThatTheModuleIsOn] == TheseAreTheCorrespondingTextsThatAreTheSolutionsToEachTweet[ThisIsARandomNumberUsedToSelectText])
        {
            Debug.LogFormat("[Bottom Gear #{0}] you corect! jams dead!!!!!!!!!!!! jermia stil lsmok wed thoug.", _moduleID);
            Module.HandlePass();
            Audio.PlaySoundAtTransform("solve", transform);
            IfTheModuleIsSolvedThisBooleanIsTrue = true;
            ThisIsTheMaterialThatTheSurfaceOfTheModuleHas.material = ThisIsTheMaterialThatShouldBeAssignedWheneverTheModuleIsSolved;
            ThisIsTheTextThatIsDisplayedOnTheModule.text = "";
        }
        else
        {
            Debug.LogFormat("[Bottom Gear #{0}] you incroect. jams comit war crim agianst arfica and jermiah smkoe weedd.", _moduleID);
            Module.HandleStrike();
            Audio.PlaySoundAtTransform("strike", transform);
            ThisIsSupposedToBeAShuffledVersionOfTheAboveStringArray.Shuffle();
            ThisIsARandomNumberUsedToSelectText = Rnd.Range(0, TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule.Length);
            ThisIsTheTextThatIsDisplayedOnTheModule.text = TheseAreAllOfThePossibleTextsThatCanAppearOnTheModule[ThisIsARandomNumberUsedToSelectText];
        }
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonRelease, ThisIsTheSubmitButtonOnTheModule.transform);
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheSubmitButtonOnTheModule.transform.localPosition -= new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        ThisIsTheSubmitButtonOnTheModule.AddInteractionPunch(0.5f);
        }
        for (int i = 0; i < 3; i++)
        {
            ThisIsTheSubmitButtonOnTheModule.transform.localPosition += new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

#pragma warning disable 414
    private string TwitchHelpMessage = "Use '!{0} left' to press the left button. Use '!{0} right' to press the right button. Use '!{0} submit' to press the submit button.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string ThisIsTheCommandThatIsSentThroughTwitch)
    {
        ThisIsTheCommandThatIsSentThroughTwitch = ThisIsTheCommandThatIsSentThroughTwitch.ToLowerInvariant();
        if (ThisIsTheCommandThatIsSentThroughTwitch == "left")
        {
            ThisIsTheLeftButtonOnTheModule.OnInteract();
        }
        else if (ThisIsTheCommandThatIsSentThroughTwitch == "right")
        {
            ThisIsTheRightButtonOnTheModule.OnInteract();
        }
        else if (ThisIsTheCommandThatIsSentThroughTwitch == "submit")
        {
            ThisIsTheSubmitButtonOnTheModule.OnInteract();
        }
        else
        {
            yield return "sendtochaterror Invalid command.";
            yield break;
        }
        yield return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        yield return true;
        while (ThisIsTheTextThatIsDisplayedOnTheModule.text != TheseAreTheCorrespondingTextsThatAreTheSolutionsToEachTweet[ThisIsARandomNumberUsedToSelectText])
        {
            ThisIsTheRightButtonOnTheModule.OnInteract();
            yield return true;
        }
        ThisIsTheSubmitButtonOnTheModule.OnInteract();
    }
}