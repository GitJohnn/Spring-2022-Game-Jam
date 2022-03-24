using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public NoteHitsManager hitManager;
    public LeaderboardController leaderboard;
    [Space()]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI comboText;
    public TMP_InputField playerName;
    public LeanTweenType easeType;

    void Start()
    {
        scoreText.text = "Score: 0";
        endScoreText.text = "Score: XXXXXXX";
        multiplierText.text = "x1";
        comboText.text = "0";
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
        StartCoroutine(ShowLeaderboard());
        hitManager.ResetScores();
    }

    public void ResetScores()
    {
        hitManager.ResetScores();
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "Score: " + hitManager.CurrentScore;
        endScoreText.text = "Score: " + hitManager.CurrentScore;
        comboText.text = hitManager.ComboScore.ToString();
        LeanTween.scale(comboText.gameObject, new Vector2(1, 1) * 1.5f, 0.1f).setEase(easeType).setOnComplete(() => {
            LeanTween.scale(comboText.gameObject, new Vector2(1, 1), 0.1f).setEase(easeType);
        });
        multiplierText.text = "x" + hitManager.CurrentMultiplier.ToString();
    }

    IEnumerator ShowLeaderboard()
    {
        yield return new WaitForSeconds(0.75f);
        leaderboard.ShowScores();
        GameManager.instance.menuController.LeaderboardScreen();
    }
}
