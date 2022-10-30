using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderRotation : MonoBehaviour
{
    public float rotationSpeed;
    void Start()
    {   // This code locke's the Visibility of the mouse while playing the game
    //   Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
     {  if(!GameManager.isGameStarted)
     return;
        // This section is for PC control
         if(Input.GetMouseButton(0)){ 
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0,mouseX * -rotationSpeed + Time.deltaTime, 0 );
        } 

        // This section is for mobile control always comment it out if your texting on PC 

        /* if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        { 
            float xDelta = Input.GetTouch(0).deltaPosition.x;
             transform.Rotate(0,-xDelta * -rotationSpeed + Time.deltaTime, 0 );
        
         */}
    }
    

