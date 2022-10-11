using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Rigidbody playerRIgidbody;
  public float bounceForce = 6;
  private string materialColidedWith;
  private AudioManager audioManager;
  

  private void Start() {
    audioManager =FindObjectOfType<AudioManager>();
    
  }

   // This section of code adds vertical upWard force
   // to the player in other to bake the player bounce 

  private void OnCollisionEnter(Collision other) {
   audioManager.Play("GamePlay");
    playerRIgidbody.velocity = new Vector3(playerRIgidbody.velocity.x, bounceForce, playerRIgidbody.velocity.z);

   // Debug.Log(other.transform.GetComponent<MeshRenderer>().material.name); // This is an important debuging code use for knowing the name of the object you are making colission with
  
  materialColidedWith =  (other.transform.GetComponent<MeshRenderer>().material.name);
  if(materialColidedWith == "safe (Instance)"){
    FindObjectOfType<AudioManager>().Play("GoodSlide");
   // Debug.Log("Good point");
    

  } 
 else if(materialColidedWith == "Unsafe (Instance)"){
   // Debug.Log("Danger");
    GameManager.gameOver = true;  
   audioManager.Play("BadSide");
  }
 else if(materialColidedWith == "BaseCylinder (Instance)"){
    Debug.Log("level Completed");
    GameManager.levelCompleted = true; 
    audioManager.Play("levelCompleted");
  }
  }
}
