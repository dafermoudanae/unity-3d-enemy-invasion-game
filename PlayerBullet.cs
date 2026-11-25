using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Enemy"))
        {
            Destroy(col.collider.gameObject);
            FindFirstObjectByType<GameManager>()?.WinCheck();
        }

        Destroy(gameObject);
    }
}
