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
        Vector3 headRotation = Camera.main.transform.localEulerAngles;

        if (canShoot && headRotation.z > tiltThreshold && headRotation.z < 90f)
        {
            Shoot();
            canShoot = false;
        }

        if (!canShoot && headRotation.z < resetThreshold)
        {
            canShoot = true;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = shootPoint.forward * bulletSpeed;
        Destroy(bullet, bulletLifeTime);
    }
}
