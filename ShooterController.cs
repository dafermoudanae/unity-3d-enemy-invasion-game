using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public float moveSpeed = 12f;
    public GameObject playerBullet;
    public float projectileSpeed = 35f;

    void Update()
    {
        float dir = 0f;
        if (Input.GetKey(KeyCode.J)) dir = -1f;
        if (Input.GetKey(KeyCode.L)) dir = +1f;

        transform.position += new Vector3(dir * moveSpeed * Time.deltaTime, 0f, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
    }

    void Fire()
    {
        var p = Instantiate(playerBullet, transform.position + Vector3.up * 1.0f, Quaternion.identity);
        var rb = p.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.up * projectileSpeed;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            FindFirstObjectByType<GameManager>()?.Lose();
        }
    }
}
