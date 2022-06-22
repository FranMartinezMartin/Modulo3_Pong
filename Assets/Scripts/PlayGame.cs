using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
   public void PlayGame_1vsCPU() 
   {
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
       SceneManager.LoadScene("PongPVE");
   }

   public void PlayGame_1vs1() 
   {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        SceneManager.LoadScene("PongPVP");
   }
}
