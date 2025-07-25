using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // UI¿ë

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverUI;

    private float minigameDuration = 15f;
    private bool isMinigameActive = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        UpdateScoreUI();
    }

    public void StartMinigame(string name)
    {
        Debug.Log("Starting Minigame: " + name);
        score = 0;
        UpdateScoreUI();
        isMinigameActive = true;

        if (gameOverUI != null)
            gameOverUI.SetActive(false);

        StartCoroutine(MinigameTimer());
    }

    IEnumerator MinigameTimer()
    {
        yield return new WaitForSeconds(minigameDuration);
        EndMinigame(score);
    }

    public void EndMinigame(int finalScore)
    {
        Debug.Log("Minigame Ended. Score: " + finalScore);
        isMinigameActive = false;

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            if (scoreText != null)
                scoreText.text = "Final Score: " + finalScore;
        }

        StartCoroutine(ReturnToMainSceneAfterDelay(3f));
    }

    IEnumerator ReturnToMainSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int amount)
    {
        if (!isMinigameActive) return;

        score += amount;
        UpdateScoreUI();
        Debug.Log("Current Score: " + score);
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
