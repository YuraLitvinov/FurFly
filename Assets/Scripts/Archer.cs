using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public Animator anim;
    public Transform transform;
    private Rigidbody2D arrow;
    private float speed = 1;


    public const int archer_idle = 0;
    public const int archer_attack = 1;
    public const int archer_walk = 2;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        arrow = Resources.Load("Arrow") as Rigidbody2D;
    }

    void Fire()
    {
        Rigidbody2D arrowClone = (Rigidbody2D)Instantiate(arrow, transform.position, transform.rotation);
        arrowClone.velocity = transform.forward * speed;

        // You can also acccess other components / scripts of the clone
        //arrowClone.GetComponent<MyRocketScript>().DoSomething();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector2 start = transform.position;
        Vector2 end = start;

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("StateArcher", archer_attack);
            Fire();
        }
        // Moving character
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            end += new Vector2(0, step);
            anim.SetInteger("StateArcher", archer_walk);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            end -= new Vector2(0, step);
            anim.SetInteger("StateArcher", archer_walk);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            end -= new Vector2(step, 0);
            anim.SetInteger("StateArcher", archer_walk);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            end += new Vector2(step, 0);
            anim.SetInteger("StateArcher", archer_walk);
        }
        else
        {
            anim.SetInteger("StateArcher", archer_idle);
        }
        transform.position = end;
    }
}

     


    







    