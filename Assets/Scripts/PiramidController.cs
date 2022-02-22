using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiramidController : MonoBehaviour
{
    public GameObject diamond;
    public Text diamondText;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCanvas();
        SpawnDiamond();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Player":
                if (other.gameObject.GetComponent<PlayerCollisionManager>().hasDiamond)
                {
                    other.gameObject.GetComponent<PlayerCollisionManager>().hasDiamond = false;
                    Destroy(other.gameObject.GetComponent<PlayerCollisionManager>().diamond);
                    other.gameObject.GetComponent<PlayerCollisionManager>().diamond = null;
                    count++;
                    UpdateCanvas();
                    SpawnDiamond();
                }
                break;
        }
    }

    private void SpawnDiamond()
    {
        GameObject temp = Instantiate(diamond, new Vector3(Random.Range(-40, 160), 1, Random.Range(-50, 50)), Quaternion.identity); ;
         if (!Physics.Raycast(temp.transform.position, Vector3.down, 1F + 0.1F))
        {
            Destroy(temp);
            SpawnDiamond();
        }

    }

    private void UpdateCanvas()
    {
        diamondText.text = count.ToString();
    }

}
