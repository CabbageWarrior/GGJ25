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
        Increse();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))

            bob.ExploseBubble();


        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Increse();
        }
    }


    public void SetSpecialBubbleType()
    {
        specialState = (ESpecialBubble)UnityEngine.Random.Range(0, 5);
    }

    public override void Explode()
    {
        bob.ExploseBubble();
        Destroy(this.gameObject);

    }
    public override void Increse()
    {
        step++;
        timer = stepTimer;

        if (step >= 4)
            Explode();
        else
        {
            if (sb != null)
                sb.SetState(step);
        }

        Debug.Log(step);
    }
}
