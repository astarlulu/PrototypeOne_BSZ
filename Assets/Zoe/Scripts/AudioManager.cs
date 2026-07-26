using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Sound Effects")]
    public AudioClip dialogueClick;
    public AudioClip gainPoints;
    public AudioClip losePoints;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(AudioClip audioClip, float volume = 0.5f)
    {
        StartCoroutine(PlaySFXCoroutine(audioClip, volume));
    }

    IEnumerator PlaySFXCoroutine(AudioClip audioClip, float volume = 0.5f)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.Play();

        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(audioSource);
    }
}