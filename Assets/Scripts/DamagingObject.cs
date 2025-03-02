using UnityEngine;

public class DamagingObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(1f);
        }
    }
}
