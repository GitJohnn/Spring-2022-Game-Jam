using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    private int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    private int currentMultiplier;
    private int comboScore = 0;
    private int highestComboScore = 0;
    private int multiplierTracker = 0;
    public int[] multiplierThresholds;
    private int multiplierThresholdsIndex = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiplierText;
    public TextMeshProUGUI comboText;

    private void Awake()
    {
        instance = this;

        scoreText.text = "Score: 0";
        multiplierText.text = "Multiplier x1";
        comboText.text = "Combo Hits: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();                
            }
        }
    }

    public void NoteHit()
    {
        comboScore++;

        if(multiplierThresholdsIndex < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTracker >= multiplierThresholds[multiplierThresholdsIndex])
            {
                multiplierTracker = 0;
                currentMultiplier *= 2;
            }
        }        

        //currentScore += scorePerNote * currentMultiplier;
        //UpdateUI();
    }

    public void NormalHit()
    {
        NoteHit();

        currentScore += scorePerNote * currentMultiplier;
        UpdateUI();
    }

    public void GoodHit()
    {
        NoteHit();

        currentScore += scorePerGoodNote * currentMultiplier;
        UpdateUI();
    }

    public void PerfectHit()
    {
        NoteHit();

        currentScore += scorePerPerfectNote * currentMultiplier;
        UpdateUI();
    }

    public void NoteMissed()
    {
        if(comboScore > highestComboScore)
        {
            highestComboScore = comboScore;
        }
        comboScore = 0;
        multiplierTracker = 0;
        currentMultiplier = 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
        comboText.text = "Combo Hits: " + comboScore;
        multiplierText.text = "Multiplier x" + currentMultiplier;
    }

}
