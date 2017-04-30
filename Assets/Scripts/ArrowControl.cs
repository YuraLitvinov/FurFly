using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

// calculate drag and set the speed
// fire projectile(Arrow) in its +ve X direction.
//Rotate as in gideros.

public class bowScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    //Clone of the bullet
    GameObject Clone;

    Vector2 mousePos;
    Vector3 screenPos;
    bool isDragged;
    bool fired;
    public float hSliderValue = 0.0f;
    private object vel;

    void Start()
    {
        mousePos = new Vector2();
        screenPos = new Vector3();
        fired = false;
        isDragged = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.gameObject.name == "Archer")
                {

                    if (!isDragged)
                    {
                        isDragged = true;
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {

            if (isDragged)
            {
                isDragged = false;
                FireBullet();
            }

        }
        if (isDragged)
        {
            mousePos = Input.mousePosition;
            screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

            float temp_Z = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;
            if (temp_Z >= -10 && temp_Z <= 90)
            {
                transform.eulerAngles = new Vector3(0, 0, temp_Z);
            }
        }
        if (fired && !Clone.GetComponent<Archer>().anim)
        {
            Debug.Log("Done");

            float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;

            print(angle);
            Clone.transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }


    void OnGUI()
    {
        hSliderValue = GUILayout.VerticalSlider(hSliderValue, 10.0f, 20.0f);
        GUILayout.Label("Force : " + hSliderValue.ToString());
    }

    public void FireBullet()
    {

        fired = true;
        Clone = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 2f), transform.rotation) as GameObject;
        Clone.rigidbody.velocity = transform.TransformDirection(Vector3.right * hSliderValue);

    }

}

