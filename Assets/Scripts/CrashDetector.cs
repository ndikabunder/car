using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CapsuleCollider2D playerHead;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashEffect; // Optional: Particle effect to play on crash
    [SerializeField] AudioClip crashSound; // Optional: Sound effect to play on crash

    void Start()
    {
        playerHead = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            Debug.Log("Hit my Head!!");

            if (crashEffect != null)
            {
                crashEffect.Play(); // Play the crash effect if you have one set up
            }

            // Kenapa tidak audio tidak jalan 1 kali?

            if (crashSound != null)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSound); // Play the crash sound effect
            }

            Invoke("ReloadScene", loadDelay); // Reload the scene after the specified delay
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
