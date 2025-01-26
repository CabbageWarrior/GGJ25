using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCalculator : MonoBehaviour
{
    public List<TMP_Text> pos = new List<TMP_Text>();

    public ScoreManager scoreManager;

    List<float> multi = new List<float>();
    List<float> result = new List<float>();


    void Start()
    {
        scoreManager = this.GetComponentInParent<ScoreManager>();
        LoadData();
        LoadUI();
    }
    void LoadData()
    {
        multi.Add(scoreManager.smallBubbleScores);
        multi.Add(scoreManager.midBubbleScores);
        multi.Add(scoreManager.bigBubbleScores);
        multi.Add(scoreManager.TimeMultiplier);
        multi.Add(-scoreManager.totalHits);
        multi.Add(-scoreManager.totalCatHits);

        result.Add(scoreManager.SmallScore);
        result.Add(scoreManager.MidScore);
        result.Add(scoreManager.BigScore);
        result.Add(Mathf.Floor(scoreManager.gameTimer));
        result.Add(-scoreManager.HitMalus);
        result.Add(-scoreManager.CatHitMalus);
    }
    void LoadUI()
    {
        for(int i = 0; i < pos.Count - 1; i++)
        {
            string bob = $"{multi[i]} = {result[i]}";
            pos[i].text = bob;
        }

        pos[6].text = $"{scoreManager.TotalScore}";
    }
}
