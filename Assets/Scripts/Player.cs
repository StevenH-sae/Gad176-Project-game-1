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
        
        public KeyCode arrowLeft;
        public KeyCode arrowRight;
        public KeyCode Useitem;
        
        public IUseable heldObject;
        [SerializeField] private Transform handSlot;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            PlayerMovement();
            if (Input.GetKey(Useitem))
            {
                CheckUseItem();
            }
        }

        // Doorway to use our Hammer
        public void CheckUseItem()
        {
                if (heldObject != null)
                {
                    heldObject.Use();
                }
        }
        
        #region "Player Movement"
        private void PlayerMovement()
        {
            float horizontalMovement = 0f;

            if(Input.GetKey(arrowLeft)) horizontalMovement -= 1f;
            if(Input.GetKey(arrowRight)) horizontalMovement += 1f;
            
            Vector3 velocity = new Vector3(horizontalMovement * movementSpeed, _rigidbody.linearVelocity.y, 0f);
            
            _rigidbody.linearVelocity = velocity;
            
        }
        #endregion

        // Looking at script to make a collision to update Health and if we walk into a hammer item to pick up
        public void OnCollisionEnter(Collision  collision)
        {
            if (collision.gameObject.GetComponent<IHealth>() != null)
            {
                collision.gameObject.GetComponent<IHealth>().ChangeHealth();
            }
            
            if (heldObject == null && collision.gameObject.GetComponent<IUseable>() != null)
            {
                heldObject = collision.gameObject.GetComponent<IUseable>();
                
                collision.transform.SetParent(handSlot);
                
                collision.transform.localPosition = Vector2.zero;
                collision.transform.localRotation = Quaternion.identity;
                
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Destroy(rb);
                }
                Collider col = collision.gameObject.GetComponent<Collider>();
                if (col != null)
                {
                    col.enabled = false;
                }
            }
        }
    }
}
