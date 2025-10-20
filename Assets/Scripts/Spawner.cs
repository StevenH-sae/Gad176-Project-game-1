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
    
    [SerializeField] private float minSpawnDelay = 5f;
    [SerializeField] private float maxSpawnDelay = 10f;
    [SerializeField] private float warningTime = 2f;
    [SerializeField] private int maxHammerCount = 3;

    private bool showWarningBox = false;
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
            float randomDelay = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            float quietTime = randomDelay - warningTime;
            
            if(quietTime < 0) quietTime = 0;
            yield return new WaitForSeconds(quietTime);
            
            showWarningBox = true;
            yield return new WaitForSeconds(warningTime);
            
            if (spawnHammer != null)
            {
                int hammerCount = FindObjectsOfType<Hammer>().Length;
                if (hammerCount < maxHammerCount)
                {
                    Instantiate(spawnHammer, transform.position, Quaternion.identity);
                }
            }
            showWarningBox = false;
        }
    }

    public void OnDrawGizmos()
    {
        if (showWarningBox)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 1f);
        }
    }
}