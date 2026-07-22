using UnityEngine;
using UnityEngine.InputSystem;

public class InteractTrigger : MonoBehaviour
{
    // keep all these references
    [SerializeField] private InputActionReference interactActionRef; // input action
    [SerializeField] private DialogueConversationsManager conversationScript; // conversation script reference
    [SerializeField] private SpriteRenderer exclamationSprite; // exclamation point sprite
    PlayerCamera playerCamera; // ZOE ADDED
    public float interactionRange = 2; // ZOE ADDED

    private bool near = false; // check if the player is close enough

    private InputAction interactAction; //for new unity system

    void Start() // ZOE ADDED
    {
        playerCamera = GetComponentInChildren<PlayerCamera>(); //Finding script on main camera/child of player
    }

    public void Interact(InputAction.CallbackContext context) // ZOE ADDED
    {

        if (context.performed)
        {
            RaycastHit hit; //what we are hitting with our ray
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 10))
            {
                if (hit.collider != null) //if we hit something
                {
                    Debug.Log("Hitting" + hit.collider.name); //tell what we hit
                }
            }
        }

    }

    public void Update()
    {

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionRange, Color.red);

        //// ------- can probably stay about the same? - just make "near" toggled by the ray elsewhere (or whatever works) - sienna
        //// if "near" is true, 'E' is pressed, and there isn't already a conversation playing
        if (interactAction.WasPressedThisFrame() && !conversationScript.conversationActive)
        {
            Debug.Log("Interact pressed");
            conversationScript.StartConversation();
        }

        //// turns off exclamation point
        if (conversationScript.conversationActive)
            exclamationSprite.enabled = false;
        //// ------


    }

    private void Awake()
    {
        Debug.Log("interactActionRef = " + interactActionRef);
        Debug.Log("exclamationSprite = " + exclamationSprite);

        if (interactActionRef != null)
            interactAction = interactActionRef.action;

        if (exclamationSprite != null)
            exclamationSprite.enabled = false;
    }






    // NOTE: I don't remember the raycast script but below here is probably the main thing to remove


    // enter collider turns near true (replace with raycast)
    //void OnTriggerEnter(Collider other)
    //{

    //    Debug.Log("Can Interact");
    //    near = true;
    //    exclamationSprite.enabled = true;
    //}

    //// exit collider turns near false (replace with raycast)
    //void OnTriggerExit(Collider other)
    //{

    //    Debug.Log("Cannot Interact");
    //    near = false;
    //    exclamationSprite.enabled = false;
    //    conversationScript.EndConversation();
    //}


}
