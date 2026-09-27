using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int pointValue = 10;

    [Header("Hit Effect")]
    [SerializeField] private GameObject hitEffectPrefab;

    [Header("Hit Sounds")]
    [SerializeField] private AudioClip[] hitSounds;
    [SerializeField] private AudioSource audioSource;

    private bool animationStopped = false;

    private void OnMouseDown()
    {
        GameManager gameManager = FindAnyObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager could not be found!");
            return;
        }

        gameManager.RegisterHit(pointValue);

        Debug.Log("Hit registered! +" + pointValue);

        PlayHitEffect();
        PlayRandomHitSound();

        if (!animationStopped)
        {
            StopIdleAnimation();
            animationStopped = true;
        }
    }

    private void PlayHitEffect()
    {
        if (hitEffectPrefab == null)
            return;

        GameObject effect = Instantiate(
            hitEffectPrefab,
            transform.position,
            Quaternion.identity
        );

        Destroy(effect, 1f);
    }

    private void PlayRandomHitSound()
    {
        if (audioSource == null || hitSounds == null || hitSounds.Length == 0)
            return;

        AudioClip randomClip = hitSounds[Random.Range(0, hitSounds.Length)];

        audioSource.PlayOneShot(randomClip);
    }

    private void StopIdleAnimation()
    {
        Transform body = transform.parent.Find("Body");

        if (body == null)
        {
            Debug.LogError("Body not found under Suspect!");
            return;
        }

        SuspectIdleAnimation idleAnimation =
            body.GetComponent<SuspectIdleAnimation>();

        if (idleAnimation != null)
        {
            idleAnimation.StopAnimation();
        }
    }
}