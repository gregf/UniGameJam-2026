using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialoguePanelUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject contentParent;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;


    private void OnEnable()
    {
        EventsManager.Instance.dialogueEvents.onDialogueStarted += DialogueStarted;
        EventsManager.Instance.dialogueEvents.onDialogueFinished += DialogueFinished;
        EventsManager.Instance.dialogueEvents.onDisplayDialogue += DisplayDialogue;
    }

    private void OnDisable()
    {
        EventsManager.Instance.dialogueEvents.onDialogueStarted -= DialogueStarted;
        EventsManager.Instance.dialogueEvents.onDialogueFinished -= DialogueFinished;
        EventsManager.Instance.dialogueEvents.onDisplayDialogue -= DisplayDialogue;
    }

    private void Awake()
    {
        contentParent.SetActive(false);
        //reset anything for next time
        ResetPanel();
    }

    private void DialogueStarted()
    {
        contentParent.SetActive(true);
    }

    private void DialogueFinished()
    {
        contentParent.SetActive(false);

        //reset anything for next time
        ResetPanel();
    }

    private void DisplayDialogue(string dialogueLine, List<Choice> dialogueChoices)
    {
        dialogueText.text = dialogueLine;

        //check if there are more choices than we can support
        if (dialogueChoices.Count > choiceButtons.Length)
        {
            Debug.LogError("More dialogue choices  ("
                + dialogueChoices.Count + "came through than are supported"
                + choiceButtons.Length + ").");
        }

        //starts with buttons hidden
        foreach (DialogueChoiceButton choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        //enable and set info for the buttons
        int choiceButtonIndex = dialogueChoices.Count - 1;
        for (int inkChoiceIndex = 0; inkChoiceIndex < dialogueChoices.Count; inkChoiceIndex++)
        {
            Choice dialogueChoice = dialogueChoices[inkChoiceIndex];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(inkChoiceIndex);

            if (inkChoiceIndex == 0)
            {
                choiceButton.SelecetButton();
                EventsManager.Instance.dialogueEvents.UpdateChoiceIndex(0);
            }

            choiceButtonIndex--;
        }
    }

    private void ResetPanel()
    {
        dialogueText.text = "";
    }
}