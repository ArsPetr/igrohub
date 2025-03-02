using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int score = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var collectable = collision.gameObject.GetComponent<PlayerController>();
            if (collectable != null)
            {
                collectable.Score += score;
                Destroy(gameObject);
            }
        }
    }
}
