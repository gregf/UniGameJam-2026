using Unity.VisualScripting;
using UnityEngine;

public class CollectItemsQuestStep : QuestStep
{
    private int itemCollected = 0;
    private int itemsToCollect = 5;

    private void OnEnable()
    {
        EventsManager.Instance.miscEvents.onItemCollected += ItemCollected;
    }

    private void OnDisable()
    {
        EventsManager.Instance.miscEvents.onItemCollected -= ItemCollected;
    }


    private void ItemCollected()
    {
        if (itemCollected < itemsToCollect)
        {
            itemCollected++;
        }

        if(itemCollected >= itemsToCollect)
        {
            FinishQuestStep();
        }
    }

    private void UpdateState()
    {
        string state = itemCollected.ToString();
        string status = "Collected" + itemCollected + " / " + itemsToCollect + "items";
        ChangeState(state, status);
    }

    protected override void SetQuestStepState(string state)
    {
        this.itemCollected = System.Int32.Parse(state);
        UpdateState();
    }
}
