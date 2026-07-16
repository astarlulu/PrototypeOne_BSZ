using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [Header("UI Refernce")]
    [SerializeField] private Slider sliderBar;

    [Header("Points")]
    [SerializeField] private float maxPoints = 20f; //default to be safe
    [SerializeField] private float currentPoints;


    void Start()
    {
        //point values initlised
        currentPoints = maxPoints;
        sliderBar.maxValue = maxPoints;
        sliderBar.value = maxPoints;

    }

    // Update is called once per frame
    public void UpdateStatus(float amount)
    {
        currentPoints += amount;

        currentPoints = Mathf.Clamp(currentPoints, 0, maxPoints);
        sliderBar.value = currentPoints;
    }

    //get current points for points button managaer
    public float GetCurrentPoints()
    {
        return currentPoints;
    }


}
