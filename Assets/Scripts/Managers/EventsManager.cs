using UnityEngine;

public class EventsManager : MonoBehaviour
{
    //Initializes all events and holds references to them for easy access
    public static EventsManager Instance { get; private set; }

    public InputEvents inputEvents;
    public PlayerEvents playerEvents;
    public DialogueEvents dialogueEvents;

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
    }
}
