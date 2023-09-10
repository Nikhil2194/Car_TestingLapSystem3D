using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public float countdownDuration = 5.0f; // Set the countdown duration in seconds
    private float startTime;
    private bool isRunning = false;

    float currentTime = 0f;
    [SerializeField] float startingTime = 10f;
    [SerializeField] TMP_Text countDownText;
    [SerializeField] GameObject gameOverScreen;

    private void Start()
    {
        //currentTime = startingTime;
        //timerText.text = "Time: " + countdownDuration.ToString("F2");

        currentTime = startingTime;
    }

    public void StartCountdown()
    {
        startTime = Time.time;
        isRunning = true;
    }

    private void Update()
    {
        //if (isRunning)
        //{
        //    float elapsedTime = Time.time - startTime;
        //    float remainingTime = Mathf.Max(0f, countdownDuration - elapsedTime);

        //    if (remainingTime > 0f)
        //    {
        //        UpdateTimerUI(remainingTime);
        //    }
        //    else
        //    {
        //        StopCountdown();
        //    }
        //}

        TimeLimit();
    }

    private void UpdateTimerUI(float time)
    {
        timerText.text = "Time: " + time.ToString("F2");
    }

    private void StopCountdown()
    {
        isRunning = false;
        timerText.text = "Time: 0.00";
    }

    private void TimeLimit()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = "Remaining Tme - " + currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }
}
