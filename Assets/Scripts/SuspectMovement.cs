using UnityEngine;

public class SuspectMovement : MonoBehaviour
{
    [Header("Jump Movement")]
    [SerializeField] private float jumpDistance = 0.5f;
    [SerializeField] private float jumpInterval = 0.12f;

    [Header("Movement Limits")]
    [SerializeField] private float leftLimit = -4f;
    [SerializeField] private float rightLimit = 4f;

    private int direction = 1;
    private float timer;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        // Stop exactly where the suspect is when the timer ends
        if (gameManager == null || !gameManager.IsGameRunning)
            return;

        timer += Time.deltaTime;

        if (timer >= jumpInterval)
        {
            timer = 0f;
            JumpSideways();
        }
    }

    private void JumpSideways()
    {
        Vector3 newPosition = transform.position;

        newPosition.x += jumpDistance * direction;

        // Reached right limit
        if (newPosition.x >= rightLimit)
        {
            newPosition.x = rightLimit;
            direction = -1;
        }

        // Reached left limit
        else if (newPosition.x <= leftLimit)
        {
            newPosition.x = leftLimit;
            direction = 1;
        }

        transform.position = newPosition;
    }
}