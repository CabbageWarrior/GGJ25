using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public float bubbleTimer;
    [SerializeField] float bubbleExplode = 3.0f;
    [SerializeField] float bubbleGbabed = 20.0f;
    [SerializeField] ParticleSystem particle;

    public GameObject bubble;
    bool full = true;

    private void Start()
    {
        SpawnBubble();
    }
    void Update()
    {
        bubbleTimer -= Time.deltaTime;
        if(bubbleTimer <= 0 && !full)
        {
            SpawnBubble();
        }
    }

    public void GrabBubble()
    {
        bubbleTimer = bubbleGbabed;
        full = false;
        Debug.Log("Grabbed");
    }

    void SpawnBubble()
    {
        GameObject bubbleSpawned = Instantiate(bubble);
        bubbleSpawned.transform.position = transform.position;
        bubbleSpawned.GetComponent<SpawnBubble>().spawner = this; //b = this;
        full = true;
    }
    public void ExploseBubble()
    {
        Debug.Log("Bubble explode");
        bubbleTimer = bubbleExplode;
        full = false;
        particle.Play();
    }

}
