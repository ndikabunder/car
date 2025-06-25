using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticleSystem; // Particle system for dust trail

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (dustParticleSystem != null)
            {
                dustParticleSystem.Play();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (dustParticleSystem != null)
            {
                dustParticleSystem.Stop();
            }
        }
    }
}
