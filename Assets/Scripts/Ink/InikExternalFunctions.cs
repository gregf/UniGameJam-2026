using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions
{

    public void Bind(Story story)
    {
        story.BindExternalFunction("StartDay", (string questId) => StartDay(questId));
        story.BindExternalFunction("Reminder", (string questId) => Reminder(questId));
        story.BindExternalFunction("FinishDay", (string questId) => FinishDay(questId));
        story.BindExternalFunction("WhatWords", (string questId) => WhatWords(questId));
    }
    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("StartDay");
        story.UnbindExternalFunction("Reminder");
        story.UnbindExternalFunction("FinishDay");
        story.UnbindExternalFunction("WhatWords");
    }
    private void StartDay(string questId)
    {
        
    }

    private void Reminder(string questId)
    {
        
    }

    private void FinishDay(string questId)
    {
        
    }

    private void WhatWords(string questId)
    {
        
    }
}
