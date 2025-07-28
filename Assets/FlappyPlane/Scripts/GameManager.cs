using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace MinigameFlap
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;

        UIManager uIManager;
        public string lastPlayedMiniGame;
        public int lastScore;
        public UIManager UIManager { get { return uIManager; } }
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;
        private int highScore = 0;

        private void Awake()
        {
            gameManager = this;
            uIManager = FindObjectOfType<UIManager>();

            // 이전 하이스코어 불러오기 (PlayerPrefs 사용)
            highScore = PlayerPrefs.GetInt("FlapHighScore", 0);
        }

        private void Start()
        {
            currentScore = 0;
            uIManager.UpdateScore(0);
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log("Score : " + currentScore);
            uIManager.UpdateScore(currentScore);
        }

        public void GameOver()
        {
            // 최고 점수 갱신
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("FlapHighScore", highScore);

                Main.GameManager.Instance.lastPlayedMiniGame = "Flap";
                Main.GameManager.Instance.lastScore = currentScore;
            }

            // 게임오버 UI 표시
            uIManager.ShowGameOver(currentScore, highScore);

            // 2초 후 메인씬으로
            StartCoroutine(ReturnToMainAfterDelay());
        }

        private IEnumerator ReturnToMainAfterDelay()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("MainScene");
        }
    }
}
