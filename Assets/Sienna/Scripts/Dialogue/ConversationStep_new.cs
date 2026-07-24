using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

[System.Serializable]
public class ConversationStep_new
{
    public string speaker;  // Which dialogue component to use
    
    public List<string> dialogues;  // dialogue list
    public List<DialogueLine> dialogueLines;

    public List<DialogueChoice> choices;

    public bool IsQuestion()
    {
        return choices != null && choices.Count > 0;
    }
}

[System.Serializable]
public class DialogueLine
{
    public string text;
    public AudioClip voiceClip;

}
