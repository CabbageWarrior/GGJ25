using UnityEngine;

public class SpawnSpecialBubble : SpawnBubble
{
    public ESpecialBubble specialState = ESpecialBubble.Marijuana;
    public SpecialBubbleSpawner bob;
    public SpecialBubble sb;
    private void Start()
    {
        sb = GetComponent<SpecialBubble>();
        SetSpecialBubbleType();
        sb.SetSpecial(specialState);
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


    public void SetSpecialBubbleType()
    {
        bob.currentColorIndex = UnityEngine.Random.Range(0, 5);
        specialState = (ESpecialBubble)bob.currentColorIndex;
    }

    public override void Explode()
    {
        bob.ExploseBubble();
        Destroy(this.gameObject);

    }

    public override void Increse()
    {
        step++;
        timer = RandomSpawn();

        if (step >= 4)
            Explode();
        else
        {
            if (sb != null)
                sb.SetState(step);
        }

    }
}
