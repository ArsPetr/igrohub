using UnityEngine;

public class BuffPickup : MonoBehaviour
{

    public Buff buff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var buffMngr = collision.gameObject.GetComponent<BuffManager>();
        if (buffMngr != null)
        {
            buffMngr.AddBuff(buff);
            Destroy(gameObject);
        }
    }
}
