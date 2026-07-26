using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.Rendering;

public class GameEndingManager : MonoBehaviour
{
    public static GameEndingManager Instance;

    //refernce for sliderbar
    [Header("Slider Bar Reference")]
    [SerializeField] private SliderBar sliderBar;

    //refernce for the two converstaions (one will be for the conversation if the player has enough points, the other is for not enough points eg: current <= 20
    [Header("Security Conversations")]
    [SerializeField] private DialogueConversationsManager conversation2;
    [SerializeField] private DialogueConversationsManager conversation3;

    [SerializeField] private GameStartManager startManager;

    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private string sceneName;

    private bool endingConversationPlays;
    private bool endingConversationStarted;

    private void Awake()
    {
        Instance = this;
    }

    //public DialogueConversationsManager GetSecurityConversation()
    //{
    //    if(!endingConversationPlays && startManager.firstConversationDone)
    //    {
    //        endingConversationPlays = true;

    //        //if the player has 20 points/max pouinst then conversation 3/ending convo will play
    //        if(sliderBar.HasMaxPoints())
    //        {
    //            Debug.Log("You win yay into Corteos office we go");
    //            conversation3.StartConversation();
    //        }

    //        //if not enough points will player conversation 2/get more points conversations
    //        Debug.Log("Need more points");
    //        conversation2.StartConversation();

    //    }

    //    if (sliderBar.HasMaxPoints())
    //        conversation3.StartConversation();

    //    conversation2.StartConversation();

    //    return GameEndingManager.Instance.GetSecurityConversation();
    //}
    public void StartEndSecurityConversation()
    {
        if (!endingConversationPlays && startManager.firstConversationDone)
        {
            //endingConversationPlays = true;

            //if the player has 20 points/max pouinst then conversation 3/ending convo will play
            if (sliderBar.HasMaxPoints())
            {
                Debug.Log("You win yay into Corteos office we go");
                endingConversationStarted = true;
                conversation3.StartConversation();
                
            }
            else
            {
                //if not enough points will player conversation 2/get more points conversations
                Debug.Log("Need more points");
                conversation2.StartConversation();
            }
        }

    }

    //loading scene afyer xvonsersation 3 has ended
    public void EndingConversationStart()
    {
            if (endingConversationStarted)
            {
                sceneLoader.LoadSceneByName(sceneName);
            }
            else
            {
                Debug.Log("cannot load scene");
            }
            
    }
}
