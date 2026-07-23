using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //[SerializeField] private LayerMask securityLayer;

    public int monsterScore = 0;

    //added by brooke broken stuff will fix later
    //checking if the raycast is hitting the layer that is added on the security is on (add on in their monster layer tags)
    //void Update()
    //{

    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, 10f, securityLayer))
    //    {
    //        Debug.Log("YO SECURITY");
    //    }

    //}

//            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionRange, securityLayer))
//        {
//            // IF TRUE: The raycast successfully HIT an object on the targetLayerMask
//            Debug.Log($"Hit an object on the allowed layer: {hit.collider.name}");
//        }
//        else
//{
//    // IF FALSE: The raycast HIT NOTHING or passed right through unmasked layers
//    Debug.Log("Did not hit anything on the target LayerMask.");



private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void IncreaseMonsterScore(int amount)
    {
        monsterScore += amount;
    }
}
