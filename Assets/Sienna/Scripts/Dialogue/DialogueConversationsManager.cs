using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DialogueConversationsManager : MonoBehaviour
{
    [Header("Conversation Sequence")]
    [SerializeField] private string conversationName;
    // [SerializeField] private List<ConversationStep> steps = new List<ConversationStep>();
    
    // new version
    [SerializeField] private ConversationReader cReader;
    [SerializeField] private List<ConversationStep_new> steps = new List<ConversationStep_new>();
    
    
    [SerializeField] private float trasitionDelay = 0.5f;

    private int currentStep = 0;
    public bool conversationActive = false;
    private bool waitingForNext = false;

    private void Update()
    {
        if (!conversationActive || waitingForNext)
            return;

        if (currentStep >= steps.Count)
        {
            conversationActive = false;
            Debug.Log("Conversation done");
            return;
        }

        var step = steps[currentStep];

        if (!cReader.started && !cReader.waiting)
        {
            StartCoroutine(WaitAndAdvance());
        }
    }


    public void StartConversation()
    {
        if (steps.Count == 0)
            return;

        currentStep = 0;
        conversationActive = true;
        StartStep(steps[currentStep]);

    }

    public void EndConversation()
    {
        conversationActive = false;
        steps.ForEach(step => cReader.EndDialogue());
    }

    private void StartStep(ConversationStep_new step)
    {
        if (step == null)
        {
            Debug.LogError($"Step {currentStep} is null!");
            return;
        }

        if (step.speaker == null)
        {
            Debug.LogError($"Step {currentStep} has no speaker assigned!");
            return;
        }

        cReader.StartDialogue(step.speaker, step.dialogues);
    }

    private IEnumerator WaitAndAdvance()
    {
        waitingForNext = true;
        Debug.Log($"Waiting to advance from step {currentStep}...");
        yield return new WaitForSeconds(trasitionDelay);

        currentStep++;
        Debug.Log($"Advancing to step {currentStep} / total {steps.Count}");

        if (currentStep < steps.Count)
            StartStep(steps[currentStep]);
        else
            conversationActive = false;

        waitingForNext = false;
    }

    public bool IsDialogueActive
    {
        get
        {
            if(!conversationActive || currentStep >= steps.Count)
                return false;
            return cReader.started;
        }
    }


}
