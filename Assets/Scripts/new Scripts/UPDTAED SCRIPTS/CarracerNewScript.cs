using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarracerNewScript : MonoBehaviour                        // THIS SCIPT WILL ATTACH TO CAR PARENT GAME OBJECT
{
    [Header("LAP TRIGGERS")]
    public int totalLaps = 4;
    [SerializeField] LapTrigger[] lapTriggers;    // Storing LAPS objects
    [SerializeField] TMP_Text LapNoText;
    [SerializeField] GameObject startObj, EndObj;          // Start and end gameobject which are responsble for Starting and ending the race

    [Header("TIME SETTINGS")]
    [SerializeField] float startingTime = 10f;
    [SerializeField] TMP_Text countDownText;
    [SerializeField] GameObject gameOverScreen, winningGameObject;



    private bool startTimer = false;
    private bool endFinishedPoint = false;
    private float currentTime;
    private int currentLap = 0;


    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (startTimer)
        {
            StartCountDownTime();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == startObj)            // As car collided with Starting Line Time Starts Running
        {
            startTimer = true;
            startObj.SetActive(false);
        }

        foreach (LapTrigger lapTrigger in lapTriggers)        // Loop going through each object and verify for which gameobject is car collided it with
        {
            if (other.gameObject == lapTrigger.gameObject)
            {
                currentTime = lapTrigger.lapTime;
                lapTrigger.gameObject.SetActive(false);
                IncrementLap();
                break;
            }
        }

        if (other.gameObject == EndObj)          // As Car collides with end/ last finsih line (This is winning Condition)
        {
            endFinishedPoint = true;
            EndObj.SetActive(false);
            WinningCondition();
        }
    }

    private void WinningCondition()
    {
        if (currentTime >= 0 && endFinishedPoint)
        {
            winningGameObject.SetActive(true);
        }
    }


    private void StartCountDownTime()              // This function start reverse time count in START Functions
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0);
        countDownText.text = "Remaining Time: " + currentTime.ToString("F2");

        if (currentTime <= 0 && !endFinishedPoint)
        {
            currentTime = 0;
            gameOverScreen.SetActive(true);
        }
    }


    private void IncrementLap()          // Update the UI Text as Car went through them
    {
        currentLap++;
        if (currentLap <= totalLaps)
        {
          //  UpdateLapUI();
            LapNoText.text = "Lap: " + currentLap + " / " + totalLaps;
        }
    }

    //private void UpdateLapUI()
    //{
        
    //}
}
