using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
using TMPro;

public class LeaderboardController : MonoBehaviour
{
    public TMP_InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 12;
    public TextMeshProUGUI[] Entries;

    private void Start()
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


    public void ShowScores()
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
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
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
}
