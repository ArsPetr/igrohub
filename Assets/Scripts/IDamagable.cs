using UnityEngine;

public interface IDamagable
{
    public void Heal(float v);

    public void TakeDamage(float v);

    public void Die();
}
