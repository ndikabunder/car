using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f; // Delay before reloading the scene
    [SerializeField] ParticleSystem finishEffect; // Optional: Particle effect to play when crossing the finish line


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has crossed the finish line!");
            // You can add more logic here, like updating the game state or triggering an event.
            if (finishEffect != null)
            {
                finishEffect.Play(); // Play the finish effect if you have one set up
            }

            Invoke("ReloadScene", loadDelay); // Reload the scene after the specified delay
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
