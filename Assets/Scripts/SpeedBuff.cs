using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Scriptable Objects/Buff/SpeedBuff")]
public class SpeedBuff : Buff
{
    public float speedUp;

    public override void OnBuff(GameObject afflicted)
    {
        var PC = afflicted.GetComponent<PlayerController>();

        if (PC != null)
        {
            PC.currentSpeed += speedUp;
        }
    }

    public override void PostBuff(GameObject afflicted)
    {
        var PC = afflicted.GetComponent<PlayerController>();

        if (PC != null)
        {
            PC.currentSpeed -= speedUp;
        }
    }
}
