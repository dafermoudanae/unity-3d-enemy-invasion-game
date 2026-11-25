using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
            return;
        }

        if (col.collider.CompareTag("Player"))
        {
            Destroy(col.collider.gameObject);
            FindFirstObjectByType<GameManager>()?.Lose();
            Destroy(gameObject);
        }
    }
}
