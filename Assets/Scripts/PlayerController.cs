using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController m_instance;
    private Rigidbody2D rb2d;
    float speed = 5.0f;
    float jumpForce = 300.0f;
    bool jump = false;
    bool mata = false;
    public bool box = false;
    public GameObject bird_viewArea;
    public GameObject resultPanel;
    public bool clear = false;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mata && !box)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.speed = 1;
                animator.Play("Walk_Right");
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.speed = 1;
                animator.Play("Walk_Left");
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                animator.speed = 0;
            }
        }
        else if(mata && !box)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.speed = 2;
                animator.Play("Walk_Right");
                transform.position += Vector3.right * speed * 2 * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.speed = 2;
                animator.Play("Walk_Left");
                transform.position += Vector3.left * speed * 2 * Time.deltaTime;
            }
            else
            {
                animator.speed = 0;
            }
        }
        else if (!mata && box)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.speed = 1;
                animator.Play("Box_Right");
                transform.position += Vector3.right * speed * 0.5f * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.speed = 1;
                animator.Play("Box_Left");
                transform.position += Vector3.left * speed * 0.5f * Time.deltaTime;
            }
            else
            {
                animator.speed = 0;
            }
        }
        else if(mata && box)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.speed = 1;
                animator.Play("Box_Right");
                transform.position += Vector3.right * speed * 1 * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.speed = 1;
                animator.Play("Box_Left");
                transform.position += Vector3.left * speed * 1 * Time.deltaTime;
            }
            else
            {
                animator.speed = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !jump)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            box = true;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            box = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jump = false;
        }
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Matatabi")
        {
            mata = true;
            Invoke("RunTime", 2);
        }

        if(collision.gameObject.tag == "Goal")
        {
            clear = true;
            speed = 0;
            jumpForce = 0;
            PointController.instance.ResultData();
            Invoke("ShowResult", 2);
        }
    }

    void RunTime()
    {
        mata = false;
    }

    public static PlayerController instance
    {
        get
        {
            if (m_instance == false)
            {
                m_instance = FindObjectOfType<PlayerController>();
            }
            return m_instance;
        }
    }

    /*public void BirdAttack()
    {
        if (!box)
        {
            bird_viewArea.SetActive(false);
            PointController.instance.LossFish();
            PointController.instance.SetData();
            PointController.instance.LogData();
        }
    }*/
    public void BirdVoid()
    {
        speed = 5.0f;
        jumpForce = 500.0f;
    }

    public void MovementStop()
    {
        speed = 0;
        jumpForce = 0;
        animator.speed = 0;
    }

    void ShowResult()
    {
        resultPanel.SetActive(true);
    }
}
