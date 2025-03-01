using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamagable playerHealth = collision.gameObject.GetComponent<IDamagable>();
            if (playerHealth != null)
            {
                playerHealth.Heal(1f);
                Destroy(gameObject);
            }
        }
    }
}
