using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI RestartText;
    // Start is called before the first frame update
    void Start()
    {
        //if (RestartText == null)
        //{
        //    Debug.Log("����ŸƮ�� null �Դϴ�.");
        //}

        if (scoreText == null)
        {
            Debug.Log("���ھ null �Դϴ�.");
        }
        
        //RestartText.gameObject.SetActive(false);
      
    }

    //public void SetRestart()
    //{
    //    RestartText.gameObject.SetActive(true);
    //}

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}
