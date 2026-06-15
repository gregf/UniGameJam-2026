using UnityEngine;


[RequireComponent(typeof(CircleCollider2D))]
public class Npc : MonoBehaviour
{
    [Header("Dialogue name \nName of the Npc you are trying to access:\n")]
    //Case sensitive, must match knot name in ink file to work
    [SerializeField] private string dialogueKnotName;

    private bool PlayerIsNear = false;


    private void OnEnable()
    {
        EventsManager.Instance.inputEvents.onSubmitPressed += SubmitPressed;
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
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            PlayerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            PlayerIsNear = false;
        }
    }
    
}

