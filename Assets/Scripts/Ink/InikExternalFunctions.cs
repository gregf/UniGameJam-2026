using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{

    public void Bind(Story story)
    {
        story.BindExternalFunction("StartDay", (string questId) => StartDay(questId));
        story.BindExternalFunction("FinishDay", (string questId) => FinishDay(questId));
        story.BindExternalFunction("WhatWords", (string questId) => WhatWords(questId));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("StartDay");
        story.UnbindExternalFunction("FinishDay");
        story.UnbindExternalFunction("WhatWords");
    }
    private void StartDay(string questId)
    {
        EventsManager.Instance.questEvents.StartQuest(questId);
    }

    private void FinishDay(string questId)
    {
        EventsManager.Instance.questEvents.FinishQuest(questId);
    }

    private void WhatWords(string questId)
    {
        EventsManager.Instance.questEvents.AdvanceQuest(questId);
    }
}
