using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int playerHealth = 30;

    public void ChangeHealth()
    {
        // here will have the player health updated on if the hammer prefab collision with player
        // this removes 10 health and knock player back
        // if player health is == 0, player 'dies' and point goes to winner, a score script handles scores
        Debug.Log("Players health is " + playerHealth);
        
        
    }
    
}
