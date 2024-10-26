using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButtonShootTrigger : MonoBehaviour
{
    public Button startButton;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Button hit by bullet!");
            startButton.onClick.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
