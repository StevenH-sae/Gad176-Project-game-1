using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Hammer : MonoBehaviour, IUseable
{
    public Transform targetObject;
    public float rotationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Use()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Bash());
        }
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Bash()
    {
        //transform.Rotate(0f, 0f, 90f );
        //transform.DOScale(Vector3.zero, 3f);
        // I can see a problem in the direction the hammer will fall
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, 90), 1f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(2f);
        
        transform.DORotateQuaternion(Quaternion.Euler(0, 0, 0), 1.5f);
    }
    
    
}
