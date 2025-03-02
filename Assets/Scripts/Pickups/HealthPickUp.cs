using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float health = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamagable playerHealth = collision.gameObject.GetComponent<IDamagable>();
            if (playerHealth != null)
            {
                playerHealth.Heal(health);
                Destroy(gameObject);
            }
        }
    }
}
