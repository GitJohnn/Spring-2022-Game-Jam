using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;

public class LeaderboardController : MonoBehaviour
{
    private int ID;
    int MaxScores = 12;
    public TextMeshProUGUI[] Entries;

    private void Awake()
    {
        StartSession();
    }

    public void StartSession()
    {
        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucess!");
            }
            else
            {
                Debug.Log("Failed to upload score");
            }
        });
    }


    public bool ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLocker.Requests.LootLockerLeaderboardMember[] scores = response.items;
                for(int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = (scores[i].rank + ". " + scores[i].member_id + ": " + scores[i].score);
                }

                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ": none";
                    }
                }
            }
            else
            {
                Debug.Log("Failed to get scores");
            }
        });

        return true;
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore("Test", 900, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucess!");
            }
            else
            {
                Debug.Log("Failed to upload score");
            }
        });
    }

    public void SubmitScore(string playerId, int playerScore)
    {
        LootLockerSDKManager.SubmitScore(playerId, playerScore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Sucess!");
            }
            else
            {
                Debug.Log("Failed to upload score");
            }
        });        
    }

    public void SetLeaderboardID(int id)
    {
        ID = id;
    }
}
