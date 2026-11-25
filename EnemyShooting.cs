using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;
    public float minShootDelay = 2.0f;
    public float maxShootDelay = 3.5f;
    public float bulletSpeed = 25f;
    private float nextShot;

    void Start()
    {
        ScheduleNextShot();
    }

    void Update()
    {
        if (Time.time >= nextShot)
        {
            Shoot();
            ScheduleNextShot();
        }
    }

    void ScheduleNextShot()
    {
        nextShot = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    void Shoot()
    {
        var bullet = Instantiate(enemyBullet, transform.position + Vector3.down * 2.0f, Quaternion.identity);

        var bulletCollision = bullet.GetComponent<Collider>();
        var enemyCollision = GetComponent<Collider>();
        if (bulletCollision != null && enemyCollision != null)
            Physics.IgnoreCollision(bulletCollision, enemyCollision);

        var bulletRigidBody = bullet.GetComponent<Rigidbody>();
        bulletRigidBody.linearVelocity = Vector3.down * bulletSpeed;
    }

}
