using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHitsManager : MonoBehaviour
{
    private int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    private int currentMultiplier;
    private int comboScore = 0;
    //private int highestComboScore = 0;
    private int multiplierTracker = 0;
    public int[] multiplierThresholds;
    private int multiplierThresholdsIndex = 0;

    public static NoteHitsManager instance;

    public int CurrentScore { get { return currentScore; } }
    public int ComboScore { get { return comboScore; } }
    public int CurrentMultiplier {  get { return currentMultiplier; } }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentMultiplier = 1;
    }

    public void NoteHit()
    {
        comboScore++;

        if (multiplierThresholdsIndex < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTracker >= multiplierThresholds[multiplierThresholdsIndex])
            {
                multiplierTracker = 0;
                currentMultiplier *= 2;
                multiplierThresholdsIndex++;
            }
        }
    }

    public void NormalHit()
    {
        NoteHit();

        currentScore += scorePerNote * currentMultiplier;
        GameManager.instance.scoreManager.UpdateUI();
    }

    public void GoodHit()
    {
        NoteHit();

        currentScore += scorePerGoodNote * currentMultiplier;
        GameManager.instance.scoreManager.UpdateUI();
    }

    public void PerfectHit()
    {
        NoteHit();

        currentScore += scorePerPerfectNote * currentMultiplier;
        GameManager.instance.scoreManager.UpdateUI();
    }

    public void NoteMissed()
    {
        //if (comboScore > highestComboScore)
        //{
        //    highestComboScore = comboScore;
        //}
        comboScore = 0;
        multiplierTracker = 0;
        currentMultiplier = 1;
        multiplierThresholdsIndex = 0;
        GameManager.instance.scoreManager.UpdateUI();
    }

    public void ResetScores()
    {
        comboScore = 0;
        multiplierTracker = 0;
        currentMultiplier = 1;
        currentScore = 0;
        multiplierThresholdsIndex = 0;
    }
}
