using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class GameManager : MonoBehaviour
{
    #region Varibles
    public static GameManager Instance;

    [SerializeField] private int score;

    [SerializeField] private TextMeshProUGUI scoreTxt;

    [SerializeField] private TextMeshProUGUI puntuacionActual;

    [SerializeField] private TextMeshProUGUI puntuacionMax;

    private const string NAME_KEY = "puntuacion";
    private const string MAX_POINT_KEY = "MaxKills";
    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    #region OnEnableOnDisable
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
        scoreTxt.text = score.ToString();
    }

    public void LoadPuntuaction()
    {
        string scoreToLoad = PlayerPrefs.GetString(NAME_KEY);
        puntuacionActual.text = scoreToLoad;

    }

    public void SavePunctuation()
    {
        string puntuacion = score.ToString();
        PlayerPrefs.SetString(NAME_KEY, puntuacion);
    }


    public void CheckMaxScore()
    {
        int currentMaxKills = PlayerPrefs.GetInt(MAX_POINT_KEY);

        if (score > currentMaxKills)
        {
            PlayerPrefs.SetInt(MAX_POINT_KEY, score);

        }
        puntuacionMax.text = currentMaxKills.ToString();
    }


}//Class
