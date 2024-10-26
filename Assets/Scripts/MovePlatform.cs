using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
