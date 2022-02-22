using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject infoPanel;
    public float time = 60;
    private bool finished = false;
    private int coins = 0;
    public Text timeText;
    public Text coinText;
    private int updated = 0;
    private float timeCount = 1;
    private Transform[] spawnPoints;
    public GameObject timePrefab;
    public float[] timers;
    private float timer = 0;
    public GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCanvas(0);
        spawnPoints = GameObject.FindGameObjectWithTag("Respawn").GetComponentsInChildren<Transform>();
        timers = new float[spawnPoints.Length];
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            CheckTimers();
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (updated != 0 && timeCount > 0)
                {
                    timeCount -= Time.deltaTime;
                } else
                {
                    updated = 0;
                }
                UpdateCanvas(updated);
            }
            else
            {
                SceneManager.LoadScene("SampleScene");
                Debug.Log("Lose");
            }
        } else
        {
            infoPanel.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void SetTime()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            timers[i] = Random.Range(1F, 100F);
        }
    }

    public void CheckTimers()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (timers[i] > 0 && timer > timers[i])
            {
                SpawnTime(i);
            }
        }
    }

    public void SpawnTime(int i)
    {
        timers[i] = 0;
        Instantiate(timePrefab, spawnPoints[i].position, Quaternion.identity, GameObject.FindGameObjectWithTag("Respawn").transform);
    }

    public void ObstacleHit(float timeDamage)
    {
        time -= timeDamage;
        updated = -1;
        timeCount = 1;
    }

    public void TimePickup()
    {
        time += 5;
        updated = 1;
        timeCount = 1;
    }

    public void coinPickup()
    {
        time += 3;
        coins--;
        updated = 1;
        timeCount = 1;
    }

    public void newCoin()
    {
        coins++;
    }

    public void UpdateCanvas(int type)
    {
        timeText.text = ((int)time).ToString();
        coinText.text = coins.ToString();
        if (type == 1)
        {
            timeText.color = Color.green;
        } else if (type == -1)
        {
            timeText.color = Color.red;
        } else
        {
            timeText.color = Color.black;
        }
    }

    public void setFinished()
    {
        finished = true;
    }
}
