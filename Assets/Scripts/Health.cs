using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth = 30f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; 
    }

    public void ChangeHealth(float amount)
    {
        
        currentHealth += amount;

        Debug.Log(currentHealth);
    }
}
