using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    
    private Dictionary<Buff, float> Buffs = new Dictionary<Buff, float>();


    public GameObject buffDisplayPrefab;
    public GameObject buffDisplayParent;

    public void AddBuff(Buff buff)
    {
        Buffs.Add(buff, buff.duration);
        buff.OnBuff(gameObject);
        Image buffDisplay = Instantiate(buffDisplayPrefab, buffDisplayParent.transform).GetComponent<Image>();
        buffDisplay.fillAmount = 1;
        
        StartCoroutine(Progress(buff, buffDisplay));
    }

    public IEnumerator Progress(Buff buff, Image slider)
    {      
        while (Buffs[buff] > 0)
        {
            Debug.Log(buff.buffname + " " + Buffs[buff]);
         
            Buffs[buff] -= 0.1f;
            slider.fillAmount = Buffs[buff] / buff.duration;
            yield return new WaitForSeconds(0.1f);
        }

        Buffs.Remove(buff);
        buff.PostBuff(gameObject);
    }
}
