using UnityEngine;
using UnityEngine.InputSystem;

public class InteractTrigger : MonoBehaviour
{
    // keep all these references
    [SerializeField] private InputActionReference interactActionRef; // input action
    [SerializeField] private DialogueConversationsManager conversationScript; // conversation script reference
    [SerializeField] private SpriteRenderer exclamationSprite; // exclamation point sprite

    private bool near = false; // check if the player is close enough

    private InputAction interactAction; //for new unity system

   

    private void Awake()
    {
        interactAction = interactActionRef.action; // input stuff
        exclamationSprite.enabled = false; // exclamation sprite off on awake
    }


    
    public void Update()
    {
        
        
        
        // ------- can probably stay about the same? - just make "near" toggled by the ray elsewhere (or whatever works) - sienna
        // if "near" is true, 'E' is pressed, and there isn't already a conversation playing
        if(near == true && interactAction.WasPressedThisFrame() && !conversationScript.conversationActive)
        {
            conversationScript.StartConversation();
        }

        // turns off exclamation point
        if(conversationScript.conversationActive)
            exclamationSprite.enabled = false;
        // ------

    }


 // NOTE: I don't remember the raycast script but below here is probably the main thing to remove


    // enter collider turns near true (replace with raycast)
    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Can Interact");
        near = true;
        exclamationSprite.enabled = true;
    }

    // exit collider turns near false (replace with raycast)
    void OnTriggerExit(Collider other)
    {
        
        Debug.Log("Cannot Interact");
        near = false;
        exclamationSprite.enabled = false;
        conversationScript.EndConversation();
    }


}
