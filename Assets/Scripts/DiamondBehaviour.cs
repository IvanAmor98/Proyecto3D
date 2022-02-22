using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBehaviour : MonoBehaviour
{
    private GameObject player;
    private float timer = 0;
    public bool picked = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector3.Distance(player.transform.position, transform.position);
        timer = dist / 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!picked)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } else
            {
                //Destroy(gameObject);
            }
        }
    }
}
