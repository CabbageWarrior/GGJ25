using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    public BubbleSpawner spawner;
    public float stepTimer = 4.0f;
    public float timer = 0.0f;
    public int step = 0;
    // BubbleBase bubbleBase;
    void Explode()
    {
        if(spawner != null)
            spawner.ExploseBubble();

        Destroy(this.gameObject);
    }

    public void Grabbed()
    {
        if (spawner != null)
            spawner.GrabBubble();
    }

    private void Start()
    {
        Increse();
        // bubbleBase = GetComponent<BubbleBase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Grabbed();

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Increse();
        }
    }

    void Increse()
    {
        step++;
        timer = stepTimer;
        if (step >= 4)
            Explode();/*
        else
            {
                if (bubbleBase != null)
                    SetState(step);
            }*/
        Debug.Log(step);
    }

}
