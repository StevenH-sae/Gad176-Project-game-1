using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;
    public void Update()
    {
        MoveWithCosine();
    }
    
    void MoveWithCosine()
    {
        // this will also move my cube, but it will move from left to right
        float xPosition = (transform.position.x + amplitude) * Mathf.Sin(frequency);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}
