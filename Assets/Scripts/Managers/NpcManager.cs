using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class Npc : MonoBehaviour
{
    [Header("Dialogue name \nName of the Npc you are trying to access:\n\n")]
    //Case sensitive, must match knot name in ink file to work
    [SerializeField] private string dialogueKnotName;

    private bool PlayerIsNear = false;
    [SerializeField] private GameObject IconSprite;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private string questId;
    private QuestState currentQuestState;


    private void OnEnable()
    {
        EventsManager.Instance.inputEvents.onSubmitPressed += SubmitPressed;
    }
    private void Awake()
    {
        IconSprite.SetActive(false);
    }

    private void OnDisable()
    {
        EventsManager.Instance.inputEvents.onSubmitPressed -= SubmitPressed;
    }
    public void SubmitPressed(InputEventContext inputEventContext)
    {
        if (!PlayerIsNear || !inputEventContext.Equals(InputEventContext.DEFAULT))
        {
            return;
        }
        

        //if the knot name is defined try to start dialogue with it
        if (!dialogueKnotName.Equals(""))
        {
            EventsManager.Instance.dialogueEvents.EnterDialogue(dialogueKnotName);
            IconSprite.SetActive(false);
        }
        else 
        {
            // start or finish a quest
            if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
            {
                EventsManager.Instance.questEvents.StartQuest(questId);
            }
            else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
            {
                EventsManager.Instance.questEvents.FinishQuest(questId);
            }
        }
    }

    private void QuestStateChange(Quest quest)
    {
        // only update the quest state if this point has the corresponding quest
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            PlayerIsNear = true;
            IconSprite.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            PlayerIsNear = false;
            IconSprite.SetActive(false);
        }
    } 
}