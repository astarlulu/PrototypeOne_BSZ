using System.Collections;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip[] footStepSFX;
    private int lastIndex = -1;

    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();  
        StartCoroutine(PlayFootSteps());
    }

    IEnumerator PlayFootSteps()
    {
        while (true)
        {
            if (movement.input.magnitude > 0.1f)
            {
                int randomIndex;

                do
                {
                    randomIndex = Random.Range(0, footStepSFX.Length);
                }
                while (randomIndex == lastIndex && footStepSFX.Length > 1);

                lastIndex = randomIndex;

                AudioManager.instance.PlaySFX(footStepSFX[randomIndex]);
            }

            yield return new WaitForSeconds(0.48f); 
        }

        

    }

    
}
