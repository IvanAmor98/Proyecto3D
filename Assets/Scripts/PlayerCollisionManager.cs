using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionManager : MonoBehaviour
{
    GameController controller;
    public bool hasDiamond = false;
    public GameObject diamond;
    public bool pickable = false;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("IA").GetComponent<GameController>();
    }

    private void Update()
    {
        if (hasDiamond)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                DiamondDrop();
            } else
            {
                diamond.transform.position = point.transform.position;
            }
        } else
        {
            if (pickable && Input.GetKey(KeyCode.E))
            {
                DiamondPickUp();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Obstacle":
                controller.ObstacleHit(other.GetComponent<ObstacleMovement>().timeDamage);
                break;
            case "Time":
                controller.TimePickup();
                Destroy(other.gameObject);
                break;
            case "Diamond":
                pickable = true;
                diamond = other.gameObject;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Diamond":
                pickable = false;
                diamond = null;
                break;
        }
    }

    private void DiamondPickUp()
    {
        if (!hasDiamond)
        {
            hasDiamond = true;
            diamond.GetComponent<DiamondBehaviour>().picked = true;
        }
    }

    private void DiamondDrop()
    {
        hasDiamond = false;
        diamond.GetComponent<DiamondBehaviour>().picked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
