using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ConversationReader : MonoBehaviour
{
    // public ConversationStep_new cStep;
    private List<DialogueLine> currentDialogue;

    private InputAction interactAction; // replace mouse click
    [SerializeField] private InputActionReference interactActionRef;

    [SerializeField] private GameObject textObject;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text nameText;

    [SerializeField] private AudioSource audioSource;


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
        textObject.SetActive(show);

    }

    public void StartDialogue(string speaker, List<DialogueLine> dialogue)
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

        DialogueLine current = currentDialogue[index];
        
        PlayVoice(current);

        charIndex = 0;

        while (charIndex < current.text.Length)
        {
            dialogueText.text += current.text[charIndex];
            charIndex++;
            yield return new WaitForSeconds(writingSpeed);
        }

        waitForNext = true;

    }

    // play voice line code
    public void PlayVoice(DialogueLine current)
    {
        if (current.voiceClip != null)
        {
            audioSource.Stop();
            audioSource.clip = current.voiceClip;
            audioSource.Play();
        }
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
