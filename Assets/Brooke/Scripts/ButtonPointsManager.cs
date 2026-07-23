using UnityEngine;
using UnityEngine.UI;

public class ButtonPointsManager : MonoBehaviour
{
    //thorw away code will be later replaced with dialouge choices
    public float stepValue = 1f;

    [Header("Button Refernces")]
    public Button finalButton;
    public Button removeButton;
    public Button addButton;

    [Header("SliderBar script")]
    public SliderBar sliderBar;

    public void RemovePoints()
    {
        sliderBar.UpdateStatus(-stepValue);
        Debug.Log("1 point removed, current slider points: " +sliderBar.GetCurrentPoints());
    }

    public void AddPoints()
    {
        sliderBar.UpdateStatus(stepValue);
        Debug.Log("1 point added, current slider points: " + sliderBar.GetCurrentPoints());
    }


    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
