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
        if (scoreText == null) Debug.Log("���ھ null �Դϴ�.");
        if (finalScoreText == null) Debug.Log("���� ������ null �Դϴ�.");
        if (highScoreText == null) Debug.Log("���̽��ھ null �Դϴ�.");
        if (gameOverPanel == null) Debug.Log("���ӿ��� �ؽ�Ʈ�� null �Դϴ�.");

        // ���� ���� ��: ���� �ؽ�Ʈ�� Ȱ��ȭ
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
