using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{

    public float time;
    public Text timer;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 0)
        {
            timer.text = "TIME : 00";
        }
        else
        {
            time -= Time.deltaTime;
            seconds = (int)time;
            timer.text = "TIME : " + seconds.ToString();
        }
    }
}
