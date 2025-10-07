using UnityEngine;

public class Hammer : MonoBehaviour, IUseable
{
    public Transform targertObject;
    public float rotationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Use()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0f, 0f, 90f );
        }
        //transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
