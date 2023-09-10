using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TMP_Text lapUIText;
    private int currentLap = 0;
    private int totalLaps = 4;

    // ...

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
        lapUIText.text = "Lap: " + currentLap + " / " + totalLaps;
    }



    // Other methods and logic for the game manager
}
