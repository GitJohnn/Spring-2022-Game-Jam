using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public NoteHitsManager hitManager;
    public int leaderboardID;
    public LeaderboardController leaderboard;
    [Space()]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI comboText;
    public TMP_InputField playerName; 

    void Start()
    {
        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier x1";
        comboText.text = "Combo Hits: 0";
        //leaderboard.ID = leaderboardID;
        leaderboard.StartSession();
    }

    public void ShowScore()
    {
        leaderboard.ShowScores();
    }

    public void SubmitScore()
    {
        leaderboard.SubmitScore(playerName.text, hitManager.CurrentScore);
        Debug.Log("Submit attempt " + playerName.text + " " + hitManager.CurrentScore);
        StartCoroutine(SwitchMenus());
        hitManager.ResetScores();
    }

    public void ResetScores()
    {
        hitManager.ResetScores();
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + hitManager.CurrentScore;
        comboText.text = "Combo Hits: " + hitManager.ComboScore;
        multiplierText.text = "Multiplier x" + hitManager.CurrentMultiplier;
    }

    IEnumerator SwitchMenus()
    {
        yield return new WaitUntil(()=> leaderboard.ShowScores());
        GameManager.instance.menuController.LeaderboardScreen();
    }
}
