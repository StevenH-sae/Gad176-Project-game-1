using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Hammer : MonoBehaviour, IUseable
{
    
    [SerializeField] private float cooldownTime = 1.5f;
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float damageAmount = 10f;

    private bool canUse = true;
    private bool isSwinging = false;

    
    public void Use()
    {
        if (!canUse) return;
        StartCoroutine(Bash());
    }
    
    private IEnumerator Bash()
    {
        
        canUse = false;
        isSwinging = true;
        
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 90), 0.5f).SetEase(Ease.OutBounce);
        
        yield return new WaitForSeconds(0.4f);
        
        isSwinging = false;
        
        transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), 0.5f);
        
        yield return new WaitForSeconds(cooldownTime);
        canUse = true;
    }

}
