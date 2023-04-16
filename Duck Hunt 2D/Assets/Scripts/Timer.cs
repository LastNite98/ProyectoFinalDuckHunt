using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Variables
    [SerializeField] private float timer = 30f;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] GameObject spawnerObject;
    [SerializeField] GameObject EndPanel;
    public static Action OnTimesUp;
    #endregion

    private void Awake()
    {
        timerText.text = timer.ToString("0.00");
    }

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("0.00");
        }
        else
        {
            OnTimesUp?.Invoke();
            timer = 0;
            GameManager.Instance.SavePunctuation();
            GameManager.Instance.LoadPuntuaction();
            GameManager.Instance.CheckMaxScore();
            Time.timeScale = 0f;
            EndPanel.SetActive(true);
            Destroy(spawnerObject);
        }
    }
}//Class
