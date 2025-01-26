using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    private const string PREF_SCORES_SINGLE = "scores";
    private const string PREF_SCORES_MULTI = "scoresMulti";
    public List<Scores> leaderboard = new List<Scores>();
    Scores score;

    public bool multiPlayer;
    public string playerName;
    public int playerPoint;
    public List<TMP_Text> pos = new List<TMP_Text>();

    void Start()
    {

        LoadLeaderBoard(multiPlayer);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetScore(multiPlayer, playerName, playerPoint);
        }
    }

    public void SetScore(bool isMulti, string name, int points)
    {
        // FIX for UI!
        isMulti = false;

        score = new Scores();
        score.name = playerName;
        score.point = playerPoint;
        UpdateLeaderBoard(isMulti);
    }

    void UpdateLeaderBoard(bool isMulti)
    {
        // FIX for UI!
        isMulti = false;

        leaderboard.Add(score);
        leaderboard = leaderboard.OrderByDescending(x => x.point).ToList();
        if (leaderboard.Count > 6)
            leaderboard.RemoveAt(6);

        SaveLeaderBoard(isMulti);

        LoadUi();
    }
    void LoadUi()
    {
        for (int i = 0; i < leaderboard.Count(); i++)
        {
            string bob = $"{leaderboard[i].name}: {leaderboard[i].point}";
            pos[i].text = bob;
        }


    }
    void LoadLeaderBoard(bool isMulti)
    {
        // FIX for UI!
        isMulti = false;

        string jsonLeaderboard;

        if (!isMulti)
            jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_SINGLE, null);
        else
            jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_MULTI, null);

        if (string.IsNullOrEmpty(jsonLeaderboard))
        {
            //leaderboard = new List<Scores>();
            SaveLeaderBoard(isMulti);
            string newLeaderboard = Newtonsoft.Json.JsonConvert.SerializeObject(leaderboard);

            if (!isMulti)
                jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_SINGLE, newLeaderboard);
            else
                jsonLeaderboard = PlayerPrefs.GetString(PREF_SCORES_MULTI, newLeaderboard);
        }
        else
        {
            leaderboard = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Scores>>(jsonLeaderboard);
        }
        LoadUi();

    }
    void SaveLeaderBoard(bool isMulti)
    {
        // FIX for UI!
        isMulti = false;

        string newLeaderboard = Newtonsoft.Json.JsonConvert.SerializeObject(leaderboard);
        Debug.Log(newLeaderboard);
        if (!isMulti)
            PlayerPrefs.SetString(PREF_SCORES_SINGLE, newLeaderboard);
        else
            PlayerPrefs.SetString(PREF_SCORES_MULTI, newLeaderboard);
        PlayerPrefs.Save();
    }
}
