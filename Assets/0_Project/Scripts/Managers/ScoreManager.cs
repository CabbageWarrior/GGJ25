using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameSelector gameSelector;
    [SerializeField] private NormalBubble[] bubblePivots;

    private int[] slots = { 0, 0, 0, 0, 0, 0 };

    public void SetNewBubble(int step)
    {
        int i = 0;
        for (i = 0; i < slots.Length; i++)
        {
            if (slots[i] == 0)
            {
                slots[i] = step;

                bubblePivots[i].SetState(step);

                break;
            }
        }
        if (i == slots.Length - 1)
        {
            gameSelector.TriggerGameEnd();
        }
    }
}
