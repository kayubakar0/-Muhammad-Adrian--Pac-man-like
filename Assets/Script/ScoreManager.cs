using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private int _score;
    private int _maxScore;

    private void Start()
    {
        _score = 0;
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "Score : " + _score + "/" + _maxScore;
    }

    public void SetMaxScore(int score)
    {
        _maxScore = score;
        UpdateUI();
    }

    public void AddScore(int score)
    {
        _score += score;
        UpdateUI();
    }
}
