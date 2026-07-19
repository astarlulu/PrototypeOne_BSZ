using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ConversationReader : MonoBehaviour
{
    // public ConversationStep_new cStep;
    private List<string> currentDialogue;

    private InputAction interactAction; // replace mouse click
    [SerializeField] private InputActionReference interactActionRef;

    [SerializeField] private GameObject text;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText;


    private int indexStart;
    private int indexEnd;

    private int index;

    private int charIndex;
    public float writingSpeed;

    public bool started;
    public bool waitForNext;

    public bool waiting;



    void Start()
    {
        ToggleWindow(false);
        interactAction = interactActionRef.action;

    }



    private void ToggleWindow(bool show)
    {
        text.SetActive(show);

    }

    public void StartDialogue(string speaker, List<string> dialogue)
    {
        if (started)
            return;

        waiting = true;

        charIndex = 0;
        ToggleWindow(true);

        currentDialogue = dialogue;
        indexStart = 0;
        indexEnd = dialogue.Count - 1;

        nameText.text = speaker;

        GetDialogue(indexStart);

        started = true;
    }

    public void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        
        StartCoroutine(Writing());

    }

    public void EndDialogue()
    {
        waiting = false;
        started = false;
        waitForNext = false;

        ToggleWindow(false);

        StopAllCoroutines();
    }




    public IEnumerator Writing()
    {

        yield return new WaitForSeconds(writingSpeed);

        string current = currentDialogue[index];

        charIndex = 0;

        while (charIndex < current.Length)
        {
            dialogueText.text += current[charIndex];
            charIndex++;
            yield return new WaitForSeconds(writingSpeed);
        }

        waitForNext = true;

    }


    private void Update()
    {
        //if(waiting == true)
        //    return;
        if (!started)
            return;


        if (interactAction.WasPressedThisFrame()) // new input system
        {
            if (waitForNext)
            {
                waitForNext = false;
                index++;

                if (index <= indexEnd)
                {
                    GetDialogue(index);
                }
                else
                {
                    index--;
                    EndDialogue();
                }
            }


        }
    }
}
