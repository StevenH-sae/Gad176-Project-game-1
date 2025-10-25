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
        [SerializeField] private float jumpMomentum = 8f;
        
        public KeyCode arrowLeft;
        public KeyCode arrowRight;
        public KeyCode useItem;
        public KeyCode jumpKey;
        
        private IUseable heldObject;
        [SerializeField] private Transform handSlot;

        [SerializeField] private bool isPlayerGrounded;
        private bool facingRight = true;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        void Update()
        {
            PlayerMovement();
            HandleJump();
            if (Input.GetKey(useItem))
            {
                CheckUseItem();
            }
        }

        private void FixedUpdate()
        {
            isPlayerGrounded = Physics.Raycast(transform.position, Vector2.down, out RaycastHit hit,1.5f);
        }

        // Doorway to use our Hammer
        public void CheckUseItem()
        {
                if (heldObject != null)
                {
                    heldObject.Use();
                }
        }

        public void HandleJump()
        {
            if (isPlayerGrounded == true)
            {
                if (Input.GetKey(jumpKey))
                {
                    Vector3 currentVelocity = _rigidbody.linearVelocity;
                    currentVelocity.y = jumpMomentum;
                    _rigidbody.linearVelocity = currentVelocity;
                }
            }
        }
        #region "Player Movement"
        private void PlayerMovement()
        {
            float horizontalMovement = 0f;
            
            
            if(Input.GetKey(arrowLeft)) horizontalMovement -= 1f;
            if(Input.GetKey(arrowRight)) horizontalMovement += 1f;

            if (horizontalMovement > 0 && !facingRight)
            {
                FlipToRight();
            }

            if (horizontalMovement < 0 && facingRight)
            {
                FlipToLeft();
            }
            
            Vector3 velocity = new Vector3(horizontalMovement * movementSpeed, _rigidbody.linearVelocity.y, 0f);
            
            _rigidbody.linearVelocity = velocity;
            
            //Vector3 moveDirection = new Vector3(horizontalMovement, 0, 0);
            
            //_rigidbody.AddForce(moveDirection * movementSpeed * 10, ForceMode.Force);
        }

        private void FlipToRight()
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            facingRight = true;
        }

        private void FlipToLeft()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            facingRight = false;
        }
        #endregion

        // Looking at script to make a collision to update Health and if we walk into a hammer item to pick up
        public void OnCollisionEnter(Collision  collision)
        {
            
            // if the heldObject is null and the component is not null
            // the heldObject variable is equeal to the IUseable
            if (heldObject == null && collision.gameObject.GetComponent<IUseable>() != null)
            {
                heldObject = collision.gameObject.GetComponent<IUseable>();
                
                // set then heldObject as a child of a gameObject handslot
                collision.transform.SetParent(handSlot);
                
                // transform the local position to 0,0,0
                collision.transform.localPosition = Vector2.zero;
                collision.transform.localRotation = Quaternion.identity;
                
                // as the prefab has a rigid body, I have it destroyed when the player grabs the item, so no issues occur
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
