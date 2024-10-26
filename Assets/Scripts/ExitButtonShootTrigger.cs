using UnityEngine;
using UnityEngine.UI;

public class ExitButtonShootTrigger : MonoBehaviour
{
    public Button exitButton;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Button hit by bullet!");
            exitButton.onClick.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
