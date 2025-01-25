using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestController : MonoBehaviour
{
    public void AddBubble(int bubbleState)
    {
        FindObjectOfType<ScoreManager>().SetNewBubble(bubbleState);
    }
}
