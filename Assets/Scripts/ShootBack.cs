using System.Xml.Serialization;
using UnityEngine;

public class ShootBack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public Transform player;
    public float shootInterval = 2f;
    public float bulletSpeed = 10f;
    public float detectionRange = 10f;
    public float noShootRange = 2f;

    private float shootTimer = 0f;
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= noShootRange)
            {
                Destroy(gameObject);
            }
            if (distanceToPlayer <= detectionRange)
            {
                animator.SetBool("enemySpotted", true);
                shootTimer += Time.deltaTime;
                if (shootTimer >= shootInterval)
                {
                    ShootAtPlayer();
                    animator.SetBool("shootDone", true);
                    shootTimer = 0f;
                }
            }
        }
    }

    void ShootAtPlayer()
    {
        if (bulletPrefab != null && shootPoint != null && player != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            Vector3 direction = (player.position - shootPoint.position).normalized;
            bulletRb.velocity = direction * bulletSpeed;

            Destroy(bullet, 5f);
        }
    }
}
