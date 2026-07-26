using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public static GameStartManager Instance;

    public LayerMask securityLayer;
    //refernce for conversation 1/starting convosation
    [SerializeField] private DialogueConversationsManager conversation1;

    [SerializeField] private bool interactionSecurityComplete = false; //starting off can interact with anyone else (other than security)
    private bool firstConversationDone; //if first convo done
    

    //private bool securityConversationTriggered = false; //stops the startmanager from ever happening again

    private void Awake()
    {
        Instance = this;
    }

    public bool CanInteract(GameObject target)
    {

        if (interactionSecurityComplete) //after interacting with security every other monster can be interacted with
            return true;

        bool result = ((1 << target.layer) & securityLayer) != 0; //only the security layer tag is allowed can interact

        //debugging to see
        Debug.Log(target.name); //name of object that hit
        Debug.Log(LayerMask.LayerToName(target.layer)); //whats it layer/ is it a security or something else
        Debug.Log($"Result: {result}"); //result if player can interact with yet or no (onyl security at begining)

        return result;
    }

    public void InteractWithAllMonsters()
    {
        if (interactionSecurityComplete)
            return;

        interactionSecurityComplete = true;
        Debug.Log("Now all monsters can be interacted with");
    }

    public DialogueConversationsManager GetSecurityConversation()
    {
        if(!firstConversationDone)
        {
            firstConversationDone = true;
            return conversation1;
        }

        return GameEndingManager.Instance.GetSecurityConversation();
    }

}
