using UnityEngine;

[System.Serializable]
public class ConversationStep
{
    public Dialogue speaker;              // Which dialogue component to use
    public int startLine;                 // Dialogue start index
    public int endLine;                   // Dialogue end index
}
