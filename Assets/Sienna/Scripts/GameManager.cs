using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    //added by Brooke, refernce for sliderbar so increasemonstercore can do its thing (replacing buttonpoint controler now)
    [Header("Slider Bar Reference")]
    [SerializeField] private SliderBar sliderBar;

    public int monsterScore = 0;


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

        if(sliderBar != null)
            sliderBar.UpdateStatus(amount);
    }
}
