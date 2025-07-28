using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverPanel;

    void Start()
    {
        if (scoreText == null) Debug.Log("스코어가 null 입니다.");
        if (finalScoreText == null) Debug.Log("최종 점수가 null 입니다.");
        if (highScoreText == null) Debug.Log("하이스코어가 null 입니다.");
        if (gameOverPanel == null) Debug.Log("게임오버 텍스트가 null 입니다.");

        // 게임 시작 시: 점수 텍스트만 활성화
        scoreText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(false);
        highScoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowGameOver(int finalScore, int highScore)
    {
        finalScoreText.gameObject.SetActive(true);
        highScoreText.gameObject.SetActive(true);
        gameOverPanel.SetActive(true);

        finalScoreText.text = "Final Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;
    }
}
