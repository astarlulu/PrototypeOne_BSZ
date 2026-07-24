using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public static GameStartManager Instance;

    [SerializeField] private LayerMask securityLayer;

    [SerializeField] private bool securityConvoComplete = false; //starting off can interact with anyone else (other than security)

    private void Awake()
    {
        Instance = this;
    }

    public bool CanInteract(GameObject target)
    {
        //temporary 
        Debug.Log(target.name);
        Debug.Log(LayerMask.LayerToName(target.layer));

        if (securityConvoComplete) //after interacting with security every other monster can be interacted with
            return true;

        bool result = ((1 << target.layer) & securityLayer) != 0; //only the security layer tag is allowed can interact

        //debugging to see if the raycast is hitting the security layer tag
        Debug.Log($"Checking {target.name}");
        Debug.Log($"Layer: {LayerMask.LayerToName(target.layer)}");
        Debug.Log($"Result: {result}");

        return result;
    }

    public void InteractWithAllMonsters()
    {
        securityConvoComplete = true;
        Debug.Log("Now all monsters can be interacted with");
    }

}
