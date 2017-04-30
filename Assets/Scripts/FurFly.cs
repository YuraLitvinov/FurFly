using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurFly : MonoBehaviour
{
    Animator anim;
    Transform transform;
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector2 start = transform.position;
        Vector2 end = start;

        if (Input.GetKey(KeyCode.W))
        {
            end += new Vector2(0, step);
            anim.SetInteger("furfly_state", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            end -= new Vector2(0, step);
            anim.SetInteger("furfly_state", 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            end -= new Vector2(step, 0);
            anim.SetInteger("furfly_state", 1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            end += new Vector2(step, 0);
            anim.SetInteger("furfly_state", 1);
        }
        else
        {
            anim.SetInteger("furfly_state", 0);
        }
        transform.position = end;
    }
}
