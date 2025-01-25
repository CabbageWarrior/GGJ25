using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameSelector gameSelector;
    [SerializeField] private NormalBubble[] bubblePivots;

    private int[] slots = { 0, 0, 0, 0, 0, 0 };


    // Score things
    bool isGameInProgress = true;

    float gameTimer = 0f;
    int totalHits = 0;
    int totalCatHits = 0;
    int smallBubbleScores = 0;
    int midBubbleScores = 0;
    int bigBubbleScores = 0;

    const int SMALL_SCORE = 30;
    const int MID_SCORE = 70;
    const int BIG_SCORE = 150;

    const int HIT_MALUS = 20;
    const int CATHIT_MALUS = 120;



    public int SmallScore => smallBubbleScores * SMALL_SCORE;
    public int MidScore => midBubbleScores * MID_SCORE;
    public int BigScore => bigBubbleScores * BIG_SCORE;

    public float TimeMultiplier
    {
        get
        {
            // 0-59 => x2
            // 60-89 => x1.5
            // 90-120 => x1
            // >120 => x0.5
            if (gameTimer > 600f) return .5f;
            if (gameTimer > 90f) return 1f;
            if (gameTimer > 120f) return 1.5f;
            return 2f;
        }
    }

    public int HitMalus => totalHits * HIT_MALUS;
    public int CatHitMalus => totalCatHits * CATHIT_MALUS;

    // totalBubbleScores * timeMod - hit * hit malus - cat hit * cat hit malus
    public float TotalScore => (SmallScore + MidScore + BigScore) * TimeMultiplier - HitMalus - CatHitMalus;

    public void SetNewBubble(int step)
    {
        int i = 0;
        for (i = 0; i < slots.Length; i++)
        {
            if (slots[i] == 0)
            {
                slots[i] = step;

                bubblePivots[i].SetState(step);

                switch (step)
                {
                    case 1:
                        smallBubbleScores++;
                        break;
                    case 2:
                        midBubbleScores++;
                        break;
                    case 3:
                        bigBubbleScores++;
                        break;
                    default:
                        break;
                }

                break;
            }
        }
        if (i == slots.Length - 1)
        {
            isGameInProgress = false;



            gameSelector.TriggerGameEnd();
        }
    }

    private void Update()
    {
        if (isGameInProgress)
        {
            gameTimer += Time.deltaTime;
        }
    }

    public void AddHit()
    {
        totalHits++;
    }
    public void AddCatHit()
    {
        totalCatHits++;
    }
}
