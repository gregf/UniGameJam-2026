using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using Unity.VisualScripting;


public class InkDialogueVeriables
{
    private Dictionary<string, Ink.Runtime.Object> variables;

    public InkDialogueVeriables(Story story)
    {
        // initialize the dictionary using the global variables in the story
        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach (string name in story.variablesState)
        {
            Ink.Runtime.Object value = story.variablesState.GetVariableWithName(name);
            variables.Add(name, value);

            Debug.Log("Initialized global dialogue variable: " + name + " = " + value);
        }
    }

    public void SyncVariablesAndStartListening(Story story)
    {
        SyncVariableToStory(story);
        story.variablesState.variableChangedEvent += UpdateVariableState;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= UpdateVariableState;
    }

    public void UpdateVariableState(string name, Ink.Runtime.Object value)
    {
        //only maintain variables that were initialized from the global ink file 
        if (!variables.ContainsKey(name))
        {
            return;
        }

        variables[name] = value;
        Debug.Log("Updates dialogue variable: " + name + " = " + value);
    }

    private void SyncVariableToStory(Story story)
    {
        foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}