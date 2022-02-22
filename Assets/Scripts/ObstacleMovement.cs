using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float timeDamage = 5;
    public int speed;
    private bool going = false;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position == point1.transform.position)
        {
            going = false;
        } else
        {
            going = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            transform.position = Vector3.MoveTowards(transform.position, point1.transform.position, Time.deltaTime * speed);
            if (transform.position == point1.transform.position)
            {
                going = false;
            }
        } else
        {
            transform.position = Vector3.MoveTowards(transform.position, point2.transform.position, Time.deltaTime * speed);
            if (transform.position == point2.transform.position)
            {
                going = true;
            }
        }
    }
}
