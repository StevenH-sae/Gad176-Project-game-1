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
        // [SerializeField] private float movementSpeed = 5f; 
        [SerializeField] private GameObject usableItem;
        private Transform parentObject;

        void Start()
        {
            ItemTransformPosition();
        }
        void Update()
        {
            
        }

        public void ItemTransformPosition()
        {
            // instantiate the object as the prefab item
            GameObject instantiatedObject = Instantiate(usableItem);
            
            // make the instantiated item a child of the player object
            instantiatedObject.transform.SetParent(this.transform);
            
            // set the local position of the prefab offset by a bit
            instantiatedObject.transform.localPosition = new Vector3(-0.5f, 1f, 0);
            
            /* other code I was working on to get an understanding of the transform.position / parent
             (it is very confusing for learning)
             if (usableItem != null)
            {
                // logs to the console if the game object isn't null
                Debug.Log("Usable Item Position: " + usableItem.transform.position);

                // sets the game object to be a child of this 'player' object
                usableItem.transform.SetParent(this.transform);
            }
            */
        }
    }
}
