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

        public UIManager UIManager { get { return uIManager; } }
        public static GameManager Instance { get { return gameManager; } }

        private int currentScore = 0;

        private void Awake()
        {
            gameManager = this;
            uIManager = FindObjectOfType<UIManager>();
        }

        private void Start()
        {
            uIManager.UpdateScore(0);
        }

        public void GameOver()
        {
            

            // 2�� �� MainScene���� ��ȯ
            StartCoroutine(ReturnToMainAfterDelay());

            //uIManager.SetRestart(); // ����ŸƮ ��� ��
        }

        private IEnumerator ReturnToMainAfterDelay()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("MainScene");
        }

        public void AddScore(int score)
        {
            currentScore += score;
            Debug.Log("Score : " + currentScore);
            uIManager.UpdateScore(currentScore);
        }


    }
}