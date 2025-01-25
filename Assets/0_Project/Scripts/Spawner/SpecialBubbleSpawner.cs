using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBubbleSpawner : MonoBehaviour
{
    public float timer;
    [SerializeField] float spawnTimer = 5.0f;
    bool full = true;
    public GameObject bubble;

    private void Start()
    {
        SpawnBubble();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !full)
        {
            SpawnBubble();
        }
    }


    void SpawnBubble()
    {
        Debug.Log("New bubble");
        GameObject bubbleSpawned = Instantiate(bubble);
        bubbleSpawned.transform.position = transform.position;
        bubbleSpawned.GetComponent<SpawnSpecialBubble>().bob = this;
        full = true;
    }
    public void ExploseBubble()
    {
        Debug.Log("Bubble explode");
        timer = spawnTimer;
        full = false;
    }

}
