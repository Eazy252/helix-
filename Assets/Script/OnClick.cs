using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnClick : MonoBehaviour
{ 
   public TextMeshProUGUI soundtext;

   private void Start() {
      if(GameManager.mute)
      soundtext.text = "/";
      else 
      soundtext.text = "";
    
   }  

 public void  ToggleMute(){ 
      if(GameManager.mute){ 
         GameManager.mute = false;
         soundtext.text = "";
      } 
      else
      {
         GameManager.mute = true;
         soundtext.text = "/";
      }
   }

  public void QuitGame(){
    Application.Quit();
    Debug.Log("Application will stop on mobile");

   }
}
