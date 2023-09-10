using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime=10f;
    [SerializeField] TMP_Text countDownText;
    [SerializeField] GameObject gameOverScreen;

    void Start()
    {
        currentTime = startingTime;   
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text ="Remaining Tme - "+ currentTime.ToString("0");

        if(currentTime <=0)
        {
            currentTime = 0;
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }
}
