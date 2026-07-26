using UnityEngine;

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

    private bool endingConversationPlays;

    private void Awake()
    {
        Instance = this;
    }

    public DialogueConversationsManager GetSecurityConversation()
    {
        if(!endingConversationPlays)
        {
            endingConversationPlays = true;

            //if the player has 20 points/max pouinst then conversation 3/ending convo will play
            if(sliderBar.HasMaxPoints())
            {
                Debug.Log("You win yay into Corteos office we go");
                return conversation3;
            }

            //if not enough points will player conversation 2/get more points conversations
            Debug.Log("Need more points");
            return conversation2;

        }

        if (sliderBar.HasMaxPoints())
            return conversation3;

        return conversation2;
    }
}
