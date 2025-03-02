using System.Collections;
using UnityEngine;

public abstract class Buff : ScriptableObject
{
    public string buffname;
    public float duration;

    abstract public void OnBuff(GameObject afflicted);
    abstract public void PostBuff(GameObject afflicted);
}
