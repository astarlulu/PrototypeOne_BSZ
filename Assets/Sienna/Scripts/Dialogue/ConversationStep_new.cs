using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ConversationStep_new
{
    public string speaker;  // Which dialogue component to use
    
    public List<string> dialogues;  // dialogue list

    public bool isQuestion; // if its a question/prompts a choice response
}
