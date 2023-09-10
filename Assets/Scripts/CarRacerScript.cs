using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarRacerScript : MonoBehaviour
{
    public float lapTime;
    private bool startTimer=false;


    private bool endFinshedPoint=false;

    float currentTime = 0f;
    [SerializeField] float startingTime = 10f;

    [SerializeField] TMP_Text countDownText, LapNoText;

    [SerializeField] GameObject gameOverScreen,winningGameObject;
    [SerializeField] GameObject startObj, Lap01, Lap02, Lap03, Lap04, EndObj;
    [SerializeField] float Lap01Time = 10, Lap02Time = 12, Lap03Time = 14, Lap04Time=5;

    private int currentLap = 0;
    public int totalLaps = 4;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if(startTimer==true)
        {
            StartCountDownTime();
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == startObj)
        {
            startTimer = true;
        }
        
        if(other.gameObject== Lap01)
        {
            currentTime = Lap01Time;
            Lap01.SetActive(false);
            IncrementLap();
        }

        if (other.gameObject == Lap02)
        {
            currentTime = Lap02Time;
            Lap02.SetActive(false);
            IncrementLap();
        }

        if (other.gameObject == Lap03)
        {
            currentTime = Lap03Time;
            Lap03.SetActive(false);
            IncrementLap();
        }

        if (other.gameObject == Lap04)
        {
            currentTime = Lap04Time;
            Lap04.SetActive(false);
            IncrementLap();
        }

        if(other.gameObject == EndObj)
        {
            endFinshedPoint = true;
            WinningConditon();
        }

    }

    void StartCountDownTime()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = "Remaining Tme - " + currentTime.ToString("0");

        if (currentTime <= 0 && endFinshedPoint==false)
        {
            currentTime = 0;
            //Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }

    void WinningConditon()
    {
        if(currentTime>=0 && endFinshedPoint==true)
        {
            winningGameObject.SetActive(true);
        }
    }


    public void IncrementLap()
    {
        currentLap++;
        if (currentLap > totalLaps)
        {
            // Race finished, display results or perform other actions
        }
        else
        {
            UpdateLapUI();
        }
    }

    void UpdateLapUI()
    {
        LapNoText.text = "Lap: " + currentLap + " / " + totalLaps;
    }


 }
