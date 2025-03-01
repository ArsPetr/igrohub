using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var collectable = collision.gameObject.GetComponent<PlayerController>();
            if (collectable != null)
            {
                collectable.Score += 1;
                Destroy(gameObject);
            }
        }
    }
}
