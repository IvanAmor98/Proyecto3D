using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private GameController controller;

    public static int coinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("IA").GetComponent<GameController>();
        controller.newCoin();
        coinCount++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        coinCount--;
        controller.coinPickup();
        if (coinCount == 0)
        {
            Debug.Log("Win");
            controller.setFinished();

            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Firework");
            foreach (GameObject firework in fireworks)
            {
                firework.GetComponent<ParticleSystem>().Play();
                firework.GetComponent<AudioSource>().Play();
            }
        }
    }
}
