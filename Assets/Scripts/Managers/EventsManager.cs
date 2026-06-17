using System;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance { get; private set; }

    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    public DialogueEvents dialogueEvents;
    public QuestEvents questEvents;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        Instance = this;

        // initialize all events
        inputEvents = new InputEvents();
        playerEvents = new PlayerEvents();
        dialogueEvents = new DialogueEvents();
        questEvents = new QuestEvents();
    }
}
