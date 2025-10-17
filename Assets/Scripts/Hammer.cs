using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Hammer : MonoBehaviour, IUseable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Use()
    {
        StartCoroutine(Bash());
    }
    
    private IEnumerator Bash()
    {
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 90), 0.5f).SetEase(Ease.OutBounce);
        
        yield return new WaitForSeconds(1f);
        
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), 1.5f);
    }
}
