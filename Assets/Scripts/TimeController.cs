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
                panel.SetActive(true);
            }
        }
        else
        {
            time -= Time.deltaTime;
            seconds = (int)time;
            timer.text = "TIME : " + seconds.ToString();
        }
    }
}
