using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBubble : MonoBehaviour
{
    public BubbleSpawner spawner;
    public Vector2 stepTimer = new Vector2(3.5f, 7.5f);
    public float timer = 0.0f;
    public int step = 0;
    NormalBubble normalBubble;
    public virtual void Explode()
    {
        if(spawner != null)
            spawner.ExploseBubble();

        Destroy(this.gameObject);
    }

    public void Grabbed()
    {
        if (spawner != null)
            spawner.GrabBubble();

        Destroy(this.gameObject);
    }

    private void Start()
    {
        normalBubble = GetComponent<NormalBubble>();
        timer = RandomSpawn();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Increse();
        }
    }
    public virtual float RandomSpawn()
    {
        return Random.Range(stepTimer.x, stepTimer.y);
    }
    public virtual void Increse()
    {
        step++;
        timer = RandomSpawn();
        if (step >= 4)
            Explode();
        else
        {
            if (normalBubble != null)
                normalBubble.SetState(step);
        }
    }

}
