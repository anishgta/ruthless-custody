using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField] private float gameTime = 30f;
    [SerializeField] private TMP_Text timerText;

    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text hitsText;

    [Header("Damage")]
    [SerializeField] private DamageSpriteChanger damageSpriteChanger;

    private float timeRemaining;
    private int score;
    private int totalHits;
    private bool gameRunning;

    // Lets other scripts know whether the level is still running
    public bool IsGameRunning => gameRunning;

    private void Start()
    {
        timeRemaining = gameTime;
        gameRunning = true;

        if (damageSpriteChanger == null)
        {
            damageSpriteChanger = FindAnyObjectByType<DamageSpriteChanger>();
        }

        UpdateUI();
    }

    private void Update()
    {
        if (!gameRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            gameRunning = false;

            Debug.Log("TIME'S UP!");

            SceneManager.LoadScene("Interval1");
            return;
        }

        UpdateUI();
    }

    public void RegisterHit(int points)
    {
        if (!gameRunning)
            return;

        score += points;
        totalHits++;

        if (damageSpriteChanger != null)
        {
            damageSpriteChanger.UpdateDamageSprite(totalHits);
        }

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (timerText != null)
            timerText.text = "00:" + Mathf.CeilToInt(timeRemaining).ToString("00");

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (hitsText != null)
            hitsText.text = "Hits: " + totalHits;
    }
}