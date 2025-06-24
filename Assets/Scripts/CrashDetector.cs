using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    CapsuleCollider2D playerHead;
    [SerializeField] float loadDelay = 1f;

    void Start()
    {
        playerHead = GetComponent<CapsuleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            Debug.Log("Hit my Head!!");
            Invoke("ReloadScene", loadDelay); // Reload the scene after the specified delay
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
