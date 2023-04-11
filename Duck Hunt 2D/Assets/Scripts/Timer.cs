using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 30f;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] GameObject spawnerObject;

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
            timer = 0;
            Destroy(spawnerObject);
        }
    }
}//Class
