using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [Header("Points for this hit point")]
    [SerializeField] private int pointValue = 10;

    private bool hasBeenHit = false;

    private void OnMouseDown()
    {
        RegisterHit();
    }

    private void RegisterHit()
    {
        // Only stop the idle animation on the FIRST hit.
        if (!hasBeenHit)
        {
            hasBeenHit = true;

            // Find the Body object inside Suspect.
            Transform body = transform.parent.Find("Body");

            if (body != null)
            {
                SuspectIdleAnimation animation =
                    body.GetComponent<SuspectIdleAnimation>();

                if (animation != null)
                {
                    animation.StopAnimation();
                }
            }
        }

        Debug.Log("Hit! +" + pointValue + " points");
    }
}