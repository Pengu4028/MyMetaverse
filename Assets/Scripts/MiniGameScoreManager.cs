using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameUIManager : MonoBehaviour
{
    public TextMeshProUGUI flapScoreText;
    public TextMeshProUGUI goldScoreText;
    public TextMeshProUGUI stackScoreText;

    private int flapHighScore = 0;
    private int goldHighScore = 0;
    private int stackHighScore = 0;

    void Start()
    {
        LoadHighScores();
        UpdateScoreUI();

        if (Main.GameManager.Instance != null)
        {
            string game = Main.GameManager.Instance.lastPlayedMiniGame;
            int score = Main.GameManager.Instance.lastScore;

            if (!string.IsNullOrEmpty(game))
            {
                UpdateMiniGameScore(game, score);
            }
        }
        
    }

    public void UpdateMiniGameScore(string miniGameName, int score)
    {
        switch (miniGameName)
        {
            case "Flap":
                flapHighScore = Mathf.Max(flapHighScore, score);
                PlayerPrefs.SetInt("FlapHighScore", flapHighScore);
                break;
            case "Gold":
                goldHighScore = Mathf.Max(goldHighScore, score);
                PlayerPrefs.SetInt("GoldHighScore", goldHighScore);
                break;
            case "Stack":
                stackHighScore = Mathf.Max(stackHighScore, score);
                PlayerPrefs.SetInt("StackHighScore", stackHighScore);
                break;
        }

        UpdateScoreUI();
    }

    void LoadHighScores()
    {
        flapHighScore = PlayerPrefs.GetInt("FlapHighScore", 0);
        goldHighScore = PlayerPrefs.GetInt("GoldHighScore", 0);
        stackHighScore = PlayerPrefs.GetInt("StackHighScore", 0);
    }

    void UpdateScoreUI()
    {
        flapScoreText.text = $"Flap: {flapHighScore}";
        goldScoreText.text = $"Gold: {goldHighScore}";
        stackScoreText.text = $"Stack: {stackHighScore}";
    }
}
