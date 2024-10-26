using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject platform;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlatformGenerator"))
        {
            Instantiate(platform, new Vector3(0f, 0f, 27f), Quaternion.identity);
        }
    }
}
