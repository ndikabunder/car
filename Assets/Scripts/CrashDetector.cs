using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CapsuleCollider2D playerHead;
    [SerializeField] float loadDelay = 10f;
    [SerializeField] ParticleSystem crashEffect; // Optional: Particle effect to play on crash
    [SerializeField] AudioClip crashSound; // Optional: Sound effect to play on crash

    bool isCrashed = false; // Flag to prevent multiple crashes

    void Start()
    {
        playerHead = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && !isCrashed && playerHead.IsTouching(other.collider))
        {
            Debug.Log("Hit my Head!!");
            isCrashed = true; // Set the flag to prevent multiple crashes

            FindFirstObjectByType<PlayerController>().DisableControls(); // Disable player controls on crash

            if (crashEffect != null)
            {
                crashEffect.Play(); // Play the crash effect if you have one set up
            }

            // Kenapa tidak audio tidak jalan 1 kali?

            if (crashSound != null)
            {
                GetComponent<AudioSource>().PlayOneShot(crashSound); // Play the crash sound effect
            }

            CrashUIManager crashUI = FindObjectOfType<CrashUIManager>();
            if (crashUI != null)
            {
                crashUI.ShowCrashPanel();
            }

            Invoke("ReloadScene", loadDelay); // Reload the scene after the specified delay
        }
    }
    
    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // ambil scene yang sedang aktif
        SceneManager.LoadScene(currentScene.name); // reload scene berdasarkan nama
    }
}
