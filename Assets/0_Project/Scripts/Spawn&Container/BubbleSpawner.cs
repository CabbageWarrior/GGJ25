using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public float bubbleTimer;
    [SerializeField] float bubbleExplode = 3.0f;
    [SerializeField] float bubbleGbabed = 20.0f;

    public GameObject bubble;
    bool occupato = true;

    private void Start()
    {
        SpawnBubble();
    }
    void Update()
    {
        bubbleTimer -= Time.deltaTime;
        if(bubbleTimer <= 0 && !occupato)
        {
            SpawnBubble();
        }



        
    }

    public void GrabBubble()
    {
        bubbleTimer = bubbleGbabed;
        occupato = false;
        Debug.Log("Grabbed");
    }

    void SpawnBubble()
    {
        Debug.Log("New bubble");
        GameObject bubbleSpawned = Instantiate(bubble);
        bubbleSpawned.transform.position = transform.position;
        bubbleSpawned.GetComponent<SpawnBubble>().spawner = this; //b = this;
        occupato = true;
    }
    public void ExploseBubble()
    {
        Debug.Log("Bubble explode");
        bubbleTimer = bubbleExplode;
        occupato = false;
    }

}
