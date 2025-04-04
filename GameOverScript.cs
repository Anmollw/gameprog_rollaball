using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

 public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
   public void setup(int score) 
   {
     gameObject.SetActive(true);
     pointsText.text = score.ToString() + " Points" ;
   }

   public void RestartButton()
   {
    SceneManager.LoadScene("minigame");
   }
}
