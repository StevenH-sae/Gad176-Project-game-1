using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float frequency = 2f;

    [SerializeField] private GameObject spawnHammer;
    
    private Vector3 startPosition;

    public void Start()
    {
        startPosition = transform.position;
        StartCoroutine(SpawnHammer()); 
    }
    
    public void Update()
    {
        MoveWithCosine();
    }
    
    void MoveWithCosine()
    {
        float xOffset = movementSpeed * Mathf.Cos(Time.time * frequency);
        
        transform.position = new Vector3(startPosition.x + xOffset, startPosition.y, startPosition.z);
    }

    public IEnumerator SpawnHammer()
    {
        while (true)
        {
            if (spawnHammer != null)
            {
                yield return new WaitForSeconds(7f);
                Instantiate(spawnHammer, transform.position, Quaternion.identity);
            }
        }
    }
}
