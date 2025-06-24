using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    CapsuleCollider2D playerHead;

    void Start()
    {
        playerHead = GetComponent<CapsuleCollider2D>();
    }  
 
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider))
        {
            Debug.Log("Hit my Head!!");
        }
    }
}
