using UnityEngine;

public class SuspectVoice : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.Play();
    }

    public void StopVoice()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}