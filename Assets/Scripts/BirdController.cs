using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    int count;
    int speed = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       count++;
        transform.Translate(speed * Vector2.left * Time.deltaTime);

        if(count % 500 == 0)
        {
            speed *= -1;
        }
    }
}
