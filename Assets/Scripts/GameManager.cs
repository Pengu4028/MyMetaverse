using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // UI용

namespace Main
{


    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private int score = 0;

        public TextMeshProUGUI scoreText;
        public GameObject gameOverUI;

        private float minigameDuration = 15f;
        private bool isMinigameActive = false;

        public string lastPlayedMiniGame = ""; // "Flap", "Gold", "Stack"
        public int lastScore = 0;

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
            score = 0;
            UpdateScoreUI();
            isMinigameActive = true;

            if (gameOverUI != null)
                gameOverUI.SetActive(false);

            StartCoroutine(MinigameTimer());
        }

        IEnumerator MinigameTimer() // 코루틴으로 게임시간 독립적으로 관리
        {
            yield return new WaitForSeconds(minigameDuration);
            EndMinigame(score);
        }

        public void EndMinigame(int finalScore)
        {
            Debug.Log("Minigame Ended. Score: " + finalScore);
            isMinigameActive = false;

            //점수 기록
            ReportMiniGameScore(lastPlayedMiniGame, finalScore);

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
            if (isMinigameActive) return;

            score += amount;
            Debug.Log("점수 증가: " + score);
            UpdateScoreUI();
            Debug.Log("Current Score: " + score);
        }

        private void UpdateScoreUI()
        {
            if (scoreText != null)
                scoreText.text = "Score: " + score;
        }

        public void ReportMiniGameScore(string miniGameName, int score)
        {
            lastPlayedMiniGame = miniGameName;
            lastScore = score;
        }

        void OnEnable()
        {
            if (GameManager.Instance != null)
            {
                string game = GameManager.Instance.lastPlayedMiniGame;
                int score = GameManager.Instance.lastScore;

                if (!string.IsNullOrEmpty(game))
                {
                    FindObjectOfType<MiniGameUIManager>().UpdateMiniGameScore(game, score);
                }
            }
        }

    }
}