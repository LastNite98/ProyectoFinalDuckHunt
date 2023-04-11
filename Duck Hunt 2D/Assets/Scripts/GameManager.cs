using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    [SerializeField] TextMeshProUGUI scoreText;
    private void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        #endregion
        scoreText.text = score.ToString();
    }
    #region EnableDisable
    private void OnEnable()
    {
        Shoot.OnScore += UpdateScore;
    }
    private void OnDisable()
    {
        Shoot.OnScore -= UpdateScore;
    }
    #endregion
    private void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}//Class
