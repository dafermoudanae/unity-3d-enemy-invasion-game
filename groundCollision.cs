using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            FindFirstObjectByType<GameManager>()?.Lose();
        }
    }
}
