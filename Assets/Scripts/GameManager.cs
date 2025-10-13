using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject startButton;

   public float amplitude = 1f;
   public float frequency = 1f;

   public void Update()
   {
      MoveWithCosine();
   }
   public void StartGame()
   {
      StartCoroutine(StartGame_Coroutine());
   }
   public IEnumerator StartGame_Coroutine()
   {
      startButton.SetActive(false);
      yield return new WaitForSeconds(1f);
      Debug.Log("Get Ready!");
      yield return new WaitForSeconds(1f);
      Debug.Log("GO!");
   }
   void MoveWithCosine()
   {
      // this will also move my cube but it will move from left to right
      float xPosition = (transform.position.x + amplitude) * Mathf.Sin(Time.time * frequency);
      transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
   }
}
