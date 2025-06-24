using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has crossed the finish line!");
            // You can add more logic here, like updating the game state or triggering an event.
            SceneManager.LoadScene(0); // Reload the current scene
        }
    }
}
