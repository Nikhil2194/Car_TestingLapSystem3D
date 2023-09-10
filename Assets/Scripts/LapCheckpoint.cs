using UnityEngine;

public class LapCheckpoint : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager script
    public LapTimer lapTimer;


    private void OnTriggerEnter(Collider other)
    {

       

        if (other.CompareTag("Player")) // Assuming the player car has the "Player" tag
        {
            gameManager.IncrementLap();
        }

//        if(start)

    }
}
