using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{

    private static PointController m_instance;
    public int playerFish = 0;
    public int playerScore = 0;
    public Text fish;
    public Text score;
    public Text resultScore;
    public Text resultFish;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Awake()
    {
        playerFish = PlayerPrefs.GetInt("fish", 0);
        playerScore = PlayerPrefs.GetInt("score", 0);
        SetData();
    }

    public void SetData()
    {
        fish.text = playerFish.ToString("000");
        score.text = playerScore.ToString("00000");
    }

    public void AddFish()
    {
        playerFish++;
        playerScore += 100;
    }

    public void AddMata()
    {
        playerScore += 150;
    }

    public void LossFish()
    {
        if(playerFish >= 1 && playerScore >= 100)
        {
            playerFish--;
            playerScore -= 100;
        }
        else
        {
            playerFish = 0;
            playerScore = 0;
        }
    }

    public void LogData()
    {
        PlayerPrefs.SetInt("score", playerScore);
        PlayerPrefs.SetInt("fish", playerFish);
    }

    public static PointController instance
    {
        get
        {
            if(m_instance == false)
            {
                m_instance = FindObjectOfType<PointController>();
            }
            return m_instance;
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("fish", 0);
        PlayerPrefs.SetInt("score", 0);
    }

    public void ResultData()
    {
        resultFish.text = ":" + playerFish.ToString("00") + "/15";
        resultScore.text = "Score:" + playerScore.ToString("00000");
    }
}
