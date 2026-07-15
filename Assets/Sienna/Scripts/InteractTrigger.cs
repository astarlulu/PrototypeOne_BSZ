using UnityEngine;
using UnityEngine.InputSystem;

public class InteractTrigger : MonoBehaviour
{
    //[SerializeField] private BoxCollider interactionCollider;
    [SerializeField] private InputActionReference interactActionRef;
    [SerializeField] private DialogueConversationsManager conversationScript;

    private bool near = false; // check if the player is close enough
    private InputAction interactAction; //for new unity system??

    private void Awake()
    {
        interactAction = interactActionRef.action;
    }


    public void Update()
    {
        if(near == true && interactAction.WasPressedThisFrame())
        {
            conversationScript.StartConversation();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Can Interact");
        near = true;
    }

    void OnTriggerExit(Collider other)
    {
        
        Debug.Log("Cannot Interact");
        near = false;
        conversationScript.EndConversation();
    }


}
