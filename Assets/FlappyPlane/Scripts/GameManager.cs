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

            // ���� ���̽��ھ� �ҷ����� (PlayerPrefs ���)
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
            // �ְ� ���� ����
            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("FlapHighScore", highScore);

                Main.GameManager.Instance.lastPlayedMiniGame = "Flap";
                Main.GameManager.Instance.lastScore = currentScore;
            }

            // ���ӿ��� UI ǥ��
            uIManager.ShowGameOver(currentScore, highScore);

            // 2�� �� ���ξ�����
            StartCoroutine(ReturnToMainAfterDelay());
        }

        private IEnumerator ReturnToMainAfterDelay()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("MainScene");
        }
    }
}
