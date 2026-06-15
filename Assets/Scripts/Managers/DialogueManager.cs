using Ink.Runtime;
using UnityEngine;
public class DialogueManager : MonoBehaviour
{
    //handles everythng related to dialogue, starting it, ending it, and progressing it.
    //Also holds reference to the ink story for easy access from other scripts if needed
    [Header("Ink Story \n(Input Main Json file here)\n")] [SerializeField] private TextAsset inkJson;
    private Story story;
    private bool dialoguePlaying = false;
    private int currentChoiceIndex = -1;


    private void Awake()
    {
        story = new Story(inkJson.text);
    }


    private void OnEnable()
    {
        EventsManager.Instance.inputEvents.onSubmitPressed += SubmitPressed;
        EventsManager.Instance.dialogueEvents.onEnterDialogue += EnterDialogue;
        EventsManager.Instance.dialogueEvents.onUpdateChoiceIndex += UpdateChoiceIndex;
    }

    private void OnDisable()
    {
        EventsManager.Instance.inputEvents.onSubmitPressed -= SubmitPressed;
        EventsManager.Instance.dialogueEvents.onEnterDialogue -= EnterDialogue;
        EventsManager.Instance.dialogueEvents.onUpdateChoiceIndex -= UpdateChoiceIndex;
    }


    private void UpdateChoiceIndex(int choiceIndex)
    {
        this.currentChoiceIndex = choiceIndex;
    }


    public void SubmitPressed(InputEventContext inputEventContext)
    {
        //if context isn't dialogue never register input here
        if (!inputEventContext.Equals(InputEventContext.DIALOGUE))
        {
            return;
        }

        ContinueOrExitStory();
    }
    
    private void EnterDialogue(string knotName)
    {
        //dont enter dialogue if we have already entered it
        if (dialoguePlaying)
        {
            return;
        }
        
        dialoguePlaying = true;

        //inform other parts of code that dialogue started
        EventsManager.Instance.dialogueEvents.DialogueStarted();

        EventsManager.Instance.playerEvents.DisablePlayerMovement();

        EventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DIALOGUE);

        //jump to the knot
        if (!knotName.Equals(""))
        {
            story.ChoosePathString(knotName);
        }

        //start the story
        ContinueOrExitStory();
    }


    private void ContinueOrExitStory()
    {
        //make choice if you can
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);

            //reset index for next time
            currentChoiceIndex = -1;
        }

        if(story.canContinue)
        {
            string dialogueLine = story.Continue();

            //in case of empty dialogue continut until there is dialogue
            while (IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            //if choice is blank and story cant continue
            if (IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                EventsManager.Instance.dialogueEvents.DisplayDialogue(dialogueLine, story.currentChoices);
            }
        }
        else if (story.currentChoices.Count == 0)
        {
            ExitDialogue();
        }
    }

    private void ExitDialogue()
    {
        dialoguePlaying = false;

        EventsManager.Instance.playerEvents.EnablePlayerMovement();
        EventsManager.Instance.inputEvents.ChangeInputEventContext(InputEventContext.DEFAULT);
        //inform other parts of code that dialogue finished
        EventsManager.Instance.dialogueEvents.DialogueFinished();

        story.ResetState();
    }

    private bool IsLineBlank(string dialogueLine)
    {
        return dialogueLine.Trim().Equals("") || dialogueLine.Trim().Equals("\n");
    }
}
