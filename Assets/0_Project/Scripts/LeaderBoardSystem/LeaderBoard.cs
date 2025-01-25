using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class LeaderBoard : MonoBehaviour
{
    private const string PREF_SCORES_SINGLE = "scores";
    private const string PREF_SCORES_MULTI = "scoresMulti";
    public List<Scores> leaderboard = new List<Scores>();
    Scores score;

    public bool multiPlayer;
    public string playerName;
    public int playerPoint;

    void Start()
    {

        LoadLeaderBoard(multiPlayer);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetScore(multiPlayer, playerName, playerPoint);
        }
    }

    public void SetScore(bool isMulti, string name, int points)
    {
        score = new Scores();
        score.name = playerName;
        score.point = playerPoint;
        UpdateLeaderBoard(isMulti);
    }

    void UpdateLeaderBoard(bool isMulty)
    {
        leaderboard.Add(score);
        leaderboard = leaderboard.OrderByDescending(x=>x.point).ToList();
        if(leaderboard.Count > 10 )
            leaderboard.RemoveAt(10);
        SaveLeaderBoard(isMulty);
    }
    void LoadLeaderBoard(bool isMulty)
    {
        string jsonLeaderboard;

        if(!isMulty)
            jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_SINGLE, null);
        else
            jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_MULTI, null);

        if (string.IsNullOrEmpty(jsonLeaderboard))
        {
            leaderboard = new List<Scores>();
            string newLeaderboard = Newtonsoft.Json.JsonConvert.SerializeObject(leaderboard);

            if (!isMulty)
                jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_SINGLE, newLeaderboard);
            else
                jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_MULTI, newLeaderboard);
        }
        else
            leaderboard = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Scores>>(jsonLeaderboard);

    }
    void SaveLeaderBoard(bool isMulty)
    {
        string newLeaderboard = Newtonsoft.Json.JsonConvert.SerializeObject(leaderboard);
        Debug.Log(newLeaderboard);
        if (!isMulty)
            PlayerPrefs.SetString(PREF_SCORES_SINGLE, newLeaderboard);
        else
            PlayerPrefs.SetString(PREF_SCORES_MULTI, newLeaderboard);
        PlayerPrefs.Save();
    }
}
