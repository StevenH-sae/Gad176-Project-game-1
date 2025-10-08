using System;
using UnityEngine;

namespace SAE.GAD176.ProjectOne.Player
{
    /// <summary>
    /// Here should the player script that will work with
    /// prefab object being attached to the player when item is picked up
    /// player health
    /// player movement
    /// </summary>
    public class Player : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        [SerializeField] private float movementSpeed = 5f; 
        [SerializeField] private GameObject usableItem;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            ItemTransformPosition();
        }
        void Update()
        {
            PlayerMovement();
        }
        #region "Attached prefab"
        // function applies the prefab hammer object to the player and slightly offsets it
        public void ItemTransformPosition()
        {
            // instantiate the object as the prefab item
            GameObject instantiatedObject = Instantiate(usableItem);
            
            // make the instantiated item a child of the player object
            instantiatedObject.transform.SetParent(transform);
            
            // set the local position of the prefab offset by a bit
            instantiatedObject.transform.localPosition = new Vector3(-0.5f, 1f, 0);
        }
        #endregion
        
        #region "Player movement"
        private void PlayerMovement()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            
            Vector3 horizontalDirection = new Vector3(horizontalMovement, 0f, 0f).normalized;
            
            transform.position  += horizontalDirection * (movementSpeed * 0.02f);
            
        }
        #endregion

        // Looking at script to make a collision to update Health
        public void OnCollisionEnter(Collision  collision)
        {
            if (collision.gameObject.GetComponent<IHealth>() != null)
            {
                collision.gameObject.GetComponent<IHealth>().ChangeHealth();
            }
        }
    }
}
