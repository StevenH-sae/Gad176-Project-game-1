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
        
        [SerializeField] private float movementSpeed = 15f; 
        [SerializeField] private GameObject usableItem;
        
        public KeyCode arrowLeft = KeyCode.LeftArrow;
        public KeyCode arrowRight = KeyCode.RightArrow;
        public KeyCode aKey = KeyCode.A;
        public KeyCode dKey = KeyCode.D;
        public KeyCode eKey = KeyCode.E;
        
        public IUseable heldObject;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            ItemTransformPosition();
        }
        void Update()
        {
            PlayerMovement();
            UseItem();
        }

        // Doorway to use our Hammer
        public void UseItem()
        {
            if (Input.GetKey(eKey))
            {
                heldObject.Use();
            }
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
        
        #region "Player Movement"
        private void PlayerMovement()
        {
            // Not the greatest code, but it moves for both characters separately? 
            // Using if the tag is = to the players tag set in inspector, this code runs
            if (tag == "PlayerOne")
            {
                // Setting a variable as a float for movement
                float horizontalMovement = 0f;
                
                // setting the KeyCode inputs to adjust the variable by minus 1 or plus 1 each frame
                if(Input.GetKey(aKey)) horizontalMovement -= 1f;
                if(Input.GetKey(dKey)) horizontalMovement += 1f;
                
                // Creating a new Vector3 for the rigidbody, I believe this is grabbing the x and y axis in floats with my speed variable
                Vector3 velocity = new Vector3(horizontalMovement * movementSpeed, _rigidbody.linearVelocity.y, 0f);
                
                // then we are applying that rigidbody to the velocity Vector3 above
                _rigidbody.linearVelocity = velocity;
            }
            
            if (tag == "PlayerTwo")
            {
                float horizontalMovement = 0f;
                
                if(Input.GetKey(arrowLeft)) horizontalMovement -= 1f;
                if(Input.GetKey(arrowRight)) horizontalMovement += 1f;
                
                Vector3 velocity = new Vector3(horizontalMovement * movementSpeed, _rigidbody.linearVelocity.y, 0f);
            
                _rigidbody.linearVelocity = velocity;
            }
        }
        #endregion

        // Looking at script to make a collision to update Health and if we walk into a hammer item to pick up
        public void OnCollisionEnter(Collision  collision)
        {
            if (collision.gameObject.GetComponent<IHealth>() != null)
            {
                collision.gameObject.GetComponent<IHealth>().ChangeHealth();
            }
            
            if (collision.gameObject.GetComponent<IUseable>() != null)
            {
                collision.gameObject.GetComponent<IUseable>().Use();
            }
        }
    }
}
