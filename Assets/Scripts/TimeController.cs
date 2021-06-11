using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public float time;
    public Text timer;
    int seconds;
    public GameObject panel;
    GameObject player;
    PlayerController playerscript;
    public AudioClip timeOverVoice;
    bool timeOver = false;
    public GameObject bgm;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            timer.text = "TIME : 00";
            PlayerController.instance.MovementStop();
            if (!playerscript.clear)
            {
                bgm.SetActive(false);
                panel.SetActive(true);
                SendMessage("TimeOverVoice");
            }
        }
        else
        {
            time -= Time.deltaTime;
            seconds = (int)time;
            timer.text = "TIME : " + seconds.ToString();
        }
    }

    void TimeOverVoice()
    {
        if (!timeOver)
        {
            AudioSourceController.instance.PlayOneShot(timeOverVoice);
            timeOver = true;
        }
    }
}
