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
        //    Debug.Log("리스타트가 null 입니다.");
        //}

        if (scoreText == null)
        {
            Debug.Log("스코어가 null 입니다.");
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
