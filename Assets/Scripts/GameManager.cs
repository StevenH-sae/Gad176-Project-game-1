using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject startButton;
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
   
}
