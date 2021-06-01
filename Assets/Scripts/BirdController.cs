using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    int count;
    int speed = 3;

    public LayerMask mask;
    public GameObject viewArea;

    // Start is called before the first frame update
    void Start()
    {
        //bird_pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //bird_pos = this.transform;
        //Vector2 pos = bird_pos.position;

       count++;
        transform.Translate(speed * Vector2.left * Time.deltaTime);

        if(count % 500 == 0)
        {
            speed *= -1;
        }

        Ray ray1 = new Ray(transform.position, new Vector3(-0.3f, -1, 0));
        Ray ray2 = new Ray(transform.position, new Vector3(-0.2f, -1, 0));
        Ray ray3 = new Ray(transform.position, new Vector3(0, -1, 0));
        Ray ray4 = new Ray(transform.position, new Vector3(0.2f, -1, 0));
        Ray ray5 = new Ray(transform.position, new Vector3(0.3f, -1, 0));
        Debug.DrawRay(ray1.origin, ray1.direction * 8, Color.green);
        Debug.DrawRay(ray2.origin, ray2.direction * 8, Color.green);
        Debug.DrawRay(ray3.origin, ray3.direction * 8, Color.green);
        Debug.DrawRay(ray4.origin, ray4.direction * 8, Color.green);
        Debug.DrawRay(ray5.origin, ray5.direction * 8, Color.green);

        RaycastHit hit;
        if(Physics.Raycast(ray1, out hit, 10.0f, mask) || Physics.Raycast(ray2, out hit, 10.0f, mask) ||
            Physics.Raycast(ray3, out hit, 10.0f, mask) || Physics.Raycast(ray4, out hit, 10.0f, mask) ||
            Physics.Raycast(ray5, out hit, 10.0f, mask))
        {
            Debug.Log("attack");
            viewArea.SetActive(false);
            PlayerController.instance.BirdAttack();
            Invoke("BirdNext", 2.0f);
        }

    }

    void BirdNext()
    {
        viewArea.SetActive(true);
        PlayerController.instance.BirdVoid();
    }
}
