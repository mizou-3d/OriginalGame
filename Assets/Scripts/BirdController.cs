using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    int count;
    int speed = 3;

    public LayerMask mask;
    public GameObject viewArea;
    bool hit = false;

    GameObject player;
    PlayerController playerscript;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<PlayerController>();
        animator.SetFloat("x", 0);
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

        Ray ray1 = new Ray(transform.position, new Vector2(-0.3f, -1));
        Ray ray2 = new Ray(transform.position, new Vector2(-0.2f, -1));
        Ray ray3 = new Ray(transform.position, new Vector2(0, -1));
        Ray ray4 = new Ray(transform.position, new Vector2(0.2f, -1));
        Ray ray5 = new Ray(transform.position, new Vector2(0.3f, -1));
        Debug.DrawRay(ray1.origin, ray1.direction * 8, Color.green);
        Debug.DrawRay(ray2.origin, ray2.direction * 8, Color.green);
        Debug.DrawRay(ray3.origin, ray3.direction * 8, Color.green);
        Debug.DrawRay(ray4.origin, ray4.direction * 8, Color.green);
        Debug.DrawRay(ray5.origin, ray5.direction * 8, Color.green);

        RaycastHit2D hit1 = Physics2D.Raycast((Vector2)ray1.origin, (Vector2)ray1.direction, 10.0f, mask);
        RaycastHit2D hit2 = Physics2D.Raycast((Vector2)ray2.origin, (Vector2)ray2.direction, 10.0f, mask);
        RaycastHit2D hit3 = Physics2D.Raycast((Vector2)ray3.origin, (Vector2)ray3.direction, 10.0f, mask);
        RaycastHit2D hit4 = Physics2D.Raycast((Vector2)ray4.origin, (Vector2)ray4.direction, 10.0f, mask);
        RaycastHit2D hit5 = Physics2D.Raycast((Vector2)ray5.origin, (Vector2)ray5.direction, 10.0f, mask);

        if (hit1.collider || hit2.collider || hit3.collider || hit4.collider || hit5.collider)
        {
            if (!hit && !playerscript.box)
            {
                viewArea.SetActive(false);
                animator.SetFloat("x", 1);
                hit = true;
                Invoke("BirdNext", 2.0f);
            }
        }

    }

    void BirdAtacck()
    {
        PointController.instance.LossFish();
        PointController.instance.SetData();
        PointController.instance.LogData();
    }

    void BirdNext()
    {
        viewArea.SetActive(true);
        animator.SetFloat("x", 0);
        hit = false;
        //PlayerController.instance.BirdVoid();
    }
}
