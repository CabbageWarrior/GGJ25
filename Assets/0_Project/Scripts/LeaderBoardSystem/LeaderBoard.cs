using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    private const string PREF_SCORES = "scores";

    public List<Scores> leaderboard = new List<Scores>();
    Scores score;

    void Start()
    {
        LoadLeaderBoard();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            score = new Scores();
            score.name = "Bob";
            score.score = 0;
            UpdateLeaderBoard();
        }
    }

    void UpdateLeaderBoard()
    {
        leaderboard.Add(score);


        // check player e posiziona nel caso cambia posizione
        // cancella oltre il 10
        SaveLeaderBoard();
    }
    void LoadLeaderBoard()
    {
        string jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES, null);
        if (string.IsNullOrEmpty(jsonLeaderboard))
        {
            leaderboard = new List<Scores>();
            string newLeaderboard = JsonUtility.ToJson(leaderboard);
            PlayerPrefs.SetString(PREF_SCORES, newLeaderboard);
        }
        else
            leaderboard = JsonUtility.FromJson<List<Scores>>(jsonLeaderboard);
    }
    void SaveLeaderBoard()
    {
        string newLeaderboard = JsonUtility.ToJson(leaderboard);
        Debug.Log(newLeaderboard);
        PlayerPrefs.SetString(PREF_SCORES, newLeaderboard);
        PlayerPrefs.Save();
    }
}
