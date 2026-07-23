using UnityEngine;
using UnityEngine.InputSystem;

public class InteractTrigger : MonoBehaviour
{
    // keep all these references
    [SerializeField] private InputActionReference interactActionRef; // input action
    [SerializeField] private DialogueConversationsManager conversationScript; // conversation script reference
    [SerializeField] private SpriteRenderer exclamationSprite; // exclamation point sprite
    [SerializeField] private Camera playerCamera; //ZOE ADD
    [SerializeField] private float interactionRange = 8f; //ZOE ADD

    private bool look = false; // check if the player is close enough

    private InputAction interactAction; //for new unity system

   

    private void Awake()
    {
        interactAction = interactActionRef.action; // input stuff
        exclamationSprite.enabled = false; // exclamation sprite off on awake
    }



    public void Update()
    {
        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionRange, Color.cornflowerBlue); //show raycast line/checking distance

        RaycastHit hit;

        look = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange) //origin/go forwards from camera/hit NPC/ray cast length (line 11)
               && hit.collider.gameObject == gameObject; //

        exclamationSprite.enabled = look && !conversationScript.conversationActive; //if looking at NPC + no conversation happening show !

        
        if (look && interactAction.WasPressedThisFrame() && !conversationScript.conversationActive)
        {
            conversationScript.StartConversation(); //start conversation when looking at NPC and pressing E
        }

        
        if (!look && conversationScript.conversationActive)
        {
            conversationScript.EndConversation(); // end conversation if the player looks away/replacing the leave collider - can change to when conversation ends?
        }
    }





}
