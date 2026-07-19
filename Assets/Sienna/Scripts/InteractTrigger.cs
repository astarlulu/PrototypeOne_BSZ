using UnityEngine;
using UnityEngine.InputSystem;

public class InteractTrigger : MonoBehaviour
{
    //[SerializeField] private BoxCollider interactionCollider;
    [SerializeField] private InputActionReference interactActionRef;
    [SerializeField] private DialogueConversationsManager conversationScript;
    [SerializeField] private SpriteRenderer exclamationSprite;

    private bool near = false; // check if the player is close enough
    private InputAction interactAction; //for new unity system??



    private void Awake()
    {
        interactAction = interactActionRef.action;
        exclamationSprite.enabled = false;
    }


    public void Update()
    {
        if(near == true && interactAction.WasPressedThisFrame() && !conversationScript.conversationActive)
        {
            conversationScript.StartConversation();
        }

        if(conversationScript.conversationActive)
            exclamationSprite.enabled = false;

    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Can Interact");
        near = true;
        exclamationSprite.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        
        Debug.Log("Cannot Interact");
        near = false;
        exclamationSprite.enabled = false;
        conversationScript.EndConversation();
    }


}
