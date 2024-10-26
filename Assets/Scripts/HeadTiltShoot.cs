using UnityEngine;

public class HeadTiltShoot : MonoBehaviour
{
    public GameObject gun;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float tiltThreshold = 15f;
    public float bulletSpeed = 20f;
    public float bulletLifeTime = 2f;
    private bool canShoot = true;
    public float resetThreshold = 5f;

    void Update()
    {
        // Get the device's head rotation in the local space
        Vector3 headRotation = Camera.main.transform.localEulerAngles;

        // Check if the user tilts their head to the right and if shooting is allowed
        if (canShoot && headRotation.z > tiltThreshold && headRotation.z < 90f)
        {
            Shoot();
            canShoot = false; // Prevent shooting again until head is reset
        }

        // Check if the head has returned to the neutral position
        if (!canShoot && headRotation.z < resetThreshold)
        {
            canShoot = true;  // Allow shooting again when head is back to normal
        }
    }

    void Shoot()
    {
        // Instantiate the bullet and set its velocity
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootPoint.forward * bulletSpeed;

        // Destroy the bullet after a certain amount of time
        Destroy(bullet, bulletLifeTime);
    }
}
