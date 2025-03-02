using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    
    private Dictionary<Buff, float> Buffs = new Dictionary<Buff, float>();

    public void AddBuff(Buff buff)
    {
        Buffs.Add(buff, buff.duration);
        buff.OnBuff(gameObject);
        StartCoroutine(Progress(buff));
    }

    public IEnumerator Progress(Buff buff)
    {
        float duration = Buffs.GetValueOrDefault(buff, 0);

        while (duration > 0)
        {
            Debug.Log(buff.buffname + " " + duration);

            Buffs[buff] -= 0.1f;
            duration -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        Buffs.Remove(buff);
        buff.PostBuff(gameObject);
    }
}
