using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.AddScore(10);
        }
        
        Destroy(gameObject);
    }
}
